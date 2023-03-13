
using Amazon;


Customer[] customers = new Customer[10];

Product[] products = new Product[10]; 

Location[] locations = new Location[10];

Book[] books = new Book[10];

Computer[] computers = new Computer[10];

Order[] orders = new Order[100];

Card[] cards = new Card[10];

Item[] items = new Item[100];

Console.WriteLine("How to use this program?!");
Console.WriteLine("The idea of this program is a shopping company,\nthat it contains a customers and this customers" +
    "\nhave some details and they live in a location. The customer can order many orders, each of these orders\n" +
    "has one customer, has a location to go to and has the card that was pay by,\n" +
    "Also we has products that this product can books or computers, each product has a supplier.\n" +
    "The order can has many products and the product can by buyed by many order, So we made the item class to implement that...");
Console.ReadKey();


int op;
do 
{
    menue:
    Console.Clear();
    Console.WriteLine("                         -----------------------------------------");
    Console.WriteLine("                         -                                       -");
    Console.WriteLine("                         ----------WELECOME TO THE MENUE----------");
    Console.WriteLine("                         -                                       -");
    Console.WriteLine("                         -----------------------------------------");
    Console.WriteLine();
    Console.WriteLine("             ---------------------------------------------------------------------");
    Console.WriteLine("             1- To add Location            --              2- To add customer");
    Console.WriteLine("             ---------------------------------------------------------------------");
    Console.WriteLine("             3- To add product             --              4- To add Credit Card");
    Console.WriteLine("             ---------------------------------------------------------------------");
    Console.WriteLine("             5- To add order               --              6- To add Item");
    Console.WriteLine("             ---------------------------------------------------------------------");
    Console.WriteLine("             7- To show the customers      --              8- To show the products");
    Console.WriteLine("             ---------------------------------------------------------------------");
    Console.WriteLine("             9- To show the orders         --              10- To show the items");
    Console.WriteLine("             ---------------------------------------------------------------------");
    Console.WriteLine("             0- To exit");
option:
    try
    {
        Console.Write("Enter option: ");
        op = int.Parse(Console.ReadLine());
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
        goto option;
        throw;
    }

    switch (op)
    {
        //--------------------------------------------------------------------------//
        case 1:
            Console.Clear();
            locations[Location.locCount] = AddClass.addLocation(locations);

            Console.WriteLine("The Location added successfuly....");
            Location.locCount++;

            Thread.Sleep(1000);

            break;

        //-----------------------------------------------------------------------------------------
        case 2:
            Console.Clear();
            customers[Customer.cusCount] = AddClass.addCustomer(customers, locations);

            Console.WriteLine("The Customer added successfuly....");
            Customer.cusCount++;

            Thread.Sleep(1000);
            break;


            //------------------------------------------------------------------------//
        case 3:

            products[Product.prodCount] = AddClass.addProduct(products, books, computers, customers, locations);
            Console.WriteLine("The Product added successfuly....");
            Product.prodCount++;

            Thread.Sleep(1000);

            break;

        //--------------------------------------------------------------------------//

        case 4:
            Console.Clear();
            cards[Card.cardCount] = AddClass.addCard(cards);
            
            Console.WriteLine("The Credit Card added successfuly....");
            Card.cardCount++;

            Thread.Sleep(1000);


            break;


        //--------------------------------------------------------------------------//
        case 5:
            Console.Clear();
            orders[Order.orderCount] = AddClass.addOrder(orders, customers, cards, locations);
            

            Console.WriteLine("The Order added successfuly....");
            Thread.Sleep(1000);

            Order.orderCount++;

            break;


        //----------------------------------------------------------------------//
        case 6:
            Console.Clear();
            Item item = AddClass.addItem(items, products, books, computers, orders, customers, cards, locations);
            if (item == null)
            {
                goto menue;
            }
            else
            {
                items[Item.itemCount] = item;
            }

            Console.WriteLine("The Item added successfuly....");
            Item.itemCount++;

            Thread.Sleep(1000);

            break;

        //--------------------------------------------------------------------------//
        case 7:
            Console.Clear();
            for (int i = 0; i < Customer.cusCount; i++)
            {
                Console.WriteLine("----------------THE INFORMATION OF THE CUSTOMER NUMBER " + (i + 1) + "-----------------");
                customers[i].printInfo();
            }
            Console.ReadKey();

            break;

        //--------------------------------------------------------------------------//
        case 8:
            Console.Clear();
            for (int i = 0; i < Product.prodCount; i++)
            {
                Console.WriteLine("----------------THE INFORMATION OF THE PRODUCT NUMBER " + (i + 1) + "-----------------");
                products[i].printInfo();
            }

            Console.ReadKey();

            break;


        //--------------------------------------------------------------------------//
        case 9:
            Console.Clear();
            for (int i = 0; i < Order.orderCount; i++)
            {
                Console.WriteLine("----------------THE INFORMATION OF THE ORDER NUMBER " + (i + 1) + "-----------------");
                orders[i].printInfo();
            }

            Console.ReadKey();

            break;

        //--------------------------------------------------------------------------//
        case 10:
            Console.Clear();
            for (int i = 0; i < Item.itemCount; i++)
            {
                Console.WriteLine("----------------THE INFORMATION OF THE ITEM NUMBER " + (i + 1) + "-----------------");
                items[i].printInfo();
            }

            Console.ReadKey();

            break;

        default:
            break;
    }

}while(op != 0);