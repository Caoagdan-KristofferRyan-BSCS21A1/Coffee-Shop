using System;
using System.Collections.Generic;

class CaoagdanCoffeeShop
{
    static List<(string item, double price)> menu = new List<(string, double)>();
    static List<(string item, double price)> order = new List<(string, double)>();

    static void Main()
    {

        static void AddItem()
        {
            Console.WriteLine(" ");
            Console.Write("Enter item name: ");
            string item = Console.ReadLine();
            Console.Write("Enter item price: ");
            double price = Convert.ToDouble(Console.ReadLine());

            menu.Add((item, price));
            Console.WriteLine(" ");
            Console.WriteLine("Item added successfully!");
            Console.WriteLine(" - - - - - - - - - -");
        }


        static void ViewMenu()
        {
            if (menu.Count == 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Menu is empty.");
                Console.WriteLine(" - - - - - - - - - -");
                return;
            }

            Console.WriteLine("Menu:");
            for (int i = 0; i < menu.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {menu[i].item} - ${menu[i].price}");
            }
        }


        static void PlaceOrder()
        {
            if (menu.Count == 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine("No items in the menu to order from.");
                Console.WriteLine(" - - - - - - - - - -");
                return;
            }

            ViewMenu();
            Console.WriteLine(" ");
            Console.Write("Enter the item number to order: ");
            int itemNum = Convert.ToInt32(Console.ReadLine());

            if (itemNum > 0 && itemNum <= menu.Count)
            {
                order.Add(menu[itemNum - 1]);
                Console.WriteLine(" ");
                Console.WriteLine("Item added to order!");
                Console.WriteLine(" - - - - - - - - - -");
            }
            else
            {
                Console.WriteLine(" ");
                Console.WriteLine("Invalid item number.");
            }
        }


        static void ViewOrder()
        {
            if (order.Count == 0)
            {
                Console.WriteLine(" ");
                Console.WriteLine("Your order is empty.");
                Console.WriteLine(" - - - - - - - - - -");
                return;
            }

            Console.WriteLine(" ");
            Console.WriteLine("Your Order:");
            foreach (var items in order)
            {
                Console.WriteLine($"{items.item} - ${items.price}");
            }
        }


        bool running = true;
        while (running)
        {

            Console.WriteLine("~ ~ Welcome to the Coffee Shop! ~ ~");
            Console.WriteLine(" ");
            Console.WriteLine("1. Add Menu Item");
            Console.WriteLine("2. View Menu");
            Console.WriteLine("3. Place Order");
            Console.WriteLine("4. View Order");
            Console.WriteLine("5. Calculate Total");
            Console.WriteLine("6. Exit");
            Console.WriteLine(" ");
            Console.Write("Select an option: ");
            string option = Console.ReadLine();

            if (option == "1")
            {
                AddItem();
            }
            else if (option == "2")
            {
                ViewMenu();
            }
            else if (option == "3")
            {
                PlaceOrder();
            }
            else if (option == "4")
            {
                ViewOrder();
            }
            else if (option == "5")
            {
                CalculateTotal();
            }
            else if (option == "6")
            {
                running = false;
                Console.WriteLine(" ");
                Console.WriteLine("Come Again Soon!");
            }
            else
            {
                Console.WriteLine("Invalid option, try again.");
            }

            Console.WriteLine();
        }
    }

    static void CalculateTotal()
    {
        if (order.Count == 0)
        {
            Console.WriteLine("No items in the order to calculate.");
            return;
        }

        double total = 0;
        foreach (var items in order)
        {
            total += items.price;
        }

        Console.WriteLine($"Total Amount Payable: ${total}");
    }
}