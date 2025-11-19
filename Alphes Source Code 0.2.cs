using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alphes_Project_0._2
{
    internal class Program
    {
        static List<string> selectedToppings = new List<string>();
        static List<List<string>> allOrders = new List<List<string>>();

        const int PriceOmelette = 20;
        const int PriceTopping = 5;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("╔═════════════════════════════════╗ ");
                Console.WriteLine("║  WELCOME TO THE OMELETTE SHOP   ║");
                Console.WriteLine("║         By AlphesTEAM           ║");
                Console.WriteLine("╚═════════════════════════════════╝ ");
                Console.WriteLine("Please Select Menu");
                Console.WriteLine("[1] Select Orders");
                Console.WriteLine("[2] Cart");
                Console.WriteLine("[3] CheckOut");
                Console.WriteLine("[4] Cancel");
                Console.Write("Select Menu : ");
                int select = Convert.ToInt32(Console.ReadLine());

                switch (select)
                {
                    case 1: AddOders(); break;
                    case 2: ShowCart(); break;
                    case 3: CheckOut(); break;
                    case 4: Cancel(); break;
                    default:
                        Console.WriteLine("Please select 1-4 only.");
                        Console.WriteLine("(Press Enter to continue)");
                        Console.ReadLine();
                        break;
                }
            }
        }
        static void AddOders()
        {
            Console.WriteLine("====== Select Quantity ======");
            Console.WriteLine("1 piece = 20 THB");

            int Quantity = 0;
            while (Quantity <= 0)
            {
                Console.Write("Enter quantity : ");
                Quantity = Convert.ToInt32(Console.ReadLine());
                if (Quantity <= 0)
                {
                    Console.WriteLine("( Please Select 1 or more )");
                    Console.WriteLine("( Press Enter to continue )");
                    Console.ReadLine();
                }
            }

            for (int orderNum = 1; orderNum <= Quantity; orderNum++)
            {
                selectedToppings = new List<string>();

                Console.Clear();
                Console.WriteLine("======== Select Toppings ========");
                Console.WriteLine("1 topping = 5 THB");
                Console.WriteLine("( You can select up to 3 toppings )");
                Console.WriteLine("[1] Coriander");
                Console.WriteLine("[2] Chili peppers");
                Console.WriteLine("[3] Crab sticks");
                Console.WriteLine("[4] Sausage");
                Console.WriteLine("[5] Ham");
                Console.WriteLine("[6] Carrot");
                Console.WriteLine();

                int toppingCount = -1;
                while (toppingCount < 0 || toppingCount > 3)
                {
                    Console.WriteLine($"======== Order {orderNum} ========");
                    Console.Write("How many topping(s) : ");
                    toppingCount = Convert.ToInt32(Console.ReadLine());
                    if (toppingCount < 0 || toppingCount > 3)
                    {
                        Console.WriteLine("( Please select only 0-3 )");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                    }
                }

                for (int i = 1; i <= toppingCount; i++)
                {
                    int ToppingsSelect = 0;
                    while (ToppingsSelect < 1 || ToppingsSelect > 6)
                    {
                        Console.Write($"[{i}] Enter topping : ");
                        ToppingsSelect = Convert.ToInt32(Console.ReadLine());
                        if (ToppingsSelect < 1 || ToppingsSelect > 6)
                        {
                            Console.WriteLine("( Please Select Only 1-6 )");
                            Console.WriteLine("Press Enter to continue...");
                            Console.ReadLine();
                        }
                    }
                    string toppingName = "";
                    switch (ToppingsSelect)
                    {
                        case 1: toppingName = "Coriander"; break;
                        case 2: toppingName = "Chili peppers"; break;
                        case 3: toppingName = "Crab sticks"; break;
                        case 4: toppingName = "Sausage"; break;
                        case 5: toppingName = "Ham"; break;
                        case 6: toppingName = "Carrot"; break;
                    }

                    selectedToppings.Add(toppingName);
                    Console.WriteLine($"---> Added '{toppingName}'");
                }

                allOrders.Add(selectedToppings);
                Console.WriteLine("====== Added order to cart ! ======");
                Console.WriteLine("( Press Enter to continue )");
                Console.ReadLine();
            }
        }

        static void ShowCart()
        {
            Console.Clear();
            Console.WriteLine("=========== Your Cart ===========");
            if (allOrders.Count == 0)
            {
                Console.WriteLine("( No orders yet )");
            }
            else
            {
                int num = 1;
                int totalPrice = 0;

                foreach (var order in allOrders)
                {
                    int omelettePrice = PriceOmelette;
                    int toppingsPrice = order.Count * PriceTopping;
                    totalPrice += omelettePrice + toppingsPrice;

                    Console.WriteLine($"[{num}] Omelette x1             {omelettePrice} THB");
                    foreach (var t in order)
                    {
                        Console.WriteLine($"     - {t,-25}{PriceTopping} THB");
                    }
                    num++;
                }

                Console.WriteLine("=================================");
                Console.WriteLine($"Current Total : {totalPrice} THB");
            }
            Console.WriteLine("( Press Enter to continue )");
            Console.ReadLine();
        }

        static void CheckOut()
        {
            Console.Clear();
            if (allOrders.Count == 0)
            {
                Console.WriteLine("Cart is empty!");
                Console.WriteLine("( Press Enter to continue )");
                Console.ReadLine();
                return;
            }

            int totalPrice = 0;
            foreach (var order in allOrders)
            {
                totalPrice += PriceOmelette + order.Count * PriceTopping;
            }

            Console.WriteLine("====== Checkout ========");
            Console.WriteLine($"FINAL PRICE : {totalPrice} THB");
            Console.WriteLine("==== Payment Method ====");
            Console.WriteLine("[1] PromptPay");
            Console.WriteLine("[2] TrueMoney");
            Console.WriteLine("[3] PayPal");
            Console.WriteLine("[4] Cash");

            int method = 0;
            while (method < 1 || method > 4)
            {
                Console.Write("Select Method : ");
                method = Convert.ToInt32(Console.ReadLine());
                if (method < 1 || method > 4)
                {
                    Console.WriteLine("( Please select only 1-4 )");
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }
            }

            int money = 0;
            while (money < totalPrice)
            {
                Console.Write("Enter amount to be paid : ");
                money = Convert.ToInt32(Console.ReadLine());
                if (money < totalPrice)
                {
                    Console.WriteLine("Not enough money!");
                    Console.WriteLine("* Payment Incomplete *");
                    Console.WriteLine("(Press Enter to try again)");
                    Console.ReadLine();
                }
            }

            Console.WriteLine("~ Please wait while your transaction is being processed ~");
            Console.WriteLine($"Received Money : {money}");
            if (money > totalPrice)
            {
                Console.WriteLine($"Your Change : {money - totalPrice}");
            }
            Console.WriteLine("( Press Enter to continue )");
            Console.ReadLine();
            Console.WriteLine("* Payment Completed *");
            Console.WriteLine("Thank you for your order !");
            Console.WriteLine("( Press Enter to continue )");
            Console.ReadLine();

            allOrders.Clear();
        }
        static void Cancel()
        {
            Console.WriteLine("<--------- Order Has Been Cancelled -------->");
            Console.WriteLine("( Press Enter to continue )");
            Console.ReadLine();
            allOrders.Clear();
        }
    }
}
