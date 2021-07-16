using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bakery.Models;
using Bakery.Models.Products;

namespace Bakery.Tests
{
  [TestClass]
  public class RegisterTests
  {
    [TestMethod]
    public void Constructor_InitializesWithCorrectValues_SuchAsPrice ()
    {
      Register register = new Register();

      Assert.AreEqual(register.Products.Count, 0);
      Assert.AreEqual(register.TotalPrice, 0);
    }

    [TestMethod]
    public void Register_CanAddProducts_GivesCorrectLengthAndPrice ()
    {
      Register register = new Register();
      Bread bread1 = new Bread();
      Pastry pastry1 = new Pastry();

      register.Products.Add(bread1);
      register.Products.Add(pastry1);

      Assert.AreEqual(register.TotalPrice, 7);
      Assert.AreEqual(register.Products.Count, 2);
      CollectionAssert.AreEqual(
        register.Products,
        new List<Product> { bread1, pastry1 }
      );
    }

    [TestMethod]
    public void GetPriceWithDiscounts_AccountsForDiscountPrice_Returns5PerTwoBread ()
    {
      Register register = new Register();

      register.Products.Add(new Bread());
      register.Products.Add(new Bread());

      Assert.AreEqual(register.GetPriceWithDiscount(), 5);

      register.Products.Add(new Bread());
      register.Products.Add(new Bread());

      Assert.AreEqual(register.GetPriceWithDiscount(), 10);
    }

    [TestMethod]
    public void GetPriceWithDiscounts_AccountsForDiscountPrice_Returns10For3Bread ()
    {
      Register register = new Register();

      register.Products.Add(new Bread());
      register.Products.Add(new Bread());
      register.Products.Add(new Bread());

      Assert.AreEqual(register.GetPriceWithDiscount(), 10);
    }
  }
}