using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IntermediateLvl;

namespace UInterfase
{
    public class UI : IUI
    {
        public UI() 
        { }

        public void Start()
        {
            bool flag = false;
            double env1Side1;
            double env1Side2;
            double env2Side1;
            double env2Side2;
            do
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("Write width of envelope 1");
                    //double.TryParse(Console.ReadLine(), out env1Side1);
                } while (!double.TryParse(Console.ReadLine(), out env1Side1));

                do
                {
                    Console.Clear();
                    Console.WriteLine("Write heith of envelope 1");
                    //double.TryParse(Console.ReadLine(), out env1Side1);
                } while (!double.TryParse(Console.ReadLine(), out env1Side2));

                do
                {
                    Console.Clear();
                    Console.WriteLine("Write width of envelope 2");
                    //double.TryParse(Console.ReadLine(), out env1Side1);
                } while (!double.TryParse(Console.ReadLine(), out env2Side1));

                do
                {
                    Console.Clear();
                    Console.WriteLine("Write heith of envelope 2");
                    //double.TryParse(Console.ReadLine(), out env1Side1);
                } while (!double.TryParse(Console.ReadLine(), out env2Side2));


                //тут информируем контролер
                if (_sendData != null)
                {
                    _sendData(env1Side1, env1Side2, env2Side1, env2Side2);
                }
                CompareResult result = CompareResult.NotCompared;
                if (_compareEnvelopes != null)
                {
                    result = _compareEnvelopes();
                }

                Console.Clear();
                switch (result)
                { 
                    case CompareResult.SecondToFirst:
                        Console.WriteLine("Yoy can put in second to first");
                        break;
                    case CompareResult.Equals:
                        Console.WriteLine("Envelops are equals");
                        break;
                    case CompareResult.FirstToSecond:
                        Console.WriteLine("Yoy can put in first to second");
                        break;
                    case CompareResult.NoOne:
                        Console.WriteLine("No one can be put in to anyone");
                        break;
                    default:
                        Console.WriteLine("Comparison was not successful");
                        break;
                }
                Console.WriteLine("Continue?");
                string flagContinue = Console.ReadLine();
                flagContinue = flagContinue.ToLower();

                if (flagContinue == "y" || flagContinue == "yes")
                {
                    flag = true;
                }

            } while (flag);


            
        }

        public event SendData SendDataDesc
        {
            add
            {
                _sendData += value;
            }
            remove
            {
                _sendData -= value;
            }
        }

        SendData _sendData;


        public event CompareEnvelopes CompareEnvelopesDesc
        {
            add
            {
                _compareEnvelopes += value;
            }
            remove
            {
                _compareEnvelopes -= value;
            }
        }

        CompareEnvelopes _compareEnvelopes;





















    }
}
