using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Amazon
{
    static class AddClass
    {

        public static Location addLocation(Location[] loc)
        {
            int locationId;
            string country;
            string city;
            string street;
        locId:
            try
            {
                Console.Write("Enter The location id: ");
                locationId = int.Parse(Console.ReadLine());
                for (int i = 0; i < Location.locCount; i++)
                {
                    if (loc[i].Id == locationId)
                    {
                        Console.Write("The location id already exists, Try Agin: ");
                        goto locId;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto locId;
                throw;
            }

            Console.Write("Enter the country: ");
            country = Console.ReadLine();

            Console.Write("Enter the city: ");
            city = Console.ReadLine();

            Console.Write("Enter the street: ");
            street = Console.ReadLine();

            Location location = new Location(locationId, country, city, street);

            return location;
        }

        public static Customer addCustomer(Customer[] customers, Location[] locations)
        {
            Customer customer = new Customer();

        cusId:
            try
            {
                Console.Write("Enter the customer Id: ");
                customer.Id = int.Parse(Console.ReadLine());
                for (int i = 0; i < Customer.cusCount; i++)
                {
                    if (customers[i].Id == customer.Id)
                    {
                        Console.Write("The Customer id already exists, Try Agin: ");
                        goto cusId;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto cusId;
                throw;
            }

            Console.Write("Enter the customer first name: ");
            customer.FirstName = Console.ReadLine();

            Console.Write("Enter the customer last name: ");
            customer.LastName = Console.ReadLine();

        email:
            try
            {
                Console.Write("Enter the customer email: ");
                customer.Email = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto email;
                throw;
            }

        phone:
            try
            {
                Console.Write("Enter the customer phone number: ");
                customer.Phone = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto phone;
                throw;
            }

            Console.Write("Enter the customer Nationality: ");
            customer.Nationality = Console.ReadLine();

        cusSex:
            try
            {
                Console.Write("Enter the customer sex: ");
                customer.Sex = char.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto cusSex;
                throw;
            }

        cusLocId:
            int locId;
            try
            {
                Console.Write("Enter the customer Location id: ");
                locId = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto cusLocId;
                throw;
            }
            if (Location.locCount == 0)
            {
                char ch;
                Console.Write("You don not have any location yet, Do you want to add a location(y, n)?: ");
                ch = char.Parse(Console.ReadLine());

                if (ch == 'y')
                {
                    locations[Location.locCount] = addLocation(locations);
                    customer.Location = locations[Location.locCount];
                    Location.locCount++;
                    Console.WriteLine("The location added successfully...");
                }
                else
                {
                    goto cusLocId;
                }

            }
            else
            {
                bool found = false;
                for (int i = 0; i < Location.locCount; i++)
                {
                    if (locations[i].Id == locId)
                    {
                        customer.Location = locations[i];
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("The Location Not Found....");
                    goto cusLocId;
                }
            }
            return customer;
        }

        public static Product addProduct(Product[] products, Book[] books, Computer[] computers, Customer[] customers, Location[] locations)
        {
            Product product = null;

            int prodId;
            string prodName;
            decimal price;
            int supId;
            string type;
            Customer supplier = new Customer();

        prodId:
            Console.Clear();
            try
            {
                Console.Write("Enter the product id: ");
                prodId = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto prodId;
                throw;
            }

            for (int i = 0; i < Product.prodCount; i++)
            {
                if (products[i].Id == prodId)
                {
                    Console.Write("The product id already exists, Try Agin: ");
                    goto prodId;
                }
            }

            Console.Write("Enter the product name: ");
            prodName = Console.ReadLine();

        prodPrice:
            try
            {
                Console.Write("Enthe the product price: ");
                price = decimal.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto prodPrice;
                throw;
            }

        supId:
            try
            {
                Console.Write("Enter the supplier Id: ");
                supId = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto supId;
                throw;
            }

            if (Customer.cusCount == 0)
            {
                char ch;
                Console.Write("You don not have any supplier yet, Do you want to add a supplier(y, n)?: ");
                ch = char.Parse(Console.ReadLine());

                if (ch == 'y')
                {
                    customers[Customer.cusCount] = addCustomer(customers, locations);
                    supplier = customers[Customer.cusCount];
                    Customer.cusCount++;
                    Console.WriteLine("The supplier added successfully, continue to product...");
                }
                else
                {
                    goto supId;
                }
            }
            else
            {
                bool foundSup = false;
                for (int i = 0; i < Customer.cusCount; i++)
                {
                    if (customers[i].Id == supId)
                    {
                        supplier = customers[i];
                        foundSup = true;
                        break;
                    }
                }
                if (!foundSup)
                {
                    Console.WriteLine("The Supplier Not Found....");
                    goto supId;
                }
            }
        type:
            Console.Write("Enter the type of the product: ");
            type = Console.ReadLine();
            while (type != "book" && type != "computer")
            {
                Console.WriteLine("The Type is (book, computer), Try Agin: ");
                goto type;
            }


            if (type == "book")
            {
                Book book = new Book();

                string author;
                string lang;
                int pages;
                string cat;

                book.Id = prodId;
                book.Name = prodName;
                book.Price = price;
                book.Supplier = supplier;
                book.Type = type;

                Console.Write("Enter the author: ");
                book.Author = Console.ReadLine();

                Console.Write("Enter the language: ");
                book.Language = Console.ReadLine();

            bookPage:
                try
                {
                    Console.Write("Enter the number of the pages: ");
                    book.Pages = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    goto bookPage;
                    throw;
                }

                Console.Write("Enter the category: ");
                book.Category = Console.ReadLine();



                books[Book.bookCount] = book;
                Book.bookCount++;

                product = book;
            }

            else if (type == "computer")
            {
                string brand;
                string os;
                string color;
                int storage;
                int ram;

                Console.Write("Enter the brand: ");
                brand = Console.ReadLine();

                Console.Write("Enter the operating system: ");
                os = Console.ReadLine();

                Console.Write("Enter the color: ");
                color = Console.ReadLine();

            comStorage:
                try
                {
                    Console.Write("Enter the storage size: ");
                    storage = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    goto comStorage;
                    throw;
                }

            comRam:
                try
                {
                    Console.Write("Enter the ram size: ");
                    ram = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    goto comRam;
                    throw;
                }

                computers[Computer.comCount] = new Computer(prodId, prodName, price, supplier, type, brand, os, color, storage, ram);

                product = computers[Computer.comCount];
                Computer.comCount++;
            }

            return product;
        }

        public static Card addCard(Card[] cards)
        {
            Card card = new Card();

        cardId:
            try
            {
                Console.Write("Enter The card id: ");
                card.Id = int.Parse(Console.ReadLine());
                for (int i = 0; i < Card.cardCount; i++)
                {
                    if (cards[i].Id == card.Id)
                    {
                        Console.Write("The card id already exists, Try Agin: ");
                        goto cardId;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto cardId;
                throw;
            }

            Console.Write("Enter the card number: ");
            card.Number = Console.ReadLine();

            Console.Write("Enter the Type: ");
            card.Type = Console.ReadLine();

        amount:
            try
            {
                Console.Write("Enter the amount: ");
                card.Amount = decimal.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto amount;
                throw;
            }

        expire:
            try
            {
                Console.Write("Enter The expire date: ");
                card.ExpireDate = DateOnly.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto expire;
                throw;
            }

            return card;
        }

        public static Order addOrder(Order[] orders, Customer[] customers, Card[] cards, Location[] locations)
        {
            Order order = new Order();
            int orderCusId;
            int orderCardId;
            int orderLocId;

        orderId:
            try
            {
                Console.Write("Enter The Order Id: ");
                order.Id = int.Parse(Console.ReadLine());
                for (int i = 0; i < Order.orderCount; i++)
                {
                    if (orders[i].Id == order.Id)
                    {
                        Console.Write("The order id already exists, Try Agin: ");
                        goto orderId;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto orderId;
                throw;
            }

        orderCusId:
            try
            {
                Console.Write("Enter The Customer Id: ");
                orderCusId = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto orderCusId;
                throw;
            }

            if (Customer.cusCount == 0)
            {
                char ch;
                Console.Write("You don not have any customer yet, Do you want to add a customer(y, n)?: ");
                ch = char.Parse(Console.ReadLine());

                if (ch == 'y')
                {
                    customers[Customer.cusCount] = addCustomer(customers, locations);
                    order.Customer = customers[Customer.cusCount];
                    Customer.cusCount++;
                    Console.WriteLine("The customer added successfully, continue to order...");
                }
                else
                {
                    goto orderCusId;
                }
            }
            else
            {
                bool foundOrderCus = false;
                for (int i = 0; i < Customer.cusCount; i++)
                {
                    if (customers[i].Id == orderCusId)
                    {
                        order.Customer = customers[i];
                        foundOrderCus = true;
                        break;
                    }
                }
                if (!foundOrderCus)
                {
                    Console.WriteLine("The Customer not found, Try Agin...");
                    goto orderCusId;
                }
            }

        orderCardId:
            try
            {
                Console.Write("Enter The Card Id: ");
                orderCardId = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto orderCardId;
                throw;
            }

            if (Card.cardCount == 0)
            {
                char ch;
                Console.Write("You don not have any Credit card yet, Do you want to add a card(y, n)?: ");
                ch = char.Parse(Console.ReadLine());

                if (ch == 'y')
                {
                    cards[Card.cardCount] = addCard(cards);
                    order.Card = cards[Card.cardCount];
                    Card.cardCount++;
                    Console.WriteLine("The card added successfully, continue to order...");
                }
                else
                {
                    goto orderCardId;
                }
            }
            else
            {
                bool foundOrderCard = false;
                for (int i = 0; i < Card.cardCount; i++)
                {
                    if (cards[i].Id == orderCardId)
                    {
                        order.Card = cards[i];
                        foundOrderCard = true;
                        break;
                    }
                }
                if (!foundOrderCard)
                {
                    Console.WriteLine("The Card not found, Try Agin...");
                    goto orderCardId;
                }
            }


        orderLocId:
            try
            {
                Console.Write("Enter The Location Id: ");
                orderLocId = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto orderLocId;
                throw;
            }
            
            if (Location.locCount == 0)
            {
                char ch;
                Console.Write("You don not have any location yet, Do you want to add a location(y, n)?: ");
                ch = char.Parse(Console.ReadLine());

                if (ch == 'y')
                {
                    locations[Location.locCount] = addLocation(locations);
                    order.Location = locations[Location.locCount];
                    Location.locCount++;
                    Console.WriteLine("The location added successfully, continue to order...");
                }
                else
                {
                    goto orderLocId;
                }
            }
            else
            {
                bool foundOrderLoc = false;
                for (int i = 0; i < Location.locCount; i++)
                {
                    if (locations[i].Id == orderLocId)
                    {
                        order.Location = locations[i];
                        foundOrderLoc = true;
                        break;
                    }
                }
                if (!foundOrderLoc)
                {
                    Console.WriteLine("The Location not found, Try Agin...");
                    goto orderLocId;
                }
            }

            order.OrderDate = DateTime.Now;

            return order;
        }

        public static Item addItem(Item[] items, Product[] products, Book[] books, Computer[] computers,Order[] orders, Customer[] customers, Card[] cards, Location[] locations)
        {
            Item item = new Item();

            int itemOrderId;
            int itemProdId;

        itemOrderId:
            try
            {
                Console.Write("Enter the Order Id: ");
                itemOrderId = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto itemOrderId;
                throw;
            }

            if (Order.orderCount == 0)
            {
                char ch;
                Console.Write("You don not have any order yet, Do you want to add an order(y, n)?: ");
                ch = char.Parse(Console.ReadLine());

                if (ch == 'y')
                {
                    orders[Order.orderCount] = addOrder(orders, customers, cards, locations);
                    item.Order = orders[Order.orderCount];
                    Order.orderCount++;
                    Console.WriteLine("The order added successfully, continue to item...");
                }
                else
                {
                    goto itemOrderId;
                }
            }
            else
            {
                bool foundItemOrder = false;
                for (int i = 0; i < Order.orderCount; i++)
                {
                    if (orders[i].Id == itemOrderId)
                    {
                        item.Order = orders[i];
                        foundItemOrder = true;
                        break;
                    }
                }
                if (!foundItemOrder)
                {
                    Console.WriteLine("The Order not found, Try Agin...");
                    goto itemOrderId;
                }
            }


        itemProdId:
            try
            {
                Console.Write("Enter the Product Id: ");
                itemProdId = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto itemProdId;
                throw;
            }

            if (Product.prodCount == 0)
            {
                char ch;
                Console.Write("You don not have any product yet, Do you want to add a product(y, n)?: ");
                ch = char.Parse(Console.ReadLine());

                if (ch == 'y')
                {
                    products[Product.prodCount] = addProduct(products, books, computers, customers, locations);
                    item.Product = products[Product.prodCount];
                    Product.prodCount++;
                    Console.WriteLine("The product added successfully, continue to item...");
                }
                else
                {
                    goto itemProdId;
                }
            }
            else
            {
                bool foundItemProd = false;
                for (int i = 0; i < Product.prodCount; i++)
                {
                    if (products[i].Id == itemProdId)
                    {
                        foundItemProd = true;

                        foreach (var it in items)
                        {
                           
                            if ((it?.Order?.Id == itemOrderId) && (it?.Product?.Id == itemProdId))
                            {
                                Console.WriteLine("The order is exists with the same product...");
                                goto itemProdId;
                            }
                            else
                            {
                                item.Product = products[i];
                                continue;
                            }
                        }
                    }
                }
                if (!foundItemProd)
                {
                    Console.WriteLine("The Product not found, Try Agin...");
                    goto itemProdId;
                }
            }

        quantity:
            try
            {
                Console.Write("Enter the quantity: ");
                item.Quantity = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto quantity;
                throw;
            }

        discount:
            try
            {
                Console.Write("Enter the Discount: ");
                item.Discount = float.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                goto discount;
                throw;
            }

            if (item.checkAmount())
            {
                item.takeAmount();
            }
            else
            {
                Console.WriteLine("The Amount Not Enought....");
                Console.ReadKey();

                return null;
            }

            return item;
        }
    }
}
