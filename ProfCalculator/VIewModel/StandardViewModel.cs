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

namespace ProfCalculator
{
    public class StandardViewModel : INotifyPropertyChanged
    {
        public StandardViewModel()
        {
            buttoncontents = new ObservableCollection<Buttoncontent>()
            {
                new Buttoncontent { Content = "%", Width = 100 ,Height = 30 , Color = "#b4d8fa",},
                new Buttoncontent { Content = "CE",Width = 100 ,Height = 30 , Color = "#b4d8fa"},
                new Buttoncontent { Content = "C"  ,Width = 100 ,Height = 30 ,Color = "#b4d8fa"},
                new Buttoncontent { Content = "<" ,Width = 100 ,Height = 30 ,Color = "#b4d8fa" },
                new Buttoncontent { Content = "1/x" ,Width = 100,Height = 30 ,Color = "#b4d8fa"},
                new Buttoncontent { Content = "√",Width = 100 ,Height = 30 ,Color = "#b4d8fa"},
                new Buttoncontent { Content = "x^2",Width = 100 ,Height = 30 ,Color = "#b4d8fa"},
                new Buttoncontent { Content = "/",  Width = 100 ,Height = 30 ,Color = "#b4d8fa"},
                new Buttoncontent { Content = "7",  Width = 100 ,Height = 30 ,Color = "#d5e7f7"},
                new Buttoncontent { Content = "8",  Width = 100 ,Height = 30 ,Color = "#d5e7f7"},
                new Buttoncontent { Content = "9",  Width = 100 ,Height = 30,Color = "#d5e7f7"},
                new Buttoncontent { Content = "X",  Width = 100 ,Height = 30,Color = "#b4d8fa"},
                new Buttoncontent { Content = "4",  Width = 100 ,Height = 30,Color = "#d5e7f7"},
                new Buttoncontent { Content = "5",  Width = 100 ,Height = 30,Color = "#d5e7f7"},
                new Buttoncontent { Content = "6",  Width = 100 ,Height = 30,Color = "#d5e7f7"},
                new Buttoncontent { Content = "-",  Width = 100 ,Height = 30,Color = "#b4d8fa"},
                new Buttoncontent { Content = "1",  Width = 100 ,Height = 30,Color = "#d5e7f7"},
                new Buttoncontent { Content = "2",  Width = 100 ,Height = 30,Color = "#d5e7f7"},
                new Buttoncontent { Content = "3",  Width = 100 ,Height = 30,Color = "#d5e7f7"},
                new Buttoncontent { Content = "+",  Width = 100 ,Height = 30,Color = "#b4d8fa"},
                new Buttoncontent { Content = "+/-", Width = 100 ,Height = 30,Color = "#d5e7f7"},
                new Buttoncontent { Content = "0",  Width = 100 ,Height = 30,Color = "#d5e7f7"},
                new Buttoncontent { Content = ".",  Width = 100 ,Height = 30,Color = "#d5e7f7"},
                new Buttoncontent { Content = "=",  Width = 100 ,Height = 30,Color = "#b4d8fa"},
        };

            VISIBLITY = false;
    }
        private bool visiblity;
        public bool VISIBLITY 
        { 
            get 
            { 
                return visiblity; 
            } 
            set 
            {
                visiblity = value;
                OnPropertyChanged("VISIBLITY");
            } 
        }
        public ObservableCollection<Buttoncontent> buttoncontents { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }


        public void WidthCheing(double width)
        {

            foreach (var item in buttoncontents)
            {

                item.Width = width /4.2;


            }
        }

        internal void HeightCheing(double height)
        {
            foreach (var item in buttoncontents)
            {
                //height = height - 119.7;
                item.Height = (height/6);
            }
        }                   

        
    }
}
