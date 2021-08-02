using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.Services
{
    public class ScientificCalc : BaseCalc
    {
        private string _x = "0";
        private List<string> _line = new List<string>();
        private string prev = "number";
        private bool isEnd = false;

        public List<string> Line
        {
            get => _line;
            set { _line = value; OnPropertyChanged(); }
        }
        public string LineString
        {
            get => string.Join(" ", _line);
        }
        public string X
        {
            get => _x;
            set { _x = value; OnPropertyChanged(); }
        }

        public override ICalcData GetData()
        {
            throw new NotImplementedException();
        }

        public override void OnC()
        {
            throw new NotImplementedException();
        }

        public override void OnCE()
        {
            throw new NotImplementedException();
        }

        public override void OnEquals(string input)
        {
            //if prev is operator -> copy X to the end of Line
            throw new NotImplementedException();
        }

        public override void OnNumber(string input)
        {
            if (prev == "operator")
                X = input;
            else if (prev == "number")
                if (X == "0")
                    X = input;
                else
                    X += input;

            prev = "number";
            isEnd = false;
        }

        public override void OnOperator(string input)
        {
            if(prev == "number")
            {

            }
            else
            {
                
            }
            prev = "operator";
            isEnd = false;
        }

        public override void OnReactOperator(string input)
        {
            throw new NotImplementedException();
        }

        public override void OnRemove()
        {
            throw new NotImplementedException();
        }

        public override void SetData(ICalcData data)
        {
            throw new NotImplementedException();
        }
    }
}
