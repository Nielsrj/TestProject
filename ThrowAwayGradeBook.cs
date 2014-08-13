using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class ThrowAwayGradeBook : GradeBook, IGradeTracker
    {
        public ThrowAwayGradeBook(string name)
            :base(name)
        {

        }


        public override GradeStatistics ComputeStatistics()
        {
            Console.WriteLine("In TA Compute");
            float lowest = float.MaxValue;
            foreach (float grade in grades)
            {
                lowest = Math.Min(lowest, grade);
            }
            
            grades.Remove(lowest);
            return base.ComputeStatistics();
        }
    }
}
