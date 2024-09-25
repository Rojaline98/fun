using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DIAssignment.CustomerServices;

namespace DIAssignment
{
    
        interface ICustomers
        {
            IList<customer> ShowAllCustomers(DbSet table);
            customer ShowByid(int id);
            int DeleteCustomer(int id);
            int AddCustomer(customer custobj);
        }
        internal class CustomerServices : ICustomers
        {
            studentsdbEntities dc = new studentsdbEntities();
            CustomerRepository cr = new CustomerRepository();
            public int AddCustomer(customer c)
            {
                return cr.AddCustomer(c);
            }

            public int DeleteCustomer(int id)
            {
                return cr.DeleteById<customer>(id);
            }

            public IList<customer> ShowAllCustomers(DbSet table)
            {
                return cr.ShowAllCustomer(dc.customers);
            }

            public customer ShowByid(int id)
            {
                return cr.ShowById<customer>(id);
            }
        }
}

    
    




    

