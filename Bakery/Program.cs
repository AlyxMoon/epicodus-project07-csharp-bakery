using System;
using Bakery.Models;
using Bakery.Models.Products;

namespace Bakery
{  
  public enum ApplicationState: int
  {
    ORDERING_ITEMS,
    ADDED_ITEM_TO_CART,
    IN_CHECKOUT,
  }

  public class Program
  {
    private static string[] OptionsOrderingItems = new string[] {
      "See Deals",
      "Bread ($5)",
      "Pastry ($2)",
      "Checkout",
    };

    private static Register register = new Register();
    private static ApplicationState state = ApplicationState.ORDERING_ITEMS;
    private static int selectedOption = 0;
    

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

      if (state == ApplicationState.ORDERING_ITEMS) {
        Console.WriteLine("Welcome to Allister's Bakery!");
        Console.WriteLine("We have many delicious items for sale! Sadly, you aren't allowed to buy them.");
        Console.WriteLine("You can buy bread and pastries though, have as many as you like!\n");

        Console.WriteLine("(Use arrow keys to change options, and enter to select one)");
        for (int i = 0; i < OptionsOrderingItems.Length; i++)
        {
          string option = $"  {OptionsOrderingItems[i]}  ";
          ConsoleColor foreground = i == selectedOption ? ConsoleColor.White : ConsoleColor.DarkBlue;
          ConsoleColor background = i == selectedOption ? ConsoleColor.DarkBlue : ConsoleColor.Black;

          WriteWithColor(option, foreground, background);          
          Console.Write("  ");
        }

        Console.WriteLine("\n\nCurrently In Your Cart:");
        foreach (Product item in register.Products)
        {
          Console.WriteLine($"- {item.GetType().Name}");
        }
      }
    }

    private static bool HandleUserInput()
    {
      ConsoleKeyInfo pressedKey = Console.ReadKey(true);

      if (pressedKey.Key == ConsoleKey.LeftArrow) selectedOption--;
      if (pressedKey.Key == ConsoleKey.RightArrow) selectedOption++;

      if (state == ApplicationState.ORDERING_ITEMS)
      {
        int minOption = 0;
        int maxOption = OptionsOrderingItems.Length - 1;

        if (selectedOption < minOption) selectedOption = minOption;
        if (selectedOption > maxOption) selectedOption = maxOption;

        if (pressedKey.Key != ConsoleKey.Enter) return false;

        if (selectedOption == 0)
        {

        }
        else if (selectedOption == 1) register.AddBread();
        else if (selectedOption == 2) register.AddPastry();
        else
        {
          selectedOption = 0;
          state = ApplicationState.IN_CHECKOUT;
        }
      }

      return false;
    }

    private static void WriteWithColor (
      string text, 
      ConsoleColor foreground, 
      ConsoleColor background
    )
    {
      Console.BackgroundColor = background;
      Console.ForegroundColor = foreground;
      Console.Write(text);
      Console.ResetColor();
    }
  }
}