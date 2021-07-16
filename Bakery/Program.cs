using System;
using System.Collections.Generic;
using Bakery.Models;
using Bakery.Models.Products;

namespace Bakery
{  
  public enum ApplicationState: int
  {
    ORDERING_ITEMS,
    ADDED_ITEM_TO_CART,
    IN_CHECKOUT,
    SEE_DEALS,
    FINISHED,
    STEALING,
  }

  public class Program
  {
    private static Dictionary<ApplicationState, string[]> _optionsPerState = new Dictionary<ApplicationState, string[]> {
      { ApplicationState.ORDERING_ITEMS, new string[] {
        "See Deals",
        "Bread ($5)",
        "Pastry ($2)",
        "Checkout",
      }},
      { ApplicationState.ADDED_ITEM_TO_CART, new string[] {
        "Yum!",
      }},
      { ApplicationState.SEE_DEALS, new string[] {
        "Great!",
      }},
      { ApplicationState.IN_CHECKOUT, new string[] {
        "Thanks! (exit)",
        "I don't want to pay! (steal)",
      }},
    };
    private static Dictionary<ApplicationState, string[]> OptionsPerState {
      get { return _optionsPerState; }
    }

    private static Register _register = new Register();
    public static Register Register {
      get { return _register; }
    }

    private static ApplicationState _state = ApplicationState.ORDERING_ITEMS;
    public static ApplicationState State {
      get { return _state; }
    }

    private static int _selectedOption = 0;
    public static int SelectedOption {
      get { return _selectedOption; }
    }
    

    public static void Main ()
    {
      Console.CursorVisible = false;

      bool exit = false;
      while (!exit)
      {
        exit = DrawDisplay();

        if (!exit)
        {
          exit = HandleUserInput();
        }
      }

      Console.CursorVisible = true;
    }

    private static bool DrawDisplay ()
    {
      Console.Clear();

      if (State == ApplicationState.SEE_DEALS)
      {
        Console.WriteLine("We have two deals on at the moment:");
        Console.WriteLine("- For bread, it's buy one get one free.");
        Console.WriteLine("- For pastries, if you buy three at a time you save $1.");

        DrawCurrentOptions();
      }

      if (State == ApplicationState.ORDERING_ITEMS)
      {
        Console.WriteLine("Welcome to Allister's Bakery!");
        Console.WriteLine("We have many delicious items for sale! Sadly, you aren't allowed to buy them.");
        Console.WriteLine("You can buy bread and pastries though, have as many as you like!");

        DrawCurrentOptions();

        Console.WriteLine("Currently In Your Cart:");
        foreach (Product item in Register.Products)
        {
          Console.WriteLine($"- {item.GetType().Name}");
        }
      }

      if (State == ApplicationState.ADDED_ITEM_TO_CART)
      {
        Product latestItem = Register.Products[Register.Products.Count - 1];

        Console.WriteLine($"You place the {latestItem.GetType().Name} in your cart.");

        DrawCurrentOptions();
      }

      if (State == ApplicationState.IN_CHECKOUT)
      {
        int total = Register.TotalPrice;
        int totalWithDiscount = Register.GetPriceWithDiscount();

        Console.WriteLine($"Ready to check out, eh? Your total comes out to ${total}");

        if (total != totalWithDiscount)
        {
          Console.WriteLine("Oh wait! I forgot to include your discount!");
          Console.Write($"Sorry about that, your actual total is ${totalWithDiscount}.");
        }

        DrawCurrentOptions();
      }

      if (State == ApplicationState.STEALING)
      {
        Console.WriteLine("Excuse me? Nobody steals on my watch!");
        Console.WriteLine("The shopkeeper takes your cart and kicks you out of the store.");

        string[] person = new string[] {
          "\\  \\",
          " ----O",
          "/  |",
        };

        for (int i = 0; i < Console.WindowWidth; i++)
        {
          System.Threading.Thread.Sleep(50);
          Console.Clear();

          string animationPadding = new String(' ', i);

          Console.WriteLine($"\n\n{animationPadding} noooo");

          foreach (string line in person)
          {
            string updatedLine = animationPadding + line;
            int end = Math.Min(Console.WindowWidth - 1, updatedLine.Length);

            Console.WriteLine(updatedLine.Substring(0, end));
          }
        }

        return true;
      }

      return false;
    }

    private static void DrawCurrentOptions ()
    {
      string[] options = OptionsPerState[State];

      Console.WriteLine('\n');
      for (int i = 0; i < options.Length; i++)
      {
        string option = $"  {options[i]}  ";
        ConsoleColor foreground = i == SelectedOption ? ConsoleColor.White : ConsoleColor.DarkBlue;
        ConsoleColor background = i == SelectedOption ? ConsoleColor.DarkBlue : ConsoleColor.Black;

        WriteWithColor(option, foreground, background);          
        Console.Write("  ");
      }

      Console.WriteLine("\n(Use arrow keys to change options, and enter to select one. Press any other keys to stop the program)\n");
    }

    private static bool HandleUserInput()
    {
      ConsoleKeyInfo pressedKey = Console.ReadKey(true);

      switch (pressedKey.Key)
      {
        case ConsoleKey.LeftArrow:
          ChoosePreviousOption();
          return false;
        case ConsoleKey.RightArrow:
          ChooseNextOption();
          return false;
        case ConsoleKey.Enter:
          break;
        default:
          return true;
      }

      switch (State)
      {
        case ApplicationState.ORDERING_ITEMS:
          HandleOptionsOrderingItems();
          break;
        case ApplicationState.SEE_DEALS:
          HandleOptionsSeeDeals();
          break;
        case ApplicationState.ADDED_ITEM_TO_CART:
          HandleOptionsAddedToCard();
          break;
        case ApplicationState.IN_CHECKOUT:
          HandleOptionsInCheckout();
          break;
      }

      return State == ApplicationState.FINISHED;
    }

    private static void ChoosePreviousOption ()
    {
      _selectedOption = Math.Max(SelectedOption - 1, 0);
    }

    private static void ChooseNextOption ()
    {
      string[] options = OptionsPerState[State];
      _selectedOption = Math.Min(SelectedOption + 1, options.Length - 1);
    }

    private static void HandleOptionsOrderingItems ()
    {
      switch (SelectedOption)
      {
        case 0:
          ChangeState(ApplicationState.SEE_DEALS);
          break;
        case 1:
          Register.AddBread();
          ChangeState(ApplicationState.ADDED_ITEM_TO_CART);
          break;
        case 2:
          Register.AddPastry();
          ChangeState(ApplicationState.ADDED_ITEM_TO_CART);
          break;
        case 3:
          ChangeState(ApplicationState.IN_CHECKOUT);
          break;
      }
    }

    private static void HandleOptionsSeeDeals ()
    {
      ChangeState(ApplicationState.ORDERING_ITEMS);
    }

    private static void HandleOptionsAddedToCard ()
    {
      ChangeState(ApplicationState.ORDERING_ITEMS);
    }

    private static void HandleOptionsInCheckout ()
    {
      switch(SelectedOption)
      {
        case 0:
          ChangeState(ApplicationState.FINISHED);
          break;
        case 1:
          ChangeState(ApplicationState.STEALING);
          break;
      }
    }

    private static void ChangeState (ApplicationState state)
    {
      _selectedOption = 0;
      _state = state;
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