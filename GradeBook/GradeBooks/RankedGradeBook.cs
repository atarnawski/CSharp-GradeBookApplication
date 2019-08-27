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
            var A = 0.2 * Students.Count;
            var B = 0.4 * Students.Count;
            var C = 0.6 * Students.Count;
            var D = 0.8 * Students.Count;



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
                    if(averageGrade < averageGradeList) { break; }
                    counter++;
                }
                if (counter <= A) { return 'A'; }
                if (counter > A || counter <= B) { return 'B'; }
                if (counter > B || counter <= C) { return 'C'; }
                if (counter > C || counter <= D) { return 'D'; }
            }
            return 'F';
        }
    }
}
