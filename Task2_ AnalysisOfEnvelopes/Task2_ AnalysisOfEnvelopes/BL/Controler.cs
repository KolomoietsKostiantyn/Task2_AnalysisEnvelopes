using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2__AnalysisOfEnvelopes.IntermediateLvl;

namespace Task2__AnalysisOfEnvelopes.BL
{
    class Controler
    {
        private IVisualizer _visualizer;
        private string[] _arr;
        private ILogick _logick;

        public Controler(IVisualizer visualizer, string [] arr)
        {
            _visualizer = visualizer;
            _arr = arr;
            _logick = new Logick();
        }

        public void Start()
        {
            ValidateStartData(_arr);
            double width;
            double heidth;
            do
            {
                while (_logick.CanAddMore())
                {
                    AskSides(out heidth, out width);
                    if (_logick.AddEnvelope(heidth, width))
                    {
                        _visualizer.ShowStatus(Result.EnvelopeAdd);
                    }
                    else
                    {
                        _visualizer.ShowStatus(Result.IncorectData);
                    }
                }
                CalculatingResult res = _logick.Result();
                _visualizer.ShowAnswer(res);
                _logick.Restart();
            } while (_visualizer.AskContinue());
        }

        private void AskSides(out double heidth, out double width)
        {
            string parm;
            do
            {
                parm = _visualizer.AskSides(Sides.Heigth);
            } while (!double.TryParse(parm, out heidth));

            do
            {
                parm = _visualizer.AskSides(Sides.Width);
            } while (!double.TryParse(parm, out width));
        }

        private void ValidateStartData(string[] _arr)
        {
            if (_arr == null || _arr.Length != (int)Sides.SideCounts)
            {
                _visualizer.ShowStatus(Result.Instruction);
                return;
            }

            double width = 0; 
            double height = 0;
            bool result = double.TryParse(_arr[(int)Sides.Heigth], out height);
            if (result)
            {
                result = double.TryParse(_arr[(int)Sides.Width], out width);
            }
            if (result && _logick.AddEnvelope(width, height))
            {
                _visualizer.ShowStatus(Result.EnvelopeAdd);
            }
            else
            {
                _visualizer.ShowStatus(Result.Instruction);
            }
        }
    }
}
