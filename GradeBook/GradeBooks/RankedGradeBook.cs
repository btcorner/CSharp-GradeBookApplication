using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) throw new InvalidOperationException("Ranked-grading requires a minimum of 5 students to work");
            double min = Students.Min(x => x.AverageGrade);
            double max = Students.Max(x => x.AverageGrade);
            double diff = max - min;

            switch (averageGrade)
            {
                case double a when a >= (min + (diff * 0.8)):
                    return 'A';
                case double a when a >= (min + (diff * 0.6)):
                    return 'B';
                case double a when a >= (min + (diff * 0.4)):
                    return 'C';
                case double a when a >= (min + (diff * 0.2)):
                    return 'D';
                default:
                    return 'F';
            }
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }

    }
}
