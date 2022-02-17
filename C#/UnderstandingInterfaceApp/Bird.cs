using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnderstandingInterfaceApp
{
    class Bird : IFlying
    {
        public void Eat()
        {
            Console.WriteLine("Eats small portions");
        }
        public void Breathe()
        {
            Console.WriteLine("Inhale.....................Exale");
        }

        public void TakeOff()
        {
            Console.WriteLine("Flap wings fast");
        }

        public void Fly()
        {
            Console.WriteLine("Glide along");
        }

        public void Land()
        {
            Console.WriteLine("Stop flapping wings");
        }
    }
}
