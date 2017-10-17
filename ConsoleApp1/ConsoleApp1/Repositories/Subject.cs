using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleApp1.Interface;


namespace ConsoleApp1.Repositories
{
    public class Subject : IAverageScore
    {
        public Subject()
        {
            SubjectName = "";
            SubjectNote = new List<int>();
        }
        public Subject(string sbjName, List<int> sbjNotes)
        {
            SubjectName = sbjName;
            SubjectNote = sbjNotes;
        }
        public string SubjectName { get; set; }
        public List<int> SubjectNote { get; set; }
        public int GetAverageScore()
        {
            return SubjectNote.Sum() / SubjectNote.Count();
        }
        public void GetInfo()
        {
            Console.WriteLine("Subject name: {0}", SubjectName);
            Console.Write("Subject {0} notes: ",SubjectName);
            foreach (int note in SubjectNote)
            {
                Console.Write("{0} ", note);
            }
            Console.WriteLine();
            Console.WriteLine("Subject {1} average score: {0}", GetAverageScore(),SubjectName);
        }
    }
}
