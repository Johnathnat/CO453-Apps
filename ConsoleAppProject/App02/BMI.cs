namespace ConsoleAppProject.App02
{
    /// <summary>
    /// Please describe the main features of this App
    /// </summary>
    /// <author>
    /// John Barker version 0.1
    /// </author>
    using System;

    public class BMI
    {
        static void Main()
        {
            Console.WriteLine("Enter your weight in kilograms: ");
            double weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter your height in meters: ");
            double height = double.Parse(Console.ReadLine());

            double bmi = CalculateBMI(weight, height);

            Console.WriteLine($"Your BMI is: {bmi:F2}");
        }

        static double CalculateBMI(double weight, double height)
        {
            return weight / (height * height);
        }
    }
}
