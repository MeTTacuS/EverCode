using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV.UI;

namespace What_s_That
{
    public partial class MainWindow : Form
    {
        #region Variables
        Recognition rec; //Face detection and recognition
        #endregion
        public MainWindow()
        {
            SetDllPath();
            InitializeComponent();
            rec = new Recognition(box : imgCamUser);
        }

        private void buttonAddFace_Click(object sender, EventArgs e)
        {
            rec.AddFace(nameTextBox);
        }
        
        /*
         * A method that sets the path to the folder that contains 
         * all DLL's used for face recognition and detection
         */
        private void SetDllPath()
        {
            string dllDirectory = @"../../DLL"; // Regular expression?
            Environment.SetEnvironmentVariable("PATH", Environment.GetEnvironmentVariable("PATH") + ";" + dllDirectory);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void imgCamUser_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            lebel2.text
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
