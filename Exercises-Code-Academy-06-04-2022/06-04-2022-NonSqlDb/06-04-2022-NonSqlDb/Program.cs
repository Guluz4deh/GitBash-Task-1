using _06_04_2022_NonSqlDb.Helpers;
using _06_04_2022_NonSqlDb.Models;
using _28_03_2022_ConsoleApp.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading;

namespace FileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuLoading();
            Menu();
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
            Console.Clear();
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
        public static void Menu()
        {
        Menu:
            Console.WriteLine("\n===================================\n1: See all people\n2: Create a person\n3: Remove all person\n0: Exit\n===================================");
            string input = null;
            input = input.StringInputExtension("input");
            switch (input)
            {
                case "1":
                    InputLoading();
                    ConsoleDesign();
                    GetAllPeople();
                    ConsoleDesign();
                    goto Menu;
                case "2":
                    CreatePerson();
                    ConsoleDesign();
                    InputLoading();
                    goto Menu;
                case "3":
                    RemovePeopleById();
                    InputLoading();
                    goto Menu;
                case "0":
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid input try again!");
                    goto Menu;
            }
        }
        public static void ConsoleDesign()
        {
            Console.WriteLine("=================================");
        }
        public static void GetAllPeople()
        {
            Console.Clear();
            string rootDir = Constans.rootDir;
            IEnumerable<string> peopleJson = Read(rootDir);
            List<Person> people = new List<Person>();
            foreach (var item in peopleJson)
            {
                Person person = JsonSerializer.Deserialize<Person>(item);
                people.Add(person);
            }
            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }
        public static void RemovePeopleById()
        {
            int? id = null;
            id = id.IntInputExtension("Id for Delete Person");
            string rootDir = Constans.rootDir;
            IEnumerable<string> peopleJson = Read(rootDir);
            List<Person> people = new List<Person>();
            foreach (var item in peopleJson)
            {
                Person personaddid = JsonSerializer.Deserialize<Person>(item);
                people.Add(personaddid);
            }

            var searchingfordelete = people.Find(x => x.Id == id);
            people.Remove(searchingfordelete);


            string jsonPerson = JsonSerializer.Serialize(people);
            Write(rootDir, jsonPerson);
        }
        public static void CreatePerson()
        {
            #region createperson
            Console.Clear();
            string name = null;
            name = name.StringInputExtension("Person Name");
            string surname = null;
            surname = surname.StringInputExtension("Person Surname");
            #endregion
            string rootDir = Constans.rootDir;
            IEnumerable<string> peopleJson = Read(rootDir);
            List<Person> people = new List<Person>();
            foreach (var item in peopleJson)
            {
                Person personaddid = JsonSerializer.Deserialize<Person>(item);
                people.Add(personaddid);
            }
                var last = people[people.Count - 1];
            int id;
            id = last.Id;
            ++id;
            Person person = new Person(name, surname, id);
            string jsonPerson = JsonSerializer.Serialize(person);
            Write(rootDir, jsonPerson);
            Console.WriteLine("----------------------------------------\nPerson created successfully\n----------------------------------------");
        }
        public static string CreateFile(string rootDir)
        {
            string contentDir = Path.Combine(rootDir, "Content");

            if (!Directory.Exists(contentDir))
            {
                Directory.CreateDirectory(contentDir);
            }
            string fileDir = Path.Combine(contentDir, "people.txt");

            if (!File.Exists(fileDir))
            {
                File.Create(fileDir);
            }
            return fileDir;
        }
        public static void Write(string rootDir, string text)
        {
            string fileDir = CreateFile(rootDir);
            using (var textWriter = new StreamWriter(fileDir, true))
            {
                textWriter.WriteLine(text);
            }
        }
        public static IEnumerable<string> Read(string rootDir)
        {
            string fileDir = CreateFile(rootDir);
            IEnumerable<string> lines = File.ReadLines(fileDir);
            return lines;
        }
    }
}
