using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adonetdemo
{
    internal class Class1
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        public void demo1()
        {
            SqlConnection con = new SqlConnection("integrated security=sspi;database=moviedb;server=WKSPUN05GTR0902");



            //string command = "update testing set custname='aa' where custid=1";

            string command = "update cust set cname=@cn where cid=@cid";
            //upCmd.Parameters.Add("@Age", SqlDbType.Int, 4, "Age");
            SqlParameter p1 = new SqlParameter("@cid", SqlDbType.Int, 4, "cid");
            SqlParameter p2 = new SqlParameter("@cn", SqlDbType.VarChar, 20, "cname");

            SqlDataAdapter da = new SqlDataAdapter("Select * from cust", con);


            SqlCommand cmd = new SqlCommand(command, con);
            //  cmd.Connection = con;
            //   cmd.CommandText = command;
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            da.UpdateCommand = cmd;

            da.Fill(ds);
            dt = ds.Tables[0];
            foreach (DataRow item in dt.Rows)
            {
                Console.WriteLine(item[0].ToString() + ":" + item[1].ToString());
            }

            Console.WriteLine("enter the name");
            dt.Rows[0][0] = 1;
            dt.Rows[0][1] = Console.ReadLine();


            da.Update(dt);

            Console.WriteLine("Success");

        }

        public void demo2()
        {
            try
            {
                SqlConnection con = new SqlConnection("integrated security=sspi;database=moviedb;server=WKSPUN05GTR0902");


                //string command = "update testing set custname='aa' where custid=1";

                string command = "update cust set cname=@cn where cid=@cid and cname=@ocn";
                //upCmd.Parameters.Add("@Age", SqlDbType.Int, 4, "Age");
                SqlParameter p1 = new SqlParameter("@cid", SqlDbType.Int, 4, "cid");
                SqlParameter p2 = new SqlParameter("@cn", SqlDbType.VarChar, 20, "cname");


                SqlParameter p3 = new SqlParameter("@ocn", SqlDbType.VarChar, 12, "cname");
                p3.SourceVersion = DataRowVersion.Original;

                SqlDataAdapter da = new SqlDataAdapter("Select * from cust", con);


                SqlCommand cmd = new SqlCommand(command, con);
                //  cmd.Connection = con;
                // cmd.CommandText = command;
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);

                da.UpdateCommand = cmd;

                da.Fill(ds);
                dt = ds.Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                    Console.WriteLine(item[0].ToString() + ":" + item[1].ToString());
                }
                Console.WriteLine("enter the name");
                dt.Rows[0][0] = 1;
                dt.Rows[0][1] = Console.ReadLine();


                da.Update(dt);

                Console.WriteLine("Success");
            }
            catch (DBConcurrencyException ex)
            {
                Console.WriteLine("somebody already modified");
            }
        }

        public void demo3()
        {
            try
            {
                SqlConnection con = new SqlConnection("integrated security=sspi;database=moviedb;server=WKSPUN05GTR0902");



                //string command = "update testing set custname='aa' where custid=1";

                string command = "update cust set cname=@cn where cid=@cid and tn=@t";
                //upCmd.Parameters.Add("@Age", SqlDbType.Int, 4, "Age");
                SqlParameter p1 = new SqlParameter("@cid", SqlDbType.Int, 4, "cid");
                SqlParameter p2 = new SqlParameter("@cn", SqlDbType.VarChar, 20, "cname");


                SqlParameter p3 = new SqlParameter("@t", SqlDbType.Timestamp, 0, "tn");
                p3.SourceVersion = DataRowVersion.Original;

                SqlDataAdapter da = new SqlDataAdapter("Select * from cust", con);


                SqlCommand cmd = new SqlCommand(command, con);
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);

                da.UpdateCommand = cmd;

                da.Fill(ds);
                dt = ds.Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                    Console.WriteLine(item[0].ToString() + ":" + item[1].ToString());
                }

                Console.WriteLine("enter the name");

                dt.Rows[0][0] = 1;
                dt.Rows[0][1] = Console.ReadLine();


                da.Update(dt);

                Console.WriteLine("Success");
            }
            catch (DBConcurrencyException ex)
            {
                Console.WriteLine("somebody already modified");
            }
        }
    }
}
