using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Task.Entities
{
    public enum Category
    {
        Electronics,
        ComputersAndNetworks,
        Appliances,
        BuildingAndRepair,
        HouseAndGarden,
        AutoMoto,
        Sport,
        ForChildren,
        OfficeSupplies
    }

    public class Product
    {
        [Key]
        public string Title { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public byte[] Image { get; set; }

        public override string ToString()
        {
            return $"{Title} is from {Category} category\n{Description}\nIt's cost {Price}";
        }
    }
}
