using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Emgu.CV;
using Emgu.CV.Structure;
using System.Windows.Forms;

/*
 * A basic face detection and recognition class
 * Stores faces and their labels in Faces directory
 */

namespace What_s_That
{
    class Recognition
    {
        #region Variables
        HaarCascade _haarCascade; //Used for detecting faces
        Capture _camera;
        Image<Bgr, Byte> _frame;
        Image<Gray, byte> _result;
        Image<Gray, byte> _trainedFace = null;
        Image<Gray, byte> _grayFace = null;
        List<Image<Gray, byte>> _trainingImages = new List<Image<Gray, byte>>();
        List<string> _labels = new List<string>();
        List<string> _users = new List<string>();
        int _count, _numOfLabels, _t = 1;
        string _name, _names;
        MCvFont font = new MCvFont(Emgu.CV.CvEnum.FONT.CV_FONT_HERSHEY_TRIPLEX, 0.6d, 0.6d);
        #endregion

        public Recognition()
        {
            _t = 1;
            // We're using only the frontal-face recognition
            _haarCascade = new HaarCascade("../../DLL/haarcascade_frontalface_default.xml");
            try
            {
                string labelsPath = File.ReadAllText("../../Faces/Faces.txt");
                MessageBox.Show(labelsPath);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
