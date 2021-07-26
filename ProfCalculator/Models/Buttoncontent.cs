using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.Models
{
    public class Buttoncontent: INotifyPropertyChanged
    {
        private string _content;
        public string Content
        {
            get
            {
                return _content;
            }
            set
            {
                _content = value;
                OnPropertyChanged("Content");
            }
        }
        private double _height;
        public double Height { get 
            {
                return _height;
            } set 
            {
                _height = value;
                OnPropertyChanged("Height");
            } 
        }
        public double _width;
        public double Width { get 
            {
                return _width;
            }
            set
            {
                _width = value;
                OnPropertyChanged("Width");
            }
                }
        public string _color;
        public string Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                OnPropertyChanged("Color");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
