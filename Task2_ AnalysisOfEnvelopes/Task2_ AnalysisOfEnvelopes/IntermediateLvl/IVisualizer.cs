using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2__AnalysisOfEnvelopes.IntermediateLvl
{
    interface IVisualizer
    {
        void ShowAnswer(CalculatingResult res);
        void ShowStatus(Result res);
        string AskSides(Sides side);
        bool AskContinue();
    }
}
