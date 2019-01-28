using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_AnalysisOfEnvelopes.BL
{
    interface IInnerDataValidator
    {
        bool ValidateInputArray(string[] arr);
        bool ConvertStringToParam(string str, out double side);
        bool ConvertArrayToParams(string[] arr, out double tr1Side1, out double tr1Side2, out double tr2Side1, out double tr2Side2);
    }
}
