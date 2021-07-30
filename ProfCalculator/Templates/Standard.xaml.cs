using ProfCalculator.Models;
using ProfCalculator.VIewModel;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ProfCalculator.Services;


namespace ProfCalculator.Templates
{
    public sealed partial class Standard : UserControl, INotifyPropertyChanged
    {
        public Standard()
        {
            this.InitializeComponent();
            uiViewModel = new StandardViewModel();
            _historyCalculatorVM = new HistoryCalculatorVM();
            _standardCalc = new StandardCalc();

        }
        private StandardCalc _standardCalc;

        public HistoryCalculatorVM _historyCalculatorVM
        {
            get { return (HistoryCalculatorVM)GetValue(_historyCalculatorVMProperty); }
            set { SetValue(_historyCalculatorVMProperty, value); }
        }
        public static readonly DependencyProperty _historyCalculatorVMProperty =
            DependencyProperty.Register("_historyCalculatorVM", typeof(HistoryCalculatorVM), typeof(Standard), new PropertyMetadata(null));

        public StandardViewModel uiViewModel
        {
            get { return (StandardViewModel)GetValue(uiViewModelProperty); }
            set { SetValue(uiViewModelProperty, value); }
        }
        public static readonly DependencyProperty uiViewModelProperty =
            DependencyProperty.Register("uiViewModel", typeof(StandardViewModel), typeof(Standard), new PropertyMetadata(null));

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void Root_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            var v = (ListHistoryAndMemory.SelectedItem as PivotItem).Name;
            var h = e.NewSize.Height - op.Height - nu.Height - HistoryCalc.Height ;
            var w = e.NewSize.Width - ListHistoryAndMemory.Width;
            uiViewModel.WidthCheing(e.NewSize.Width);
            uiViewModel.HeightCheing(h);
            if (e.NewSize.Width >= 600)
            {
               uiViewModel.WidthCheing(w);
                uiViewModel.VISIBLITY = true;
                if (v == "History")
                    HisteryClean.Visibility = Visibility.Visible;
            }
            else
            {
                HisteryClean.Visibility = Visibility.Collapsed;
                uiViewModel.VISIBLITY = false;
            }

        }

        private void ListviewRoot_ItemClick(object sender, ItemClickEventArgs e)
        {
            var buttonName = e.ClickedItem as Buttoncontent;
            _standardCalc.Input(buttonName.Content);
            _historyCalculatorVM.Histerycheng(buttonName.Content, _standardCalc);
        }

        private void HistoryCalc_ItemClick(object sender, ItemClickEventArgs e)
        {
            var buttonName = e.ClickedItem as HistoryCalculator;
            _historyCalculatorVM.InputMemory(buttonName.Content, _standardCalc);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var bat = sender as Button;
            var data = bat.DataContext as HistoryCalculator;
            _historyCalculatorVM.DeletList(data);
        }

        private void ListHistory_ItemClick(object sender, ItemClickEventArgs e)
        {
            var list = e.ClickedItem as HistoryCalculator;
            if(_historyCalculatorVM.HistoryList[0].X != "HistoryList empty")
            {
            _standardCalc.X = list.X;
            _standardCalc.Info = list.Info;
            }
        }

        private void ListHistoryAndMemory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var h = (ListHistoryAndMemory.SelectedItem as PivotItem).Name;
            if (h == "Memory")
                HisteryClean.Visibility = Visibility.Collapsed;
            if (h == "History")
                HisteryClean.Visibility = Visibility.Visible;
        }

        private void ListMemory_PointerEntered(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            var stec = sender as StackPanel;
            if (_historyCalculatorVM.MemoryList[0].MemoryList != "MemoryList empty")
                stec.Children[1].Visibility = Visibility.Visible;
        }

        private void HisteryClean_Click(object sender, RoutedEventArgs e)
        {
            _historyCalculatorVM.HistoryList.Clear();
            _historyCalculatorVM.HistoryList.Add(new HistoryCalculator { X = "HistoryList empty", Info = "" });
        }

        private void ListMemory_PointerCanceled(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            var stec = sender as StackPanel;
            if(_historyCalculatorVM.HistoryList[0].MemoryList != "MemoryList empty")
                stec.Children[1].Visibility = Visibility.Collapsed;
        }
    }                                                                 
}                                                                     
