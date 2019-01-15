using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntermediateLvl;

namespace BLogick
{
    public class MainControler
    {
        public MainControler(IUI visualizator)
        {
            visualizator.SendDataDesc += CreateNewEnvelops;
            visualizator.CompareEnvelopesDesc += Compare;
        }


        private void CreateNewEnvelops(double e1s1, double e1s2, double e2s1, double e2s2)
        {
            _first = new Envelope(e1s1, e1s2);
            _second = new Envelope(e2s1, e2s2);
        }

        private CompareResult Compare()
        {
            int ComparationCount = 2;
            int[] compereResult = new int[ComparationCount];

            CompareResult result = CompareResult.NoOne;

            compereResult = _first.Compare(_second);

            if (compereResult[0] == 1 && compereResult[1] == 1)
            {
                result = CompareResult.SecondToFirst;
            }

            if (compereResult[0] == -1 && compereResult[1] == -1)
            {
                result = CompareResult.FirstToSecond;      
            }

            if (compereResult[0] == 0 && compereResult[1] == 0)
            {
                result = CompareResult.Equals;
            }

            _first.Rotate();

            compereResult = _first.Compare(_second);

            if (compereResult[0] == 1 && compereResult[1] == 1)
            {
                result = CompareResult.SecondToFirst;
            }

            if (compereResult[0] == -1 && compereResult[1] == -1)
            {
                result = CompareResult.FirstToSecond;
            }

            return result;
        }


        Envelope _first;
        Envelope _second;
    }
}
