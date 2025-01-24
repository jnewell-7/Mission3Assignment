using Mission3Assignment;

class Program
{
    static List<FoodItem> foodInventory = new List<FoodItem>();

    static void Main(string[] args)
    {
        string[] menuOptions = {
            "1. Add Food Item",
            "2. Delete Food Item",
            "3. Print List of Current Food Items",
            "4. Exit Program"
        };

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Food Bank Inventory System");
            Console.WriteLine("--------------------------");

            // Display the menu
            for (int i = 0; i < menuOptions.Length; i++)
            {
                Console.WriteLine(menuOptions[i]);
            }

            Console.WriteLine("\nSelect an option: ");
            string input = Console.ReadLine();

            // Handle menu options
            if (input == "4")
            {
                Console.WriteLine("Exiting program...");
                break; 
            }
            else if (input == "1")
            {
                AddFoodItem();
            }
            else if (input == "2")
            {
                DeleteFoodItem();
            }
            else if (input == "3")
            {
                PrintFoodItems();
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
                Pause();
            }
        }
    }

    static void AddFoodItem()
    {
        Console.WriteLine("\nAdding a new food item:");
        Console.Write("Enter Name: ");
        string name = Console.ReadLine();

        Console.Write("Enter Category: ");
        string category = Console.ReadLine();

        int quantity;
        do
        {
            Console.Write("Enter Quantity (positive integer): ");
        } while (!int.TryParse(Console.ReadLine(), out quantity) || quantity < 0);

        DateTime expirationDate;
        do
        {
            Console.Write("Enter Expiration Date (MM/DD/YYYY): ");
        } while (!DateTime.TryParse(Console.ReadLine(), out expirationDate));

        FoodItem newItem = new FoodItem(name, category, quantity, expirationDate);
        foodInventory.Add(newItem);

        Console.WriteLine("Food item added successfully!");
        Pause();
    }

    static void DeleteFoodItem()
    {
        if (foodInventory.Count == 0)
        {
            Console.WriteLine("No food items to delete.");
            Pause();
            return;
        }

        Console.WriteLine("\nCurrent Food Items:");
        for (int i = 0; i < foodInventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {foodInventory[i]}");
        }

        int index;
        do
        {
            Console.Write("\nEnter the number of the food item to delete: ");
        } while (!int.TryParse(Console.ReadLine(), out index) || index <= 0 || index > foodInventory.Count);

        foodInventory.RemoveAt(index - 1);
        Console.WriteLine("Food item deleted successfully!");
        Pause();
    }

    static void PrintFoodItems()
    {
        Console.WriteLine("\nCurrent Food Items:");

        if (foodInventory.Count == 0)
        {
            Console.WriteLine("No food items in inventory.");
        }
        else
        {
            foreach (var item in foodInventory)
            {
                Console.WriteLine(item);
            }
        }

        Pause();
    }

    static void Pause()
    {
        Console.WriteLine("\nPress any key to continue...");
        Console.ReadKey();
    }
}