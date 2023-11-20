

namespace HW_InventoryManagementSystem
{
    class Product
    {
        public string productName { get; set; }
        public string Description { get; set; }
        public decimal price { get; set; }
        public int quantity { get; set; }
    }
    class Program
    {
        static List<Product> products = new List<Product>();
        static void DisplayOptions()
        {
            Console.WriteLine(
                       "\nOptions: \n" +
                       "1. Add a new product.\n" +
                       "2. Update product quantity \n" +
                       "3. Display product list \n" +
                       "4. Record sale \n" +
                       "5. Generate product report\n" +
                       "6. Generate sales report \n" +
                       "7. Exit \n"
                   );

            Console.Write("Select an operation (1-7): ");
            int choice = Convert.ToInt32(Console.ReadLine());


            AdminChoice(choice);
        }
        static void AdminChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    AddNewProduct();
                    break;
                case 2:
                    UpdateProductQuantity();
                    break;
                case 3:
                    DisplayProductList();
                    break;

                case 4:
                    Console.WriteLine("Record sale: ");
                    DeleteSale();
                    // Console.WriteLine("Sale recorded successfully!");


                    break;
                case 5:
                    Console.WriteLine("product Report: ");

                    foreach (var product in products)
                    {
                        Console.WriteLine($"Product Name: {product.productName}");
                        Console.WriteLine($"Price: ${product.price}");
                        Console.WriteLine($"Quantity: {product.quantity}\n");
                    }
                    break;
                case 6:
                    int totalSales = 0;
                    decimal totalRevenue = 0;

                    foreach (var product in products)
                    {
                        int productSales = product.quantity; // Assuming productSales is the number of units sold

                        Console.WriteLine($"Product Name: {product.productName}");
                        Console.WriteLine($"Units Sold: {productSales}");
                        Console.WriteLine($"Total Revenue: ${productSales * product.price}\n");

                        totalSales += productSales;
                        totalRevenue += productSales * product.price;
                    }


                    Console.WriteLine("Sales Report: ");
                    Console.WriteLine($"Total Sales: {totalSales}");
                    Console.WriteLine($"Total Revenue: {totalRevenue:C}");

                    break;
                case 7:
                    Console.WriteLine("Thank you for using the Inventory Management System, admin!");
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid operation.\r\n");
                    break;
            }
            DisplayOptions();
        }

        static void AddNewProduct()
        {
            Product myProduct = new Product();

            Console.Write("Enter product name: ");
            myProduct.productName = Console.ReadLine();

            Console.Write("Enter product price: ");
            myProduct.price = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter initial quantity: ");
            myProduct.quantity = Convert.ToInt32(Console.ReadLine());

            // To Add the new product to the list <products>:
            products.Add(myProduct);

            Console.WriteLine("Product added successfully!");

        }

        static void UpdateProductQuantity()
        {
            Console.Write("Enter the product name to update quantity: ");
            string productName = Console.ReadLine();

            Product foundProduct = products.Find(p => p.productName.Equals(productName, StringComparison.OrdinalIgnoreCase));

            if (foundProduct != null)
            {
                Console.WriteLine($"Current quantity of {foundProduct.productName}: {foundProduct.quantity}");
                Console.Write("Enter the new quantity: ");
                if (int.TryParse(Console.ReadLine(), out int newQuantity))
                {
                    foundProduct.quantity = newQuantity;
                    Console.WriteLine("Quantity updated successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid quantity format. Quantity update failed.");
                }
            }
            else
            {
                Console.WriteLine($"Product '{productName}' not found.");
            }
        }

        static void DeleteSale()
        {
            Console.Write("Enter the product name for sale: ");
            string productName = Console.ReadLine();

            Product foundProduct = products.Find(p => p.productName.Equals(productName, StringComparison.OrdinalIgnoreCase));

            if (foundProduct != null)
            {
                Console.Write($"Enter the quantity of {foundProduct.productName} sold: ");
                if (int.TryParse(Console.ReadLine(), out int quantity))
                {
                    if (quantity > 0 && quantity <= foundProduct.quantity)
                    {
                        foundProduct.quantity -= quantity;
                        Console.WriteLine($"Sale of {quantity} units of {foundProduct.productName} recorded successfully!");

                    }
                    else
                    {
                        Console.WriteLine("Invalid quantity !!.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid quantity format.");
                }
            }
            else
            {
                Console.WriteLine($"Product '{productName}' not found.");
            }
        }

        static void DisplayProductList()
        {
            Console.WriteLine("Products List:\n");
            foreach (var product in products)
            {
                Console.Write($"1.Product Name {product.productName}");
                Console.Write($" - Price: ${product.price}");
                Console.WriteLine($" Quantity: {product.quantity}");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Inventory Management System!");



            Console.Write("Please enter your username: ");
            string username = Console.ReadLine();
            Console.Write("Please enter your password: ");
            string password = Console.ReadLine();
            // Check if the username is "verified" or not 
            string verificationStatus = ((username.ToLower() == "admin") && (password.ToLower() == "adminpass")) ? $"Authentication successful! Welcome, {username} !" : "not verified, Try agin..";
            Console.WriteLine(verificationStatus);


            Console.WriteLine(
            "Options: \n" +
            "1. Add a new product.\n" +
            "2. Update product quantity \n" +
            "3. Display product list \n" +
            "4. Record sale \n" +
            "5. Generate product report\n" +
            "6. Generate sales report \n" +
            "7. Exit \n");

            Console.Write("Select an operation (1-7): ");
            int choice = Convert.ToInt32(Console.ReadLine());


            AdminChoice(choice);




            int TotalSales = 0;

            decimal totalRevenue = 0;







            //if (verificationStatus == "yes")
            //    DisplayOptions();

            //string productName;
            //int price, quantity;


            // List<Product> products = new List<Product>();
            //array////



        }
    }
}
