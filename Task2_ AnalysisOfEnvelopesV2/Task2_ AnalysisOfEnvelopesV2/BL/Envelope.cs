using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2_AnalysisOfEnvelopes.BL
{
    public class Envelope
    {
        public double Height { get; private set; }
        public double Width { get; private set; }

        public Envelope(double height, double width)
        {
            Height = height;
            Width = width;
        }
    }
}
