using System;
using System.Collections.Generic;
using System.Text;
using _30_03_2022.Interfaces;
using _28_03_2022_ConsoleApp.Helpers;
using System.Collections;

namespace ConsoleApp1_04_22.Models
{
    class User : IAccount, IEnumerable
    {
        #region values
        private static int _idCounter;
        private static User[] _user;

        #endregion
        private int id;
        private string name;
        private string surname;
        private string email;
        private string password;

        public bool PasswordChecker(string input)
        {
            bool bigletter = false;
            bool smallletter = false;
            bool digit = false;
            if (input.Length >= 7 && input.Length <= 15)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (bigletter == false && char.IsUpper(input[i]))
                    {
                        bigletter = true;
                    }
                    else if (smallletter == false && char.IsLower(input[i]))
                    {
                        smallletter = true;
                    }
                    else if (digit == false && char.IsDigit(input[i]))
                    {
                        digit = true;
                    }
                }
                if (bigletter == false || smallletter == false || digit == false)
                {
                    Console.Clear();
                    Console.WriteLine("Password condition is wrong.Please try again !");
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Password length is wrong.Please try again !");
                return false;
            }

        }

        static User()
        {
            _idCounter = 0;
            _user = new User[0];
        }
        public static void AddUser()
        {
            string name = null;
            name = name.StringInputExtension("Your Name");

            string surname = null;
            surname = surname.StringInputExtension("Your Surname");

            string email = null;
            email = email.StringInputExtension("Your Email");

            string password = null;
            tryagain:
            password = password.StringInputExtension("Your Password");
            IAccount pass = new User();
            if (pass.PasswordChecker(password) == true)
            {
                pass.PasswordChecker(password);
            }
            else
            {
                goto tryagain;
            }

            _ = new User(name, surname, email, password);
            Console.Clear();
            Console.WriteLine("User Successfully created!");
        }
        public string ShowInfo()
        {
            return $"ID - {id} \n- User name : {name} \n- User surname : {surname} \n- User email : {email} \n- User password : {password}";
        }
        private User()
        {
            this.id = ++_idCounter;
            Array.Resize(ref _user, _user.Length + 1);
            _user[_user.Length - 1] = this;
        }
        public User(string name, string surname, string email, string password) : this()
        {
            this.name = name;
            this.surname = surname;
            this.email = email;
            this.password = password;
        }
        public static void PrintUsers()
        {
            foreach (var user in _user)
            {
                Console.WriteLine(user.ShowInfo());
            }
        }
        public static void SearchForId()
        {
            int? id = null;
            id = id.IntAgeInputExtension("User Id for Search");
            --id;
            Console.WriteLine(_user[(int)id]);
        }
        public override string ToString()
        {
            return $"ID - {id} \n- User name : {name} \n- User surname : {surname} \n- User email : {email} \n- User password : {password}";
        }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
