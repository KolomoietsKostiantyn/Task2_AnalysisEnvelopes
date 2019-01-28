using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_AnalysisOfEnvelopes.Intermediate;

namespace Task2_AnalysisOfEnvelopes.BL
{
    class Controler
    {
        private readonly int _envelopCount = 2;
        private IEnvelopesStorage _envelopesStorage;
        private string[] _arr;
        IInnerDataValidator _innerDataValidator;
        IVisualizer _visualizer;

        public Controler(IVisualizer visualizer,IEnvelopesStorage envelopesStorage, IInnerDataValidator innerDataValidator, string[] arr)
        {
            _visualizer = visualizer;
            _envelopesStorage = envelopesStorage;
            _arr = arr;
            _innerDataValidator = innerDataValidator;
        }

        public void Start()
        {
            ProcesingStartData();

            if (!_visualizer.AskContinue())
            {
                return;
            }

            do
            {
                ContinuationTriggersAdding();
            } while (_visualizer.AskContinue());

        }

        private void ContinuationTriggersAdding()
        {
            double side1;
            double side2;
            string sides;

            for (int i = 0; i < _envelopCount; i++)
            {
                do
                {
                    sides = _visualizer.AskSides(Sides.Heigth);
                } while (!_innerDataValidator.ConvertStringToParam(sides, out side1));
                do
                {
                    sides = _visualizer.AskSides(Sides.Width);
                } while (!_innerDataValidator.ConvertStringToParam(sides, out side2));
                _envelopesStorage.AddEnvelope(side1, side2);
            }
            _visualizer.ShowAnswer(_envelopesStorage.Result());
        }

        private void ProcesingStartData()
        {
            if (_innerDataValidator.ValidateInputArray(_arr))
            {
                double envelope1Side1;
                double envelope1Side2;
                double envelope2Side1;
                double envelope2Side2;
                if (_innerDataValidator.ConvertArrayToParams(_arr, out envelope1Side1, out envelope1Side2, out envelope2Side1, out envelope2Side2))
                {
                    _envelopesStorage.AddEnvelope(envelope1Side1, envelope1Side2);
                    _envelopesStorage.AddEnvelope(envelope2Side1, envelope2Side2);
                    _visualizer.ShowAnswer(_envelopesStorage.Result());
                }
                else
                {
                    _visualizer.ShowMassage(Result.IncorectData);
                }
            }
            else
            {
                _visualizer.ShowMassage(Result.Instruction);
            }
        }
    }
}
