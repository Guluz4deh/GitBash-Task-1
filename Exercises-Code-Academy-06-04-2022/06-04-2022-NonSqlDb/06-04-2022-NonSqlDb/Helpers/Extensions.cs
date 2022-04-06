using System;
using System.Collections.Generic;
using System.Text;
using FileIO;

namespace _28_03_2022_ConsoleApp.Helpers
{
    public static class Extensions
    {
        public static string StringInputExtension(this string input, string output = "input")
        {

        tryInputAgain:
            Console.Write($"Enter your {output}: ");
            input = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(input))
            {
                Console.Clear();
                Console.WriteLine($"{output} can not be empty!");
                goto tryInputAgain;
            }
            return input;
        }
        public static int IntInputExtension(this int? input, string? output)
        {
            TryAgain:
            Console.WriteLine($"Please enter your {output}: ");
            string consoleInput = null;
            consoleInput = consoleInput.StringInputExtension(output);
            int? convInput = null;
            try
            {
                convInput = Convert.ToInt32(consoleInput);
            }
            catch(Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid input!\nTry again!");
                goto TryAgain;
            }
            if (convInput is null)
            {
                Console.Clear();
                Console.WriteLine("Wrong!\nPlease try again.");
                goto TryAgain;
            } 
            return (int) convInput ;
        }
     }
}
