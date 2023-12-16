using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Possible_coin_combinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double amount = 0;
                bool isValidInput = false;

                while (!isValidInput)
                {
                    Console.Write("Enter an amount (not bigger than 5.00): ");
                    string input = Console.ReadLine();

                    if (string.IsNullOrEmpty(input))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No input provided.");
                        Console.ResetColor();
                        continue;
                    }

                    if (!double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out amount))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        Console.ResetColor();
                        continue;
                    }

                    if (amount < 0 || amount > 5.00)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter an amount between 0 and 5.00.");
                        Console.ResetColor();
                        continue;
                    }

                    isValidInput = true;
                }

                Coin_Combinator coinCombinator = new Coin_Combinator();
                List<double> minCoinsCombination = coinCombinator.GetMinimumCoinCombination(amount);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("All combinations:");
                Console.ResetColor();

                foreach (var combination in coinCombinator.GetAllCombinations(amount))
                {
                    Console.WriteLine(string.Join(", ", combination));
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nCombination with the smallest number of coins:");
                Console.ResetColor();

                if (minCoinsCombination != null && minCoinsCombination.Count > 0)
                {
                    Console.WriteLine(string.Join(", ", minCoinsCombination));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("No combination found.");
                    Console.ResetColor();
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Press Enter to exit the application.");               
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An error occurred: {ex.Message}");
                Console.ResetColor();

                Console.WriteLine("Press Enter to exit the application.");
                Console.ReadLine();
            }
        }
    }
}
