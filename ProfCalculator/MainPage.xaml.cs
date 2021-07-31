using ProfCalculator.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using ProfCalculator.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ProfCalculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            sidebarViewModel = new SidebarViewModel();
            _uiViewModel = new StandardViewModel();
        }




        private SidebarViewModel sidebarViewModel;
        public StandardViewModel _uiViewModel
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
