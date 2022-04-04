using _28_03_2022_ConsoleApp.Helpers;
using ConsoleApp1_04_22.Exceptions;
using System;
namespace ConsoleApp1_04_22.Models
{
    class Group
    {
        private string _groupno;

        private static Student[] _students = new Student[0];

        public static int studentcount = 0;
        private Group(string groupno)
        {
            this._groupno = groupno;
        }
        public static void AddGroup()
        {
            string groupno = null;
            CheckGroupNo(groupno);

            _ = new Group(groupno);
        }
        public static string CheckGroupNo(string input, string output = "Group No")
        {
        tryInputAgain:
            Console.Write($"Enter the {output}(Ex: AB123): ");
            input = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(input))
            {
                Console.Clear();
                Console.WriteLine($"{output} can not be empty!");
                goto tryInputAgain;
            }
            if (input.Length == 5) { }
            else
            {
                Console.Clear();
                Console.WriteLine($"The length of the {output} must be equal to 5!");
                goto tryInputAgain;
            }
            if (char.IsUpper(input[0]) && char.IsUpper(input[1]) && char.IsDigit(input[2]) && char.IsDigit(input[3]) && char.IsDigit(input[4])) { }
            else
            {
                Console.Clear();
                Console.WriteLine($"Password condition is wrong.Please try again !");
                goto tryInputAgain;
            }
            return input;
        }
        public static void AddStudent()
        {
            string name = null;
            name = name.StringInputExtension("Student Name");

            string surname = null;
            surname = surname.StringInputExtension("Student Surname");

            int? point = null;
            point = point.IntPointInputExtension("Student Point");
            studentcount++;
            Student student = new Student(name, surname, (int)point);
            Array.Resize(ref _students, _students.Length + 1);
            _students[_students.Length - 1] = student;
            Console.Clear();
            Console.WriteLine("Student Successfully created!");
        }
        public static void StudentInfo()
        {
            foreach (var student in _students)
            {
                Console.WriteLine(student.ToString());
            }
        }
        public static void SearchForId()
        {
            int? id = null;
            id = id.IntAgeInputExtension("User Id for Search");
            --id;
            try
            {
                Console.WriteLine(_students[(int)id]);
            }
            catch (Exception)
            {
                throw new IndexOutTheRangeException("This student id was not found.\nPlease try again !");
            }
        }
        public static void StudentCreateByLimit()
        {
            creatgroup:
            if (studentcount < 4)
            {
                AddStudent();
                goto creatgroup;
            }
            if (studentcount <= 14)
            {
                AddStudent();
            }
            else
            {
                Console.WriteLine("Your Group is Full !!");
            }
        }
    }
}
