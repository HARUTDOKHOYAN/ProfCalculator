using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ProfCalculator.Templates
{
    class CalculatorTemplateSelector: DataTemplateSelector
    {
        public DataTemplate Standard { get; set; }
        public DataTemplate Scientific { get; set; }
        public DataTemplate Programmer { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            switch ((container as ContentControl).Content)
            {
                case "Scientific":
                    return Scientific;
                case "Programmer":
                    return Programmer;
                default:
                    return Standard;
            }
        }
    }
}
