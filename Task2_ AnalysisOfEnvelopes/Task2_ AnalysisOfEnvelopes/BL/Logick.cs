using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Task2__AnalysisOfEnvelopes.IntermediateLvl;

namespace Task2__AnalysisOfEnvelopes.BL
{
    class Logick : ILogick
    {
        public bool AddEnvelope(double with, double height)
        {
            bool result = false;
            Envelope newEnvelope = Envelope.CreateNewEnvelope(with, height);
            if (newEnvelope == null)
            {
                return false;
            }
            if (_en1 == null)
            {
                _en1 = newEnvelope;
                result = true;
            }
            else
            {
                if (_en2 == null)
                {
                    _en2 = newEnvelope;
                    result = true;
                }
            }
            return result;
        }

        public void Restart()
        {
            _en1 = null;
            _en2 = null;
        }

        public CalculatingResult Result()
        {
            if (_en1 == null || _en2 == null)
            {
                return CalculatingResult.NotEnoughData;
            }
            int compareResult = _en1.CompareTo(_en2);
            if (compareResult == 1)
            {
                return CalculatingResult.SecondToFirst;
            }
            if (compareResult == 0)
            {
                return CalculatingResult.Equal;
            }
            if (_en2.CompareTo(_en1) == 1)
            {
                return CalculatingResult.FirstToSecond;
            }

            return CalculatingResult.NoOne;
        }

        public bool CanAddMore()
        {
            bool flag = false;
            if (_en1 == null || _en2 == null)
            {
                flag = true;
            }
            return flag;
        }

        private Envelope _en1;
        private Envelope _en2;
    }
}