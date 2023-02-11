using System;

namespace ConsoleAppProject.App01
{
    /// <summary>
    /// Please describe the main features of this App
    /// </summary>
    /// <author>
    /// Johnathan version 0.1
    /// </author>
    public class DistanceConverter
    {
        public static double FEET_IN_MILES = 5280;
        public static double METERS_IN_MILES = 1609;
        public static double FEET_IN_METERS = 3.281;
        private double miles, feet, meters :
        public int choice:
        public void Run()
        {
            OutputHeading();
            OutputChoice();
            
            switch(choice)
            {  
                case 1:
                    InputMiles();
                    CalcualteMile2feet();
                    OutputMiles2feet();
                    break;
                    
                case 2:
                    InputMiles();
                    CalcualteMile2Meters();
                    OutputMiles2Meters();
                    break;
                
                // Meters to...
                case 3:
                    InputMeters();
                    CalcualteMeters2Feet();
                    OutputFeet();
                    break;
                
                case 4:
                    InputMeters();
                    CalcualteMeters2Mile();
                    OutputMiles();
                    break;
                    
                //Feet to...
                case 5:
                    InputFeet();
                    CalcualteFeet2mile();
                    OutputMiles();
                    break;
                
                case 6:
                    InputFeet();
                    CalcualteFeet2Meters();
                    OutputMeters();
                    break;
                    
                default:
                    Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                    break;
            };  
            
        }
        public void OutputHeading();
        {
            Console.WriteLine("-----------------")
            Console.WriteLine("-App01  Distance-")
            Console.WriteLine("----Converter----")
            Console.WriteLine("-----------------")
        }
        //Choice of feet to miles or meaters and vice versa
        public void OutputChoice();
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
        public void InputMiles();
        {
            Console.WriteLine("Enter the number of miles you want to convert:");
            miles = Convert.ToDouble(Console.ReadLine());    
        }
        //Miles to Feet calcuation      
        public void CalcualteMile2feet();
        {
            feet = miles * FEET_IN_MILES;
        }
        
        public void OutputMiles2Feet();
        {
            Console.WriteLine(miles + " miles is equal to " + feet + " feet.");
        }
        
        //miles to Meters
        public void CalcualteMile2Meters();
        {
            meters = miles * METERS_IN_MILES;
        }
        
        public void OutputMiles2Meters();
        {
            Console.WriteLine(miles + " miles is equal to " + meters + " meters.");
        }
        
        
        
        //Feet Input
        public void InputFeet();
        {
            Console.WriteLine("Enter the number of feet you want to convert:");
            feet = Convert.ToDouble(Console.ReadLine());    
        }
        
        //Feet to miles calcuation
        public void CalcualteFeet2mile();
        {
            miles = feet / FEET_IN_MILES;
        }
        
        public void OutputFeet2Miles();
        {
            Console.WriteLine(miles + " miles is equal to " + feet + " feet.");
        }
        //Feet to Meters
        public void CalcualteFeet2Meters();
        {
            meters = feet / FEET_IN_METERS;
        }
        
        public void OutputFeet2Meters();
        {
            Console.WriteLine(feet + " feet is equal to " + meters + " meters.");
        }
        
        
        
        //meters Input
        public void InputMeters();
        {
            Console.WriteLine("Enter the number of miles you want to convert:");
            meters = Convert.ToDouble(Console.ReadLine());    
        }
        
        //Meters to miles
        public void CalcualteMeters2Miles();
        {
            miles = meters / METERS_IN_MILES;
        }
        
        public void OutputMeters2Miles();
        {
            Console.WriteLine(meters + " meters is equal to " + miles + " miles.");
        }
        
        //Meters to feet
        public void CalcualteMeters2Feet();
        {
            feet = meters * FEET_IN_METERS;
        }
        
        public void OutputMeters2Feet();
        {
            Console.WriteLine(feet + " feet is equal to " + meters + " meters.");
        }
        
    }
}
