using System;
using System.Collections.Generic;
using ConsoleApp1.Interface;


namespace ConsoleApp1.Repositories
{
    public class Student : IAverageScore
    {
        public Student()
        {
            Firstname = "";
            Lastname = "";
            StudentSubject = new List<Subject>();
        }
        public Student(string firstname, string lastname, List<Subject> studentsubject)
        {
            Firstname = firstname;
            Lastname = lastname;
            StudentSubject = studentsubject;
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<Subject> StudentSubject { get; set; }
        public int GetAverageScore()
        {
            int _studentNoteSum = 0;
            foreach (Subject sbj in StudentSubject)
            {
                _studentNoteSum += sbj.GetAverageScore();
            }
            return _studentNoteSum / StudentSubject.Count;
        }
        public void GetInfo()
        {
            Console.WriteLine("Student: {0} {1}", Firstname, Lastname);
            Console.WriteLine("Student notes: ");
            foreach (Subject sjb in StudentSubject)
            {
                Console.Write("Subject name: {0} ", sjb.SubjectName);
                for (int i = 0; i < sjb.SubjectNote.Count; i++)
                {
                    Console.Write("{0} ", sjb.SubjectNote[i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine("Student average score: {0}", GetAverageScore());
        }
    }
}
