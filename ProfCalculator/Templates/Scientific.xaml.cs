using ProfCalculator.Models;
using ProfCalculator.ViewModel;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ProfCalculator.Services;


namespace ProfCalculator.Templates
{
    public sealed partial class Scientific : UserControl, INotifyPropertyChanged
    {
        public Scientific()
        {
            this.InitializeComponent();
            scientificViewModel = new ScientificViewModel();
            historyCalculatorViewModel = new HistoryCalculatorViewModel();
            _scientificCalc = new ScientificCalc();

        }
        private ScientificCalc _scientificCalc;

        public static readonly DependencyProperty _historyCalculatorVMProperty =
            DependencyProperty.Register(nameof(historyCalculatorViewModel), typeof(HistoryCalculatorViewModel), typeof(Standard), new PropertyMetadata(null));
        public HistoryCalculatorViewModel historyCalculatorViewModel
        {
            get { return (HistoryCalculatorViewModel)GetValue(_historyCalculatorVMProperty); }
            set { SetValue(_historyCalculatorVMProperty, value); }
        }

        public static readonly DependencyProperty uiViewModelProperty =
            DependencyProperty.Register(nameof(scientificViewModel), typeof(ScientificViewModel), typeof(Standard), new PropertyMetadata(null));
        public ScientificViewModel scientificViewModel
        {
            get { return (ScientificViewModel)GetValue(uiViewModelProperty); }
            set { SetValue(uiViewModelProperty, value); }
        }

        private void Root_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var h = e.NewSize.Height - op.Height - nu.Height - MemoryCalc.Height;
            var w = e.NewSize.Width - ListHistoryAndMemory.Width;
            scientificViewModel.WidthChange(e.NewSize.Width);
            scientificViewModel.HeightChange(h);
            if (e.NewSize.Width >= 600)
            {
                scientificViewModel.WidthChange(w);
                scientificViewModel.Visibility = true;
            }
            else
                scientificViewModel.Visibility = false;
        }

        private void ButtonsList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var button = e.ClickedItem as UIButton;
            _scientificCalc.Input(button.Content);
            if (button.Content == "=")
            {
                historyCalculatorViewModel.InputHistory(_scientificCalc.GetData());
                historyIsEmpty.Visibility = Visibility.Collapsed;
                HistoryClean.Visibility = Visibility.Visible;
            }
        }

        private void MemoryCalc_ItemClick(object sender, ItemClickEventArgs e)
        {
            var button = e.ClickedItem as UIButton;
            var memory = historyCalculatorViewModel.InputMemory(button.Content, _scientificCalc.X);
            if (memory != "")
                _scientificCalc.X = memory;
            memoryIsEmpty.Visibility = historyCalculatorViewModel.MemoryList.Count > 0 ? Visibility.Collapsed : Visibility.Visible;
        }

        private void MemoryDelete_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var data = button.DataContext as MemoryCell;
            historyCalculatorViewModel.RemoveMemory(data);
            memoryIsEmpty.Visibility = historyCalculatorViewModel.MemoryList.Count > 0 ? Visibility.Collapsed : Visibility.Visible;
        }

        private void ListHistory_ItemClick(object sender, ItemClickEventArgs e)
        {
            var list = e.ClickedItem as HistoryCell;
            _scientificCalc.SetData(list.calcData);
        }

        private void ListMemory_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            var stackPanel = sender as StackPanel;
            stackPanel.Children[1].Visibility = Visibility.Visible;
        }

        private void ListMemory_PointerCanceled(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            var stackPanel = sender as StackPanel;
            stackPanel.Children[1].Visibility = Visibility.Collapsed;
        }

        private void HistoryClean_Click(object sender, RoutedEventArgs e)
        {
            historyCalculatorViewModel.CleanHistory();
            historyIsEmpty.Visibility = Visibility.Visible;
            HistoryClean.Visibility = Visibility.Collapsed;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
