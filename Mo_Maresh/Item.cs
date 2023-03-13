using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    class Item : IPrintInfo, IAmount
    {
        public static int itemCount = 0;
        float discount = 0;
        public Order? Order { get; set; }
        public Product? Product { get; set; }
        public decimal Quantity { get; set; } 
        public float Discount
        {
            get { return discount; }
            set 
            { 
                if(Quantity >= 5)
                {
                    if(value >= 0 && value < 0.05)
                    {
                        discount = value;
                    }
                    else
                    {
                        Console.WriteLine("WE CAN NOT MAKE DISCOUNT MORE THAN 5%");
                    }
                }
                else
                {
                    if(value > 0)
                        Console.WriteLine("WE CAN NOT MAKE A DISCOUNT FOR YOU ORDER MORE THAN 5 TO GET DICOUNT...");
                }
            }
        }


        public decimal getAmount()
        {
            return Convert.ToDecimal((Quantity * Product?.Price) - (Quantity * Product?.Price) * Convert.ToDecimal(Discount));
        }

        public bool checkAmount()
        {
            if(Order?.Card?.Amount >= getAmount())
            {
                return true;
            }
            return false;
        }

        public void takeAmount()
        {
            Order.Card.Amount -= getAmount(); 
        }

        public void printInfo()
        {
            Console.WriteLine("The Order Id: " + Order?.Id);
            Console.WriteLine("The Customer Of The Order: " + Order?.Customer?.FirstName + ' ' + Order?.Customer?.LastName);
            Console.WriteLine("The Product Name: " + Product?.Name);
            Console.WriteLine("The Product Price: " + Product?.Price);
            Console.WriteLine("The Product Type: " + Product?.Type);
            Console.WriteLine("The Quantity Of The Item: " + Quantity);
            Console.WriteLine("The Total Price Of The Item: " + getAmount());
        }
    }
}
