using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2_AnalysisOfEnvelopes.Intermediate;

namespace Task2_AnalysisOfEnvelopes.BL
{
    public class EnvelopesStorage: IEnvelopesStorage
    {
        public Envelope Envelope1
        {
            get;
            set;
        }
        public Envelope Envelope2
        {
            get;
            set;
        }
        private IEnvelopeCreator _envelopeCreator;
        IComparer<Envelope> _comparer;

        public EnvelopesStorage(IEnvelopeCreator envelopeCreator, IComparer<Envelope> comparer)
        {
            _comparer = comparer;
            _envelopeCreator = envelopeCreator;
        }

        public bool AddEnvelope(double with, double height)
        {
            if (Envelope1 != null && Envelope2 != null)
            {
                return false;
            }
            Envelope newEnvelope = _envelopeCreator.CreateEnvelope(with, height);
            if (newEnvelope == null)
            {
                return false;
            }

            if (Envelope1 == null)
            {
                Envelope1 = newEnvelope;
            }
            else
            {
                Envelope2 = newEnvelope;
            }
            return true;
        }

        public void Restart()
        {
            Envelope1 = null;
            Envelope2 = null;
        }

        public CalculatingResult Result()
        {
            if (Envelope1 == null || Envelope2 == null)
            {
                return CalculatingResult.NotEnoughData;
            }
            int compareResult = _comparer.Compare(Envelope1, Envelope2);           
            if (compareResult == 1)
            {
                return CalculatingResult.SecondToFirst;
            }
            if (compareResult == 0)
            {
                return CalculatingResult.Equal;
            }
            if (_comparer.Compare(Envelope2, Envelope1)  == 1)
            {
                return CalculatingResult.FirstToSecond;
            }
            Restart();

            return CalculatingResult.NoOne;
        }

        public bool CanAddMore()
        {
            bool flag = false;
            if (Envelope1 == null || Envelope2 == null)
            {
                flag = true;
            }
            return flag;
        }
    }
}
