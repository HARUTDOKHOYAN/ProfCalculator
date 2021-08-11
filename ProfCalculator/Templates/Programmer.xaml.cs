using ProfCalculator.Models;
using ProfCalculator.ViewModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ProfCalculator.Templates
{
    public sealed partial class Programmer : UserControl, INotifyPropertyChanged
    {
        public Programmer()
        {
            this.InitializeComponent();
            programmerViewModel = new ProgrammerViewModel();
        }


        private void Root_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            programmerViewModel.WidthChange(e.NewSize.Width);
            programmerViewModel.HeightChange(e.NewSize.Height);

        }


        private void ProgramerButtons_ItemClick(object sender, ItemClickEventArgs e)
        {
            var button = e.ClickedItem as UIButton;
            programmerViewModel.displayInfo.Display = programmerViewModel.displayInfo.Display + button.Content;
            programmerViewModel.INotifyPropertyChanged("displayInfo");
            programmerViewModel.Input(button.Content);
            
        }

        private void BIN_Click(object sender, RoutedEventArgs e)
        {
            var but = sender as Button;
            programmerViewModel.displayInfo.Display = BinNum.Text;
            programmerViewModel.displayInfo.CalculatorModе = but.Name;
            programmerViewModel.INotifyPropertyChanged("displayInfo");
        }

        private void OCT_Click(object sender, RoutedEventArgs e)
        {
            var but = sender as Button;
             programmerViewModel.displayInfo.CalculatorModе = but.Name;
            programmerViewModel.displayInfo.Display = OctNum.Text;
            programmerViewModel.INotifyPropertyChanged("displayInfo");
        }

        private void Dec_Click(object sender, RoutedEventArgs e)
        {
            var but = sender as Button;
            programmerViewModel.displayInfo.CalculatorModе= but.Name;
            programmerViewModel.displayInfo.Display = DecNum.Text;
            programmerViewModel.INotifyPropertyChanged("displayInfo");
        }

        private void Hex_Click(object sender, RoutedEventArgs e)
        {
            var but = sender as Button;
            programmerViewModel.displayInfo.CalculatorModе = but.Name;
            programmerViewModel.displayInfo.Display = HexNum.Text;
            programmerViewModel.INotifyPropertyChanged("displayInfo");
        }
        private void Bit_Click(object sender, RoutedEventArgs e)
        {
            programmerViewModel.BitCount++;
            programmerViewModel.BitChanged();
            programmerViewModel.INotifyPropertyChanged("displayInfo");
        }



        //HistoryCalculatorViewModel object
        public HistoryCalculatorViewModel _historyCalculatorViewModel
        {
            get { return (HistoryCalculatorViewModel)GetValue(_historyCalculatorViewModelProperty); }
            set { SetValue(_historyCalculatorViewModelProperty, value); }
        }
        public static readonly DependencyProperty _historyCalculatorViewModelProperty =
            DependencyProperty.Register("_historyCalculatorViewModel", typeof(HistoryCalculatorViewModel), typeof(Programmer), new PropertyMetadata(0));
        
        //ProgrammerViewModel object
        public ProgrammerViewModel programmerViewModel
        {
            get { return (ProgrammerViewModel)GetValue(programmerViewModelProperty); }
            set { SetValue(programmerViewModelProperty, value); }
        }
        public static readonly DependencyProperty programmerViewModelProperty =
            DependencyProperty.Register(nameof(programmerViewModel), typeof(ProgrammerViewModel), typeof(Programmer), new PropertyMetadata(null));


        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void MemoryDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
    }
}
