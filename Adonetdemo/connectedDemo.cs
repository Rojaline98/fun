using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Adonetdemo
{
    internal class connectedDemo
    {


        public void Display()
        {
            SqlConnection con = new SqlConnection("integrated security=sspi;database=moviedb;server=WKSPUN05GTR0902");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from movie", con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr[0]}  {dr[1]}  {dr[2]}");

            }
            con.Close();
            // code to display records

        }

        public void DisplayByid()
        {
            Console.WriteLine("enter id");
            int i= int.Parse( Console.ReadLine() ); 
            SqlConnection con = new SqlConnection("integrated security=sspi;database=moviedb;server=WKSPUN05GTR0902");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from movie where movieid=" +1, con);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Console.WriteLine($"{dr[0]} {dr[1]}  {dr[2]} ");

            }
            con.Close();
            // code to display records
        }

        public void AddRecords()
        {
            SqlConnection con = new SqlConnection("integrated security=sspi;database=moviedb;server=WKSPUN05GTR0902");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into movie values(4,'rrr','ramcharan','alia',70000)", con);
            int i = cmd.ExecuteNonQuery();
            Console.WriteLine("total record inserted is " + i);
            con.Close();



        }

        public void UpdateRecords()
        {

            SqlConnection con = new SqlConnection("integrated security=sspi;database=moviedb;server=WKSPUN05GTR0902");
            con.Open();
            SqlCommand cmd = new SqlCommand("update movie set budget=90000 where movieid=1", con);
            int i = cmd.ExecuteNonQuery();
            Console.WriteLine("total record updated is " + i);
            con.Close();

        }

        public void RemoveRecords()
        {

            SqlConnection con = new SqlConnection("integrated security=sspi;database=moviedb;server=WKSPUN05GTR0902");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from movie where movieid=4", con);
            int i = cmd.ExecuteNonQuery();
            Console.WriteLine("total record deleted is " + i);
            con.Close();
        }

    }
}
