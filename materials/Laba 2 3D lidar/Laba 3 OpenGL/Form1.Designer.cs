namespace Laba_3_OpenGL
{
    partial class scale
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadCSVToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openGLControl1 = new SharpGL.OpenGLControl();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.scale_2 = new System.Windows.Forms.TrackBar();
            this.labelPath = new System.Windows.Forms.Label();
            this.playPause = new System.Windows.Forms.Button();
            this.timeLab = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.pathSave = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.readSpeed = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox = new System.Windows.Forms.TextBox();
            this.xlN = new System.Windows.Forms.NumericUpDown();
            this.xrN = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bound_show = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.zrN = new System.Windows.Forms.NumericUpDown();
            this.zlN = new System.Windows.Forms.NumericUpDown();
            this.yrN = new System.Windows.Forms.NumericUpDown();
            this.ylN = new System.Windows.Forms.NumericUpDown();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.iso = new System.Windows.Forms.RadioButton();
            this.notIso = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.alfa = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.r_z = new System.Windows.Forms.NumericUpDown();
            this.r_y = new System.Windows.Forms.NumericUpDown();
            this.r_x = new System.Windows.Forms.NumericUpDown();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scale_2)).BeginInit();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.readSpeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xlN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrN)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zrN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zlN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yrN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ylN)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alfa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_z)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_y)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_x)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1182, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadCSVToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadCSVToolStripMenuItem
            // 
            this.loadCSVToolStripMenuItem.Name = "loadCSVToolStripMenuItem";
            this.loadCSVToolStripMenuItem.Size = new System.Drawing.Size(181, 34);
            this.loadCSVToolStripMenuItem.Text = "Load file";
            this.loadCSVToolStripMenuItem.Click += new System.EventHandler(this.Load_file);
            // 
            // openGLControl1
            // 
            this.openGLControl1.DrawFPS = false;
            this.openGLControl1.Location = new System.Drawing.Point(457, 65);
            this.openGLControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.openGLControl1.Name = "openGLControl1";
            this.openGLControl1.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl1.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl1.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl1.Size = new System.Drawing.Size(700, 450);
            this.openGLControl1.TabIndex = 10;
            this.openGLControl1.OpenGLDraw += new SharpGL.RenderEventHandler(this.OpenGLDraw_func);
            this.openGLControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown);
            this.openGLControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDown);
            this.openGLControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MouseMove);
            this.openGLControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.scale_2);
            this.groupBox2.Location = new System.Drawing.Point(457, 613);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 96);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Scale";
            // 
            // scale_2
            // 
            this.scale_2.Location = new System.Drawing.Point(52, 20);
            this.scale_2.Maximum = 300;
            this.scale_2.Minimum = 1;
            this.scale_2.Name = "scale_2";
            this.scale_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.scale_2.Size = new System.Drawing.Size(323, 69);
            this.scale_2.TabIndex = 12;
            this.scale_2.TickFrequency = 1000;
            this.scale_2.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.scale_2.Value = 15;
            this.scale_2.Scroll += new System.EventHandler(this.Scale_change);
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Location = new System.Drawing.Point(27, 45);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(51, 20);
            this.labelPath.TabIndex = 16;
            this.labelPath.Text = "label5";
            // 
            // playPause
            // 
            this.playPause.Location = new System.Drawing.Point(27, 77);
            this.playPause.Name = "playPause";
            this.playPause.Size = new System.Drawing.Size(406, 43);
            this.playPause.TabIndex = 17;
            this.playPause.Text = "Read";
            this.playPause.UseVisualStyleBackColor = true;
            this.playPause.Click += new System.EventHandler(this.ReadDump);
            // 
            // timeLab
            // 
            this.timeLab.AutoSize = true;
            this.timeLab.BackColor = System.Drawing.Color.Black;
            this.timeLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.timeLab.ForeColor = System.Drawing.Color.White;
            this.timeLab.Location = new System.Drawing.Point(994, 472);
            this.timeLab.Name = "timeLab";
            this.timeLab.Size = new System.Drawing.Size(73, 20);
            this.timeLab.TabIndex = 28;
            this.timeLab.Text = "timeLab";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(67, 79);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 45);
            this.button4.TabIndex = 32;
            this.button4.Text = "Browse";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.BrowseSave);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(177, 79);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(209, 45);
            this.button3.TabIndex = 31;
            this.button3.Text = "Save image";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.SaveSave);
            // 
            // pathSave
            // 
            this.pathSave.Location = new System.Drawing.Point(67, 38);
            this.pathSave.Name = "pathSave";
            this.pathSave.Size = new System.Drawing.Size(319, 26);
            this.pathSave.TabIndex = 33;
            this.pathSave.Text = "C:\\Users\\andre\\Desktop\\Учёба\\Политех\\Лабораторки\\3 курс 2 семестр\\Технологии визу" +
    "ализации данных систем управления\\Лабораторная работа 4 (Вторая по CAN)";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(19, 41);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 20);
            this.label15.TabIndex = 34;
            this.label15.Text = "Path:";
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.label15);
            this.groupBox12.Controls.Add(this.pathSave);
            this.groupBox12.Controls.Add(this.button3);
            this.groupBox12.Controls.Add(this.button4);
            this.groupBox12.Location = new System.Drawing.Point(27, 681);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(406, 142);
            this.groupBox12.TabIndex = 33;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "Save image";
            // 
            // readSpeed
            // 
            this.readSpeed.Location = new System.Drawing.Point(204, 127);
            this.readSpeed.Maximum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.readSpeed.Name = "readSpeed";
            this.readSpeed.Size = new System.Drawing.Size(120, 26);
            this.readSpeed.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 20);
            this.label1.TabIndex = 35;
            this.label1.Text = "Delay between frames:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "ms";
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(27, 168);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ReadOnly = true;
            this.textBox.Size = new System.Drawing.Size(406, 499);
            this.textBox.TabIndex = 37;
            // 
            // xlN
            // 
            this.xlN.DecimalPlaces = 2;
            this.xlN.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.xlN.Location = new System.Drawing.Point(52, 35);
            this.xlN.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.xlN.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.xlN.Name = "xlN";
            this.xlN.Size = new System.Drawing.Size(101, 26);
            this.xlN.TabIndex = 38;
            this.xlN.Value = new decimal(new int[] {
            15,
            0,
            0,
            -2147418112});
            this.xlN.ValueChanged += new System.EventHandler(this.BoundariesCount);
            // 
            // xrN
            // 
            this.xrN.DecimalPlaces = 2;
            this.xrN.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.xrN.Location = new System.Drawing.Point(170, 35);
            this.xrN.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.xrN.Name = "xrN";
            this.xrN.Size = new System.Drawing.Size(101, 26);
            this.xrN.TabIndex = 38;
            this.xrN.Value = new decimal(new int[] {
            6,
            0,
            0,
            65536});
            this.xrN.ValueChanged += new System.EventHandler(this.BoundariesCount);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bound_show);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.zrN);
            this.groupBox1.Controls.Add(this.zlN);
            this.groupBox1.Controls.Add(this.yrN);
            this.groupBox1.Controls.Add(this.ylN);
            this.groupBox1.Controls.Add(this.xrN);
            this.groupBox1.Controls.Add(this.xlN);
            this.groupBox1.Location = new System.Drawing.Point(852, 523);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 186);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bounding planes";
            // 
            // bound_show
            // 
            this.bound_show.AutoSize = true;
            this.bound_show.Checked = true;
            this.bound_show.CheckState = System.Windows.Forms.CheckState.Checked;
            this.bound_show.Location = new System.Drawing.Point(52, 141);
            this.bound_show.Name = "bound_show";
            this.bound_show.Size = new System.Drawing.Size(158, 24);
            this.bound_show.TabIndex = 46;
            this.bound_show.Text = "Show boundaries";
            this.bound_show.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 20);
            this.label5.TabIndex = 45;
            this.label5.Text = "Z:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(24, 20);
            this.label4.TabIndex = 44;
            this.label4.Text = "Y:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 20);
            this.label3.TabIndex = 43;
            this.label3.Text = "X:";
            // 
            // zrN
            // 
            this.zrN.DecimalPlaces = 2;
            this.zrN.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.zrN.Location = new System.Drawing.Point(170, 99);
            this.zrN.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.zrN.Name = "zrN";
            this.zrN.Size = new System.Drawing.Size(101, 26);
            this.zrN.TabIndex = 41;
            this.zrN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.zrN.ValueChanged += new System.EventHandler(this.BoundariesCount);
            // 
            // zlN
            // 
            this.zlN.DecimalPlaces = 2;
            this.zlN.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.zlN.Location = new System.Drawing.Point(52, 99);
            this.zlN.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.zlN.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.zlN.Name = "zlN";
            this.zlN.Size = new System.Drawing.Size(101, 26);
            this.zlN.TabIndex = 42;
            this.zlN.Value = new decimal(new int[] {
            42,
            0,
            0,
            -2147352576});
            this.zlN.ValueChanged += new System.EventHandler(this.BoundariesCount);
            // 
            // yrN
            // 
            this.yrN.DecimalPlaces = 2;
            this.yrN.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.yrN.Location = new System.Drawing.Point(170, 67);
            this.yrN.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.yrN.Name = "yrN";
            this.yrN.Size = new System.Drawing.Size(101, 26);
            this.yrN.TabIndex = 39;
            this.yrN.Value = new decimal(new int[] {
            31,
            0,
            0,
            65536});
            this.yrN.ValueChanged += new System.EventHandler(this.BoundariesCount);
            // 
            // ylN
            // 
            this.ylN.DecimalPlaces = 2;
            this.ylN.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.ylN.Location = new System.Drawing.Point(52, 67);
            this.ylN.Maximum = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.ylN.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.ylN.Name = "ylN";
            this.ylN.Size = new System.Drawing.Size(101, 26);
            this.ylN.TabIndex = 40;
            this.ylN.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.ylN.ValueChanged += new System.EventHandler(this.BoundariesCount);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.iso);
            this.groupBox3.Controls.Add(this.notIso);
            this.groupBox3.Location = new System.Drawing.Point(457, 523);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(381, 89);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "View";
            // 
            // iso
            // 
            this.iso.AutoSize = true;
            this.iso.Location = new System.Drawing.Point(223, 33);
            this.iso.Name = "iso";
            this.iso.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.iso.Size = new System.Drawing.Size(95, 24);
            this.iso.TabIndex = 1;
            this.iso.Text = "Isometry";
            this.iso.UseVisualStyleBackColor = true;
            this.iso.CheckedChanged += new System.EventHandler(this.ChangeView);
            // 
            // notIso
            // 
            this.notIso.AutoSize = true;
            this.notIso.Checked = true;
            this.notIso.Location = new System.Drawing.Point(86, 33);
            this.notIso.Name = "notIso";
            this.notIso.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.notIso.Size = new System.Drawing.Size(89, 24);
            this.notIso.TabIndex = 0;
            this.notIso.TabStop = true;
            this.notIso.Text = "3D view";
            this.notIso.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.alfa);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.r_z);
            this.groupBox4.Controls.Add(this.r_y);
            this.groupBox4.Controls.Add(this.r_x);
            this.groupBox4.Location = new System.Drawing.Point(852, 715);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(295, 147);
            this.groupBox4.TabIndex = 35;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Robot coordinates";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(172, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(74, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "Rotation:";
            // 
            // alfa
            // 
            this.alfa.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.alfa.Location = new System.Drawing.Point(176, 64);
            this.alfa.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.alfa.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.alfa.Name = "alfa";
            this.alfa.Size = new System.Drawing.Size(92, 26);
            this.alfa.TabIndex = 6;
            this.alfa.ValueChanged += new System.EventHandler(this.Rob_rot);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 95);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 20);
            this.label8.TabIndex = 5;
            this.label8.Text = "Z:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 63);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Y:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 20);
            this.label6.TabIndex = 3;
            this.label6.Text = "X:";
            // 
            // r_z
            // 
            this.r_z.DecimalPlaces = 2;
            this.r_z.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.r_z.Location = new System.Drawing.Point(52, 93);
            this.r_z.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.r_z.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.r_z.Name = "r_z";
            this.r_z.Size = new System.Drawing.Size(89, 26);
            this.r_z.TabIndex = 2;
            // 
            // r_y
            // 
            this.r_y.DecimalPlaces = 2;
            this.r_y.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.r_y.Location = new System.Drawing.Point(52, 61);
            this.r_y.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.r_y.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.r_y.Name = "r_y";
            this.r_y.Size = new System.Drawing.Size(89, 26);
            this.r_y.TabIndex = 1;
            // 
            // r_x
            // 
            this.r_x.DecimalPlaces = 2;
            this.r_x.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.r_x.Location = new System.Drawing.Point(52, 29);
            this.r_x.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.r_x.Minimum = new decimal(new int[] {
            20,
            0,
            0,
            -2147483648});
            this.r_x.Name = "r_x";
            this.r_x.Size = new System.Drawing.Size(89, 26);
            this.r_x.TabIndex = 0;
            // 
            // scale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 983);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.readSpeed);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.timeLab);
            this.Controls.Add(this.playPause);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.openGLControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1204, 1039);
            this.MinimumSize = new System.Drawing.Size(1204, 1018);
            this.Name = "scale";
            this.Text = "3D lidar";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_ClosingEvent);
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scale_2)).EndInit();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.readSpeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xlN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrN)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zrN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zlN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yrN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ylN)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alfa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_z)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_y)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.r_x)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadCSVToolStripMenuItem;
        private SharpGL.OpenGLControl openGLControl1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TrackBar scale_2;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Button playPause;
        private System.Windows.Forms.Label timeLab;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox pathSave;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.NumericUpDown readSpeed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.NumericUpDown xlN;
        private System.Windows.Forms.NumericUpDown xrN;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown zrN;
        private System.Windows.Forms.NumericUpDown zlN;
        private System.Windows.Forms.NumericUpDown yrN;
        private System.Windows.Forms.NumericUpDown ylN;
        private System.Windows.Forms.CheckBox bound_show;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton iso;
        private System.Windows.Forms.RadioButton notIso;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown r_x;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown alfa;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown r_y;
        private System.Windows.Forms.NumericUpDown r_z;
    }
}

