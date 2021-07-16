using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery.Models.Products;

namespace Bakery.Tests
{
  [TestClass]
  public class DanishTests
  {
    [TestMethod]
    public void Constructor_InitializesWithCorrectValues_SuchAsPrice ()
    {
      Danish item = new Danish();
      Assert.AreEqual(4, item.Price);
      Assert.AreEqual(4, item.DefaultPrice);
    }
  }
}