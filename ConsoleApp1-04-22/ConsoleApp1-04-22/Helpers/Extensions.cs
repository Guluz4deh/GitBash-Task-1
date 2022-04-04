using System;
using System.Collections.Generic;
using System.Text;

namespace _28_03_2022_ConsoleApp.Helpers
{
    public static class Extensions
    {
        #region Extensions
        public static string StringInputExtension(this string input, string output = "input")
        {
        tryInputAgain:
            Console.Write($"Enter the {output}: ");
            input = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(input))
            {
                Console.Clear();
                Console.WriteLine($"{output} can not be empty!");
                goto tryInputAgain;
            }
            return input;

        }
        public static bool BoolInputExtension(this bool input, string output = "input")
        {
            Console.Write($"Enter the {output}: ");
            input = true;
                Console.Clear();
                Console.WriteLine($"{output} can not be empty!");
            return input;
        }
        public static int IntInputExtension(this int? input, string? output)
        {
            TryAgain:
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
                Console.WriteLine("Invalid input.\nPlease try again!");
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
        public static int IntSalaryInputExtension(this int? input, string? output)
        {
        TryAgain:
            string consoleInput = null;
            consoleInput = consoleInput.StringInputExtension(output);
            int? convInput = null;
            try
            {
                convInput = Convert.ToInt32(consoleInput);
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid input.\nPlease try again!");
                goto TryAgain;
            }
            if (convInput is null)
            {
                Console.Clear();
                Console.WriteLine("Wrong!\nPlease try again.");
                goto TryAgain;
            }
            if (convInput < 0 && convInput > 100000)
            {
                Console.Clear();
                Console.WriteLine("Wrong Salary!\nPlease try again.");
                goto TryAgain;
            }
            return (int)convInput;
        }
        public static int IntAgeInputExtension(this int? input, string? output)
        {
            TryAgain:
            string consoleInput = null;
            consoleInput = consoleInput.StringInputExtension(output);
            int? convInput = null;
            try
            {
                convInput = Convert.ToInt32(consoleInput);
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid input.\nPlease try again!");
                goto TryAgain;
            }
            if (convInput is null)
            {
                Console.Clear();
                Console.WriteLine("Wrong!\nPlease try again.");
                goto TryAgain;
            }
                if (convInput < 0 && convInput > 150)
                {
                    Console.Clear();
                    Console.WriteLine("Wrong Age!\nPlease try again.");
                    goto TryAgain;
                }

            return (int)convInput;
        }
        #endregion
        public static string StringPassWordInputExtension(this string input, string output = "input")
        {
            #region emptychecker
            bool bigletter = false;
            bool smallletter = false;
            bool digit = false;
            tryInputAgain:
            Console.Write($"Enter the {output}: ");
            input = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(input))
            {
                Console.Clear();
                Console.WriteLine($"{output} can not be empty!");
                goto tryInputAgain;
            }
            #endregion
            if (input.Length >= 7 && input.Length <= 15)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (bigletter == false && char.IsUpper(input[i]))
                    {
                            bigletter = true;
                    }
                    else if(smallletter == false && char.IsLower(input[i]))
                    {
                            smallletter = true;
                    }
                    else if(digit == false && char.IsDigit(input[i]))
                    {
                            digit = true;
                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Password length is wrong.Please try again !");
                goto tryInputAgain;
            }
            if (bigletter == false || smallletter == false || digit == false)
            {
                Console.Clear();
                Console.WriteLine("Password condition is wrong.Please try again !");
                goto tryInputAgain;
            }
            return input;

        }
        public static int IntPointInputExtension(this int? input, string? output)
        {
        TryAgain:
            string consoleInput = null;
            consoleInput = consoleInput.StringInputExtension(output);
            int? convInput = null;
            try
            {
                convInput = Convert.ToInt32(consoleInput);
            }
            catch (Exception)
            {
                Console.Clear();
                Console.WriteLine("Invalid input.\nPlease try again!");
                goto TryAgain;
            }
            if (convInput is null)
            {
                Console.Clear();
                Console.WriteLine("Wrong!\nPlease try again.");
                goto TryAgain;
            }
            if (convInput < 0 || convInput > 100)
            {
                Console.Clear();
                Console.WriteLine("Wrong Student Point!\nPlease try again.");
                goto TryAgain;
            }
            return (int)convInput;
        }
    }
}
