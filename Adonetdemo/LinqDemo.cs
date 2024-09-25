using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adonetdemo
{
    internal class LinqDemo
    {
        List<Product> products = new List<Product>()
            {
                new Product(){ pid=1, pname="books", description="c#", price=120},
                new Product(){ pid=2, pname="cd", description="story", price=80},
                new Product(){ pid=3, pname="moniter", description="dell", price=6000},
                new Product(){ pid=4, pname="mobile", description="oppo", price=10000},
                new Product(){ pid=5, pname="keyboard", description="hp", price=1400},

            };

        public void Demo1()
        {
            // without linq
            string[] countries = { "india", "canada", "uk", "us" };

            foreach (string country in countries)
            {
                if (country.StartsWith("u"))
                {
                    Console.WriteLine(country);
                }
            }

        }

        public void Demo2()
        {
            // with linq
            string[] countries = { "india", "canada", "uk", "us" };

            var res = from t in countries
                      where t.StartsWith("u")
                      select t;
            foreach (var country in res)
            {
                Console.WriteLine(country);
            }

        }

        public void Demo3()
        {
            int[] data = { 10, 11, 12, 13, 14, 15 };

            var res = from t in data
                      where t % 2 == 0
                      select t;
            foreach (var d in res)
            {
                Console.WriteLine(d);
            }

        }

        public void Demo4()
        {
            //linq queries for collections


            //prints all product where price > 500
            //var res = from t in products
            //          where t.price>500
            //          select t;

            //how to print specific columns
            //var res = from t in products
            //          where t.price > 500
            //          select new { t.pid, t.pname };

            //how give alias for columns
            //var res = from t in products
            //          where t.price > 500
            //          select new { productid= t.pid, productname= t.pname };

            //how to sort the column
            //var res= from t in products
            //         orderby t.price descending
            //         select t;

            //query is not executed
            var res = from t in products
                      select t;

            products.Add(new Product() { pid = 6, pname = "marker", description = "gel", price = 500 });

            foreach (var product in res)
            {
                // Console.WriteLine($" {product.pid} {product.pname} {product.description} {product.price}");
                // Console.WriteLine($" {product.pid} {product.pname}");
                // Console.WriteLine($" {product.productid} {product.productname}");
                Console.WriteLine($" {product.pid} {product.pname} {product.description} {product.price}");
            }
        }

        public void Demo5()
        {
            // query expression method
            //var re = from t in products
            //         where t.price >500
            //         select t;

            // lambda expression method

            //where
            //var res = products.Where(t => t.price > 500);

            //take
            // var res = products.Take(2);

            //skip
            //var res = products.Skip(2);

            //takewhile
            //var res = products.TakeWhile(t=> t.price != 10000);

            //skipwhile
            //var res = products.SkipWhile(t => t.price != 10000);

            var res = products.Where(t => t.price > 5000).OrderByDescending(t => t.price);

            foreach (var product in res)
            {
                Console.WriteLine($" {product.pid} {product.pname} {product.description} {product.price}");
            }


        }
    }
}
