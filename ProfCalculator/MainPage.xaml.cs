using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ProfCalculator.Models;


namespace ProfCalculator
{

    public sealed partial class MainPage : Page
    {
        private SidebarViewModel sidebarViewModel;
        public MainPage()
        {
            this.InitializeComponent();
            sidebarViewModel = new SidebarViewModel();
            _uiViewModel = new UiViewModel();

        }




        public UiViewModel _uiViewModel
        {
            get { return (UiViewModel)GetValue(_uiViewModelProperty); }
            set { SetValue(_uiViewModelProperty, value); }
        }

        
        public static readonly DependencyProperty _uiViewModelProperty =
            DependencyProperty.Register("_uiViewModel", typeof(UiViewModel), typeof(MainPage), new PropertyMetadata(0));



        private void Menu_Click(object sender, RoutedEventArgs e)
        {
            ToggleSidebar();
        }

        private void ToggleSidebar()
        {
            SidebarTransform.TranslateX = SidebarTransform.TranslateX == -400 ? 0 : -400;
        }

        private void SidebarList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item =  SidebarList.SelectedItem as TextBlock;
            sidebarViewModel.ActiveMode = item.Text;

            ToggleSidebar();
        }

        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            _uiViewModel.HeightCheing(e.NewSize.Height);
            _uiViewModel.WidthCheing(e.NewSize.Width);
        }
    }
}
