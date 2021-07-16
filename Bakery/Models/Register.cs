using System;
using System.Linq;
using System.Collections.Generic;
using Bakery.Models.Products;

namespace Bakery.Models
{
  public class Register
  {
    public List<Product> Products = new List<Product>();
    public int TotalPrice 
    {
      get 
      {
        return Products.Aggregate(0, (sum, product) => sum + product.Price);
      }
    }

    public int GetPriceWithDiscount ()
    {
      int total = TotalPrice;
      int breadCount = 0;

      foreach (Product item in Products)
      {
        if (item is Bread) breadCount++;
      }

      total -= 5 * (breadCount / 2);

      return total;
    }
  }
}