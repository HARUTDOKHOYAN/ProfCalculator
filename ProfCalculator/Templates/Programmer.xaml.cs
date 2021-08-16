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
            _historyCalculatorViewModel = new HistoryCalculatorViewModel();
        }


        private void Root_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            programmerViewModel.WidthChange(e.NewSize.Width);
            programmerViewModel.HeightChange(e.NewSize.Height);
        }

        private void MemoryCalc_ItemClick(object sender, ItemClickEventArgs e)
        {
            var button = e.ClickedItem as UIButton;
            var memory = _historyCalculatorViewModel.InputMemory(button.Content, programmerViewModel.displayInfo.Display);
            if (memory != "")
               programmerViewModel.displayInfo.Display = memory;
            memoryIsEmpty.Visibility = _historyCalculatorViewModel.MemoryList.Count > 0 ? Visibility.Collapsed : Visibility.Visible;
        }
        private void ProgramerButtons_ItemClick(object sender, ItemClickEventArgs e)
        {
            var button = e.ClickedItem as UIButton;
            programmerViewModel.INotifyPropertyChanged("displayInfo");
            programmerViewModel.Input(button.Content);
        }
        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.NewSize.Width >= 600)
            {
                programmerViewModel.Visibility = true;
            }
            else
                programmerViewModel.Visibility = false;
        }

        private void UpdateMode(string mode, string display)
        {
            var oldMode = programmerViewModel.displayInfo.CalculatorModе;
            programmerViewModel.displayInfo.CalculatorModе = mode;
            programmerViewModel.UpdateByMode(mode, oldMode);
            programmerViewModel.displayInfo.Display = display;
            programmerViewModel.INotifyPropertyChanged("displayInfo");
        }

        private void BIN_Click(object sender, RoutedEventArgs e)
        {
            var but = sender as Button;
            UpdateMode(but.Name, BinNum.Text);
        }

        private void OCT_Click(object sender, RoutedEventArgs e)
        {
            var but = sender as Button;
            UpdateMode(but.Name, OctNum.Text);
        }

        private void Dec_Click(object sender, RoutedEventArgs e)
        {
            var but = sender as Button;
            UpdateMode(but.Name, DecNum.Text);
        }

        private void Hex_Click(object sender, RoutedEventArgs e)
        {
            var but = sender as Button;
            UpdateMode(but.Name, HexNum.Text);
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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }


    }
}
