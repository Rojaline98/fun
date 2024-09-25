using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI
{
    internal class Client
    {
        IMath math;
        IMath1 math1;
        public Client(IMath m, IMath1 m1) 
        {
            math = m;
            math1 = m1;
        }

        public void show()
        {
            math.Add(10, 20);
            math1.Multiply(5, 9);
        }


        //IMath math;
        //IMath1 math1;

        //constructor injection
        //public Client(IMath m, IMath1 s)
        //{
        //    math = m;
        //    math1 = s;
        //}

        //property injection
        //public IMath m { get; set; }

        //public IMath1 s { get; set; }

        //public void show()
        //{
        //    m.Add(34, 45);
        //    s.Multiply(4, 5);
        //}


        //method injection
        //public void show(IMath m, IMath1 s)
        //{
        //    m.Add(34, 45);
        //    s.Multiply(4, 5);
        //}


    }
}
