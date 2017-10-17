using System;
using System.Collections.Generic;
using ConsoleApp1.Interface;


namespace ConsoleApp1.Repositories
{
    public class Group : IAverageScore
    {
        public Group()
        {
            GroupName = "";
            StudentList = new List<Student>();
        }
        public Group(string groupName,List<Student> listStudent)
        {
            GroupName = groupName;
            StudentList = listStudent;
        }
        public string GroupName { get; set; }
        public List<Student> StudentList { get; set; }
        public int GetAverageScore()
        {
            int _groupNotesSum = 0;
            foreach (Student std in StudentList)
            {
                _groupNotesSum += std.GetAverageScore();
            }
            return _groupNotesSum / StudentList.Count;
        }
        public void GetInfo()
        {
            Console.WriteLine("Group: {0} {1}", GroupName);
            Console.WriteLine("Student notes: ");
            foreach (Student std in StudentList)
            {
                Console.Write("Student: {0} {1} ", std.Firstname,std.Lastname);
                foreach (Subject sbj in std.StudentSubject)
                {
                    for (int i = 0; i < sbj.SubjectNote.Count; i++)
                    {
                      //  Console.Write("{0} ", sjb.SubjectNote[i]); //не успел доделать
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine("Student average score: {0}", GetAverageScore());
        }
    }
}
