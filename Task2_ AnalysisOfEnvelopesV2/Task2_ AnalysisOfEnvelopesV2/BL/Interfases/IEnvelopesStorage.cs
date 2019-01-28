using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_AnalysisOfEnvelopes.Intermediate;

namespace Task2_AnalysisOfEnvelopes.BL
{
    interface IEnvelopesStorage
    {
        bool AddEnvelope(double with, double height);
        void Restart();
        CalculatingResult Result();
        bool CanAddMore();
    }
}
