using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    class Order
    {
        public int Id { get; set; }
        public Customer? Customer { get; set; }
        public Card? Card { get; set; }
        public Location? Location { get; set; }
        public DateTime OrderDate { get; set; }
        public static int orderCount = 0;

        public Order()
        {

        }
        public Order(int id, Customer customer, Card card, Location location)
        {
            Id = id;
            Customer = customer;
            Card = card;
            Location = location;
            OrderDate = DateTime.Now;
        }

        public void printInfo()
        {
            Console.WriteLine("----------- Order Information -------------");
            Console.WriteLine("The Order Id: " + Id);
            Console.WriteLine("The Customer Name : " + Customer?.FirstName + ' ' + Customer?.LastName);
            Console.WriteLine("The Customer email: " + Customer?.Email);
            Console.WriteLine("The Card number: " + Card?.Number);
            Console.WriteLine("The Order Location: " + Location?.Country + ' ' + Location?.City + ' ' + Location?.Street);
            Console.WriteLine("The Order Date: " + OrderDate);
        }
    }
}
