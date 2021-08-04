using ProfCalculator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.VIewModel
{
    public class ProgrammerVM
    {
        public ProgrammerVM()
        {
            buttonProgrammer = new ObservableCollection<Buttoncontent>()
            {
                new Buttoncontent { Content = "A", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "<<", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = ">>", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "C", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "<", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "B", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "(", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = ")", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "%", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "/", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "C", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "7", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "8", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "9", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "X", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "D", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "4", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "5", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "6", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "-", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "E", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "1", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "2", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "3", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "+", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "F", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "+/-", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "0", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = ".", Width = 100, Height = 30, Color = "#b4d8fa", },
                new Buttoncontent { Content = "=", Width = 100, Height = 30, Color = "#b4d8fa", },

            };
           
        }

        public void WidthCheing(double width)
        {

            foreach (var item in buttonProgrammer)
            {
                item.Width = width / 5.2;

            }
        }

        public void HeightCheing(double height)
        {
            foreach (var item in buttonProgrammer)
            {
                item.Height = (height / 6);
            }
        }

        public ObservableCollection<Buttoncontent> buttonProgrammer { get; set; }
    }
}
