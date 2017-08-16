using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace MvcUI.Models
{
    public class MvcProduct
    {
        [Key]
        public string Title { get; set; }
        //public Task.Entities.Category Category { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        //public byte[] Image { get; set; }
    }
}