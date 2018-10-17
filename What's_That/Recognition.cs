using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System.Windows.Forms;
using System.Drawing;

/*
 * A basic face detection and recognition class
 * Stores faces and their labels in Faces directory
 */

namespace What_s_That
{
    class Recognition
    {
        const string path = "../../DLL/haarcascade_frontalface_default.xml";
        const string txtPath = "../../Faces/Faces.txt";

        public Recognition(ImageBox box) //Requires an ImageBox to be passed
        {
            _cameraBox = box;
            // Path to them haarcascade xml file
            _haarCascadeFrontalFace = new HaarCascade(path);
            try
            {
                // Reading all image-names, the amount of them and loading those names AND pictures
                //to our local variables. They will later be used for face recognition
                ReadFiles();
            }
            catch (Exception)
            {
                MessageBox.Show("Nothing in database");
            }

            StartRecognition();
        }

        private void ReadFiles()
        {

            string allLabels = File.ReadAllText(txtPath);
            string[] text = allLabels.Split(',');
            _numOfLabels = Convert.ToInt16(text[0]); //Contains the number of labels stored in DB
            _count = _numOfLabels;
            string facesLoad;
            for (int i = 1; i <= _numOfLabels; i++)
            {
                facesLoad = "face" + i + ".bmp";
                _trainingImages.Add(new Image<Gray, byte>($"../../Faces/{facesLoad}"));
                _labels.Add(text[i]);
            }
        }

        public void StartRecognition()
        {
            _camera = new Capture();
            _camera.QueryFrame();
            // Application.Idle is a WinForms thing. Basically method FrameHandle will be called 
            //every frame that the program is running
            Application.Idle += new EventHandler(FrameHandle);
        }

        private void FrameHandle(object sender, EventArgs e)
        {
            // Getting current frame
            _frame = _camera.QueryFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            // Converting it into gray (used for recognition later)
            _grayFace = _frame.Convert<Gray, byte>();

            // A part where OpenCV tells apart the faces and draws a rectangle around it
            MCvAvgComp[][] facesDetectedNow = _grayFace.DetectHaarCascade(_haarCascadeFrontalFace, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
            foreach (MCvAvgComp f in facesDetectedNow[0])
            {
                _result = _frame.Copy(f.rect).Convert<Gray, Byte>().Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
                // Draws a rectangle around the face
                _frame.Draw(f.rect, new Bgr(Color.Red), 2);
                // An IF that writes the name above the rectangle if there are 
                //any potential matches in our image-database
                if (_trainingImages.ToArray().Length != 0)
                {
                    MCvTermCriteria termCriterias = new MCvTermCriteria(_count, 0.001);
                    EigenObjectRecognizer recognizer = new EigenObjectRecognizer(_trainingImages.ToArray(), _labels.ToArray(), 1500, ref termCriterias);
                    _name = recognizer.Recognize(_result);
                    _frame.Draw(_name, ref font, new Point(f.rect.X - 2, f.rect.Y - 2), new Bgr(Color.Green));
                }
            }
            _cameraBox.Image = _frame;
        }

        public void AddFace(TextBox textBox) // Requires a textbox that has the name in it
        {
            _count = _count + 1;
            _grayFace = _camera.QueryGrayFrame().Resize(320, 240, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            MCvAvgComp[][] detectedFaces = _grayFace.DetectHaarCascade(_haarCascadeFrontalFace, 1.2, 10, Emgu.CV.CvEnum.HAAR_DETECTION_TYPE.DO_CANNY_PRUNING, new Size(20, 20));
            foreach (MCvAvgComp f in detectedFaces[0])
            {
                _trainedFace = _frame.Copy(f.rect).Convert<Gray, byte>();
                break;
            }
            _trainedFace = _result.Resize(100, 100, Emgu.CV.CvEnum.INTER.CV_INTER_CUBIC);
            _trainingImages.Add(_trainedFace);

            if (textBox.Text != "")
            {
                _labels.Add(textBox.Text);
                File.WriteAllText(txtpath,
                    _trainingImages.ToArray().Length.ToString() + ",");
                for (int i = 1; i < _trainingImages.ToArray().Length + 1; i++)
                {
                    _trainingImages.ToArray()[i - 1].Save("../../Faces/face" + i + ".bmp");
                    File.AppendAllText(txtPath, _labels.ToArray()[i - 1] + ",");
                }
                MessageBox.Show("Added successfully");
            }
        }
    }
}
