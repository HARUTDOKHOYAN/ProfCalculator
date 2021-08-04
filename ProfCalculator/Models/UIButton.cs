using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.Models
{
    public class UIButton: INotifyPropertyChanged
    {
        private string _content;
        public string Content
        {
            get => _content;
            set { _content = value; OnPropertyChanged(); }
        }

        private double _height = 30;
        public double Height
        {
            get => _height;
            set { _height = value; OnPropertyChanged(); }
        }
        public double _width = 100;
        public double Width
        {
            get => _width;
            set { _width = value; OnPropertyChanged(); }
        }
        private string _color;
        public string Color
        {
            get => _color;
            set { _color = value; OnPropertyChanged(); }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
