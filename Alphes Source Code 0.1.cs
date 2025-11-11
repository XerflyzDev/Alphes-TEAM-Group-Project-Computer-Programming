static List<string> selectedToppings = new List<string>();

const int PriceOmelette = 35;
static int totalQuantity = 0;
static int totalPrice;

static void Main(string[] args)
{
    while (true)
    {
        Console.WriteLine("=== OmetteShop By Alphes Team ===");
        Console.WriteLine("Please Select Menu");
        Console.WriteLine("[1] Select Oders");
        Console.WriteLine("[2] Cart");
        Console.WriteLine("[3] CheackOut");
        Console.WriteLine("[4] Exit");
        Console.Write("Select Menu : ");
        int select = Convert.ToInt32(Console.ReadLine());

        switch (select)
        {
            case 1:
                AddOders();
                break;
            case 2:
                ShowCart(); 
                break;
            case 3:
                CheckOut();
                break;
            default:
                Console.WriteLine("Please select 1-4 only.");
                break;
        }

        Console.WriteLine("(Press Enter to continue)");
        Console.ReadLine();
        Console.Clear();
    }
}

static void AddOders()
{

    Console.WriteLine("=== Select quantity ===");
    Console.WriteLine("1 piece = 35 THB ");
    Console.Write("Enter quantity : ");
    int Quantity = Convert.ToInt32(Console.ReadLine());
    totalQuantity += Quantity;
    totalPrice = Quantity * PriceOmelette;


    while (true) 
    {
        Console.WriteLine("=== Select 3 Toppings ===");
        Console.WriteLine("[1] Coriander");
        Console.WriteLine("[2] Chili peppers");
        Console.WriteLine("[3] Crab sticks");
        Console.WriteLine("[4] Sausage");
        Console.WriteLine("[5] Ham");
        Console.WriteLine("[6] Carrot");
        Console.WriteLine("=== Please Select Only 1-6 ===");
        Console.WriteLine("Enter [0]  If Finish Selecting Toppings");
        Console.Write("Enter Toppings : ");
        int ToppingsSelect = Convert.ToInt32(Console.ReadLine());

        if (ToppingsSelect == 0)
        {
            break;
        }

        string toppingName;
        switch (ToppingsSelect)
        {
            case 1: 
                toppingName = "Coriander"; 
                break;
            case 2: 
                toppingName = "Chili peppers"; 
                break;
            case 3: 
                toppingName = "Crab sticks"; 
                break;
            case 4: 
                toppingName = "Sausage"; 
                break;
            case 5: 
                toppingName = "Ham"; 
                break;
            case 6: 
                toppingName = "Carrot"; 
                break;
            default:
                Console.WriteLine("Please select 0-6 only.");
                continue;
        }

        selectedToppings.Add(toppingName);

        Console.WriteLine("==> Added '{0}'. (Total toppings: {1})" ,toppingName, selectedToppings.Count);

        if (selectedToppings.Count >= 3)
        {
            Console.WriteLine("Topping already 3");
            break;
        }
    
    }

    Console.WriteLine("=== Added order to cart! ===");

}

static void ShowCart() 
{
    Console.WriteLine("=== Your Cart ===");
    Console.WriteLine("Total Omeletters : {0}",totalQuantity);
    Console.WriteLine("=== Toppings List ===");

    if (selectedToppings.Count == 0)
    {
        Console.WriteLine("(No toppings selected)");
    }
    else
    {
        foreach (string topping in selectedToppings)
        {
            Console.WriteLine("- {0}",topping);
        }
    }
    Console.WriteLine("====================");
    Console.WriteLine("Current Total: {0} Baht",totalPrice);
}

static void CheckOut()
{
    Console.WriteLine("=== Checkout ===");
    Console.WriteLine("=======================");
    Console.WriteLine("FINAL PRICE: {0} Baht",totalPrice);
    Console.WriteLine("=======================");
    Console.Write("Enter amount to be paid : ");
    int Money = Convert.ToInt32(Console.ReadLine());
    
    int calculate_change;
    int calculate_missing;
    if (Money == totalPrice)
    {
        Console.WriteLine("Received Money : {0}", Money);
    }
    else if (Money > totalPrice)
    {
        Console.WriteLine("Received Money : {0}", Money);
        calculate_change = Money - totalPrice;
        Console.WriteLine("Your Change : {0}",calculate_change);
    }
    else if (Money < totalPrice)
    {
        Console.WriteLine("Received Money : {0}", Money);
        calculate_missing = totalPrice - Money;
        Console.WriteLine("This amount {0} is missing", calculate_missing);
    }
        Console.WriteLine("Thank you for your order!");
        totalQuantity = 0;
        totalPrice = 0;
        selectedToppings.Clear();
}
