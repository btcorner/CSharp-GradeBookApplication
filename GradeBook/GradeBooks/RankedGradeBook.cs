using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
            var gradeDiff = Students.Count / 5;
            List<Student> SortedStudents = Students.OrderByDescending(x => x.AverageGrade).ToList();
            int locationInList = SortedStudents.FindIndex(x => x.AverageGrade == averageGrade) + 1;

            switch(locationInList)
            {
                case int l when l <= gradeDiff:
                    return 'A';
                case int l when l <= gradeDiff * 2:
                    return 'B';
                case int l when l <= gradeDiff * 3:
                    return 'C';
                case int l when l <= gradeDiff * 4:
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
