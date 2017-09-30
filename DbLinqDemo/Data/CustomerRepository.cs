using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLinqDemo.Data
{
    public class CustomerRepository
    {
        public List<TblCustomer> GetCustomers()
        {
            var customers = new List<TblCustomer>();
            using (var db = new LinqDemoDataContext())
            {
                foreach (var customer in db.TblCustomers)
                {
                    customers.Add(customer);
                }
                return customers;
            }
        }

        public TblCustomer GetCustomer(int id)
        {
            using (var db = new LinqDemoDataContext())
            {
                return (from cc in db.TblCustomers where cc.Id == id select cc).FirstOrDefault();
            }
        }

        public void SaveCustomer(TblCustomer customer)
        {
            using (var db = new LinqDemoDataContext())
            {
                db.TblCustomers.InsertOnSubmit(customer);
                db.SubmitChanges();
            }
        }
    }
}
