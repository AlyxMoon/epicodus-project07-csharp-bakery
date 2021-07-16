
namespace Bakery.Models.Products
{
  public class Pastry : Product
  {
    public override int DefaultPrice {
      get { return 2; }
    }

    public Pastry ()
    {
      Price = DefaultPrice;
    }
  }
}