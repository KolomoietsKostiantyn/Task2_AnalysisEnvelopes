using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_AnalysisOfEnvelopes.BL;
using Task2_AnalysisOfEnvelopes.Intermediate;
using Task2_AnalysisOfEnvelopes.UI;

namespace Task2_AnalysisOfEnvelopes
{
    class Program
    {
        static void Main(string[] args)
        {

            IVisualizer vi = new ConsoleUI();
            IEnvelopeCreator eCreator = new EnvelopeCreator();
            IComparer<Envelope> comparer = new EnvelopeComparer();
            IEnvelopesStorage eStorage = new EnvelopesStorage(eCreator, comparer);
            IInnerDataValidator iDataValidator = new InnerDataValidator();

            Controler cntrlr = new Controler(vi, eStorage, iDataValidator, args);
            cntrlr.Start();

        }
    }
}
