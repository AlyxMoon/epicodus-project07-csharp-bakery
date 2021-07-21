using System;
using System.Linq;
using System.Collections.Generic;
using Bakery.Models.Products;

namespace Bakery.Models
{
  public class Register
  {
    public List<Product> Products = new();
    public int TotalPrice 
    {
      get 
      {
        return Products.Aggregate(0, (sum, product) => sum + product.Price);
      }
    }

    public void AddBread ()
    {
      Products.Add(new Bread());
    }

    public void AddPastry ()
    {
      Products.Add(new Pastry());
    }

    public void AddDanish ()
    {
      Products.Add(new Danish());
    }

    public int GetPriceWithDiscount ()
    {
      int total = TotalPrice;
      int breadCount = 0;
      int pastryCount = 0;
      int danishCount = 0;

      foreach (Product item in Products)
      {
        if (item is Bread) breadCount++;
        if (item is Pastry) pastryCount++;
        if (item is Danish) danishCount++;
      }

      total -= 5 * (breadCount / 3);
      total -= pastryCount / 3;
      total -= Math.Min(breadCount, danishCount);

      return total;
    }
  }
}