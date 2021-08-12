using ProfCalculator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace ProfCalculator.ViewModel
{
    public class ScientificViewModel : INotifyPropertyChanged
    {
        public ScientificViewModel()
        {
            var blue = "#b4d8fa";
            var gray = "#d5e7f7";

            UIButtons = new ObservableCollection<UIButton>()
            {
                new UIButton { Content = "", Color = blue},
                new UIButton { Content = "π", Color = blue},
                new UIButton { Content = "e",  Color = blue},
                new UIButton { Content = "C",  Color = blue},
                new UIButton { Content = "CE",  Color = blue},
                new UIButton { Content = "<", Color = blue},

                new UIButton { Content = "x^3", Color = blue},
                new UIButton { Content = "x^2", Color = blue},
                new UIButton { Content = "1/x", Color = blue},
                new UIButton { Content = "|x|", Color = blue},
                new UIButton { Content = "exp", Color = blue},
                new UIButton { Content = "mod", Color = blue},

                new UIButton { Content = "3√", Color = blue},
                new UIButton { Content = "√", Color = blue},
                new UIButton { Content = "(", Color = blue},
                new UIButton { Content = ")", Color = blue},
                new UIButton { Content = "n!", Color = blue},
                new UIButton { Content = "/", Color = blue},

                new UIButton { Content = "x√y", Color = blue},
                new UIButton { Content = "x^y", Color = blue},
                new UIButton { Content = "7", Color = gray},
                new UIButton { Content = "8", Color = gray},
                new UIButton { Content = "9", Color = gray},
                new UIButton { Content = "X", Color = blue},

                new UIButton { Content = "2^x", Color = blue},
                new UIButton { Content = "10^x", Color = blue},
                new UIButton { Content = "4", Color = gray},
                new UIButton { Content = "5", Color = gray},
                new UIButton { Content = "6", Color = gray},
                new UIButton { Content = "-", Color = blue},

                new UIButton { Content = "logyx", Color = blue},
                new UIButton { Content = "log", Color = blue},
                new UIButton { Content = "1", Color = gray},
                new UIButton { Content = "2", Color = gray},
                new UIButton { Content = "3", Color = gray},
                new UIButton { Content = "+", Color = blue},

                new UIButton { Content = "e^x", Color = blue},
                new UIButton { Content = "ln", Color = blue},
                new UIButton { Content = "+/-", Color = gray},
                new UIButton { Content = "0", Color = gray},
                new UIButton { Content = ".", Color = gray},
                new UIButton { Content = "=", Color = blue},

                //new UIButton { Content = "%", Color = blue},
                //new UIButton { Content = "CE", Color = blue},
                //new UIButton { Content = "1/x", Color = blue},
                //new UIButton { Content = "√", Color = blue},
                //new UIButton { Content = "x^2", Color = blue},
                //new UIButton { Content = "/", Color = blue},
                //new UIButton { Content = "7", Color = gray},
                //new UIButton { Content = "8", Color = gray},
                //new UIButton { Content = "9", Color = gray},
                //new UIButton { Content = "X", Color = blue},
                //new UIButton { Content = "4", Color = gray},
                //new UIButton { Content = "5", Color = gray},
                //new UIButton { Content = "6", Color = gray},
                //new UIButton { Content = "-", Color = blue},
                //new UIButton { Content = "1", Color = gray},
                //new UIButton { Content = "2", Color = gray},
                //new UIButton { Content = "3", Color = gray},
                //new UIButton { Content = "+", Color = blue},
                //new UIButton { Content = "+/-", Color = gray},
                //new UIButton { Content = "0", Color = gray},
                //new UIButton { Content = ".", Color = gray},
                //new UIButton { Content = "=", Color = blue},
            };

            Visibility = false;
        }

        private bool visibility;
        public bool Visibility
        {
            get => visibility;
            set { visibility = value; OnPropertyChanged(); }
        }

        public ObservableCollection<UIButton> UIButtons { get; set; }

        public void WidthChange(double width)
        {
            foreach (var item in UIButtons)
                item.Width = width / 6.2;
        }

        public void HeightChange(double height)
        {
            foreach (var item in UIButtons)
                item.Height = height / 7;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
