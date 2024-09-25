using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adonetdemo
{
    internal class LinqAssignment2
    {
        List<Products> li = new List<Products>()
            {
                new Products() { pid = 100, pname = "book", price = 1000, qty = 5 },
                new Products() { pid = 200, pname = "cd", price = 2000, qty = 6 },
                new Products() { pid = 300, pname = "toys", price = 3000, qty = 5 },
                new Products() { pid = 400, pname = "mobile", price = 8000, qty = 6 },
                new Products() { pid = 600, pname = "pen", price = 200, qty = 7 },
                new Products() { pid = 700, pname = "tv", price = 30000, qty = 7 },
             };

        public void Demo1()
        {
            //find second highest price
            //var res = li.OrderByDescending(t => t.price).Take(2).Skip(1);

            //display top 3 highest price
            //var res = li.OrderByDescending(t => t.price).Take(3);

            //find the sum of price where product names contains letter 'O'
            //var res = li.Where(t => t.pname.Contains('o')).Sum(t => t.price);

            //Console.WriteLine(res);

            //find the product name ends with e and display only pid and pname (filter by column name)
            var res = li.Where(t => t.pname.EndsWith("e"));

            //group all records by qty find max of price
            //var res = li.GroupBy(t => t.qty).Max(t => t.price);

            foreach (var product in res)
            {
                //Console.WriteLine($"{product.price}");
                //Console.WriteLine($" {product.pid} {product.pname} {product.qty} {product.price}");
                Console.WriteLine($" {product.pid} {product.pname}");
                //Console.WriteLine($" {product.price}");
            }
        }

    }
}
