using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ProfCalculator.Templates.DateTemplates
{
    class DateTemplateSelector : DataTemplateSelector
    {
        public DataTemplate Difference { get; set; }
        public DataTemplate AddSubtract { get; set; }

        protected override DataTemplate SelectTemplateCore(object item, DependencyObject container)
        {
            switch ((container as ContentControl).Content)
            {
                case "Difference between dates":
                    return Difference;
                default:
                    return AddSubtract;
            }
        }
    }
}
