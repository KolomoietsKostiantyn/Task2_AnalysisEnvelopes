using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_AnalysisOfEnvelopes.BL
{
    public class EnvelopeCreator: IEnvelopeCreator
    {
        public Envelope CreateEnvelope(double side1, double side2)
        {
            if (side1 <= 0 || side2 <= 0)
            {
                return null;
            }

            return new Envelope(side1, side2);
        }
    }
}
