using System;
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

      Assert.AreEqual(0, register.Products.Count);
      Assert.AreEqual(0, register.TotalPrice);
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
        new List<Product> { bread1, pastry1 },
        register.Products
      );
    }

    [TestMethod]
    public void AddBread_AddsToTheProductList_ProductListHasItems ()
    {
      Register register = new Register();

      register.AddBread();
      register.AddBread();
      
      Assert.AreEqual(2, register.Products.Count);
      CollectionAssert.AllItemsAreInstancesOfType(register.Products, typeof(Bread));
    }

    [TestMethod]
    public void AddPastry_AddsToTheProductList_ProductListHasItems ()
    {
      Register register = new Register();

      register.AddPastry();
      register.AddPastry();
      
      Assert.AreEqual(2, register.Products.Count);
      CollectionAssert.AllItemsAreInstancesOfType(register.Products, typeof(Pastry));
    }

    [TestMethod]
    public void AddPastryAndAddBread_AddsToTheProductList_ProductListHasItems ()
    {
      Register register = new Register();

      register.AddBread();
      register.AddPastry();

      Assert.AreEqual(2, register.Products.Count);
      Console.WriteLine(register.Products[0]);
      Assert.IsTrue(register.Products[0] is Bread);
      Assert.IsTrue(register.Products[1] is Pastry);
    }

    [TestMethod]
    public void GetPriceWithDiscounts_AccountsForDiscountPrice_Returns5PerTwoBread ()
    {
      Register register = new Register();

      register.Products.Add(new Bread());
      register.Products.Add(new Bread());

      Assert.AreEqual(5, register.GetPriceWithDiscount());

      register.Products.Add(new Bread());
      register.Products.Add(new Bread());

      Assert.AreEqual(10, register.GetPriceWithDiscount());
    }

    [TestMethod]
    public void GetPriceWithDiscounts_AccountsForDiscountPrice_Returns10For3Bread ()
    {
      Register register = new Register();

      register.Products.Add(new Bread());
      register.Products.Add(new Bread());
      register.Products.Add(new Bread());

      Assert.AreEqual(10, register.GetPriceWithDiscount());
    }
    
    [TestMethod]
    public void GetPriceWithDiscounts_AccountsForDiscountPrice_Returns5Per3Pastry ()
    {
      Register register = new Register();

      register.Products.Add(new Pastry());
      register.Products.Add(new Pastry());
      register.Products.Add(new Pastry());
      Assert.AreEqual(5, register.GetPriceWithDiscount());

      register.Products.Add(new Pastry());
      register.Products.Add(new Pastry());
      register.Products.Add(new Pastry());
      Assert.AreEqual(10, register.GetPriceWithDiscount());
    }
    
    [TestMethod]
    public void GetPriceWithDiscounts_AccountsForDiscountPrice_Returns12For7Pastries ()
    {
      Register register = new Register();

      for (int i = 0; i < 7; i++)
      {
        register.Products.Add(new Pastry());
      }

      Assert.AreEqual(12, register.GetPriceWithDiscount());
    }
  }
}