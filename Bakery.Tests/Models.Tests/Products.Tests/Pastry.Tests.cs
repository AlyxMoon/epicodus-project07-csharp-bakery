using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery.Models.Products;

namespace Bakery.Tests
{
  [TestClass]
  public class PastryTests
  {
    [TestMethod]
    public void Constructor_InitializesWithCorrectValues_SuchAsPrice ()
    {
      Pastry item = new();
      Assert.AreEqual(2, item.Price);
      Assert.AreEqual(2, item.DefaultPrice);
    }
  }
}