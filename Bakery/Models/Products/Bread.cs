
namespace Bakery.Models.Products
{
  public class Bread : Product
  {
    public override int DefaultPrice {
      get { return 5; }
    }
    public Bread ()
    {
      Price = DefaultPrice;
    }
  }
}