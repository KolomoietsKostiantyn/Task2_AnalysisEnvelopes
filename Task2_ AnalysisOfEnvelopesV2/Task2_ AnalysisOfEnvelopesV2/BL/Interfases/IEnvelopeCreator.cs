using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_AnalysisOfEnvelopes.BL
{
    public interface IEnvelopeCreator
    {
        Envelope CreateEnvelope(double side1, double side2);
    }
}
