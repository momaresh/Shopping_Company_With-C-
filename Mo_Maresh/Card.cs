using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    sealed class Card : IPrintInfo
    {
        public static int cardCount = 0;
        string? number;
        string? type;

        public Card()
        {

        }
        public Card(int id, string? number, string? type, decimal amount, DateOnly expireDate)
        {
            Id = id;
            Number = number;
            Type = type;
            Amount = amount;
            ExpireDate = expireDate;
        }
        
        public int Id { get; set; }
        public string? Number
        {
            get { return number; }
            set
            {
                if (value.Length == 16)
                {
                    bool found = false;
                    foreach (char c in value)
                    {
                        if (char.IsDigit(c))
                        {
                            continue;
                        }
                        else
                        {
                            found = true;
                            break;
                        }
                    }

                    if (!found)
                    {
                        number = value;
                    }
                    else
                    {
                        Console.Write("The Number is ONLY DIGIT, Try Agin: ");
                        Number = Console.ReadLine();
                    }
                }
                else
                {
                    Console.Write("The Number is 16 Digit, Try Agin: ");
                    Number = Console.ReadLine();
                }
            }
        }
        public string? Type
        {
            get { return type; }
            set
            {
                if(value == "Visa" || value == "Master" || value == "PayPal")
                {
                    type = value;
                }
                else
                {
                    Console.Write("The type is (Visa, Master, PayPal), Try Agin: ");
                    Type = Console.ReadLine();
                }
            }
        }
        public decimal Amount { get; set; }
        public DateOnly ExpireDate { get; set; }

        public void printInfo()
        {
            Console.WriteLine("------------ CARD INFORMATION ------------");
            Console.WriteLine("The card Id: " + Id);
            Console.WriteLine("The card number: " + Number);
            Console.WriteLine("The card type: " + Type);
            Console.WriteLine("The card amount: " + Amount);
            Console.WriteLine("The card expire date: " + ExpireDate);
        }

    }
}
