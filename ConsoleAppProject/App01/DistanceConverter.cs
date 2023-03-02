using System;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// This C# code implements a distance conversion program 
    /// that can convert various units of measurement to each other. 
    /// The program contains three conversion methods: Feet to Miles, Meters to Miles, and Meters to Feet.
    ///The user is prompted to enter a distance in the unit they want to convert from. The program then converts the distance to the equivalent distance in the desired unit of measurement and displays the result.
    
    /// </summary>
    /// <author>
    /// Johnathan version 0.1
    /// </author>
    public class DistanceConverter
    {
        public static double FEET_IN_MILES = 5280;
        public static double METERS_IN_MILES = 1609;
        public static double FEET_IN_METERS = 3.281;
        private double miles, feet, meters = 0;
        public int choice = 0;

        public void Run()
        {
            OutputHeading();
            OutputChoice();

            switch (choice)
            {
                case 1:
                    InputMiles();
                    CalculateMile2Feet();
                    OutputMiles2Feet();
                    break;

                case 2:
                    InputMiles();
                    CalculateMile2Meters();
                    OutputMiles2Meters();
                    break;

                // Meters to...
                case 3:
                    InputMeters();
                    CalculateMeters2Feet();
                    OutputFeet2Meters();
                    break;

                case 4:
                    InputMeters();
                    CalculateMeters2Miles();
                    OutputMeters2Miles();
                    break;

                //Feet to...
                case 5:
                    InputFeet();
                    CalculateFeet2Miles();
                    OutputFeet2Miles();
                    break;

                case 6:
                    InputFeet();
                    CalculateFeet2Meters();
                    OutputFeet2Meters();
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter 1-6.");
                    break;
            };
        }

        public void OutputHeading()
        {
            Console.WriteLine("-----------------");
            Console.WriteLine("-App01  Distance-");
            Console.WriteLine("----Converter----");
            Console.WriteLine("-----------------");
        }

        //Choice of feet to miles or meters and vice versa
        public void OutputChoice()
        {
            Console.WriteLine("1: Miles to Feet");
            Console.WriteLine("2: Miles to Meters");
            Console.WriteLine("3: Meters to Feet");
            Console.WriteLine("4: Meters to Miles");
            Console.WriteLine("5: Feet to Miles");
            Console.WriteLine("6: Feet to Meters");
            Console.WriteLine("Enter 1-6:");
            choice = Convert.ToInt32(Console.ReadLine());
        }

        // Miles Input
        public void InputMiles()
        {
            Console.WriteLine("Enter the number of miles you want to convert:");
            miles = Convert.ToDouble(Console.ReadLine());
        }

        //Miles to Feet calculation      
        public void CalculateMile2Feet()
        {
            feet = miles * FEET_IN_MILES;
        }

        public void OutputMiles2Feet()
        {
            Console.WriteLine(miles + " miles is equal to " + feet + " feet.");
        }

        //miles to Meters
        public void CalculateMile2Meters()
        {
            meters = miles * METERS_IN_MILES;
        }

        public void OutputMiles2Meters()
        {
            Console.WriteLine(miles + " miles is equal to " + meters + " meters.");
        }



        //Feet Input
        public void InputFeet()
        {
            Console.WriteLine("Enter the number of feet you want to convert:");
            feet = Convert.ToDouble(Console.ReadLine());
        }

        //Feet to miles calculation
        public void CalculateFeet2Miles()
        {
            miles = feet / FEET_IN_MILES;
        }

        public void OutputFeet2Miles()
        {
            Console.WriteLine(feet + " feet is equal to " + miles + " miles.");
        }


        // Feet to meters
        public void CalculateFeet2Meters()
        {
            meters = feet * FEET_IN_METERS;
        }
        
        public void OutputFeet2Meters()
        {
            Console.WriteLine(feet + " feet is equal to " + meters + " meters.");
        }
    


        
        
        //meters Input
        public void InputMeters()
        {
            Console.WriteLine("Enter the number of meters you want to convert:");
            meters = Convert.ToDouble(Console.ReadLine());    
        }

        //Meters to miles
        public void CalculateMeters2Miles()
        {
            miles = meters / METERS_IN_MILES;
        }

        public void OutputMeters2Miles()
        {
            Console.WriteLine(meters + " meters is equal to " + miles + " miles.");
        }

        //Meters to feet
        public void CalculateMeters2Feet()
        {
            feet = meters * FEET_IN_METERS;
        }

        public void OutputMeters2Feet()
        {
            Console.WriteLine(meters + " meters is equal to " + feet + " feet.");
        }
        
    }
}
