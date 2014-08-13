using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.IO;

namespace Grades
{
    class Program
    {
        /// <summary>
        /// C# Fundementals with C#5.0
        /// </summary>       
        static void Main(string[] args)
        {

            IGradeTracker book = CreateGradeBook();
            try
            {
                using (FileStream stream = File.Open("grades.txt", FileMode.Open))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string line = reader.ReadLine();
                    while (line != null)
                    {
                        float grade = float.Parse(line);
                        book.AddGrade(grade);
                        line = reader.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("Could not locate the file grades.txt");
                return;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("No access");
                return;
            }
            //book.DoSomething();
            foreach (float grade in book)
            {
                Console.WriteLine(grade);
            }            
            try
            {
                //Console.WriteLine("Please enter a name for the book");
                //book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid name");
            }

            GradeStatistics stats = book.ComputeStatistics();

            //add reference to event
            //book.NameChanged += onNameChanged;
            //book.NameChanged += onNameChanged;
            //book.NameChanged += onNameChanged2;
            //remove a reference to event
            //book.NameChanged -= onNameChanged;
            /*
             * This next line would wipe out the 3 above and only write 1 line to screen
             * that is 3 asterix's
             * This next line is no longer legal if the delegate is made an event
             * book.NameChanged = new NamedChangedDelegate(onNameChanged2);
             */
            //book.Name = "Your Book";
            //WriteNames(book.Name);
            //int number = 20;
            //WriteBytes(number);
            //WriteBytes(stats.AverageGrade);

            Console.WriteLine("avg = " + stats.AverageGrade);
            Console.WriteLine("lowest = " + stats.LowestGrade);
            Console.WriteLine("highest = " + stats.HighestGrade);
            Console.WriteLine("{0} {1}",stats.LetterGrade, stats.Description);

            //PreviousCode();
        }

        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook("My book");
        }

        private static void onNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("***");
        }

        private static void onNameChanged2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("Name changed from {0} to {1}", args.oldValue, args.newValue);
        }

        
        
        private static void WriteBytes(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            WriteByteArray(bytes);
        }
        
        private static void WriteBytes(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            WriteByteArray(bytes);
        }

        private static void WriteByteArray(byte[] bytes)
        {
            foreach (byte b in bytes)
            {
                Console.Write("0x{0:X}", b);
            }
            Console.WriteLine();
        }

        private static void WriteNames(params string[] names)
        {
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }

/// <summary>
/// Previous Code from Module 3 and before
/// </summary>


        //private static void PreviousCode()
        //{
        //    SpeechSynthesizer synth = new SpeechSynthesizer();
        //    synth.Speak("Hello, How are you?");

        //    Arrays();
        //    Immutable();
        //    PassByValueAndRef();
        //}

        //private static void Arrays()
        //{
        //    float[] grades;
        //    grades = new float[3];

        //    AddGrades(grades);

        //    foreach (float grade in grades)
        //    {
        //        Console.WriteLine(grade);
        //    }
        //    Console.ReadLine();

        //}

        //static void GiveBookAName(ref GradeBook book)
        //{
        //    //book = new GradeBook();
        //    //book.Name = "The New Gradebook";
        //}

        //static void IncrementNumber(ref int number)
        //{
        //    number = 42;
        //}


        //private static void AddGrades(float[] grades)
        //{
        //    if (grades.Length >= 3)
        //    {
        //        grades[0] = 91f;
        //        grades[1] = 89.1f;
        //        grades[2] = 75f;
        //    }            
        //}

        //private static void Immutable()
        //{
        //    string name = " Niels ";
        //    name = name.Trim();

        //    DateTime date = new DateTime(2014, 1, 1);
        //    date = date.AddHours(25);

        //    Console.WriteLine(date);
        //    Console.WriteLine(name);
        //}

        //private static void PassByValueAndRef()
        //{
        //    GradeBook g1 = new GradeBook();
        //    GradeBook g2 = g1;

        //    GiveBookAName(ref g2);
        //    Console.WriteLine(g2.Name);

        //    int x1 = 10;
        //    IncrementNumber(ref x1);
        //    Console.WriteLine(x1);
        //}
    }
}
