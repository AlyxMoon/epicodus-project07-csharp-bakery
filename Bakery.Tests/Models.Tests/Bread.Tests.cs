using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery.Models;

namespace Bakery.Tests
{
  [TestClass]
  public class BreadTests
  {
    [TestMethod]
    public void Constructor_InitializesWithCorrectValues_SuchAsPrice ()
    {
      Bread item = new Bread();
      Assert.AreEqual(item.Price, 5);
    }
  }
}