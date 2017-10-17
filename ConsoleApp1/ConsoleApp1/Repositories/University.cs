using System.Collections.Generic;
using ConsoleApp1.Interface;


namespace ConsoleApp1.Repositories
{
    public class University : IAverageScore
    {
        public string UniName { get; set; }
        public List<Faculty> FacultyList { get; set; }
        public int GetAverageScore()
        {
            int _facultyNotesSum = 0;
            foreach (Faculty fcl in FacultyList)
            {
                _facultyNotesSum += fcl.GetAverageScore();
            }
            return _facultyNotesSum / FacultyList.Count;
        }
    }
}
