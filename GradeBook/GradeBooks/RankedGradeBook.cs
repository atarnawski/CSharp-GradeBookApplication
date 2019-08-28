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
            var counter = 0d;
            var percentage = 0d;
            var A = 0.2;



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
                averageList.Reverse();
                foreach(var averageGradeInList in averageList)
                {
                    if(averageGrade >= averageGradeInList) { break; }
                    counter++;
                }
                Math.Ceiling(percentage = counter / Students.Count);
                if (percentage < A) { return 'A'; }
                else if (percentage < 2*A) { return 'B'; }
                else if (percentage < 3*A) { return 'C'; }
                else if (percentage < 4*A) { return 'D'; }
                
            }
            return 'F';
        }
    }
}
