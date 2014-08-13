using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Grades
{
    public class GradeBook : GradeTracker
    {
        public GradeBook(string name = "There is no name")
        {
            Name = name;
            grades = new List<float>();
        }

        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }

        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade < 100)
            {
                grades.Add(grade);
            }
        }

        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("In GB Compute");
            GradeStatistics stats = new GradeStatistics();
            
            float sum = 0f;
            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            

            stats.AverageGrade = sum / grades.Count;
            return stats;
        }

        public override void WriteGrades(TextWriter textWriter)
        {
            textWriter.WriteLine("Grades:");
            for (int i = 0; i < grades.Count; i++)
            {
                textWriter.WriteLine(grades[i]);
            }
            textWriter.WriteLine("***********");
        }

        protected List<float> grades;

    }
}
