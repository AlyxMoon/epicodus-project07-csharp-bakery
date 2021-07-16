
namespace Bakery.Models.Products
{
  public class Danish : Product
  {
    public override int DefaultPrice {
      get { return 4; }
    }
    public Danish ()
    {
      Price = DefaultPrice;
    }
  }
}