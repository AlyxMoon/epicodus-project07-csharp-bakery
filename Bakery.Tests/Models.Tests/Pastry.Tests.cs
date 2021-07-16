using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery.Models;

namespace Bakery.Tests
{
  [TestClass]
  public class PastryTests
  {
    [TestMethod]
    public void Constructor_InitializesWithCorrectValues_SuchAsPrice ()
    {
      Pastry item = new Pastry();
      Assert.AreEqual(item.Price, 2);
    }
  }
}