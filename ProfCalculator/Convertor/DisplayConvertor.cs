using ProfCalculator.Models;
using ProfCalculator.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace ProfCalculator.Convertor
{
    class DisplayConvertor: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            DisplayInfo content = value as DisplayInfo;
            string _parameter = parameter as string;
            if (content.Display == "0") return "0";
            switch (_parameter)
            {
                case "HEX":
                    return HexConvert(content.Display , content.CalculatorModе , content.BitStatus);
                case "DEC":
                    return DecConvert(content.Display, content.CalculatorModе, content.BitStatus);
                case "OCT":
                    return OctConvert(content.Display, content.CalculatorModе, content.BitStatus);
                case "BIN":
                    return BinConvert(content.Display, content.CalculatorModе, content.BitStatus);
                default:
                    return "Convert Error";
            }
        }

        public string HexConvert(string cont, string x , int bit)
        {
            switch (x)
            {
                case "DEC":
                    return ConvertorRepresentation.DecToHex(cont, bit);
                case "OCT":
                    return ConvertorRepresentation.OctToHex(cont, bit);
                case "BIN":
                    return ConvertorRepresentation.BinToHex(cont, bit);
                default:
                    cont = ConvertorRepresentation.HexToBin(cont, bit);
                    return ConvertorRepresentation.BinToHex(cont , bit);
            }
        }

        public string DecConvert(string cont, string x, int bit)
        {
            switch (x)
            {
                case "HEX":
                    return ConvertorRepresentation.HexToDec(cont,bit);
                case "OCT":
                    return ConvertorRepresentation.OctToDec(cont,bit);
                case "BIN":
                    return ConvertorRepresentation.BinToDec(cont, bit);
                default:
                    cont = ConvertorRepresentation.DecToBin(cont, bit);
                    return ConvertorRepresentation.BinToDec(cont, bit);
            }
        }

        public string OctConvert(string cont, string x, int bit)
        {
            switch (x)
            {
                case "DEC":
                    return ConvertorRepresentation.DecToOct(cont,bit);
                case "HEX":
                    return ConvertorRepresentation.HexToOct(cont,bit);
                case "BIN":
                    return ConvertorRepresentation.BinToOct(cont, bit);
                default:
                    cont = ConvertorRepresentation.OctToBin(cont, bit);
                    return ConvertorRepresentation.BinToOct(cont, bit);
            }
        }

        public string BinConvert(string cont, string x, int bit)
        {
            switch (x)
            {
                case "DEC":
                    return ConvertorRepresentation.DecToBin(cont, bit);
                case "OCT":
                    return ConvertorRepresentation.OctToBin(cont, bit);
                case "HEX":
                    return ConvertorRepresentation.HexToBin(cont, bit);
                default:
                    cont = ConvertorRepresentation.BinToDec(cont, bit);
                    return ConvertorRepresentation.DecToBin(cont, bit);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
