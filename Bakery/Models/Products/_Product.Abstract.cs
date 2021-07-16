
namespace Bakery.Models.Products
{
  public abstract class Product
  {
    public abstract int DefaultPrice { get; }
    public int Price { get; set; }
  }
}