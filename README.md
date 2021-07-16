# Epicodus | Independent Project 07 | C# Bakery

##### Table of Contents
1. [Description](#description)
2. [Setting Up The Project](#setting-up-the-project)
   - [Setting Up for Local Development](#setting-up-for-local-development)
4. [Objectives](#objectives)
   - [Further Exploration Objectives](#further-exploration-objectives)

## Description

This is my sixth independent project for the Epicodus bootcamp program. The goal is to create a C# console application with the following functionality:

- There should be two classes: one for Bread and one for Pastry.
- When the user runs the application, they should receive a prompt with a welcome message along with the cost for both Bread and Pastry.
- A user should be able to specify how many loaves of Bread and how many Pastrys they'd like.
- The application will return the total cost of the order.
- Pierre offers the following deals:
  - Bread: Buy 2, get 1 free. A single loaf costs $5.
  - Pastry: Buy 1 for \$2 or 3 for $5.
- All functionality for the models should be tested.

- **Author**: Allister Moon Kays
- **Copyright**: MIT License

## Setting Up The Project

#### Setting Up for Local Development
1. Ensure you have `.Net` (current version at this time is `.Net 5.0`) installed on your computer (https://dotnet.microsoft.com/download).
1. Download the files or clone the repository to your computer.
2. Open the project folder in your code editor of choice.
3. Running the application
  - To run the application, use `dotnet run` while in the `Bakery` directory.
  - To test the application, use `dotnet test` while in the `Bakery.Tests` directory.

## Objectives
- Code includes two custom classes and uses namespaces.
- Console application works correctly.
- Application correctly uses auto-implemented properties.
- Classes should include methods for determining the price of an order.
- Models are thoroughly tested.
- Previous objectives have been met.
- Required functionality is in place by the deadline.
- Project is in a polished, portfolio-quality state.
- Project demonstrates understanding of this week's concepts. If prompted, you can discuss your code with an instructor using the correct terminology.

### Further Exploration Objectives
- Allow users to buy different kinds of Bread and Pastry.
- Add additional deals beyond the ones mentioned above.
- Use class inheritance to DRY up code for the Bread and Pastry class.
- Allow users to keep adding to an order. In order to do this, you will need to use static variables. See the lesson on static variables to complete this objective.

##### game plan

- focus everything on USD, convert to/from that
- pull API once on page load for conversion rates, then don't use it.
- show time last updated / when will update next
- save api call in local storage for even less API usage
- check stored api call vs next update to see if update required