using System;
using System.Globalization;
using microservices_order.Entities;
using microservices_order.Entities.Enums;
namespace microservices_order {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Enter the client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("E-mail: ");
            string email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): Example - 15/03/1985: ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter the order data: ");
            Console.Write("Status: ");

            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Client ClientData = new Client(name, email, birthDate);
            Order Request = new Order(DateTime.Now, status, ClientData);
            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++) {
                Console.WriteLine($"Enter #{n} item data: ");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Price: ");
                double productPrice = double.Parse(Console.ReadLine());
                Product NewItem = new Product(productName, productPrice);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());
                OrderItem BuyingProduct = new OrderItem(quantity, productPrice, productName);
                Request.AddItem(BuyingProduct);
                }
            Console.WriteLine();
            Console.WriteLine("Order Sumarry: ");
            Console.WriteLine(Request);
            }
        }
    }