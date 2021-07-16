using System;
using Bakery.Models;
using Bakery.Models.Products;

namespace Bakery
{
  public class Program
  {
    private static Register register = new Register();

    public static void Main ()
    {
      while (true)
      {
        DrawDisplay();
        bool exit = HandleUserInput();

        if (exit) break;
      }
    }

    private static void DrawDisplay ()
    {
      Console.Clear();
      Console.WriteLine("Welcome to Allister's Bakery!");
      Console.WriteLine("We have many delicious items for sale! Sadly, you aren't allowed to buy them.");
      Console.WriteLine("You can buy bread and pastries though, have as many as you like!");

      Console.WriteLine("Currently In Your Cart:");
      foreach (Product item in register.Products)
      {
        Console.WriteLine($"- {item.GetType().Name}");
      }
    }

    private static bool HandleUserInput()
    {
      Console.ReadKey();
      register.AddBread();
      register.AddPastry();

      return false;
    }
  }
}