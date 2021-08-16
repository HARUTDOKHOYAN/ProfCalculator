using ProfCalculator.Convertor;
using ProfCalculator.Models;
using ProfCalculator.System;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.ViewModel
{
    public class HistoryCalculatorViewModel : INotifyPropertyChanged
    {
        public HistoryCalculatorViewModel()
        {
            MemoryButtons = new ObservableCollection<UIButton>
            {
                new UIButton{Content="MC"},
                new UIButton{Content="MR"},
                new UIButton{Content="M+"},
                new UIButton{Content="M-"},
                new UIButton{Content="MS"}
            };

            HistoryList = new ObservableCollection<HistoryCell>();
            MemoryList = new ObservableCollection<MemoryCell>();
        }
        public ObservableCollection<UIButton> MemoryButtons { get; set; }
        public ObservableCollection<HistoryCell> HistoryList { get; set; }
        public ObservableCollection<MemoryCell> MemoryList { get; set; }

        private MemoryCell _selectedItem;
        public MemoryCell SelectedItem
        {
            get => _selectedItem;
            set { _selectedItem = value; OnPropertyChanged(); }
        }

        public string InputMemory(string content, string X, string calcmode = "DEC")
        {
            if (SelectedItem == null & content != "MS")
            {
                if (MemoryList.Count == 0)
                    MemoryList.Add(new MemoryCell());

                SelectedItem = MemoryList[0];
            }


            switch (content)
            {
                case "M+":
                    switch (calcmode)
                    {
                        case "HEX":
                            var hexcalc = new HexCalc();
                            SelectedItem.Number = hexcalc.Add(SelectedItem.Number, X);
                            break;
                        case "OCT":
                            var octcalc = new OctCalc();
                            SelectedItem.Number = octcalc.Add(SelectedItem.Number, X);
                            break;
                        case "BIN":
                            var bincalc = new BinCalc();
                            SelectedItem.Number = bincalc.Add(SelectedItem.Number, X);
                            break;
                        default:
                            SelectedItem.Number = (double.Parse(SelectedItem.Number) + double.Parse(X)).ToString();
                            break;
                    }
                    break;
                case "M-":
                    switch (calcmode)
                    {
                        case "HEX":
                            var hexcalc = new HexCalc();
                            SelectedItem.Number = hexcalc.Subtract(SelectedItem.Number, X);
                            break;
                        case "OCT":
                            var octcalc = new OctCalc();
                            SelectedItem.Number = octcalc.Subtract(SelectedItem.Number, X);
                            break;
                        case "BIN":
                            var bincalc = new BinCalc();
                            SelectedItem.Number = bincalc.Subtract(SelectedItem.Number, X);
                            break;
                        default:
                            SelectedItem.Number = (double.Parse(SelectedItem.Number) + double.Parse(X)).ToString();
                            break;
                    }
                    break;
                case "MS":
                    MemoryList.Add(new MemoryCell() { Number = X });
                    break;
                case "MC":
                    MemoryList.Clear();
                    break;
                case "MR":
                    return SelectedItem.Number;
            }

            return "";
        }

        public void ListConver(string calculatorModе, int bitStatus, string NumberMode)
        {


            switch (calculatorModе)
            {
                case "HEX":
                    HexConvert(bitStatus);
                    break;
                case "DEC":
                    DecConvert(bitStatus);
                    break;
                case "OCT":
                    OctConvert(bitStatus);
                    break;
                case "BIN":
                    BinConvert(bitStatus);
                    break;
                default:
                    break;

            }


            void HexConvert(int bit)
            {
                switch (NumberMode)
                {
                    case "DEC":
                        foreach (var item in MemoryList)
                        {
                            item.Number = ConvertorRepresentation.DecToHex(item.Number, bit);
                        }
                        break;
                    case "OCT":
                        foreach (var item in MemoryList)
                        {
                            item.Number = ConvertorRepresentation.OctToHex(item.Number, bit);
                        }
                        break;
                    case "BIN":
                        foreach (var item in MemoryList)
                        {
                            item.Number = ConvertorRepresentation.BinToHex(item.Number, bit);
                        }
                        break;
                    default:
                        foreach (var item in MemoryList)
                        {
                            var cont = ConvertorRepresentation.HexToBin(item.Number, bit);
                            item.Number = ConvertorRepresentation.BinToHex(cont, bit);
                        }
                        break;

                }
            }

            void DecConvert(int bit)
            {
                switch (NumberMode)
                {
                    case "HEX":
                        foreach (var item in MemoryList)
                        {
                            item.Number = ConvertorRepresentation.HexToDec(item.Number, bit);
                        }
                        break;
                    case "OCT":
                        foreach (var item in MemoryList)
                        {
                            item.Number = ConvertorRepresentation.OctToDec(item.Number, bit);
                        }
                        break;
                    case "BIN":
                        foreach (var item in MemoryList)
                        {
                            item.Number = ConvertorRepresentation.BinToDec(item.Number, bit);
                        }
                        break;
                    default:
                        foreach (var item in MemoryList)
                        {
                            var cont = ConvertorRepresentation.DecToBin(item.Number, bit);
                            item.Number = ConvertorRepresentation.BinToDec(cont, bit);
                        }
                        break;
                }
            }

            void OctConvert(int bit)
            {
                switch (NumberMode)
                {
                    case "DEC":
                        foreach (var item in MemoryList)
                        {
                            item.Number = ConvertorRepresentation.DecToOct(item.Number, bit);
                        }
                        break;
                    case "HEX":
                        foreach (var item in MemoryList)
                        {
                            item.Number = ConvertorRepresentation.HexToOct(item.Number, bit);
                        }
                        break;
                    case "BIN":
                        foreach (var item in MemoryList)
                        {
                            item.Number = ConvertorRepresentation.BinToOct(item.Number, bit);
                        }
                        break;
                    default:
                        foreach (var item in MemoryList)
                        {
                            var cont = ConvertorRepresentation.OctToBin(item.Number, bit);
                            item.Number = ConvertorRepresentation.BinToOct(cont, bit);
                        }
                        break;
                }
            }

                void BinConvert(int bit)
                {
                    switch (NumberMode)
                    {
                        case "DEC":
                            foreach (var item in MemoryList)
                            {
                                item.Number = ConvertorRepresentation.DecToBin(item.Number, bit);
                            }
                            break;
                        case "OCT":
                            foreach (var item in MemoryList)
                            {
                                item.Number = ConvertorRepresentation.OctToBin(item.Number, bit);
                            }
                            break;
                        case "HEX":
                            foreach (var item in MemoryList)
                            {
                                item.Number = ConvertorRepresentation.HexToBin(item.Number, bit);
                            }
                            break;
                        default:
                            foreach (var item in MemoryList)
                            {
                                var cont = ConvertorRepresentation.BinToDec(item.Number, bit);
                                item.Number = ConvertorRepresentation.DecToBin(cont, bit);
                            }
                            break;
                    }
                }


            }

            public void InputHistory(ICalcData data)
            {
                HistoryList.Add(new HistoryCell() { calcData = data });
            }

            public void CleanHistory()
            {
                HistoryList.Clear();
            }

            public void RemoveMemory(MemoryCell data)
            {
                if (MemoryList.Count > 0)
                    MemoryList.Remove(data);
            }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}