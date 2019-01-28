using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_AnalysisOfEnvelopes.Intermediate
{
    interface IVisualizer
    {
        void ShowAnswer(CalculatingResult res);
        void ShowMassage(Result res);
        string AskSides(Sides side);
        bool AskContinue();
    }
}
