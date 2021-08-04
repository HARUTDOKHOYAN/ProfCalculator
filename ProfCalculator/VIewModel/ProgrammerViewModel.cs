using ProfCalculator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.ViewModel
{
    public class ProgrammerViewModel
    {
        public ProgrammerViewModel()
        {
            var blue = "#b4d8fa";
            var gray = "#d5e7f7";

            UIButtons = new ObservableCollection<UIButton>()
            {
                new UIButton { Content = "A", Color = blue},
                new UIButton { Content = "<<", Color = blue},
                new UIButton { Content = ">>", Color = blue},
                new UIButton { Content = "C", Color = blue},
                new UIButton { Content = "<", Color = blue},
                new UIButton { Content = "B", Color = blue},
                new UIButton { Content = "(", Color = blue},
                new UIButton { Content = ")", Color = blue},
                new UIButton { Content = "%", Color = blue},
                new UIButton { Content = "/", Color = blue},
                new UIButton { Content = "C", Color = blue},
                new UIButton { Content = "7", Color = blue},
                new UIButton { Content = "8", Color = blue},
                new UIButton { Content = "9", Color = blue},
                new UIButton { Content = "X", Color = blue},
                new UIButton { Content = "D", Color = blue},
                new UIButton { Content = "4", Color = blue},
                new UIButton { Content = "5", Color = blue},
                new UIButton { Content = "6", Color = blue},
                new UIButton { Content = "-", Color = blue},
                new UIButton { Content = "E", Color = blue},
                new UIButton { Content = "1", Color = blue},
                new UIButton { Content = "2", Color = blue},
                new UIButton { Content = "3", Color = blue},
                new UIButton { Content = "+", Color = blue},
                new UIButton { Content = "F", Color = blue},
                new UIButton { Content = "+/-", Color = blue},
                new UIButton { Content = "0", Color = blue},
                new UIButton { Content = ".", Color = blue},
                new UIButton { Content = "=", Color = blue},

            };
        }

        public ObservableCollection<UIButton> UIButtons { get; set; }

        public void WidthChange(double width)
        {
            foreach (var item in UIButtons)
                item.Width = width / 4.2;
        }

        public void HeightChange(double height)
        {
            foreach (var item in UIButtons)
                item.Height = height / 6;
        }
    }
}
