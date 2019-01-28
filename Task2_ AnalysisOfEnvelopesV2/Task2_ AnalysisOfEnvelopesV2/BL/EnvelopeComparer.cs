using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_AnalysisOfEnvelopes.BL
{
    public class EnvelopeComparer : IComparer<Envelope>
    {
        public int Compare(Envelope x, Envelope y)
        {
            if (x == null || y == null)
            {
                throw new NullReferenceException();
            }

            if (Math.Max(x.Height, x.Width) > Math.Max(y.Height, y.Width) &&
            Math.Min(x.Height, x.Width) > Math.Min(y.Height, y.Width))
            {
                return 1;
            }
            if (Math.Max(x.Height, x.Width) == Math.Max(y.Height, y.Width) &&
                    Math.Min(x.Height, x.Width) == Math.Min(y.Height, y.Width))
            {
                return 0;
            }

            return -1;
        }
    }
}
