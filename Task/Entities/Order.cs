using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task.Entities
{
    /// <summary>
    /// Purchase unit
    /// </summary>
    public class Order
    {
        public int OrderId { get; set; }
        public int Quantity { get; set; }

        [ForeignKey("Product"), Required]
        public string ProductTitle { get; set; }
        public int PurchaseId { get; set; }

        public virtual Product Product { get; set; }
        public virtual Purchase Purchase { get; set; }
    }
}
