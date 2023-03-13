using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    abstract class Product: IPrintInfo
    {
        public static int prodCount = 0;
        string? type;
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public Customer? Supplier { get; set; }
        public DateTime SupDate { get; set; }
        public string? Type
        {
            get { return type; }
            set
            {
                if (value == "book" || value == "computer")
                {
                    type = value;
                }
                else
                {
                    Console.Write("The Product Type Is book or computer, Try Agin: ");
                    Type = Console.ReadLine();
                }
            }
        }

        public Product()
        {
            SupDate = DateTime.Now;
        }
        public Product(int id, string name, decimal price, Customer sup, string type)
        {
            Id = id;
            Name = name;
            Price = price;
            Supplier = sup;
            SupDate = DateTime.Today;
            Type = type;
        }

        public abstract void printInfo();
    }
}
