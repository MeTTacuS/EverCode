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

        private int _id;
        private string _firstname;
        private string _surname;
        private int _age;

        ImageBox _imageBox;
        Label _nameLabel;
        Label _ageLabel;

        public Label AgeLabel { get => _ageLabel; set => _ageLabel = value; }
        public Label NameLabel { get => _nameLabel; set => _nameLabel = value; }
        public ImageBox ImageBox { get => _imageBox; set => _imageBox = value; }


        public void DisplayImage(List<string> _labels, string _name, List<Image<Gray, byte>> _trainingImages)
        {
            int i = 0;
            foreach (string s in _labels)
            {
                if (s == _name)
                    break;
                i++;
            }
            NameLabel.Text = _name;
            _imageBox.Image = _trainingImages[i];
            if (_ageLabel != null)
                _ageLabel.Text = _age.ToString();
        }

    }
}
