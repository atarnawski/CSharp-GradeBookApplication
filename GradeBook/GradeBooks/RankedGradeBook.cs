using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            var counter = 0;
            var listPosition = 0;
            if (Students.Count < 5)
            {
                throw new InvalidOperationException();
            }
            else
            {
                var averageList = new List<Double>();
                foreach (var student in Students)
                {
                    averageList.Add(student.AverageGrade);
                }
                averageList.Sort();
                foreach(var averageGradeList in averageList)
                {
                    if(averageGrade < averageGradeList) { listPosition = counter; }
                    counter++;
                }
                if(listPosition <= 0.2 * Students.Count) { return 'A'; }
                if (listPosition <= 0.4 * Students.Count) { return 'B'; }
                if (listPosition <= 0.6 * Students.Count) { return 'C'; }
                if (listPosition <= 0.8 * Students.Count) { return 'D'; }
            }
            return 'F';
        }
    }
}
