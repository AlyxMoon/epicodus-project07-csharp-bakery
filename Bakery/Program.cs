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
      { ApplicationState.SEE_DEALS, new string[] {
        "Great!",
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

      while (true)
      {
        DrawDisplay();
        bool exit = HandleUserInput();

        if (exit) break;
      }

      Console.CursorVisible = true;
    }

    private static void DrawDisplay ()
    {
      Console.Clear();
      string[] options = OptionsPerState[State];

      if (State == ApplicationState.SEE_DEALS)
      {
        Console.WriteLine("We have two deals on at the moment:");
        Console.WriteLine("- For bread, it's buy one get one free.");
        Console.WriteLine("- For pastries, if you buy three at a time you save $1.");
      }

      if (State == ApplicationState.ORDERING_ITEMS)
      {
        Console.WriteLine("Welcome to Allister's Bakery!");
        Console.WriteLine("We have many delicious items for sale! Sadly, you aren't allowed to buy them.");
        Console.WriteLine("You can buy bread and pastries though, have as many as you like!\n");

        Console.WriteLine("\n\nCurrently In Your Cart:");
        foreach (Product item in Register.Products)
        {
          Console.WriteLine($"- {item.GetType().Name}");
        }
      }

      Console.WriteLine("(Use arrow keys to change options, and enter to select one. Press esc at any time to leave)");
      for (int i = 0; i < options.Length; i++)
      {
        string option = $"  {options[i]}  ";
        ConsoleColor foreground = i == SelectedOption ? ConsoleColor.White : ConsoleColor.DarkBlue;
        ConsoleColor background = i == SelectedOption ? ConsoleColor.DarkBlue : ConsoleColor.Black;

        WriteWithColor(option, foreground, background);          
        Console.Write("  ");
      }
    }

    private static bool HandleUserInput()
    {
      ConsoleKeyInfo pressedKey = Console.ReadKey(true);
      
      if (pressedKey.Key == ConsoleKey.Escape) return true;

      string[] options = OptionsPerState[State];
      if (pressedKey.Key == ConsoleKey.LeftArrow) _selectedOption--;
      if (pressedKey.Key == ConsoleKey.RightArrow) _selectedOption++;


      if (State == ApplicationState.ORDERING_ITEMS)
      {
        int minOption = 0;
        int maxOption = options.Length - 1;

        if (SelectedOption < minOption) _selectedOption = minOption;
        if (SelectedOption > maxOption) _selectedOption = maxOption;

        if (pressedKey.Key != ConsoleKey.Enter) return false;

        if (SelectedOption == 0) ChangeState(ApplicationState.SEE_DEALS);
        else if (SelectedOption == 1) Register.AddBread();
        else if (SelectedOption == 2) Register.AddPastry();
        else ChangeState(ApplicationState.IN_CHECKOUT);
      }
      else if (State == ApplicationState.SEE_DEALS)
      {
        int minOption = 0;
        int maxOption = options.Length - 1;

        if (SelectedOption < minOption) _selectedOption = minOption;
        if (SelectedOption > maxOption) _selectedOption = maxOption;

        if (pressedKey.Key != ConsoleKey.Enter) return false;

        if (SelectedOption == 0) ChangeState(ApplicationState.ORDERING_ITEMS);
      }

      return false;
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