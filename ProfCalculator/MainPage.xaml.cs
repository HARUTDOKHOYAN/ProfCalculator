using ProfCalculator.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ProfCalculator
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            sidebarViewModel = new SidebarViewModel();
            _uiViewModel = new StandardViewModel();
        }




        private SidebarViewModel sidebarViewModel;
        public UiViewModel _uiViewModel
        {
            get { return (StandardViewModel)GetValue(_uiViewModelProperty); }
            set { SetValue(_uiViewModelProperty, value); }
        }

        
        public static readonly DependencyProperty _uiViewModelProperty =
            DependencyProperty.Register("_uiViewModel", typeof(StandardViewModel), typeof(MainPage), new PropertyMetadata(0));



        
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
    }
}
