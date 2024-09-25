using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIAssignment
{
    internal class ICustomer
    {
        ICustomers ic;
        studentsdbEntities dc = new studentsdbEntities();
        public ICustomer(ICustomers ic1)
        {
            ic = ic1;
        }
        public void show()
        {

            ic.ShowAllCustomers(dc.customers);
            ic.ShowByid(1);
            ic.DeleteCustomer(10);
            ic.AddCustomer(new customer
            {
                custid = 10,
                custname = "Rojaline"
            });
        }
    }
}
