using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Adonetdemo
{
    internal class LinqAssignments
    {
        List<Movies> li = new List<Movies>()
            {
                new Movies(){ MovieId=100, MovieName="Bahubali", Actor="Prabhas", Actress="Tamanna",YOR=2015 },
                new Movies(){ MovieId=200, MovieName="Bahubali2", Actor="Prabhas", Actress="Anushka",YOR=2017 },
                new Movies(){ MovieId=300, MovieName="Robot", Actor="Rajini", Actress="Aish", YOR=2010 },
                new Movies(){ MovieId=400, MovieName="3 idiots", Actor="Amir", Actress="kareena", YOR=2009 },
                new Movies(){ MovieId=500, MovieName="Saaho", Actor="Prabhas", Actress="shraddha",YOR=2019 },
            };


        public void Demo1()
        {
            //display list of movienames acted by prabhas
            //var res =  from t in li
            //          where t.Actor == "Prabhas"
            //          select t;

            //display list of all movies released in year 2019
            //var res = from t in li
            //          where t.YOR == 2019
            //          select t;


            //display the list of movies who acted togeather by prabhas and anushka
            //var res = from t in li
            //          where t.Actor == "Prabhas" && t.Actress == "Anushka"
            //          select t;

            //display the list of all actress who acted with prabhas
            //var res = from t in li
            //          where t.Actor == "Prabhas"
            //          select t;


            //display the list of all moves released from 2010 - 2018
            //var res = from t in li
            //          where t.YOR >= 2010 && t.YOR <= 2018
            //          select t;


            //sort YOR in descending order and display all its records
            //var res = from t in li
            //          orderby t.YOR descending
            //          select t;


            //display max movies acted by each actor
            //var res = from t in li
            //          group t by t.Actor into g
            //          select new { Actor = g.Key, Count = g.Count() } 
            //          into actorGroup
            //          orderby actorGroup.Count descending
            //          select actorGroup;

            //display the name of all movies which is 5 charecters long
            //var res = from t in li
            //          where t.MovieName.Length == 5
            //          select t;

            //display names of actor and actress where movie released in year 2017, 2009 and 2019
            //var res = from t in li
            //          where new[] { 2017, 2009, 2019 }.Contains(t.YOR)
            //          select new { t.Actor, t.Actress, t.YOR };

            //display the name of movies which start with 'b' and ends with 'i'
            //var res = from t in li
            //          where t.MovieName.StartsWith("B") && t.MovieName.EndsWith("i")
            //          select t;

            //display name of actress who not acted with Rajini and print in descending order
            var res = from t in li
                      where t.Actor != "Rajini"
                      orderby t.Actress descending
                      select t;

            //display records
            //var res = from t in li
            //          select t;

            foreach (var item in res)
            {
                //Console.WriteLine($"{item.MovieName}");
                //Console.WriteLine($"{item.MovieName}");
                //Console.WriteLine($"{item.MovieName}");
                //Console.WriteLine($"{item.Actress}");
                //Console.WriteLine($"{item.MovieName}");
                //Console.WriteLine($"{item.MovieName} ({item.YOR})");
                //Console.WriteLine($"{item.Actor}: {item.Count} movies");
                //Console.WriteLine($"{item.MovieName}");
                //Console.WriteLine($"{item.YOR}: {item.Actor} - {item.Actress}");
                //Console.WriteLine($"{item.MovieName}");
                Console.WriteLine($"{item.Actress}");
                //Console.WriteLine($"{item.MovieName} {item.Actor}-{item.Actress}");




            }

        }

        public void Demo2()
        {
            int[] numbers = { 1, 4, 9, 16, 25, 36 };

            var res = from t in numbers
                      where t % 2 == 0
                      select t;
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }

        public void Demo3()
        {
            string[] st = { "India", "Srilanka", "canada", "Singapore" };

            var res = st.OrderBy(s => s.Length);

            //var res = from t in st
            //          where t.Length descending
            //          select t;



            foreach (var country in res)
            {
                Console.WriteLine(country);
            }

        }
    }
}
