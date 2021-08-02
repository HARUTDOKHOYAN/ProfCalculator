using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ProfCalculator.Models;

namespace ProfCalculator.ViewModel
{
    class ScientificViewModel: INotifyPropertyChanged
    {
        public ScientificViewModel()
        {
            buttoncontents = new ObservableCollection<UIButton>()
            {
                new UIButton { Content = "%", Width = 100 ,Height = 30 , Color = "#b4d8fa",},
                new UIButton { Content = "CE",Width = 100 ,Height = 30 , Color = "#b4d8fa"},
                new UIButton { Content = "C"  ,Width = 100 ,Height = 30 ,Color = "#b4d8fa"},
                new UIButton { Content = "<" ,Width = 100 ,Height = 30 ,Color = "#b4d8fa" },
                new UIButton { Content = "1/x" ,Width = 100,Height = 30 ,Color = "#b4d8fa"},
                new UIButton { Content = "√",Width = 100 ,Height = 30 ,Color = "#b4d8fa"},
                new UIButton { Content = "x^2",Width = 100 ,Height = 30 ,Color = "#b4d8fa"},
                new UIButton { Content = "/",  Width = 100 ,Height = 30 ,Color = "#b4d8fa"},
                new UIButton { Content = "7",  Width = 100 ,Height = 30 ,Color = "#d5e7f7"},
                new UIButton { Content = "8",  Width = 100 ,Height = 30 ,Color = "#d5e7f7"},
                new UIButton { Content = "9",  Width = 100 ,Height = 30,Color = "#d5e7f7"},
                new UIButton { Content = "X",  Width = 100 ,Height = 30,Color = "#b4d8fa"},
                new UIButton { Content = "4",  Width = 100 ,Height = 30,Color = "#d5e7f7"},
                new UIButton { Content = "5",  Width = 100 ,Height = 30,Color = "#d5e7f7"},
                new UIButton { Content = "6",  Width = 100 ,Height = 30,Color = "#d5e7f7"},
                new UIButton { Content = "-",  Width = 100 ,Height = 30,Color = "#b4d8fa"},
                new UIButton { Content = "1",  Width = 100 ,Height = 30,Color = "#d5e7f7"},
                new UIButton { Content = "2",  Width = 100 ,Height = 30,Color = "#d5e7f7"},
                new UIButton { Content = "3",  Width = 100 ,Height = 30,Color = "#d5e7f7"},
                new UIButton { Content = "+",  Width = 100 ,Height = 30,Color = "#b4d8fa"},
                new UIButton { Content = "+/-", Width = 100 ,Height = 30,Color = "#d5e7f7"},
                new UIButton { Content = "0",  Width = 100 ,Height = 30,Color = "#d5e7f7"},
                new UIButton { Content = ".",  Width = 100 ,Height = 30,Color = "#d5e7f7"},
                new UIButton { Content = "=",  Width = 100 ,Height = 30,Color = "#b4d8fa"},
            };
        }

        public ObservableCollection<UIButton> buttoncontents { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
