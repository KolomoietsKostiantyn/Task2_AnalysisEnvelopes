using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2__AnalysisOfEnvelopes.IntermediateLvl;

namespace Task2__AnalysisOfEnvelopes.BL
{
    interface ILogick
    {
        bool AddEnvelope(double with, double height);
        CalculatingResult Result();
        void Restart();
        bool CanAddMore();
    }
}
