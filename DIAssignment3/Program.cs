using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace DIAssignment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UnityContainer c = new UnityContainer();

            c.RegisterSingleton<TestInstance>();
            c.RegisterType<TestInstance>("Transient");

            var singleton1 = c.Resolve<TestInstance>();
            var singleton2 = c.Resolve<TestInstance>();

            var transient1 = c.Resolve<TestInstance>("Transient");
            var transient2 = c.Resolve<TestInstance>("Transient");

            Console.WriteLine("singleton instances");
            singleton1.Show();
            singleton2.Show();

            Console.WriteLine("\nTransient instances");
            transient1.Show();
            transient2.Show();

            Console.Read();


        }
    }
}
