using ProfCalculator.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ProfCalculator.Models;
using ProfCalculator.ViewModel;


// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ProfCalculator.Templates
{
    public sealed partial class Scientific : UserControl
    {
        public Scientific()
        {
            this.InitializeComponent();
            uiViewModel = new ScientificViewModel();
            _scientificCalc = new ScientificCalc();
        }

        private ScientificViewModel uiViewModel;
        private ScientificCalc _scientificCalc;

        private void ListviewRoot_ItemClick(object sender, ItemClickEventArgs e)
        {
            var buttonName = e.ClickedItem as UIButton;
            _scientificCalc.Input(buttonName.Content);
        }
    }
}
