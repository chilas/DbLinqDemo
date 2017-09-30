using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLinqDemo.Data
{
    public class ProductRepository
    {
        public void SaveProduct(TblProduct product)
        {
            using (var db = new LinqDemoDataContext())
            {
                db.TblProducts.InsertOnSubmit(product);
                db.SubmitChanges();
            }
        }

        public List<TblProduct> GetProducts()
        {
            var products = new List<TblProduct>();
            using (var db = new LinqDemoDataContext())
            {
                foreach (var product in db.TblProducts)
                {
                    products.Add(product);
                }
                return products;
            }
        }

        public TblProduct GetProduct(int id)
        {
            using (var db = new LinqDemoDataContext())
            {
                return (from pp in db.TblProducts where pp.Id == id select pp).FirstOrDefault();
            }
        }
    }
}
