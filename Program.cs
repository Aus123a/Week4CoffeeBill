using System;

namespace ConsoleApplication
{
    class Customer
    {
        public string Name { get; set; }
        public int NumberOfCoffeeBags { get; set; }
        public bool IsReseller { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            char choice;

            do
            {
                Customer customer = new Customer();

                Console.Write("Enter Customer Name: ");
                customer.Name = Console.ReadLine();

                customer.NumberOfCoffeeBags = GetValidCoffeeBags();

                Console.Write("Is Customer A Reseller? (y/Y For Yes): ");
                choice = Console.ReadLine().ToLower()[0];
                customer.IsReseller = (choice == 'y');

                double totalCost = CalculateBagCost(customer.NumberOfCoffeeBags);
                double discount = CalculateDiscount(totalCost, customer.IsReseller);

                PrintBill(customer, totalCost, discount);

                Console.Write("Input Y/y To Continue Or Any Other Key To Exit: ");
                choice = Console.ReadLine().ToLower()[0];
                Console.WriteLine();

            } while (choice == 'y');
        }

        static int GetValidCoffeeBags()
        {
            Console.Write("Enter Number Of Coffee Bags (1-200): ");
            int numCoffeeBags = Int32.Parse(Console.ReadLine());

            while (numCoffeeBags < 1 || numCoffeeBags > 200)
            {
                Console.WriteLine("Value Must Be Between 1 And 200!");
                Console.Write("Re-Enter Number Of Coffee Bags (1-200): ");
                numCoffeeBags = Int32.Parse(Console.ReadLine());
            }

            return numCoffeeBags;
        }

        static double CalculateBagCost(int numCoffeeBags)
        {
            if (numCoffeeBags < 6)
            {
                return numCoffeeBags * 36;
            }
            else if (numCoffeeBags < 16)
            {
                return numCoffeeBags * 34.5;
            }
            else
            {
                return numCoffeeBags * 32.7;
            }
        }

        static double CalculateDiscount(double totalCost, bool isReseller)
        {
            if (isReseller)
            {
                return totalCost * 0.20;
            }

            return 0.0;
        }

        static void PrintBill(Customer customer, double totalCost, double discount)
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("------------------- BILL -------------------");
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Customer Name: {0}", customer.Name);
            Console.WriteLine("Number Of Coffee Bags: {0}", customer.NumberOfCoffeeBags);
            Console.WriteLine("Total Cost Of Bags: {0:C}", totalCost);
            Console.WriteLine("Discount: {0:C}", discount);
            Console.WriteLine("--------------------------------------------");
            Console.WriteLine("Amount Payable: {0:C}", totalCost - discount);
            Console.WriteLine("--------------------------------------------");
        }
    }
}