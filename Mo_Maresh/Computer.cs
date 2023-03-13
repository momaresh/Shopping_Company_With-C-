using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    class Computer : Product
    {
        public static int comCount = 0;
        public string? Brand { get; set; }
        public string? OS { get; set; }
        public string? Color { get; set; }
        public int StorageSize { get; set; }
        public int RamSize { get; set; }

        public Computer()
        {

        }

        public Computer(Product p, string brand, string os, string color, int storage, int ram)
        {
            base.Id = p.Id;
            base.Name = p.Name;
            base.Price = p.Price;
            base.Supplier = p.Supplier;
            base.SupDate = p.SupDate;
            base.Type = p.Type;

            this.Brand = brand;
            this.OS = os;
            this.Color = color;
            this.StorageSize = storage;
            this.RamSize = ram;  
        }

        public Computer(int id, string name, decimal price, Customer sup, string type, string brand, string os, string color, int storage, int ram)
            : base(id, name, price, sup, type)
        {
            this.Brand = brand;
            this.OS = os;
            this.Color = color;
            this.StorageSize = storage;
            this.RamSize = ram;
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
            Console.WriteLine("The Brand: " + Brand);
            Console.WriteLine("The Operating System: " + OS);
            Console.WriteLine("The Color: " + Color);
            Console.WriteLine("The Storage Size: " + StorageSize);
            Console.WriteLine("The Ram Size: " + RamSize);
        }

    }
}
