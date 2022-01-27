using System;
using System.Collections.Generic;
using System.Text;
using microservices_order.Entities.Enums;
using System.Globalization;
namespace microservices_order.Entities {
    class Order {
        public DateTime Moment { set; get; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }

        public List<OrderItem> ListItem { get; private set; } = new List<OrderItem>();

        public Order() {
            }
        public Order(DateTime moment, OrderStatus status, Client name) {
            Client = name;
            Status = status;
            Moment = moment;
            }
        public void AddItem(OrderItem item) {
            ListItem.Add(item);
            }
        public void RemoveItem(OrderItem item) {
            ListItem.Remove(item);
            }
        public double Total() {
            double sum = 0.0;
            foreach (OrderItem item in ListItem) {
                sum += item.SubTotal();
                }
            return sum;
            }
        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order moment: " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order status: " + Status);
            sb.AppendLine("Client: " + Client);
            sb.AppendLine("Order items:");
            foreach (OrderItem item in ListItem) {
                sb.AppendLine(item.ToString());
                }
            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
            }
        }
    }