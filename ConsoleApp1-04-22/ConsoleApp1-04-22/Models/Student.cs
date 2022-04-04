using System;
using System.Collections.Generic;
using System.Text;
using _28_03_2022_ConsoleApp.Helpers;
using System.Collections;
using ConsoleApp1_04_22.Exceptions;

namespace ConsoleApp1_04_22.Models
{
    class Student
    {

        private static int _idCounter;

        private int id;
        private string name;
        private string surname;
        private int point;

        static Student()
        {
            _idCounter = 0;
        } 
        public Student(string name, string surname, int point) : this()
        {
            this.name = name;
            this.surname = surname;
            this.point = point;
        }
        private Student()
        {
            this.id = ++_idCounter;
        }
        
        public override string ToString()
        {
            return $"ID - {id} \n- Student Name : {name} \n- Student Surname : {surname} \n- Student Point : {point}";
        }
        public string ShowInfo() { return $"{id} - {name} {surname} {point}"; }

    }
}
