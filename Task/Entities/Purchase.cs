using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task.Entities
{
    public class Purchase
    {
        public Purchase() => Orders = new List<Order>();

        public int PurchaseId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public override string ToString()
        {
            int total = 0;
            var sb = new StringBuilder(string.Empty);
            sb.Append($"Purchase №{PurchaseId}");
            sb.Append(Environment.NewLine);
            sb.Append("-------------------------");
            sb.Append(Environment.NewLine);
            foreach (var item in Orders)
            {
                total += item.Product.Price * item.Quantity;
                sb.Append($"{item.Product.Title} - {item.Quantity} items : {item.Product.Price * item.Quantity}");
                sb.Append(Environment.NewLine);
            }
            sb.Append($"------{total}------");
            return sb.ToString();
        }
    }
}
