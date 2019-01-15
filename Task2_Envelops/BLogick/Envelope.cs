using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLogick
{
    class Envelope: ISideComparable

    {
        
        
        public Envelope(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public void Rotate()
        {
            double buffer = Width;
            Width = Height;
            Height = buffer;
        }

        public int[] Compare(Envelope obj)
        {

            int numOfCompairs = 2;
            int[] result = new int[numOfCompairs];

            if (Width < obj.Width) // compare Wisths
            {
                result[0] = -1;
            }
            if (Width > obj.Width) 
            {
                result[0] = 1;
            }

            if (Width == obj.Width) 
            {
                result[0] = 0;
            }

            if (Height < obj.Height)// compare Height
            {
                result[1] = -1;
            }

            if (Height > obj.Height)
            {
                result[1] = 1;
            }

            if (Height == obj.Height)
            {
                result[1] = 0;
            }

            return result;
        }


        public double Width { get; private set; }
        public double Height { get; private set; }




    }
}
