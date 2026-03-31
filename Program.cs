using System;
using System.Collections.Generic;

namespace ArtStore
{
    class Program
    {
        //-----------------   MAIN   ----------------
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            ArtItem[] inventory = {
                new ArtItem("Acrylic Paint Set", 25.50),
                new ArtItem("Sketchbook", 12.00),
                new ArtItem("Sable Brush", 8.75),
                new ArtItem("Oil Pastels", 15.20)
            };

            Console.WriteLine("\t--- Welcome to Palette & Parchment! ---");

            List<ArtItem> cart = new List<ArtItem>();
            string receiptSummary = "";
            bool shopping = true;

            while (shopping)
            {
                //-----------------   INVENTORY   ------------------
                Console.WriteLine("\n--- Available Items ---");
                for (int i = 0; i < inventory.Length; i++)
                {
                    Console.WriteLine($"{i + 1}. {inventory[i].Name} ({inventory[i].Price:C})");
                }

                Console.Write("\nEnter item ID to buy (0 to checkout): ");
                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("ERROR: Please enter a valid number ID!");
                    continue;
                }

                if (choice == 0)
                {
                    shopping = false;
                }
                else if (choice > 0 && choice <= inventory.Length)
                {
                    ArtItem selected = inventory[choice - 1];
                    Console.Write($"How many {selected.Name}s? ");
                    int.TryParse(Console.ReadLine(), out int qty);

                    double lineTotal = selected.Price * qty;
                    receiptSummary += $"- {selected.Name} x{qty} ({lineTotal:C})\n";

                    // Add to cart
                    for (int j = 0; j < qty; j++) { cart.Add(selected); }
                    Console.WriteLine($"Added to cart!");
                }
                else
                {
                    Console.WriteLine($"ERROR: ID {choice} doesn't exist. Check the list above!");
                }
            }

            //-----------------   DISCOUNTS   -----------------
            double total = 0;
            foreach (var item in cart) total += item.Price;

            Console.WriteLine("\n\t--- Your Receipt ---");
            Console.WriteLine(receiptSummary);

            if (total >= 50.00)
            {
                double savings = total * 0.10;
                total -= savings;
                Console.WriteLine($"--- 10% Member Discount: -{savings:C} ---");
            }

            Console.WriteLine($"Grand Total: {total:C}");
        }
    }

    class ArtItem
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public ArtItem(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}