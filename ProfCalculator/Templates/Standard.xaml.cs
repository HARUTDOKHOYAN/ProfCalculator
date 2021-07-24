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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ProfCalculator.Templates
{
    public sealed partial class Standard : UserControl
    {
        public Standard()
        {
            this.InitializeComponent();
            uiViewModel = new UiViewModel();
        }


        public UiViewModel uiViewModel
        {
            get { return (UiViewModel)GetValue(uiViewModelProperty); }
            set { SetValue(uiViewModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for uiViewModel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty uiViewModelProperty =
            DependencyProperty.Register("uiViewModel", typeof(UiViewModel), typeof(Standard), new PropertyMetadata(null));

        private void Root_SizeChanged(object sender, SizeChangedEventArgs e)
        {

        }
    }
}
