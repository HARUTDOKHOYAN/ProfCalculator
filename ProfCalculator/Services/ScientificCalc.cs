using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfCalculator.Services
{
    class ScientificCalc: StandardCalc
    {
        public ScientificCalc()
        {
            Numbers.Add("П", "3.1415926535897932384626433832795");
            Numbers.Add("e", "2,7182818284590452353602874713527");
        }

        
    }

    
}
