using System.Linq;
using System.Collections.Generic;
using Bakery.Models.Products;

namespace Bakery.Models
{
  public class Register
  {
    public List<Product> Products = new List<Product>();
    public int TotalPrice {
      get {
        return Products.Aggregate(0, (sum, product) => sum + product.Price);
      }
    }
  }
}