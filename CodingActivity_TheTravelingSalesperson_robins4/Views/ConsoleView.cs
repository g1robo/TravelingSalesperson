using System;
using System.Text;

namespace CodingActivity_TheTravelingSalesperson
{
    /// <summary>
    /// Console class for the MVC pattern
    /// </summary>
    public class ConsoleView
    {
        #region FIELDS

        // declare a Salesperson object for the Controller to use
        // Note: There is no need for a Salesperson property given the Controller already 
        //       has access to the same Salesperson object.
        private Salesperson _salesperson;

        #endregion

        #region PROPERTIES

        #endregion

        #region CONSTRUCTORS

        /// <summary>
        /// default constructor to create the console view objects
        /// </summary>
        public ConsoleView(Salesperson salesperson)
        {
            _salesperson = salesperson;

            InitializeConsole();
        }
        #endregion
        #region METHODS
        /// <summary>
        /// initialize all console settings
        /// </summary>
        private void InitializeConsole()
        {
            ConsoleUtil.WindowTitle = "Robemaps";
            ConsoleUtil.HeaderText = " Traveling Salesperson Application";
        }

        /// <summary>
        /// display the Continue prompt
        /// </summary>
        public void DisplayContinuePrompt()
        {
            Console.CursorVisible = false;
            Console.WriteLine();
            ConsoleUtil.DisplayMessage("Press any key to continue.");
            ConsoleKeyInfo response = Console.ReadKey();
            Console.WriteLine();
            Console.CursorVisible = true;
        }

        /// <summary>
        /// display the Exit prompt on a clean screen
        /// </summary>
        public void DisplayExitPrompt()
        {
            ConsoleUtil.DisplayReset();
            Console.CursorVisible = false;
            Console.WriteLine();
            ConsoleUtil.DisplayMessage(" Thank you for using the application. Press any key to Exit.");
            Console.ReadKey();
            System.Environment.Exit(1);
        }
        /// <summary>
        /// display the welcome screen
        /// </summary>
        public void DisplayWelcomeScreen()
        {
            StringBuilder sb = new StringBuilder();
            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayMessage(" Thank you for playing the Traveling Salesperson.");
            Console.WriteLine();
            ConsoleUtil.DisplayMessage(" You are a Traveling Salesperson, you will first be asked to set up an account. You will then be asked what type of widgets to buy and sell. ");
            Console.WriteLine();
            sb.Clear();
            sb.AppendFormat(" Your first task will be to set up your account details.");
            ConsoleUtil.DisplayMessage(sb.ToString());
            DisplayContinuePrompt();
        }

        /// <summary>
        /// setup the new salesperson object with the initial data
        /// Note: To maintain the pattern of only the Controller changing the data this method should
        ///       return a Salesperson object with the initial data to the controller. For simplicity in 
        ///       this demo, the ConsoleView object is allowed to access the Salesperson object's properties.
        /// </summary>
        public void DisplaySetupAccount()
        {
            ConsoleUtil.HeaderText = "Account Setup";
            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayMessage("Setup your account now.");
            Console.WriteLine();
            ConsoleUtil.DisplayPromptMessage("Enter your First Name: ");
            _salesperson.FirstName = Console.ReadLine();
            ConsoleUtil.DisplayPromptMessage("Enter your Last Name: ");
            _salesperson.LastName = Console.ReadLine();
            _salesperson.Age = DisplayGetIntegerInRange(1, 130, "Enter your Age: ");
            _salesperson.AccountID = DisplayGetIntegerInRange(1, 10000, "Enter your Account ID: ");
            ConsoleUtil.DisplayPromptMessage("Enter a Product: ");
            _salesperson.ProductName = Console.ReadLine();
            _salesperson.ProductUnits = DisplayGetIntegerInRange(1, 10000, "Enter the number of Products: ");
            Console.WriteLine();
            DisplayContinuePrompt();
        }

        //validation method to prevent invalid integers
        private int DisplayGetIntegerInRange(int min, int max, string prompt)
        {
            int integer = 0;

            bool validAge = false;

            while (!validAge)
            {
                ConsoleUtil.DisplayPromptMessage(prompt);
                if (int.TryParse(Console.ReadLine(), out integer))
                {
                    if (integer > min && integer < max)
                    {
                        validAge = true;
                    }
                    else
                    {
                        Console.WriteLine("Thats not within the range! Try Again");
                        DisplayContinuePrompt();
                    }
                }
                else
                {
                    Console.WriteLine("That's not an integer!");
                    DisplayContinuePrompt();
                }
            }

            return integer;
        }


        /// <summary>
        /// display a closing screen when the user quits the application
        /// </summary>
        public void DisplayClosingScreen()
        {
            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayMessage("Thank you for playing Traveling Salesperson. The more you sell the better the chance you will have to purchase a yacht or small island.");

            DisplayContinuePrompt();
        }

        /// <summary>
        /// get the menu choice from the user
        /// </summary>
        public MenuOption DisplayGetUserMenuChoice()
        {
            MenuOption userMenuChoice = MenuOption.None;
            bool usingMenu = true;
            while (usingMenu)
            {
                // set up display area
                ConsoleUtil.DisplayReset();
                Console.CursorVisible = false;
                // display the menu
                ConsoleUtil.DisplayMessage("Please type the number of your menu choice.");
                Console.WriteLine();
                Console.WriteLine(
                    "\t" + "1. Travel" + Environment.NewLine +
                    "\t" + "2. Buy" + Environment.NewLine +
                    "\t" + "3. Sell" + Environment.NewLine +
                    "\t" + "4. Display Inventory" + Environment.NewLine +
                    "\t" + "5. Display Cities" + Environment.NewLine +
                    "\t" + "6. Display Account Info" + Environment.NewLine +
                    "\t" + "7. Look Into The Future" + Environment.NewLine +
                    "\t" + "8. Travel Back In Time" + Environment.NewLine +
                    "\t" + "E. Exit" + Environment.NewLine);
                // get and process the user's response
                // note: ReadKey argument set to "true" disables the echoing of the key press
                ConsoleKeyInfo userResponse = Console.ReadKey(true);
                switch (userResponse.KeyChar)
                {
                    case '1':
                        userMenuChoice = MenuOption.Travel;
                        usingMenu = false;
                        break;
                    case '2':
                        userMenuChoice = MenuOption.Buy;
                        usingMenu = false;
                        break;
                    case '3':
                        userMenuChoice = MenuOption.Sell;
                        usingMenu = false;
                        break;
                    case '4':
                        userMenuChoice = MenuOption.DisplayInventory;
                        usingMenu = false;
                        break;
                    case '5':
                        userMenuChoice = MenuOption.DisplayCities;
                        usingMenu = false;
                        break;
                    case '6':
                        userMenuChoice = MenuOption.DisplayAccountInfo;
                        usingMenu = false;
                        break;
                    case '7':
                        userMenuChoice = MenuOption.LookIntoTheFuture;
                        usingMenu = false;
                        break;
                    case '8':
                        userMenuChoice = MenuOption.TravelBackInTime;
                        usingMenu = false;
                        break;
                    case 'E':
                    case 'e':
                        userMenuChoice = MenuOption.Exit;
                        usingMenu = false;
                        break;
                    default:
                        break;
                }
            }
            Console.CursorVisible = true;

            return userMenuChoice;
        }
        /// <summary>
        /// get the next city to travel to from the user
        /// </summary>
        /// <returns>string City</returns>
        public string DisplayGetNextCity()
        {
            string nextCity = "";
            ConsoleUtil.HeaderText = "Next City of Travel";
            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayPromptMessage("Enter the next city:");
            nextCity = Console.ReadLine();
            DisplayContinuePrompt();
            return nextCity;
        }

        /// <summary>
        /// get the number of product units to buy from the user
        /// </summary>
        /// <returns>int number of units to buy</returns>
        public int DisplayGetNumberOfUnitsToBuy()
        {
            _salesperson.NumberOfUnitsToAdd = 0;
            ConsoleUtil.HeaderText = "Buy Inventory";
            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayPromptMessage($"Enter the number of {_salesperson.ProductName} to buy:  ");
            _salesperson.NumberOfUnitsToAdd = int.Parse(Console.ReadLine());
            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayMessage(_salesperson.NumberOfUnitsToAdd + $" {_salesperson.ProductName } have been added to your inventory ");
            DisplayContinuePrompt();
            return _salesperson.NumberOfUnitsToAdd;
        }

        /// <summary>
        /// get the number of product units to sell from the user
        /// </summary>
        /// <returns>int number of units to sell</returns>
        public int DisplayGetNumberOfUnitsToSell()
        {
            _salesperson.NumberOfUnitsToSell = 0;
            ConsoleUtil.HeaderText = "Sell Inventory";
            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayPromptMessage($"Enter the number of {_salesperson.ProductName} to sell:  ");
            _salesperson.NumberOfUnitsToSell = int.Parse(Console.ReadLine());
            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayMessage(_salesperson.NumberOfUnitsToSell + $" {_salesperson.ProductName } have been subtracted from your inventory ");
            DisplayContinuePrompt();
            return _salesperson.NumberOfUnitsToSell;
        }
 
        /// <summary>
        /// display the current inventory
        /// </summary>
        public void DisplayInventory()
        {
            ConsoleUtil.HeaderText = "Current Inventory";
            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayMessage($"Number of {_salesperson.ProductName}: {_salesperson.ProductUnits + _salesperson.UnitsAdded - _salesperson.UnitsSubtracted } ");
            DisplayContinuePrompt();
        }

        /// <summary>
        /// display a list of the cities traveled
        /// </summary>
        public void DisplayCitiesTraveled()
        {
            ConsoleUtil.HeaderText = "Cities Traveled To";
            ConsoleUtil.DisplayReset();
            foreach (string city in _salesperson.LocationsVisited)
            { 
                ConsoleUtil.DisplayMessage(city);
            }
            DisplayContinuePrompt();
        }

        /// <summary>
        /// display the current account information
        /// </summary>
        public void DisplayAccountInfo()
        {
            ConsoleUtil.HeaderText = "Account Info";
            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayMessage("First Name: " + _salesperson.FirstName);
            ConsoleUtil.DisplayMessage("Last Name: " + _salesperson.LastName);
            ConsoleUtil.DisplayMessage("Age: " + _salesperson.Age);
            ConsoleUtil.DisplayMessage("Account ID: " + _salesperson.AccountID);
            ConsoleUtil.DisplayMessage("Product Name: " + _salesperson.ProductName);
            ConsoleUtil.DisplayMessage($"Number of {_salesperson.ProductName}: {_salesperson.ProductUnits + _salesperson.UnitsAdded - _salesperson.UnitsSubtracted } ");
            DisplayContinuePrompt();
        }

        public void LookIntoTheFuture()
        {
            ConsoleUtil.HeaderText = "Look Into the Future";
            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayMessage($" {_salesperson.FirstName} {_salesperson.LastName} you need to sell more {_salesperson.ProductName} or purchase a crystal ball");
            DisplayContinuePrompt();
        }

        public void TravelBackInTime()
        {
            Random backInTime = new Random();
            ConsoleUtil.HeaderText = "Travel Back In Time";
            ConsoleUtil.DisplayReset();
            ConsoleUtil.DisplayMessage($" {_salesperson.FirstName} {_salesperson.LastName} you have traveled back to the year of:");
            Console.WriteLine(backInTime.Next(1885,2015));
            
            DisplayContinuePrompt();
        }

        #endregion
    }
}
