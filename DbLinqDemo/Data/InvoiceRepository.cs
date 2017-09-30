using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLinqDemo.Data
{
    public class InvoiceRepository
    {
        public void SaveInvoice(TblInvoice invoice)
        {
            using (var db = new LinqDemoDataContext())
            {
                db.TblInvoices.InsertOnSubmit(invoice);
                db.SubmitChanges();
            }
        }

        public List<TblInvoice> GetInvoices()
        {
            var invoices = new List<TblInvoice>();
            using (var db = new LinqDemoDataContext())
            {
                foreach (var invoice in db.TblInvoices)
                {
                    invoices.Add(invoice);
                }
                return invoices;
            }
        }

        public TblInvoice GetInvoice(int id)
        {
            using (var db = new LinqDemoDataContext())
            {
                return (from ii in db.TblInvoices where ii.Id == id select ii).FirstOrDefault();
            }
        }
    }
}
