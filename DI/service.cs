using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI
{

    interface IMath
    {
        void Add(int x, int y);
    }
    internal class service : IMath
    {
        public void Add(int x, int y)
        {
            Console.WriteLine("the sum is " + (x + y));

        }
    }

    interface IMath1
    {
        void Multiply(int x, int y);
    }
    internal class service1 : IMath1
    {
        public void Multiply(int x, int y)
        {
            Console.WriteLine("the mul is " + (x * y));

        }
    }
}
