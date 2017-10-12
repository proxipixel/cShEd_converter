using System;
using System.Globalization;

namespace ConsoleApplication
{
    public class Program
    {
        //method that displays of currency-specific icon with final amount output 
        private static string CurrSymb(int currType)
        {
            RegionInfo us = new RegionInfo("US");
            RegionInfo gb = new RegionInfo("GB");
            RegionInfo ru = new RegionInfo("RU");
            string[] currCountry = { "", us.ISOCurrencySymbol, gb.ISOCurrencySymbol, ru.ISOCurrencySymbol };
            return currCountry[currType];
        }
        public static void Main(string[] args)
        {
            ConsoleKeyInfo userInput; //container for interception of a key pressed by user to repete or close the app
            Console.WriteLine("To perform currency exchage follow further steps.\nSelect your options and conferm each one by pressing 'Enter' key.\n");

            //start of the exchange process's loop
            do
            {

                //declaration of app's variables
                double currAmount = 0.0;
                int currChoise1 = 0;
                int currChoise2 = 0;

                //loop for amount inputcurrAmount < 0
                Console.WriteLine("Type an amount you have for exchange:\n");
                while (!Double.TryParse(Console.ReadLine(), out currAmount) | currAmount < 0)
                {
                    Console.WriteLine("\nThe amount for exchange must contain only digits above zero.");
                }

                //"convert from" type of currency definition loop
                do
                {
                    Console.WriteLine("\nType a number corresponding to a currency you have: 1 - USD | 2 - GBP | 3 - RUB\n");
                    while (!Int32.TryParse(Console.ReadLine(), out currChoise1) || currChoise1 < 1 || currChoise1 > 3)
                    {
                        Console.WriteLine("\nOnly digits 1, 2 or 3 must be entered to choose a currency type.");
                    }

                    //"convert to" type of currency definition loop
                    Console.WriteLine("\nType a number corresponding to a currency you want to get: 1 - USD | 2 - GBP | 3 - RUB\n");
                    while (!Int32.TryParse(Console.ReadLine(), out currChoise2) || currChoise2 < 1 || currChoise2 > 3)
                    {
                        Console.WriteLine("\nOnly digits 1, 2 or 3 must be entered to choose a currency type.");
                    }

                    if (currChoise1 == currChoise2)
                        Console.WriteLine("\nLooks like you've selected the same currency twice !\n\nFeeling lucky to try with various currencies ?");
                } while (currChoise1 == currChoise2);

                //computation and displaying of an outcome depending on options previously have been chosen by user
                switch (currChoise1)
                {
                    case 1:
                        currAmount = currChoise2 == 2 ? currAmount * 0.8 : currAmount * 60.0;
                        Console.WriteLine("It's {0} {1}", currAmount, CurrSymb(currChoise2));
                        break;
                    case 2:
                        currAmount = currChoise2 == 1 ? currAmount * 1.2 : currAmount * 72.5;
                        Console.WriteLine("It's {0} {1}", currAmount, CurrSymb(currChoise2));
                        break;
                    case 3:
                        currAmount = currChoise2 == 1 ? currAmount * 0.015 : currAmount * 0.013;
                        Console.WriteLine("It's {0} {1}", currAmount, CurrSymb(currChoise2));
                        break;
                    default:
                        Console.WriteLine("You've mistaken in one of previous steps, please repeat steps");
                        break;
                }

                //"application repetition/closing by user's choise" procedure
                Console.WriteLine("\nTo close the application window press 'Enter' key or any other key to perform another exchange operation.\n");
                userInput = Console.ReadKey(true);

            } while (userInput.Key != ConsoleKey.Enter);
        }
    }
}