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
        public int PurchaseId { get; set; }
        public List<Order> Basket { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder(string.Empty);
            sb.Append($"Purchase №{PurchaseId}");
            sb.Append(Environment.NewLine);
            sb.Append("-------------------------");
            sb.Append(Environment.NewLine);
            foreach (var item in Basket)
            {
                sb.Append($"{item.Product.Title} - {item.Product.Price} - {item.Quantity}");
                sb.Append(Environment.NewLine);
            }
            sb.Append("-------------------------");
            return sb.ToString();
        }
    }
}
