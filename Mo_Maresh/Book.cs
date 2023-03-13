using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    class Book : Product
    {
        public static int bookCount = 0;
        public string? Author { get; set; }
        public string? Language { get; set; }
        public int Pages { get; set; }
        public string? Category { get; set; }

        public Book()
        {

        }

        public Book(Product p, string author, string lang, int pages, string cat)
        {
            base.Id = p.Id;
            base.Name = p.Name;
            base.Price = p.Price;
            base.Supplier = p.Supplier;
            base.SupDate = p.SupDate;
            base.Type = p.Type;

            this.Author = author;
            this.Language = lang;
            this.Pages = pages;
            this.Category = cat;
        }

        public Book(int id, string name, decimal price, Customer sup, string type, string author, string lang, int pages, string cat) 
            :base (id, name, price, sup, type)
        {
            this.Author = author;
            this.Language = lang;
            this.Pages = pages;
            this.Category = cat;
        }

        public override void printInfo()
        {
            Console.WriteLine("Product id: " + Id);
            Console.WriteLine("Product name: " + Name);
            Console.WriteLine("Product price: " + Price);
            Console.WriteLine("Supplier name: " + Supplier?.FirstName + ' ' + Supplier?.LastName);
            Console.WriteLine("Supplier email: " + Supplier?.Email);
            Console.WriteLine("Supplied Date: " + SupDate);
            Console.WriteLine("Product type: " + Type);
            Console.WriteLine("The author: " + Author);
            Console.WriteLine("The language: " + Language);
            Console.WriteLine("The pages: " + Pages);
            Console.WriteLine("The category: " + Category);
        }

    }
}
