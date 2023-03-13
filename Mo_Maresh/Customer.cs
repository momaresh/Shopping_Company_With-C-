using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    class Customer : IPrintInfo
    {
        public int Id { get; set; }
        string? email;
        string? phone;
        char? sex;
        public static int cusCount = 0;

        public Customer()
        {

        }

        public Customer(int id, string fname, string lname, string email, string phone, string nation, char sex, Location l)
        {
            Id = id;
            FirstName = fname;
            LastName = lname;
            Email = email;
            Phone = phone;
            Nationality = nation;
            Sex = sex;
            Location = l;
        }

        public string? Name { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Nationality { get; set; }
        public Location? Location { get; set; }

        public string? Email
        {
            get { return email; }
            set
            {
                int i = value.Length;
                if (value[i - 1] == 'm' && value[i - 2] == 'o' && value[i - 3] == 'c' && value[i - 4] == '.')
                {
                    email = value;
                }
                else
                {
                    Console.Write("The email Not correct, Try Agin: ");
                    Email = Console.ReadLine();
                }
            }
        }

        public string? Phone
        {
            get { return phone; }
            set
            {
                if (value[0] == '7' && (value[1] == '7' || value[1] == '3' || value[1] == '1'))
                {
                    if (value?.Length == 9)
                    {
                        foreach (char c in value)
                        {
                            if (c >= '0' && c <= '9')
                            {
                                phone += c;
                            }
                            else
                            {
                                Console.Write("The Phone number is ONLY DIGIT, try agin: ");
                                Phone = Console.ReadLine();
                            }
                        }
                    }
                    else
                    {
                        Console.Write("The Phone Number is 9 Digit, try agin: ");
                        Phone = Console.ReadLine();
                    }     
                }
                else
                {
                    Console.Write("The Phone Number is only (77, 73, 71), try agin: ");
                    Phone = Console.ReadLine();
                } 
            }
        }

        public char? Sex
        {
            get { return sex; }
            set
            {
                if(value == 'f' || value == 'F' || value == 'M' || value == 'm')
                {
                    sex = value;
                }
                else
                {
                    Console.Write("The sex is F(Female) or M(Male): Try Agin: ");
                    Sex = char.Parse(Console.ReadLine());
                }
            }
        }


        public void printInfo()
        {
            Console.WriteLine("Id: " + Id);
            Console.WriteLine("First name: " + FirstName);
            Console.WriteLine("Last name: " + LastName);
            Console.WriteLine("Email: " + Email);
            Console.WriteLine("Phone number" + Phone);
            Console.WriteLine("Nationality: " + Nationality);
            Console.WriteLine("Sex: " + Sex);
            Console.WriteLine("Location: " + Location?.Country + ", " + Location?.City + ", " + Location?.Street);
        }


    }
}
