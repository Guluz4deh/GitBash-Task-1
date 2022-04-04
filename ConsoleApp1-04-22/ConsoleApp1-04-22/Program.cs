using _28_03_2022_ConsoleApp.Helpers;
using ConsoleApp1_04_22.Exceptions;
using ConsoleApp1_04_22.Models;
using System;
using System.Text;
using System.Threading;

namespace ConsoleApp1_04_22
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuLoading();
            Menu();
        }
        public static void Menu()
        {
            //ShowSpinner();
            Console.WriteLine(@" _    _  ____   _      ____   ____    _    _    _____
/ \  / |/ __/  / \    /   _\ /  _  \ / \__/ |  /  __/
| |  | ||  \   | |    |  /   | / \ | | |\/| |  |  \  
| |/\| ||  /_  | |_ /\|  \__ | \_/ | | |  | |  |  /__
\_ / \_|\____\ \_____/\____/ \_____/ \_/  \_|  \_____\
                                            ");
            User.AddUser();
        Menu:
            Console.WriteLine(" 1 - Show information:\n " +
                              "2 - Create new group:\n ");
            string input = null;
            input = input.StringInputExtension("Input");
            switch (input)
            {
                case "1":
                    Console.Clear();
                    InputLoading();
                    ConsoleDesign();
                    User.PrintUsers();
                    ConsoleDesign();
                    goto Menu;
                case "2":
                    Group.AddGroup();
                    Console.Clear();
                menusection:
                    Console.WriteLine(" 1 - Show all students:\n " +
                              "2 - Get student by Id:\n " +
                              "3 - Add student\n " +
                              "0 - Quit\n ");
                    string menusection = null;
                    menusection = menusection.StringInputExtension("Input");
                    switch (menusection)
                    {
                        case "1":
                            Console.Clear();
                            InputLoading();
                            ConsoleDesign();
                            Group.StudentInfo();
                            ConsoleDesign();
                            goto menusection;
                        case "2":
                            Console.Clear();
                            InputLoading();
                            ConsoleDesign();
                            try
                            {
                                Group.SearchForId();
                            }
                            catch (IndexOutTheRangeException ex)
                            {
                                Console.Clear();
                                Console.WriteLine(ex.Message);
                                goto menusection;
                            }
                            ConsoleDesign();
                            goto menusection;
                        case "3":
                            Console.Clear();
                            ConsoleDesign();
                            Group.StudentCreateByLimit();
                            InputLoading();
                            ConsoleDesign();
                            goto menusection;
                        case "0":
                            Console.Clear();
                            Console.WriteLine("=== THANKS ===");
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("Invalid input.Please try again.");
                            goto menusection;
                    }
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input.Please try again.");
                    goto Menu;
            }
        }
        static void MenuLoading()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n                                     _____________________________________");
            Console.Write("                                     ");
            Console.Write("|");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(100);
                Console.Write("##");
            }

            for (int i = 0; i < 4; i++)
            {
                Thread.Sleep(500);
                Console.Write("##");
            }

            for (int i = 0; i < 7; i++)
            {
                Thread.Sleep(50);
                Console.Write("###");
            }
            Console.Write("|");
            Console.WriteLine("");
            Console.Clear();
        }
        static void InputLoading()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n                                             _____________________");
            Console.Write("                                             ");
            Console.Write("|");
            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(100);
                Console.Write("##");
            }

            for (int i = 0; i < 2; i++)
            {
                Thread.Sleep(500);
                Console.Write("##");
            }

            for (int i = 0; i < 3; i++)
            {
                Thread.Sleep(50);
                Console.Write("###");
            }
            Console.Write("|");
            Console.WriteLine("");
            Console.Clear();
        }


        public static void ConsoleDesign()
        {
            Console.WriteLine("=================================");
        }


    }
}
