using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAssignment
{
    internal class Client
    {
        int[] data = { 10, 30, 60, 90, 130, 190 };

        public void show(IMath a)
        {
            Console.WriteLine("Sum = " + a.findSUM(data));
            Console.WriteLine("Max = " + a.findMAX(data));
        }

    }
}
