using System.Collections.Generic;
using ConsoleApp1.Interface;


namespace ConsoleApp1.Repositories
{
    public class Faculty : IAverageScore
    {
        public string FacultyName { get; set; }
        public List<Group> GroupList { get; set; }
        public int GetAverageScore()
        {
            int _groupNotesSum = 0;
            foreach (Group grp in GroupList)
            {
                _groupNotesSum += grp.GetAverageScore();
            }
            return _groupNotesSum / GroupList.Count;
        }
    }
}
