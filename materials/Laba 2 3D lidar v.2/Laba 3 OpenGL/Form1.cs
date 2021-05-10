using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using SharpGL;
using System.Timers;
//using SharpGL.SceneGraph.Assets;

namespace Laba_3_OpenGL
{
    public partial class scale : Form
    {
        string pathVar = "C:\\Users\\andre\\Desktop\\Учёба\\Политех\\Лабораторки\\3 курс 2 семестр\\Технологии визуализации данных систем управления\\Лабораторная работа 2\\UDPFromVelodyneTest_lidardata.pcap";

        double[] tiltAngle = new double[]
        {
            -30.67, 
            -9.33,
            -29.33,
            -8.00,
            -28.00,
            -6.66,
            -26.66,
            -5.33,
            -25.33,
            -4.00,
            -24.00,
            -2.67,
            -22.67,
            -1.33,
            -21.33,
            0.00,
            -20.00,
            1.33,
            -18.67,
            2.67,
            -17.33,
            4.00,
            -16.00,
            5.33,
            -14.67,
            6.67,
            -13.33,
            8.00,
            -12.00,
            9.33,
            -10.67,
            10.67,
        };

        bool busy = false;
        bool busyText = false;

        double[,] bp = new double[8, 3];

        double xL;
        double xR;
        double yL;
        double yR;
        double zL;
        double zR;

        List<byte> bufText = new List<byte>();
        List<byte> bufShow = new List<byte>();

        double[] tiltAngleSin = new double[32];
        double[] tiltAngleCos = new double[32];

        RenderEventArgs args;
        OpenGL gl;

        List<double[]> cloudEx = new List<double[]>();
        double[,] laserHistory = new double[32, 2];
        int[] laserHistoryIndex = new int[32];
        List<double[]> cloudIN = new List<double[]>();
        List<double[]> cloudOUT = new List<double[]>();
        List<double[]> cloudINShow = new List<double[]>();
        List<double[]> cloudOUTShow = new List<double[]>();

        double[,] arrayEX = new double[32, 4];
        double[,] arrayIN = new double[2500 * 32, 5];
        double[,] arrayOUT = new double[2500 * 32, 5];
        double[,] arrayINshow = new double[2500 * 32, 4];
        double[,] arrayOUTshow = new double[2500 * 32, 4];

        int middle_index = -1;

        List<double[]> bound_points = new List<double[]>();
        List<double[]> bps = new List<double[]>();

        List<string> text = new List<string>();

        string str = "";
        byte prev = 0;

        bool mouse_down = false;

        int oldValueX;
        int oldValueY;

        int angleX = 0;
        int angleY = 0;
        int angleZ = 0;

        bool firstRead = true;

        Thread rosa;

        byte[] imageData;

        public scale()
        {
            InitializeComponent();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;

            BoundariesCountT();
            for (int i = 0; i < 32; i++)
            {
                double radAlfa = tiltAngle[i] * Math.PI / 180.0;

                tiltAngleSin[i] = Math.Sin(radAlfa);
                tiltAngleCos[i] = Math.Cos(radAlfa);

                laserHistory[i, 0] = -10000;
                laserHistory[i, 1] = -10000;

                laserHistoryIndex[i] = -1;
            }

            for (int i = 0; i < 80000; i++)
            {
                arrayIN[i, 4] = 0;
                arrayOUT[i, 4] = 0;
                arrayINshow[i, 3] = 0;
                arrayOUTshow[i, 3] = 0;
            }

            string[] aragog = pathVar.Split('\\');
            labelPath.Text = aragog[aragog.Length - 1];

            openGLControl1_OpenGLDraw(sender, args);
        }

        private void BoundariesCountT()
        {
            xL = Convert.ToDouble(xlN.Value);
            xR = Convert.ToDouble(xrN.Value);
            yL = Convert.ToDouble(ylN.Value);
            yR = Convert.ToDouble(yrN.Value);
            zL = Convert.ToDouble(zlN.Value);
            zR = Convert.ToDouble(zrN.Value);

            bp[0, 0] = xR;  bp[0, 1] = yL;  bp[0, 2] = zR;
            bp[1, 0] = xL;  bp[1, 1] = yL;  bp[1, 2] = zR;
            bp[2, 0] = xL;  bp[2, 1] = yL;  bp[2, 2] = zL;
            bp[3, 0] = xR;  bp[3, 1] = yL;  bp[3, 2] = zL;
            bp[4, 0] = xR;  bp[4, 1] = yR;  bp[4, 2] = zR;
            bp[5, 0] = xL;  bp[5, 1] = yR;  bp[5, 2] = zR;
            bp[6, 0] = xL;  bp[6, 1] = yR;  bp[6, 2] = zL;
            bp[7, 0] = xR;  bp[7, 1] = yR;  bp[7, 2] = zL;
        }

        private void Load_file(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".pcap";
            dlg.Filter = "Text documents (.pcap)|*.pcap";

            DialogResult result = dlg.ShowDialog();

            //pathBox.Text = dlg.FileName;
            pathVar = dlg.FileName;

            string[] aragog = pathVar.Split('\\');
            labelPath.Text = aragog[aragog.Length - 1];
        }

        private void openGLControl1_OpenGLDraw(object sender, RenderEventArgs args)
        {
            // Создаем экземпляр
            gl = openGLControl1.OpenGL;

            // Очистка экрана и буфера глубин
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //gl.ClearColor(1f, 1f, 1f, 1);

            // Сбрасываем модельно-видовую матрицу
            gl.LoadIdentity();

            // Двигаем перо вглубь экрана
            gl.Translate(0.0f, 0.0f, -10.0f);

            gl.Rotate(angleX - 75f, angleY, angleZ + 20);

            gl.Begin(OpenGL.GL_LINES);

            gl.Color(1f, 0f, 0f);
            gl.Vertex(5f, 0f, 0f);
            gl.Vertex(-5f, 0f, 0f);

            gl.Color(0f, 1f, 0f);
            gl.Vertex(0f, 5f, 0f);
            gl.Vertex(0f, -5f, 0f);

            gl.Color(0f, 0f, 1f);
            gl.Vertex(0f, 0f, 5f);
            gl.Vertex(0f, 0f, -5f);

            gl.End();

            double scale_norm = Convert.ToDouble(scale_2.Value) / 10;

            if (bound_show.Checked)
            {
                gl.Begin(OpenGL.GL_LINES);      //Cube

                gl.Color(0.0f, 1.0f, 0.7f);

                gl.Vertex(bp[0, 0] * scale_norm, bp[0, 1] * scale_norm, bp[0, 2] * scale_norm);
                gl.Vertex(bp[1, 0] * scale_norm, bp[1, 1] * scale_norm, bp[1, 2] * scale_norm);

                gl.Vertex(bp[1, 0] * scale_norm, bp[1, 1] * scale_norm, bp[1, 2] * scale_norm);
                gl.Vertex(bp[2, 0] * scale_norm, bp[2, 1] * scale_norm, bp[2, 2] * scale_norm);

                gl.Vertex(bp[2, 0] * scale_norm, bp[2, 1] * scale_norm, bp[2, 2] * scale_norm);
                gl.Vertex(bp[3, 0] * scale_norm, bp[3, 1] * scale_norm, bp[3, 2] * scale_norm);

                gl.Vertex(bp[3, 0] * scale_norm, bp[3, 1] * scale_norm, bp[3, 2] * scale_norm);
                gl.Vertex(bp[0, 0] * scale_norm, bp[0, 1] * scale_norm, bp[0, 2] * scale_norm);


                gl.Vertex(bp[2, 0] * scale_norm, bp[2, 1] * scale_norm, bp[2, 2] * scale_norm);
                gl.Vertex(bp[6, 0] * scale_norm, bp[6, 1] * scale_norm, bp[6, 2] * scale_norm);

                gl.Vertex(bp[1, 0] * scale_norm, bp[1, 1] * scale_norm, bp[1, 2] * scale_norm);
                gl.Vertex(bp[5, 0] * scale_norm, bp[5, 1] * scale_norm, bp[5, 2] * scale_norm);

                gl.Vertex(bp[3, 0] * scale_norm, bp[3, 1] * scale_norm, bp[3, 2] * scale_norm);
                gl.Vertex(bp[7, 0] * scale_norm, bp[7, 1] * scale_norm, bp[7, 2] * scale_norm);

                gl.Vertex(bp[0, 0] * scale_norm, bp[0, 1] * scale_norm, bp[0, 2] * scale_norm);
                gl.Vertex(bp[4, 0] * scale_norm, bp[4, 1] * scale_norm, bp[4, 2] * scale_norm);


                gl.Vertex(bp[4, 0] * scale_norm, bp[4, 1] * scale_norm, bp[4, 2] * scale_norm);
                gl.Vertex(bp[5, 0] * scale_norm, bp[5, 1] * scale_norm, bp[5, 2] * scale_norm);

                gl.Vertex(bp[5, 0] * scale_norm, bp[5, 1] * scale_norm, bp[5, 2] * scale_norm);
                gl.Vertex(bp[6, 0] * scale_norm, bp[6, 1] * scale_norm, bp[6, 2] * scale_norm);

                gl.Vertex(bp[6, 0] * scale_norm, bp[6, 1] * scale_norm, bp[6, 2] * scale_norm);
                gl.Vertex(bp[7, 0] * scale_norm, bp[7, 1] * scale_norm, bp[7, 2] * scale_norm);

                gl.Vertex(bp[7, 0] * scale_norm, bp[7, 1] * scale_norm, bp[7, 2] * scale_norm);
                gl.Vertex(bp[4, 0] * scale_norm, bp[4, 1] * scale_norm, bp[4, 2] * scale_norm);

                gl.End();
            }

            gl.Begin(OpenGL.GL_POINTS);      // Cloud            

            while (busy) ;

            gl.Color(1.0f, 1.0f, 1.0f);

            for (int i = 0; i < 80000; i++)
            {
                if (arrayINshow[i, 3] == 1)
                    gl.Vertex(arrayINshow[i, 0] * scale_norm, arrayINshow[i, 1] * scale_norm, arrayINshow[i, 2] * scale_norm);
            }

            //    catch (Exception er)
            //    {
            //        //MessageBox.Show(er.ToString() + "\n\r" + "i: " + i + "\n\r\n\rCloud: " + cloud.Count + "\n\rCLC: " + clc);
            //    }

            gl.Color(0.3f, 0.3f, 0.3f);

            for (int i = 0; i < 80000; i++)
            {
                if (arrayOUTshow[i, 3] == 1)
                    gl.Vertex(arrayOUTshow[i, 0] * scale_norm, arrayOUTshow[i, 1] * scale_norm, arrayOUTshow[i, 2] * scale_norm);
            }

            //if (cloudINShow.Count + cloudOUTShow.Count > 0)
            //    MessageBox.Show((cloudINShow.Count + cloudOUTShow.Count).ToString());

            gl.End();

            timeLab.Text = bps.Count.ToString();

            for (int i = 0; i < bps.Count; i++)
            {
                double l = bps[i][3] - bps[i][0];
                double w = bps[i][4] - bps[i][1];
                double h = bps[i][5] - bps[i][2];

                gl.Begin(OpenGL.GL_LINES);      //Cube

                gl.Color(0.6f, 0.6f, 1.0f);

                gl.Vertex((bps[i][0]) * scale_norm, (bps[i][1]) * scale_norm, (bps[i][2]) * scale_norm);
                gl.Vertex((bps[i][0]) * scale_norm, (bps[i][1] + w) * scale_norm, (bps[i][2]) * scale_norm);

                gl.Vertex((bps[i][0]) * scale_norm, (bps[i][1]) * scale_norm, (bps[i][2]) * scale_norm);
                gl.Vertex((bps[i][0]) * scale_norm, (bps[i][1]) * scale_norm, (bps[i][2] + h) * scale_norm);

                gl.Vertex((bps[i][0]) * scale_norm, (bps[i][1]) * scale_norm, (bps[i][2]) * scale_norm);
                gl.Vertex((bps[i][0] + l) * scale_norm, (bps[i][1]) * scale_norm, (bps[i][2]) * scale_norm);


                gl.Vertex((bps[i][3]) * scale_norm, (bps[i][4]) * scale_norm, (bps[i][5]) * scale_norm);
                gl.Vertex((bps[i][3]) * scale_norm, (bps[i][4] - w) * scale_norm, (bps[i][5]) * scale_norm);

                gl.Vertex((bps[i][3]) * scale_norm, (bps[i][4]) * scale_norm, (bps[i][5]) * scale_norm);
                gl.Vertex((bps[i][3]) * scale_norm, (bps[i][4]) * scale_norm, (bps[i][5] - h) * scale_norm);

                gl.Vertex((bps[i][3]) * scale_norm, (bps[i][4]) * scale_norm, (bps[i][5]) * scale_norm);
                gl.Vertex((bps[i][3] - l) * scale_norm, (bps[i][4]) * scale_norm, (bps[i][5]) * scale_norm);


                gl.Vertex((bps[i][0] + l) * scale_norm, (bps[i][1]) * scale_norm, (bps[i][2] + h) * scale_norm);
                gl.Vertex((bps[i][0]) * scale_norm, (bps[i][1]) * scale_norm, (bps[i][2] + h) * scale_norm);

                gl.Vertex((bps[i][0] + l) * scale_norm, (bps[i][1]) * scale_norm, (bps[i][2] + h) * scale_norm);
                gl.Vertex((bps[i][0] + l) * scale_norm, (bps[i][1]) * scale_norm, (bps[i][2]) * scale_norm);

                gl.Vertex((bps[i][0]) * scale_norm, (bps[i][1]) * scale_norm, (bps[i][2] + h) * scale_norm);
                gl.Vertex((bps[i][0]) * scale_norm, (bps[i][1] + w) * scale_norm, (bps[i][2] + h) * scale_norm);


                gl.Vertex((bps[i][3] - l) * scale_norm, (bps[i][4]) * scale_norm, (bps[i][5] - h) * scale_norm);
                gl.Vertex((bps[i][3]) * scale_norm, (bps[i][4]) * scale_norm, (bps[i][5] - h) * scale_norm);

                gl.Vertex((bps[i][3] - l) * scale_norm, (bps[i][4]) * scale_norm, (bps[i][5] - h) * scale_norm);
                gl.Vertex((bps[i][3] - l) * scale_norm, (bps[i][4]) * scale_norm, (bps[i][5]) * scale_norm);

                gl.Vertex((bps[i][3]) * scale_norm, (bps[i][4]) * scale_norm, (bps[i][5] - h) * scale_norm);
                gl.Vertex((bps[i][3]) * scale_norm, (bps[i][4] - w) * scale_norm, (bps[i][5] - h) * scale_norm);

                gl.End();
            }

            gl.Flush();

            imageData = new byte[3 * 700 * 450];

            gl.ReadPixels(0, 0, 700, 450, OpenGL.GL_RGB, OpenGL.GL_UNSIGNED_BYTE, imageData);
        }

        private void TextBomb()
        {

        }

        private void RosaFunc(object sender, EventArgs e)
        {
            try
            {
                FileStream fs = File.OpenRead(pathVar);

                int c;
                int byteCount = 0;
                byte memoryByte = 0;
                byte[] buf = new byte[1];

                int clearCount = 0;

                int rotatoinAngleByte1 = 0;
                int rotatoinAngleByte2 = 0;
                double rotatoinAngle = 0;

                int laserNum = 0;
                int byteLaserNum = 0;
                double firstLaserByte = 0;
                double secondLaserByte = 0;
                bool volk = true;
                bool fullStack = false;
                int inCount = 0;
                int outCount = 0;

                while ((c = fs.Read(buf, 0, buf.Length)) > 0)
                {
                    bufText.Add(buf[0]);

                    if (byteCount == 1)
                        rotatoinAngleByte1 = buf[0];

                    if (byteCount == 2)
                    {
                        rotatoinAngleByte2 = buf[0];
                        rotatoinAngle = (rotatoinAngleByte2 * 256.0 + rotatoinAngleByte1) / 100.0;
                    }

                    if ((byteCount > 2) && (byteCount < 101))
                    {
                        if (byteLaserNum == 0)
                            firstLaserByte = buf[0];

                        if (byteLaserNum == 1)
                            secondLaserByte = buf[0];

                        if (byteLaserNum == 2)
                        {
                            double laser = (secondLaserByte * 256.0 + firstLaserByte) * 0.001;

                            arrayEX[laserNum, 0] = 0;
                            arrayEX[laserNum, 1] = tiltAngleCos[laserNum] * laser;
                            arrayEX[laserNum, 2] = tiltAngleSin[laserNum] * laser;
                            arrayEX[laserNum, 3] = laser;

                            byteLaserNum = -1;
                            laserNum++;
                            if (laserNum == 32)
                                fullStack = true;
                        }

                        byteLaserNum++;
                    }

                    if ((buf[0] == 0xEE) && (memoryByte == 0xFF))
                    {
                        laserNum = 0;
                        byteLaserNum = 0;

                        double max_differential_h = 0.04;   // максимальный перепад по карям точки
                        double max_differential_v = 1;   // максимальный перепад по карям точки
                        double max_differential_base = 1;   // максимальный перепад базы точки

                        double radAngle = rotatoinAngle * Math.PI / 180.0;

                        if (fullStack)
                        {
                            fullStack = false;

                            for (int i = 0; i < 32; i++)
                            {
                                double newX = arrayEX[i, 0] * Math.Cos(radAngle) + arrayEX[i, 1] * Math.Sin(radAngle);
                                double newY = arrayEX[i, 0] * -Math.Sin(radAngle) + arrayEX[i, 1] * Math.Cos(radAngle);
                                double newZ = arrayEX[i, 2];

                                if ((newX >= xL) && (newX <= xR)
                                && (newY >= yL) && (newY <= yR)
                                && (newZ >= zL) && (newZ <= zR))
                                    if (volk == true)
                                    {
                                        try
                                        {
                                            if (inCount < 80000)
                                            {
                                                arrayIN[inCount, 0] = newX;
                                                arrayIN[inCount, 1] = newY;
                                                arrayIN[inCount, 2] = newZ;
                                                arrayIN[inCount, 3] = arrayEX[i, 3];
                                                arrayIN[inCount, 4] = 1;

                                                inCount++;
                                            }
                                        }
                                        catch
                                        {
                                            MessageBox.Show(inCount + "");
                                        }

                                        //cloudIN.Add(new double[] { newX, newY, newZ });
                                        //laserHistoryIndex[i] = cloudIN.Count - 1;
                                        volk = false;
                                    }
                                    else
                                        volk = true;
                                else
                                {
                                    if (inCount < 80000)
                                    {
                                        arrayOUT[outCount, 0] = newX;
                                        arrayOUT[outCount, 1] = newY;
                                        arrayOUT[outCount, 2] = newZ;
                                        arrayOUT[outCount, 3] = arrayEX[i, 3];
                                        arrayOUT[outCount, 4] = 1;

                                        outCount++;
                                    }
                                    //cloudOUT.Add(new double[] { newX, newY, newZ });
                                    //laserHistoryIndex[i] = -1;
                                }
                            }                            

                            byteCount = 0;

                            //cloudEx.Clear();

                            clearCount++;

                            try
                            {
                                if (clearCount == 2500)
                                {
                                    MessageBox.Show("");

                                    busy = true;
                                    //cloudShow = cloud.Select(item => (double[])item.Clone()).ToList();
                                    //cloudINShow = cloudIN.Select(item => (double[])item.Clone()).ToList();
                                    //cloudOUTShow = cloudOUT.Select(item => (double[])item.Clone()).ToList();

                                    arrayIN.CopyTo(arrayINshow, 0);
                                    arrayOUT.CopyTo(arrayOUTshow, 0);

                                    busy = false;

                                    MessageBox.Show("");

                                    int num_of_points = inCount;

                                    double[,] cloudInArr = new double[num_of_points, 3];

                                    for (int i = 0; i < num_of_points; i++)
                                    {
                                        cloudInArr[i, 0] = arrayINshow[i, 0];
                                        cloudInArr[i, 1] = arrayINshow[i, 1];
                                        cloudInArr[i, 2] = arrayINshow[i, 2];
                                    }

                                    int num_of_clusters = 50;
                                    int num_of_iterations = 3;
                                    int[] cluster_array = Kmeans3D(cloudInArr, num_of_clusters, num_of_iterations);

                                    int treshold = 1; //минимальное количество точек в кластере чтобы его помечать

                                    for (int i = 0; i < num_of_clusters; i++)
                                    {
                                        int num_of_points_in_the_cluster = 0;

                                        for (int j = 0; j < num_of_points; j++)
                                            if (cluster_array[j] == i)
                                                num_of_points_in_the_cluster++;

                                        //MessageBox.Show("Cluster: " + i + "\n\r" + "Num. of points: " + num_of_points_in_the_cluster);

                                        if (num_of_points_in_the_cluster >= treshold)
                                        {
                                            double min_x_cluster = 10000;
                                            double max_x_cluster = -10000;

                                            double min_y_cluster = 10000;
                                            double max_y_cluster = -10000;

                                            double min_z_cluster = 10000;
                                            double max_z_cluster = -10000;

                                            for (int j = 0; j < num_of_points; j++)
                                                if (cluster_array[j] == i)
                                                {
                                                    if (cloudINShow[j][0] < min_x_cluster)
                                                        min_x_cluster = cloudINShow[j][0];

                                                    if (cloudINShow[j][0] > max_x_cluster)
                                                        max_x_cluster = cloudINShow[j][0];

                                                    if (cloudINShow[j][1] < min_y_cluster)
                                                        min_y_cluster = cloudINShow[j][1];

                                                    if (cloudINShow[j][1] > max_y_cluster)
                                                        max_y_cluster = cloudINShow[j][1];

                                                    if (cloudINShow[j][2] < min_z_cluster)
                                                        min_z_cluster = cloudINShow[j][2];

                                                    if (cloudINShow[j][2] > max_z_cluster)
                                                        max_z_cluster = cloudINShow[j][2];
                                                }

                                            bound_points.Add(new double[]
                                            {
                                                min_x_cluster, min_y_cluster, min_z_cluster,
                                                max_x_cluster, max_y_cluster, max_z_cluster
                                            });
                                        }
                                    }

                                    busy = true;
                                    bps = bound_points.Select(item => (double[])item.Clone()).ToList();

                                    for (int i = 0; i < 80000; i++)
                                    {
                                        arrayIN[i, 4] = 0;
                                        arrayOUT[i, 4] = 0;
                                        arrayINshow[i, 3] = 0;
                                        arrayOUTshow[i, 3] = 0;
                                    }

                                    inCount = 0;
                                    outCount = 0;

                                    bound_points.Clear();
                                    busy = false;

                                    clearCount = 0;

                                    Thread.Sleep(Convert.ToInt32(readSpeed.Value));
                                }
                            }
                            catch { }
                        }
                    }

                    memoryByte = buf[0];

                    byteCount++;
                }
            }
            catch (Exception er)
            {
                MessageBox.Show(er.ToString());
            }
            playPause.Text = "Restart";
        }

        public double[,] Filter3D(double[,] x_y_z, double radius, int group_size)
        {
            int number_of_points = x_y_z.Length / 3;

            bool[] antibody = new bool[number_of_points];

            for (int i = 0; i < number_of_points; i++)
            {
                int group = 0;

                for (int j = 0; j < number_of_points; j++)
                {
                    if (i != j)
                    {
                        double new_dist = DistanceBetween3D(
                                x_y_z[i, 0], x_y_z[i, 1], x_y_z[i, 2],
                                x_y_z[j, 0], x_y_z[j, 1], x_y_z[j, 2]
                            );

                        if (new_dist < radius)
                            group++;
                    }
                }

                if (group < group_size)
                    antibody[i] = true;
                else
                    antibody[i] = false;
            }

            int new_num = 0;

            for (int i = 0; i < number_of_points; i++)
                if (!antibody[i])
                    new_num++;

            double[,] points = new double[new_num, 3];

            int new_counter = 0;

            for (int i = 0; i < number_of_points; i++)
                if (!antibody[i])
                {
                    points[new_counter, 0] = x_y_z[i, 0];
                    points[new_counter, 1] = x_y_z[i, 1];
                    points[new_counter, 2] = x_y_z[i, 2];

                    new_counter++;
                }

            return points;
        }

        public int[] Kmeans3D(double[,] x_y_z, int number_of_clusters, int number_of_iterations)
        {
            double[,] cluster_centers;

            //нахоим границы разброса наших точек
            double maxX = -100000;
            double minX = 100000;
            double maxY = -100000;
            double minY = 100000;
            double maxZ = -100000;
            double minZ = 100000;

            for (int i = 0; i < x_y_z.Length / 3; i++)
            {
                if (x_y_z[i, 0] > maxX)
                    maxX = x_y_z[i, 0];

                if (x_y_z[i, 0] < minX)
                    minX = x_y_z[i, 0];

                if (x_y_z[i, 1] > maxY)
                    maxY = x_y_z[i, 1];

                if (x_y_z[i, 1] < minY)
                    minY = x_y_z[i, 1];

                if (x_y_z[i, 2] > maxZ)
                    maxZ = x_y_z[i, 2];

                if (x_y_z[i, 2] < minZ)
                    minZ = x_y_z[i, 2];
            }

            //int number_of_clusters = 10;
            int number_of_points = x_y_z.Length / 3;
            int iter = number_of_iterations;
            int[] cluster_array = new int[number_of_points];

            //разбрасывем кластеры
            cluster_centers = new double[number_of_clusters, 3];
            Random rand = new Random();

            for (int i = 0; i < number_of_clusters; i++)
            {
                cluster_centers[i, 0] = rand.NextDouble() * (maxX - minX) + minX;
                cluster_centers[i, 1] = rand.NextDouble() * (maxY - minY) + minY;
                cluster_centers[i, 2] = rand.NextDouble() * (maxZ - minZ) + minZ;
            }

            //рассчитываем кластеры
            for (int i = 0; i < iter; i++)
            {
                for (int p = 0; p < number_of_points; p++)
                {
                    int closest_cluster = -1;
                    double min_dist = 100000;

                    for (int c = 0; c < number_of_clusters; c++)
                    {
                        double new_dist = DistanceBetween3D(x_y_z[p, 0], x_y_z[p, 1], x_y_z[p, 2],
                            cluster_centers[c, 0], cluster_centers[c, 1], cluster_centers[c, 2]);

                        if (new_dist < min_dist)
                        {
                            closest_cluster = c;
                            min_dist = new_dist;
                        }

                    }

                    cluster_array[p] = closest_cluster;
                }

                for (int c = 0; c < number_of_clusters; c++)
                {
                    double middle_x = 0;
                    double middle_y = 0;
                    double middle_z = 0;

                    double counter = 0;

                    for (int p = 0; p < number_of_points; p++)
                    {
                        if (cluster_array[p] == c)
                        {
                            counter++;

                            middle_x += x_y_z[p, 0];
                            middle_y += x_y_z[p, 1];
                            middle_z += x_y_z[p, 2];

                        }
                    }

                    if (counter != 0)
                    {
                        cluster_centers[c, 0] = Convert.ToInt32(middle_x / counter);
                        cluster_centers[c, 1] = Convert.ToInt32(middle_y / counter);
                        cluster_centers[c, 2] = Convert.ToInt32(middle_z / counter);
                    }
                    else
                    {
                        cluster_centers[c, 0] = -10;
                        cluster_centers[c, 1] = -10;
                        cluster_centers[c, 2] = -10;
                    }
                }
            }

            return cluster_array;
        }

        public void ShowArray1D(int[] array, int period, string name)
        {
            string str = name + "\n\r";

            for (int i = 0; i < array.Length; i++)
            {
                str += array[i] + " ";
                if ((i % period == 0) && (i != 0))
                    str += "\n\r";
            }

            MessageBox.Show(str);
        }

        public double DistanceBetween3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2));
        }

        private void OpenGLDraw_func(object sender, RenderEventArgs args)
        {
            openGLControl1_OpenGLDraw(sender, args);
        }

        private void Scale_change(object sender, EventArgs e)
        {
            openGLControl1_OpenGLDraw(sender, args);
        }

        private void KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void MouseDown(object sender, MouseEventArgs e)
        {
            mouse_down = true;

            oldValueX = e.X;
            oldValueY = e.Y;
        }

        private void MouseUp(object sender, MouseEventArgs e)
        {
            mouse_down = false;
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_down)
            {
                angleZ += Convert.ToInt32((e.X - oldValueX) / 2.0);
                angleX += Convert.ToInt32((e.Y - oldValueY) / 2.0);

                openGLControl1_OpenGLDraw(sender, args);

                oldValueX = e.X;
                oldValueY = e.Y;
            }
        }

        private void ReadDump(object sender, EventArgs e)
        {
            if (playPause.Text == "Read")
            {
                if (firstRead)
                {
                    rosa = new Thread(() => RosaFunc(sender, e));
                    //memosa = new Thread(() => TextBomb());
                    rosa.Start();
                    //memosa.Start();
                    firstRead = false;
                }
                else
                {
                    rosa.Resume();
                    //memosa.Resume();
                }

                playPause.Text = "Pause";
            }
            else
            if (playPause.Text == "Pause")
            {
                rosa.Suspend();
                //memosa.Suspend();
                playPause.Text = "Read";
            }
            else
            if (playPause.Text == "Restart")
            {
                rosa.Abort();
                //memosa.Abort();
                firstRead = true;
                playPause.Text = "Read";
            }
        }

        private void BrowseSave(object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog dlg = new System.Windows.Forms.FolderBrowserDialog();

            DialogResult result = dlg.ShowDialog();

            //pathBox.Text = dlg.FileName;
            pathSave.Text = dlg.SelectedPath;
        }

        private void SaveSave(object sender, EventArgs e)
        {
            Bitmap bit = new Bitmap(450, 700);

            int arrCounter = 0;

            for (int i = 0; i < 450; ++i)
            {
                for (int j = 0; j < 700; ++j)
                {
                    bit.SetPixel(i, j, Color.FromArgb(imageData[arrCounter], imageData[arrCounter + 1], imageData[arrCounter + 2]));
                    arrCounter += 3;
                }
            }

            Bitmap bit2 = new Bitmap(560, 360);

            for (int i = 0; i < 270; ++i)
            {
                for (int j = 0; j < 420; ++j)
                {
                    Color c = bit.GetPixel(i,j);

                    int r = c.R;
                    int g = c.G;
                    int b = c.B;

                    bit2.SetPixel(j, 270 - i, Color.FromArgb(r, g, b));
                }
            }

            bit2.Save(pathSave.Text + "//image.png");
        }

        private void Form1_ClosingEvent(object sender, FormClosingEventArgs e)
        {
            try
            {
                rosa.Resume();
                //memosa.Resume();
            }
            catch { }

            try
            {
                rosa.Abort();
                //memosa.Abort();
            }
            catch { }
        }

        private void BoundariesCount(object sender, EventArgs e)
        {
            BoundariesCountT();

            openGLControl1_OpenGLDraw(sender, args);
        }
    }
}
