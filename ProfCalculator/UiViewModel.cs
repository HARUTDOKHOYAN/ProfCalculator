using ProfCalculator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI.ViewManagement;

namespace ProfCalculator
{
    public class UiViewModel
    {
        public UiViewModel()
        {
            buttoncontents = new ObservableCollection<Buttoncontent>()
            {
                new Buttoncontent { Content = "%", Width = 30 ,Height = 30 },
                new Buttoncontent { Content = "CE",Width = 100 ,Height = 30 },
                new Buttoncontent { Content = "C"  ,Width = 100 ,Height = 30 },
                new Buttoncontent { Content = "<--" ,Width = 100 ,Height = 30 },
                new Buttoncontent { Content = "1/x" ,Width = 100,Height = 30 },
                new Buttoncontent { Content = "x^2",Width = 100 ,Height = 30},
                new Buttoncontent { Content = "x^(1/2)",Width = 100 ,Height = 30},
                new Buttoncontent { Content = "/",  Width = 100 ,Height = 30},
                new Buttoncontent { Content = "7",  Width = 100 ,Height = 30},
                new Buttoncontent { Content = "8",  Width = 100 ,Height = 30},
                new Buttoncontent { Content = "9",  Width = 100 ,Height = 30},
                new Buttoncontent { Content = "X",  Width = 100 ,Height = 30},
                new Buttoncontent { Content = "4",  Width = 100 ,Height = 30},
                new Buttoncontent { Content = "5",  Width = 100 ,Height = 30},
                new Buttoncontent { Content = "6",  Width = 100 ,Height = 30},
                new Buttoncontent { Content = "-",  Width = 100 ,Height = 30},
                new Buttoncontent { Content = "1",  Width = 100 ,Height = 30},
                new Buttoncontent { Content = "2",  Width = 100 ,Height = 30},
                new Buttoncontent { Content = "3",  Width = 100 ,Height = 30},
                new Buttoncontent { Content = "+",  Width = 100 ,Height = 30},
                new Buttoncontent { Content = "+/-", Width = 100 ,Height = 30},
                new Buttoncontent { Content = "0",  Width = 100 ,Height = 30},
                new Buttoncontent { Content = ",",  Width = 100 ,Height = 30},
                new Buttoncontent { Content = "=",  Width = 100 ,Height = 30},
        };

    }

        internal void WidthCheing(double width)
        {

            foreach (var item in buttoncontents)
            {

                item.Width = width;


            }
        }

        internal void HeightCheing(double height)
        {
            foreach (var item in buttoncontents)
            {

                item.Height = height;
            }
        }                   

        public double Higet { get; set; }

        public ObservableCollection<Buttoncontent> buttoncontents { get; set; }
    }
}
