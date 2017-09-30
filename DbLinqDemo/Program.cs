using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbLinqDemo.Data;

namespace DbLinqDemo
{
    public class Program
    {
        public const string CurrencyNaira = "NGN";

        public enum ProductStatus
        {
            Pending,
            Paid,
            InProgress
        }

        public static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("Attempting to save information in DB ...");
            CustomerRepository customerRepo = new CustomerRepository();
            InvoiceRepository invoiceRepo = new InvoiceRepository();
            ProductRepository productRepo = new ProductRepository();
            ;
            customerRepo.SaveCustomer(new TblCustomer()
            {
                Email = "mykeels@mailinator.com",
                Firstname = "Michael",
                Lastname = "Ikechi"
            });
            p.CreateMultipleProducts();

            invoiceRepo.SaveInvoice(new TblInvoice()
            {
                CustomerId = 1,
                ProductId = 1,
                Status = Convert.ToInt32(ProductStatus.Paid),
                CreationDate = DateTime.Now
            });

            Console.WriteLine("Customers");
            foreach (var customer in customerRepo.GetCustomers())
            {
                Console.WriteLine($"{customer.Id}\t{customer.Firstname}\t{customer.Lastname}\t{customer.Email}");
            }


            Console.WriteLine("Products");
            foreach (var product in productRepo.GetProducts())
            {
                Console.WriteLine($"{product.Id}\t{product.Name}\t{product.Currency} {product.Price}\t{product.CreationDate}");
            }

            Console.WriteLine("Invoices");
            foreach (var invoice in invoiceRepo.GetInvoices())
            {
                var customer = customerRepo.GetCustomer(invoice.CustomerId);
                var product = productRepo.GetProduct(invoice.ProductId);
                Console.WriteLine($"{invoice.Id}\t{customer.Firstname} {customer.Lastname}\t{product.Name} {((ProductStatus)invoice.Status).ToString()}\t{invoice.CreationDate}");
            }

            Console.WriteLine("Success!");
            Console.Read();
        }

        

        public void CreateMultipleProducts()
        {
            ProductRepository productRepo = new ProductRepository();
            productRepo.SaveProduct(new TblProduct()
            {
                CreationDate =  DateTime.Now,
                Currency = CurrencyNaira,
                Name = "Milo (Large)",
                Price = 700
            });
            productRepo.SaveProduct(new TblProduct()
            {
                CreationDate = DateTime.Now,
                Currency = CurrencyNaira,
                Name = "Milo (Medium)",
                Price = 400
            });
            productRepo.SaveProduct(new TblProduct()
            {
                CreationDate = DateTime.Now,
                Currency = CurrencyNaira,
                Name = "Milo (Satchet)",
                Price = 40
            });
        }

        

        
    }
}
