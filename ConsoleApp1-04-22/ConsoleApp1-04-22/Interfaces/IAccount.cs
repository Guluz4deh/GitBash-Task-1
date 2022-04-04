using System;
using System.Collections.Generic;
using System.Text;
using _28_03_2022_ConsoleApp.Helpers;

namespace _30_03_2022.Interfaces
{
    public interface IAccount 
    {
        public bool PasswordChecker(string input);
        public string ShowInfo();
    }
}
