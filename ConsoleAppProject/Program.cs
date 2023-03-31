//using ConsoleAppProject.App01;
//using ConsoleAppProject.App03;
using ConsoleAppProject.App04;
using ConsoleAppProject.Helpers;
using System;

namespace ConsoleAppProject
{
    /// <summary>
    /// The main method in this class is called first
    /// when the application is started.  It will be used
    /// to start App01 to App05 for CO453 CW1
    /// 
    /// This Project has been modified by:
    /// John Barker 28/03/2023
    /// </summary>
    public static class Program
    {
        //private static DistanceConverter converter = new DistanceConverter();
        //private static BMICalculator calculator = new BMICalculator();
        //private static StudentGrades grades = new StudentGrades();
        private static NetworkApp app04 = new NetworkApp();
        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine();
            Console.WriteLine(" =================================================");
            Console.WriteLine("    BNU CO453 Applications Programming 2022-2023! ");
            Console.WriteLine(" =================================================");
            Console.WriteLine();


            string[] choices = {"Distance converter", "BMI Calculator",
                                "Student marks", "social Network"};
            int choiceNo = ConsoleHelper.SelectChoice(choices);

            if (choiceNo == 1)
            {
                Console.WriteLine("1");
            }
            else if(choiceNo == 2)
            {
                Console.WriteLine("2");
            }
            else if (choiceNo == 3)
            {
                Console.WriteLine("3");
            }
            else if (choiceNo == 4)
            {
                app04.DisplayMenu();
            }
            //converter.run();
        }
    }
}
