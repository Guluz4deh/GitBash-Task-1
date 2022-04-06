using System;
using System.Collections.Generic;
using System.Text;
using FileIO;

namespace _06_04_2022_NonSqlDb.Models
{
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Id { get; set; }

        public Person()
        {
        }
        public Person(string name, string surname, int id) : this()
        {
            Name = name;
            Surname = surname;
            Id = id;
        }
        public override string ToString()
        {
            return $"ID =={Id}== Name is : {Name} and Surname is {Surname}";
        }

    }
}
