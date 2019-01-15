using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UInterfase;
using BLogick;


namespace Task2_Envelops
{
    class Program
    {
        static void Main(string[] args)
        {


            UI newUI = new UI();
            MainControler mControler = new MainControler(newUI);
            newUI.Start();


            
            

        }
    }
}
