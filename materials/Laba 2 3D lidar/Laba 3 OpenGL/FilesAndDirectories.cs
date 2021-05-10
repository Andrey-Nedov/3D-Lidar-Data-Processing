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

namespace Laba_3_OpenGL
{
    class FilesAndDirectories
    {
        public string BrowseFolder()
        {
            string path = "";

            System.Windows.Forms.FolderBrowserDialog dlg = new System.Windows.Forms.FolderBrowserDialog();

            DialogResult result = dlg.ShowDialog();

            path = dlg.SelectedPath;

            return path;
        }

        public string BrowseTXT()
        {
            string path = "";

            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text documents (.txt)|*.txt";

            DialogResult result = dlg.ShowDialog();

            path = dlg.FileName;

            return path;
        }

        public string BrowseCSV()
        {
            string path = "";

            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".csv";
            dlg.Filter = "Text documents (.csv)|*.csv";

            DialogResult result = dlg.ShowDialog();

            path = dlg.FileName;

            return path;
        }

        public string BrowsePNG()
        {
            string path = "";

            System.Windows.Forms.OpenFileDialog dlg = new System.Windows.Forms.OpenFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".png";
            dlg.Filter = "Text documents (.png)|*.png";

            DialogResult result = dlg.ShowDialog();

            path = dlg.FileName;

            return path;
        }
    }
}
