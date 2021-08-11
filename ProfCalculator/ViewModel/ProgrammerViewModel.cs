using ProfCalculator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace ProfCalculator.ViewModel
{
    public class ProgrammerViewModel : INotifyPropertyChanged
    {
        public ProgrammerViewModel()
        {
            var blue = "#b4d8fa";
            var gray = "#d5e7f7";
            UIButtons = new ObservableCollection<UIButton>()
            {
                new UIButton { Content = "A", Color = gray},
                new UIButton { Content = "<<", Color = blue},
                new UIButton { Content = ">>", Color = blue},
                new UIButton { Content = "C.", Color = blue},
                new UIButton { Content = "<", Color = blue},
                new UIButton { Content = "B", Color = gray},
                new UIButton { Content = "(", Color = blue},
                new UIButton { Content = ")", Color = blue},
                new UIButton { Content = "%", Color = blue},
                new UIButton { Content = "/", Color = blue},
                new UIButton { Content = "C", Color = gray},
                new UIButton { Content = "7", Color = gray},
                new UIButton { Content = "8", Color = gray},
                new UIButton { Content = "9", Color = gray},
                new UIButton { Content = "X", Color = blue},
                new UIButton { Content = "D", Color = gray},
                new UIButton { Content = "4", Color = gray},
                new UIButton { Content = "5", Color = gray},
                new UIButton { Content = "6", Color = gray},
                new UIButton { Content = "-", Color = blue},
                new UIButton { Content = "E", Color = gray},
                new UIButton { Content = "1", Color = gray},
                new UIButton { Content = "2", Color = gray},
                new UIButton { Content = "3", Color = gray},
                new UIButton { Content = "+", Color = blue},
                new UIButton { Content = "F", Color = gray},
                new UIButton { Content = "+/-", Color = gray},
                new UIButton { Content = "0", Color = gray},
                new UIButton { Content = ".", Color = gray},
                new UIButton { Content = "=", Color = blue},
            };
            _displayInfo = new DisplayInfo() { CalculatorModе = "HEX", Display = "FFDD", BitName = "WORD", BitStatus = 16 };
            BitCount = 0;
        }

        private DisplayInfo _displayInfo;
        public DisplayInfo displayInfo
        {
            get
            {
                return _displayInfo;

            }

            set
            {
                _displayInfo = value;

            }
        }
        public ObservableCollection<UIButton> UIButtons { get; set; }
        public int BitCount;



        public void Input(string content)
        {
            switch (displayInfo.CalculatorModе)
            {
                case "HEX":
                    HexCalc(content);
                    break;
                case "DEC":
                    DecCalc(content);
                    break;
                case "OCT":
                    OctCalc(content);
                    break;
                case "BIN":
                    BinCalc(content);
                    break;
            }


        }

        private void HexCalc(string content)
        {

        }

        private void DecCalc(string Content)
        {

        }

        private void OctCalc(string Content)
        {

        }

        private void BinCalc(string Content)
        {

        }



        public void WidthChange(double width)
        {
            foreach (var item in UIButtons)
                item.Width = width / 5.2;
        }

        public void HeightChange(double height)
        {
            foreach (var item in UIButtons)
                item.Height = height / 6;
        }

        public void BitChanged()
        {
            List<string> BitName = new List<string> { "WORD", "BYTE", "QWORD", "DWORD" };
            List<int> BitStatus = new List<int> { 16, 8, 64, 32 };
            if (BitCount <= 3)
            {
                displayInfo.BitName = BitName[BitCount];
                displayInfo.BitStatus = BitStatus[BitCount];
            }
            else
            {
                BitCount = 0;
                displayInfo.BitName = BitName[BitCount];
                displayInfo.BitStatus = BitStatus[BitCount];
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void INotifyPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
