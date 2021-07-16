using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery.Models.Products;

namespace Bakery.Tests
{
  [TestClass]
  public class BreadTests
  {
    [TestMethod]
    public void Constructor_InitializesWithCorrectValues_SuchAsPrice ()
    {
      Bread item = new Bread();
      Assert.AreEqual(5, item.Price);
      Assert.AreEqual(5, item.DefaultPrice);
    }
  }
}