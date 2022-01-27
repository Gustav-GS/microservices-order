using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
namespace microservices_order.Entities {
    class OrderItem {
        public int Quantity { get; set; }
        public double Price { get; set; }

        public string Product { get; set; }
        public OrderItem() {
            }
        public OrderItem(int amount, double price, string product) {
            Product = product;
            Price = price;
            Quantity = amount;
            }
        public double SubTotal() {
            return Quantity * Price;
            }
        public override string ToString() {

            return Product
                + ", $"
                + Price.ToString("F2", CultureInfo.InvariantCulture)
                + ", Quantity: "
                + Quantity
                + ", Subtotal: $"
                + SubTotal().ToString("F2", CultureInfo.InvariantCulture);
            }

        }
    }