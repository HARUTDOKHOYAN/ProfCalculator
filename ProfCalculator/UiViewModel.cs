using ProfCalculator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator
{
    public class UiViewModel
    {
        public UiViewModel()
        {
            buttoncontents = new ObservableCollection<Buttoncontent>()
            {
                new Buttoncontent { Content = "%", Height = 0, Width = 0 },
                new Buttoncontent { Content = "CE", Height = 0, Width = 0 },
                new Buttoncontent { Content = "C", Height = 0, Width = 0 },
                new Buttoncontent { Content = "<--", Height = 0, Width = 0 },
                new Buttoncontent { Content = "1/x", Height = 0, Width = 0 },
                new Buttoncontent { Content = "x^2", Height = 0, Width = 0 },
                new Buttoncontent { Content = "x^(1/2)", Height = 0, Width = 0 },
                new Buttoncontent { Content = "/", Height = 0, Width = 0 },
                new Buttoncontent { Content = "7", Height = 0, Width = 0 },
                new Buttoncontent { Content = "8", Height = 0, Width = 0 },
                new Buttoncontent { Content = "9", Height = 0, Width = 0 },
                new Buttoncontent { Content = "X", Height = 0, Width = 0 },
                new Buttoncontent { Content = "4", Height = 0, Width = 0 },
                new Buttoncontent { Content = "5", Height = 0, Width = 0 },
                new Buttoncontent { Content = "6", Height = 0, Width = 0 },
                new Buttoncontent { Content = "-", Height = 0, Width = 0 },
                new Buttoncontent { Content = "1", Height = 0, Width = 0 },
                new Buttoncontent { Content = "2", Height = 0, Width = 0 },
                new Buttoncontent { Content = "3", Height = 0, Width = 0 },
                new Buttoncontent { Content = "+", Height = 0, Width = 0 },
                new Buttoncontent { Content = "+/-", Height = 0, Width = 0 },
                new Buttoncontent { Content = "0", Height = 0, Width = 0 },
                new Buttoncontent { Content = ",", Height = 0, Width = 0 },
                new Buttoncontent { Content = "=", Height = 0, Width = 0 },
        };

        }

    public ObservableCollection<Buttoncontent> buttoncontents { get; set; }

    }
}
