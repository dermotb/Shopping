using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shopping.Models
{
    public class Product
    {
        [Key]
        public string Code { get; set; }
        public string Description { get; set; }
        [DisplayName("Price (€)")]
        public double Price { get; set; }
    }

    public class CartItem : Product
    {
        public int Quantity { get; set; }
    }
}