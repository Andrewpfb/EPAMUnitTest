using System;
using System.Collections.Generic;
using ConsoleApp1.Repositories;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Subject sbj1 = new Subject("Math", new List<int> { 5, 6, 5, 6 });
            Subject sbj2 = new Subject("Physic", new List<int> { 1, 2, 3, 4, 5 });
            Subject sbj3 = new Subject("Music", new List<int> { 1, 3, 5, 7, 9 });
            Subject sbj4 = new Subject("Language", new List<int> { 2, 4, 6, 8, 10 });
            Student std1 = new Student("Ivanov", "Ivan", new List<Subject> { sbj1, sbj2 });
            Student std2 = new Student("Petrov", "Petr", new List<Subject> { sbj3, sbj4 });

            sbj1.GetInfo();
            sbj2.GetInfo();
            sbj3.GetInfo();
            sbj4.GetInfo();

            std1.GetInfo();
            std2.GetInfo();

            //Программа минимально работает. Чтобы собралось, надо закомментить функцию GetInfo в интерфейсе IAverageScore
        }
    }
}
