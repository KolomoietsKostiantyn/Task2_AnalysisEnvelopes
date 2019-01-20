using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task2__AnalysisOfEnvelopes.BL
{
    class Envelope 
    {

        public double Height { get; private set; }
        public double Width { get; private set; }


        public static Envelope CreateNewEnvelope(double height, double width)
        {
            Envelope result = null;
            if (height > 0 && width > 0)
            {
                result = new Envelope(height, width);
            }
            return result;
        }

        private Envelope()
        {

        }

        private Envelope(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public int CompareTo(Envelope other)
        {
            if (other == null)
            {
                throw new NullReferenceException();
            }
            if (Math.Max(Height, Width) > Math.Max(other.Height, other.Width) &&
                    Math.Min(Height, Width) > Math.Min(other.Height, other.Width))
            {
                return 1;
            }
            if (Math.Max(Height, Width) == Math.Max(other.Height, other.Width) &&
                    Math.Min(Height, Width) == Math.Min(other.Height, other.Width))
            {
                return 0;
            }
            return -1;
        }
    }
}