using System;

class Program
{
    static void Main()
    {
        // Create addresses
        Address addr1 = new Address("721 S 100 E", "Kalispell", "MT", "USA");
        Address addr2 = new Address("3241 Zeus Dr", "Herriman", "UT", "Canada");
        Address addr3 = new Address("8851 Sandy Prkwy", "Sandy", "ID", "Canada");
        Address addr4 = new Address("12812 Palermo St", "Columbia Falls", "WA", "USA");

        // Create customers
        Customer cust1 = new Customer("Crystal Nuff", addr1);
        Customer cust2 = new Customer("Robert Reed", addr2);
        Customer cust3 = new Customer("Annie Smith", addr3);
        Customer cust4 = new Customer("Stormie Dawn", addr4);

        // Create orders
        Order order1 = new Order(cust1);
        order1.AddProduct(new Product("Wireless Mouse", "WM123", 65.99, 2));
        order1.AddProduct(new Product("Keyboard", "KB456", 78.00, 1));

        Order order2 = new Order(cust2);
        order2.AddProduct(new Product("USB-C Cable", "UC789", 4.99, 3));
        order2.AddProduct(new Product("Laptop Stand", "LS321", 45.99, 1));

        Order order3 = new Order(cust3);
        order3.AddProduct(new Product("Trick or Treat Candy", "C3254", 14.99, 3));
        order3.AddProduct(new Product("Caldron Candy Bowl", "H86409", 19.99, 1));
        order3.AddProduct(new Product("Halloween Witch Hat", "WE5R49", 20.99, 3));

        Order order4 = new Order(cust4);
        order4.AddProduct(new Product("Dog Food Extra Protein", "HH8796", 79.99, 1));
        order4.AddProduct(new Product("Chewy treats - Dog Bones", "B3220", 49.99, 2));

        // Display order details
        DisplayOrder(order1);
        Console.WriteLine();
        DisplayOrder(order2);
        Console.WriteLine();
        DisplayOrder(order3);
        Console.WriteLine();
        DisplayOrder(order4);
    }

    static void DisplayOrder(Order order)
    {
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order.GetTotalPrice():0.00}");
    }
}