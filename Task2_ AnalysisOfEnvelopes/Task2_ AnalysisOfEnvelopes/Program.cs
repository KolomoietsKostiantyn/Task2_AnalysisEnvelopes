using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2__AnalysisOfEnvelopes.BL;
using Task2__AnalysisOfEnvelopes.IntermediateLvl;
using Task2__AnalysisOfEnvelopes.UI;

namespace Task2__AnalysisOfEnvelopes
{
    class Program
    {
        static void Main(string[] args)
        {
            IVisualizer visualizer = new ConsoleUI();
            Controler mControler = new Controler(visualizer, args);
            mControler.Start();
        }
    }
}
