using Emgu.CV.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.UI;
using System.Windows.Forms;

namespace What_s_That
{
    class Display
    {

        ImageBox _imageBox;
        Label _nameLabel;
        Label _ageLabel;

        public Label AgeLabel { get => _ageLabel; set => _ageLabel = value; }
        public Label NameLabel { get => _nameLabel; set => _nameLabel = value; }
        public ImageBox ImageBox { get => _imageBox; set => _imageBox = value; }


        public void DisplayUser(List<string> labels, string name, List<Image<Gray, byte>> trainingImages)
        {
            int i = 0;

            foreach (string s in labels)
            {
                if (s == name)
                    break;
                i++;
            }
            NameLabel.Text = name;
            _imageBox.Image = trainingImages[i];
            if (_ageLabel != null)
                _ageLabel.Text = "0";
        }

    }
}
