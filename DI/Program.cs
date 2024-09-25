using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace DI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            UnityContainer c = new UnityContainer();

            //IMath m = new service();
            c.RegisterSingleton<IMath, service>();
            c.RegisterSingleton<IMath1, service1>();

            //Automatically resolves the dependency for Client
            var client = c.Resolve<Client>();
            client.show();





            // create object of service class
            //IMath ob = new service();

            //IMath1 ob1 = new service1();

            // send the object to client class
            //Client c = new Client(ob, ob1);

            //Client c = new Client();
            //c.m = ob;
            //c.s = ob1;
            //c.show();

            //c.show(ob,ob1);

            Console.Read();

        }
    }
}




