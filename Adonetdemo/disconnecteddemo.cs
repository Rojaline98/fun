using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Adonetdemo
{
    internal class disconnecteddemo
    {
        DataSet ds = new DataSet();// store the result
        DataTable dt = new DataTable();
        SqlDataAdapter da;
        SqlConnection con;

        public void displaymovies()
        {
         con = new SqlConnection("integrated security=sspi;database=moviedb;server=WKSPUN05GTR0902");

         da = new SqlDataAdapter("Select * from movie", con);

            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;

            SqlCommandBuilder s = new SqlCommandBuilder(da);
            //store output in dataset
            da.Fill(ds, "m");

            //print output

            
            dt = ds.Tables["m"];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Console.WriteLine(dt.Rows[i][0]);
                Console.WriteLine(dt.Rows[i][1]);
                Console.WriteLine(dt.Rows[i][2]);
                Console.WriteLine(dt.Rows[i][3]);
                
            }
            Console.WriteLine("total number of rows " + dt.Rows.Count);



        }

        public void Search()
        {
            //logic to search a record by id 
            Console.WriteLine("enter the id");
            int id = int.Parse(Console.ReadLine());
            DataRow dr = dt.Rows.Find(id);

            Console.WriteLine(dr[0]);
            Console.WriteLine(dr[1]);
            Console.WriteLine(dr[2]);
            Console.WriteLine(dr[3]);
        }

        public void Add()
        {
            dt.Rows.Add(12, "cc", "risabh", "abc", 90000);

            dt.AcceptChanges();
            dt.Rows.Add(10, "aa", "amir", "kareena", 70000);
            dt.Rows.Add(11, "bb", "risabh", "abc", 90000);


            int i = da.Update(dt);
            Console.WriteLine("total rows inserted is " + i);

        }

        public void Delete()
        {
            Console.WriteLine("enter the id");
            int id = int.Parse(Console.ReadLine());
            DataRow dr = dt.Rows.Find(id);
            dr.Delete();

            int i = da.Update(dt);
            Console.WriteLine("total rows deleted is " + i);

        }

        public void FilterRecords()
        {
            DataView dv = new DataView(dt);
            //dv.RowFilter = "budget > 10000 and moviename='kgf'";

            dv.RowFilter = "moviename like 'k%'";

            foreach(DataRowView d in dv)
            {
                Console.WriteLine(d[0]);
                Console.WriteLine(d[1]);
                Console.WriteLine(d[2]);
                Console.WriteLine(d[4]);
            }

        }

        public void xmldata()
        {
            //code to create xml file
            //ds.WriteXml("C:\\Users\\rojaline.chhotara\\source\\repos\\Adonetdemo\\Adonetdemo\\movie.xml");

            // code to create xml file with tracking support
            dt.Rows.Add(7, "robot", "rajini", "aish", 90000);
            
            ds.WriteXml("C:\\Users\\rojaline.chhotara\\source\\repos\\Adonetdemo\\Adonetdemo\\movie.xml",XmlWriteMode.DiffGram);
            Console.WriteLine("file created successfully");
        }

        public void Concurrent()
        {

        }
    }
}
