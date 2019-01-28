using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_AnalysisOfEnvelopes.BL
{
    public class InnerDataValidator: IInnerDataValidator
    {
        public bool ValidateInputArray(string[] arr)
        {
            bool result = true;
            if (arr == null || arr.Length != 4)
            {
                return false;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(arr[i]))
                {
                    result = false;
                    break;
                }
            }

            return result;
        }

        public bool ConvertStringToParam(string str, out double side)
        {
            side = 0;
            if (string.IsNullOrWhiteSpace(str))
            {
                return false;
            }

            bool result = true;
            if (double.TryParse(str, out side))
            {
                if (side <= 0)
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }


        public bool ConvertArrayToParams(string[] arr, out double envelope1Side1, out double envelope1Side2, out double envelope2Side1, out double envelope2Side2)
        {
            envelope1Side1 = 0;
            envelope1Side2 = 0;
            envelope2Side1 = 0;
            envelope2Side2 = 0;
            if (!ValidateInputArray(arr))
            {
                return false;
            }

            bool result = true;
            if (double.TryParse(arr[0], out envelope1Side1))
            {
                if (envelope1Side1 <= 0)
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            if (double.TryParse(arr[1], out envelope1Side2))
            {
                if (envelope1Side2 <= 0)
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            if (double.TryParse(arr[2], out envelope2Side1))
            {
                if (envelope2Side1 <= 0)
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }
            if (double.TryParse(arr[3], out envelope2Side2))
            {
                if (envelope2Side2 <= 0)
                {
                    result = false;
                }
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}
