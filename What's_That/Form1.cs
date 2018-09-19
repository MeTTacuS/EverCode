using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;

namespace What_s_That
{
    public partial class MainWindow : Form
    {
        VideoCapture capture;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void buttonIdentify_Click(object sender, EventArgs e)
        {
            Run();
        }

        /*
         * Function that starts the face-recognition system
         */
        private void Run()
        {
            try
            {
                capture = new VideoCapture();
                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
                throw;
            }
            Application.Idle += ProcessFrame;
        }
        private void ProcessFrame(object sender, EventArgs e)
        {
            imgCamUser.Image = capture.QuerySmallFrame();
        }


    }
}
