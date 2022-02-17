using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstApplication
{
    class Cycle
    {
        public int Speed { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public Cycle()
        {
            Speed = 10;
        }
        public Cycle(int speed)
        {
            Speed = speed;
        }
        public virtual void Run()
        {
            Console.WriteLine($"{Name}  Runs in the speed of " + Speed);
        }
    }
}
