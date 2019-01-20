using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2__AnalysisOfEnvelopes.IntermediateLvl;

namespace Task2__AnalysisOfEnvelopes.UI
{
    class ConsoleUI : IVisualizer
    {
        private string _instruction = "alternately enter the sides of the " + 
                "envelopes and find out whether you can put them in each other";
        public bool AskContinue()
        {
            Console.WriteLine("Continue?");
            string ask = Console.ReadLine();
            ask = ask.ToLower();
            bool result = false;
            if (ask == "y" || ask == "yes")
            {
                result = true;
            }
            return result;
        }

        public string AskSides(Sides side)
        {
            string sideName = "Enter {0}";
            string result = string.Empty;
            switch (side)
            {
                case Sides.Width:
                    Console.WriteLine(string.Format(sideName, Sides.Width));
                    result = Console.ReadLine();
                    break;
                case Sides.Heigth:
                    Console.WriteLine(string.Format(sideName, Sides.Heigth));
                    result = Console.ReadLine();
                    break;
                default:
                    break;
            }
            return result;
        }

        public void ShowAnswer(CalculatingResult res)
        {
            switch (res)
            {
                case CalculatingResult.NotEnoughData:
                    Console.WriteLine("You don't enter all required data.");
                    break;
                case CalculatingResult.FirstToSecond:
                    Console.WriteLine("Нou can put the first envelope to second.");
                    break;
                case CalculatingResult.SecondToFirst:
                    Console.WriteLine("You can put the second envelope to first.");
                    break;
                case CalculatingResult.Equal:
                    Console.WriteLine("Envelopes are equal.");
                    break;
                case CalculatingResult.NoOne:
                    Console.WriteLine("No envelope can be inserted into another.");
                    break;
                default:
                    break;
            }
        }

        public void ShowStatus(Result res)
        {
            switch (res)
            {
                case Result.Instruction:
                    Console.WriteLine(_instruction);
                    break;
                case Result.EnvelopeAdd:
                    Console.WriteLine("Envelope add!!!");
                    break;
                case Result.IncorectData:
                    Console.WriteLine("You enter incorect data");
                    break;
                default:
                    break;
            }
        }
    }
}
