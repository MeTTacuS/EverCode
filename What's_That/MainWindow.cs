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
        Database database; //Requires host, username, password, database (all strings)
        #endregion

        public MainWindow()
        {
            SetDllPath();
            InitializeComponent();

            rec = new Recognition(CameraBox : imgCamUser, ImageBox : FaceImageBox);

            //database = new Database("127.0.0.1", "ned", "evercode", "whatsthatdb");
            //List<string> textFromDatabase = database.RetrieveData("labas");
            //foreach (string text in textFromDatabase)
            //{
            //    MessageBox.Show(text);
            //}
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
            string dllDirectory = @"../../DLL";
            Environment.SetEnvironmentVariable("PATH", Environment.GetEnvironmentVariable("PATH") + ";" + dllDirectory);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {

        }

        private void ImgCamUser_Click(object sender, EventArgs e)
        {

        }
        
    }
}
