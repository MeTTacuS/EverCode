using System;
using System.Windows.Forms;

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

            rec = new Recognition(CameraBox : imgCamUser, ImageBox : FaceImageBox, NameLable: FirstName, AgeLabel: Age);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
