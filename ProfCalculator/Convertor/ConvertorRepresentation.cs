using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;

namespace ProfCalculator.Convertor
{
    class ConvertorRepresentation
    {
        public static string DecToBin(string decimal_number, int size=16)
        {
            long number = Int64.Parse(decimal_number);
            long[] arr = new long[size];
            int index = size - 1;
            string res = "";
            while (index >= 0)
            {
                arr[index] = number & 1;
                --index;
                number >>= 1;
            }
            foreach (var x in arr)
                res += x.ToString();

            int i = 0;
            for (; i < res.Length; ++i)
                if (res[i] == '1')
                    break;
            res = res.Substring(i, res.Length - i);
            return res;
        }
        public static string DecToHex(string s, int size=16)
        {
            string res = "";
            string str = DecToBin(s, size);

            if (str.Length != size)
                str = str.Insert(0, new string('0', size - str.Length));

            int n = size / 4;
            for (int j = 0; n > 0; --n, j += 4)
            {
                string input = str.Substring(j, 4);
                int output = Convert.ToInt32(input, 2);
                if (output < 10)
                    res += output.ToString();
                else
                    res += (char)(output + 55);
            }
            int i = 0;
            string result = res;
            int count = 0;
            for (; i < res.Length; ++i)
            {
                if (res[i] == '0')
                    ++count;
                else
                    break;
            }
            result = res.Substring(count, res.Length - count);
            return result;
        }
        public static string DecToOct(string s, int size=16)
        {
            string res = "";
            string str = DecToBin(s, size);
            if (str.Length != size)
                str = str.Insert(0, new string('0', size - str.Length));
            int n = size / 3;
            string input = str.Substring(0, size % 3);
            int output = Convert.ToInt32(input, 2);
            if (output != 0)
                res += output.ToString();
            for (int i = size % 3; n > 0; --n, i += 3)
            {
                input = str.Substring(i, 3);
                output = Convert.ToInt32(input, 2);
                res += output.ToString();
            }
            int j = 0;
            string result = res;
            int count = 0;
            for (; j < res.Length; ++j)
            {
                if (res[j] == '0')
                    ++count;
                else
                    break;
            }
            result = res.Substring(count, res.Length - count);
            return result;
        }

        public static string HexToDec(string bin_number, int size = 16)
        {
            long result = 0;
            int count = bin_number.Length - 1;
            for (int i = 0; i < bin_number.Length; i++)
            {
                int temp = 0;
                switch (bin_number[i])
                {
                    case 'A': temp = 10; break;
                    case 'B': temp = 11; break;
                    case 'C': temp = 12; break;
                    case 'D': temp = 13; break;
                    case 'E': temp = 14; break;
                    case 'F': temp = 15; break;
                    default: temp = -48 + (int)bin_number[i]; break;
                }

                result += temp * (int)Math.Pow(16, count);
                count--;
            }
            switch (size)
            {
                case 8:
                    result = (sbyte)result;
                    return result.ToString();
                case 16:
                    result = (short)result;
                    return result.ToString();
                case 32:
                    result = (int)result;
                    return result.ToString();
                default:
                    return result.ToString();
            }
        }
        public static string HexToOct(string bin_number,int size = 16)
        {
            var res = Convert.ToInt64(bin_number, 16);
            return DecToOct(res.ToString(), size);
        }
        public static string HexToBin(string bin_number, int size = 16)
        {
            var res = Convert.ToInt64(bin_number, 16);
            return DecToBin(res.ToString(), size);
        }


        public static string BinToDec(string binary, int size)
        {
            long binaryToDecimal(String n)
            {
                String num = n;
                long dec_value = 0;
                int base1 = 1;
                int len = num.Length;
                for (int i = len - 1; i >= 0; i--)
                {
                    if (num[i] == '1')
                        dec_value += base1;
                    base1 = base1 * 2;
                }
                return dec_value;
            }
            long result = binaryToDecimal(binary);
            switch (size)
            {
                case 8:
                    result = (sbyte)result;
                    return result.ToString();
                case 16:
                    result = (short)result;
                    return result.ToString();
                case 32:
                    result = (int)(result);
                    return result.ToString();
                default:
                    return result.ToString();
            }
        }
        public static string BinToHex(string bin_number, int size = 16)
        {
            var res = Convert.ToInt64(bin_number, 2);
            return DecToHex(res.ToString(), size);
        }
        public static string BinToOct(string bin_number, int size = 16)
        {
            var res = Convert.ToInt32(bin_number, 2);
            return DecToOct(res.ToString(), size);
        }

        public static string OctToDec(string s, int size = 16)
        {
            long octalToDecimal(long n)
            {
                long num = n;
                long dec_value = 0;
                long b = 1;
                long temp = num;
                while (temp != 0)
                {
                    long last_digit = temp % 10;
                    temp = temp / 10;
                    dec_value += last_digit * b;
                    b *= 8;
                }
                return dec_value;
            }
            long result = octalToDecimal(Int64.Parse(s));
            switch (size)
            {
                case 8:
                    result = (sbyte)result;
                    return result.ToString();
                case 16:
                    result = (short)result;
                    return result.ToString();
                case 32:
                    result = (int)result;
                    return result.ToString();
                default:
                    return result.ToString();
            }
        }
        public static string OctToBin(string bin_number, int size = 16)
        {
            var res = Convert.ToInt64(bin_number, 8);
            return DecToBin(res.ToString(), size);
        }
        public static string OctToHex(string bin_number, int size = 16)
        {
            var res = Convert.ToInt64(bin_number, 8);
            return DecToHex(res.ToString(), size);
        }


    }
}
