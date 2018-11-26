using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Shopping.Models
{
    public class Cart
    {
        private List<CartItem> Items;

        public Cart() : base()
        {
            Items = new List<CartItem>();
        }

        

        public void AddItem(Product product)
        {
            CartItem match = Items.FirstOrDefault(p => p.Code.ToUpper(CultureInfo.CurrentCulture).Equals(product.Code.ToUpper(CultureInfo.CurrentCulture)));
            if (match==null)
            {
                Items.Add(new CartItem() { Code = product.Code, Description = product.Description, Price = product.Price, Quantity = 1 });
            }
            else
            {
                match.Quantity++;
            }
        }

        public double CalculateTotal()
        {
            return Items.Sum(p => p.Price * p.Quantity);
        }

        public int GetCount()
        {
            return Items.Sum(c=>c.Quantity);
        }
    }
}