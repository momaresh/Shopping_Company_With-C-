using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    sealed class Location : IPrintInfo
    {
        public static int locCount = 0;
        public int Id { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }

        public Location()
        {

        }
        public Location(int id, string country, string city, string street)
        {
            Id = id;
            Country = country;
            City = city;
            Street = street;
        }

        public void printInfo()
        {
            Console.WriteLine("Location id: {0}, Country: {1}, City: {2}, Street: {3}", Id, Country, City, Street);
        }

    }
}
