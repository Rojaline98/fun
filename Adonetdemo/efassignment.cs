using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adonetdemo
{
    internal class efassignment
    {
        studentsdbEntities1 dc = new studentsdbEntities1();

        public void DisplayCustomer()
        {
            var res = from t in dc.customers
                      select t;

            foreach (var t in res)
            {
                Console.WriteLine($"{t.custid} {t.custname} {t.age} {t.caddress} ");
            }
        }

        public void DisplayOrder()
        {
            var res = from t in dc.orders
                      select t;

            foreach (var t in res)
            {
                Console.WriteLine($"{t.orderid} {t.custid} {t.orderdate} {t.product} {t.price} {t.qty} ");
            }
        }

        public void commonrecords()
        {
            var commonrecords = from c in dc.customers
                                join o in dc.orders on c.custid equals o.custid
                                select new { c.custid, c.custname, o.product, o.price };
            foreach (var r in commonrecords)
            {
                Console.WriteLine($"{r.custid},{r.custname},{r.product},{r.price}");
            }


        }

        public void showdetails()
        {
            var res = from t in dc.customers join t1 in dc.orders
                      on t.custid equals t1.custid
                      select new { t.custid, t.custname, t1.orderdate, t1.product, t1.price };


            foreach (var t in res)
            {
                Console.WriteLine($"{t.custid} {t.custname} {t.orderdate} {t.product} {t.price}");
            }
        }

        public void Demo5()
        {
            var res = from t in dc.customers
                      join t1 in dc.orders
                      on t.custid equals t1.custid
                      where t.custname.StartsWith("A") || t.custname.EndsWith("s")
                      select new {t.custid, t.caddress, t1.product, t1.price};

            foreach (var t in res)
            {
                Console.WriteLine($"{t.custid} {t.caddress} {t.product} {t.price}");
            }
        }

        public void Demo6()
        {
            var res = dc.customers.Where(t => t.age > 20).OrderByDescending(t => t.age);

            foreach (var t in res)
            {
                Console.WriteLine($"{t.custid} {t.custname} {t.age} {t.caddress} ");
            }
        }

        public void Demo7()
        {
            var res = dc.customers.Take(3);

            foreach (var t in res)
            {
                Console.WriteLine($"{t.custid} {t.custname} {t.age} {t.caddress} ");
            }

        }

        public void Demo8()
        {
            var res = dc.orders.Where(t => t.price > 500 && t.orderdate > new DateTime(2000, 01, 01))
                        .Select(t => new { t.orderid, t.product, t.orderdate, o = t.price, n = (t.price - (t.price * 0.1)) });

            foreach (var t in res)
            {
                Console.WriteLine($"{t.orderid}  {t.product}  {t.orderdate} {t.o}  {t.n}");
            }
        }

        public void Demo9()
        {
            var res = new
            {
                sum = dc.orders.Sum(t => t.price),
                max = dc.orders.Max(t => t.price)
            };

            Console.WriteLine($"Sum: {res.sum} , Max: {res.max}");
        }


        public void Demo10()
        {
            var res = dc.orders.Where(t => t.orderdate == DateTime.Today);
            
            foreach (var t in res)
            {
                Console.WriteLine($"{t.orderdate}");
            }
        }

        public void Demo11()
        {
            Console.WriteLine("Enter the first date in yyyy-mm-dd format");
            int y1 = int.Parse(Console.ReadLine());
            int m1 = int.Parse(Console.ReadLine());
            int d1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second date in yyyy-mm-dd format");
            int y2 = int.Parse(Console.ReadLine());
            int m2 = int.Parse(Console.ReadLine());
            int d2 = int.Parse(Console.ReadLine());

            var res = from t in dc.orders
                      where t.orderdate > new DateTime(y1, m1, d1) && t.orderdate < new DateTime(y2, m2, d2)
                      select t;
            foreach (var t in res)
            {
                Console.WriteLine($"${t.custid} {t.orderid} {t.orderdate} {t.product} {t.price}");
            }
        }

        public void Demo12()
        {
            var t1 = from t in dc.customers
                     select t;

            var t2 = from t in dc.orders
                     select t;
            foreach (var t in t1)
            {
                int c = 0;
                foreach (var a in t2)
                {
                    if (t.custid == a.custid)
                        c++;

                }
                if (c == 0)
                {
                    Console.WriteLine(t.custid);
                    Console.WriteLine(t.custname);
                }
            }

        }

        public void Demo13()
        {
            var res = from t in dc.customers join t1 in dc.orders
                      on t.custid equals t1.custid
                      where t1.price > 5000
                      orderby t.custid descending
                      select new {t.custid, t.custname, t1.product, t1.price };


            foreach (var t in res)
            {
                Console.WriteLine($"{t.custid} {t.custname} {t.product} {t.price} ");
            }

        }

        public void Demo14()
        {
            

        }


        public void Demo15()
        {
            var res = dc.customers.Where(t => t.caddress == "Banglore").FirstOrDefault();
            dc.customers.Remove(res);
            int i = dc.SaveChanges();

        }

        public void Demo16()
        {
            var result = dc.customers.Where(c => c.age > 25).ToList().SkipWhile(c => c.age < 35).Take(2);

            foreach (var customer in result)
            {
                Console.WriteLine($"Id: {customer.custid}, Name: {customer.custname}, Age: {customer.age}");
            }


        }





    }
}
