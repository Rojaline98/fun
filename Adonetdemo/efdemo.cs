using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adonetdemo
{
    internal class efdemo
    {
        studentsdbEntities1 dc = new studentsdbEntities1();
        Repo r = new Repo();
        public void DisplayStudents()
        {
            dc.Database.Log = Console.WriteLine;

            var res = from t in dc.students
                      select t;

            foreach (var t in res)
            {
                Console.WriteLine($"{t.studentid} {t.studentname} {t.saddress} {t.sclass}");
            }
        }

        public void DisplayStudentById()
        {

            Console.WriteLine("enter the id");
            int id = int.Parse(Console.ReadLine());

            //var res = (from t in dc.students
            //          where t.studentid == id
            //          select t).FirstOrDefault();

            var res = dc.students.Where(c => c.studentid == id).FirstOrDefault();

            
                Console.WriteLine($"{res.studentid} {res.studentname} {res.saddress} {res.sclass}");

            if(res.studentid != id)
            {
                Console.WriteLine("");
            }
            

        }

        public void AddnewStudents()
        {
            //3 steps
            //1. create object of student class
            try
            {
                student s = new student() { studentid = 7, studentname = "sriya", saddress = "puri", sclass = 6 };

                //// 2. add the object
                //dc.students.Add(s);

                //// 3. update changes
                //int i = dc.SaveChanges();
                //Console.WriteLine(i + ":record insertion success");

                r.Add(s);
            }
            catch (Exception ex)
            {
                var res = dc.GetValidationErrors();

                foreach (var item in res)
                {
                    if (item.ValidationErrors.Count > 0)
                    {
                        foreach (var err in item.ValidationErrors)
                        {
                            Console.WriteLine(err.ErrorMessage);
                        }
                    }
                }
            }
            
        }

        public void DeleteStudent()
        {
            Console.WriteLine("enter the id");
            int id = int.Parse(Console.ReadLine());

            //var res = dc.students.Where(c => c.studentid == id).FirstOrDefault();

            //dc.students.Remove(res);

            //int i = dc.SaveChanges();
            //Console.WriteLine(i + ":record deletion success");

            r.Delete<student>(id);


        }

        public void editstudent()
        {
            Console.WriteLine("enter the id");
            int id = int.Parse(Console.ReadLine());

            var res = dc.students.Where(c => c.studentid == id).FirstOrDefault();


            res.saddress = "bangalore";
            int i = dc.SaveChanges();
            Console.WriteLine(i + ":record updation success");
        }


        public void showproc()
        {
            Console.WriteLine("enter address");
            string st = Console.ReadLine();
            var res = dc.diplaystudentsbyaddress(st);

            foreach (var t in res)
            {
                Console.WriteLine($"{t.studentid} {t.studentname} {t.saddress} {t.sclass}");
            }
        }


        public void showdetails()
        {
            // code to display record from 2 tables

            //var res = from t in dc.students
            //          from t1 in dc.courses
            //          where t.studentid == t1.studentid
            //          select new { t.studentid, t.studentname, t1.coursename, t1.duration };

            var res = from t in dc.students join t1 in dc.courses
                      on t.studentid equals t1.studentid
                      select new { t.studentid, t.studentname, t1.coursename, t1.duration };


            foreach (var t in res)
            {
                Console.WriteLine($"{t.studentid} {t.studentname} {t.coursename} {t.duration}");
            }
        }
         

        public void showrecords()
        {
            dc.Database.Log = Console.WriteLine;

            var res = from t in dc.students
                      select t;

            foreach(var t in res)
            {
                Console.WriteLine($"{t.studentid} {t.studentname} ");

                    foreach(var i in t.courses)
                    {
                        Console.WriteLine($"{i.courseid} {i.coursename}");

                    }
            }

        }


    }
}
