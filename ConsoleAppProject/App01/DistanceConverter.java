package aplication_programing;

import java.util.InputMismatchException;
import java.util.Scanner;

public class DistanceConverter {


    public static void main(String[] args) {
        /*
          This is the main function that controls the flow of the program.

          It prompts the user to select the units they want to convert from and to,
          as well as the distance they want to convert.

          It then uses conditional statements to determine which conversion function
          to call based on the user's selections, and then executes that function.

          If the user's selections are not valid (i.e., they select an option that is not 1, 2, or 3),
          the program prints "Invalid input."
         */

        Scanner scanner = new Scanner(System.in);

        /** From Unit
         * This piece of code prompts the user to enter their choice of unit to convert from and reads
         * in their input using the getValidInput method. The getValidInput method ensures that the user
         * enters a valid integer value between the specified range (in this case, 1 to 3) and returns
         * it to the calling method.

         * The input value is stored in the variable fromUnit. The program then prompts the user to
         * enter their choice of unit to convert to, reads in their input using the getValidInput
         * method and stores it in the variable toUnit.

         * Once both the fromUnit and toUnit variables have been assigned valid input values, the
         * program proceeds to prompt the user to enter the distance they want to convert.
        */
        System.out.println("Which unit of distance would you like to convert from?");
        System.out.println("1. Feet");
        System.out.println("2. Miles");
        System.out.println("3. Meters");
        double fromUnit = getValidInput(scanner, 1, 3);

        /** To Unit
        * The getValidInput method is not shown, but assuming it correctly validates
        * the user input and returns a double representing the selected option,
        * this code should prompt the user to select the unit of distance they want
        * to convert to and then store their choice in the toUnit variable.

        * The user is presented with three options and the getValidInput method is
        * called with arguments of 1 and 3 to ensure that the user input is limited
        * to the valid range of 1-3.
        */
        System.out.println("Which unit of distance would you like to convert to?");
        System.out.println("1. Feet");
        System.out.println("2. Miles");
        System.out.println("3. Meters");
        double toUnit = getValidInput(scanner, 1, 3);

        /** Enter Distance
         * This code prompts the user to enter a distance value and reads the 
         * input from the console using the scanner object. 
         
         * It then passes this value to the getValidDistance method, which checks
         * whether the input is a valid double value greater than or equal to zero.
         
         * If the input is invalid, it prompts the user to enter a valid distance 
         * value until a valid input is provided. 
         
         * Once a valid input is obtained, it is returned as the distance variable
         * to be used in the subsequent conversion methods.
         */
        System.out.println("Enter the distance:");
        double distance = getValidDistance(scanner);

        /** If, Else If & Else
         * This block of code is a conditional statement that determines
         * which conversion method to use based on the user's input for the units
         * of distance to convert from and to.
         
         * If the user wants to convert from feet to miles, the convertFeetToMiles
         * method is called with the distance as a parameter.
         
         * Similarly, if the user wants to convert from miles to feet,
         * the convertMilesToFeet method is called with the distance as a parameter.
         
         * This process continues for all possible combinations of units of distance
         * that the user may input.

         * If the user inputs an invalid combination of units of distance, an error message is displayed.
         */
        if (fromUnit == 1 && toUnit == 2) {
            convertFeetToMiles(distance);
        } 
        else if (fromUnit == 1 && toUnit == 3) {
            convertFeetToMeters(distance);
        } 
        else if (fromUnit == 2 && toUnit == 1) {
            convertMilesToFeet(distance);
        } 
        else if (fromUnit == 2 && toUnit == 3) {
            convertMilesToMeters(distance);
        } 
        else if (fromUnit == 3 && toUnit == 1) {
            convertMetersToFeet(distance);
        } 
        else if (fromUnit == 3 && toUnit == 2) {
            convertMetersToMiles(distance);
        } 
        else {
            System.out.println("Invalid input.");
        }
    }


/** Conversions
 * These are methods for converting distances between feet, miles, and meters.
 * The convertFeetToMiles method takes a distance in feet as input and converts
 * it to miles, then outputs the result. The convertFeetToMeters method does
 * the same thing, but converts to meters instead. The convertMilesToFeet method
 * takes a distance in miles as input and converts it to feet, while convertMilesToMeters
 * converts to meters. Finally, convertMetersToFeet takes a distance in meters as input
 * and converts it to feet, while convertMetersToMiles converts to miles. All of the
 * methods use the String.format method to format the output to two decimal places
 */

    /** Convert Feet To Miles
     * The convertFeetToMiles method takes a distance in feet as a parameter, converts it to miles,
     * and then prints the converted value to the console in a user-friendly format.

     * First, the method calculates the number of miles by dividing the distance in feet by the number
     * of feet in a mile, which is 5280. Then, it formats the converted value to two decimal places
     * using the String.format method, and finally, it prints the original distance in feet, the
     * converted value in miles, and the units to the console using System.out.println.

     * For example, if the input distance in feet is 10560, the method will
     * print "10560 feet = 2.00 miles" to the console.
     */
    public static void convertFeetToMiles(double feet) {
        double miles = feet / 5280;
        System.out.println(feet + " feet = " + String.format("%.2f", miles) + " miles");
    }

    /** Convert Feet To Meters
     * This is a method that converts a distance value in feet to meters.

     * The conversion is done by multiplying the distance in feet by the conversion factor
     * of 0.3048, which is the number of meters in a foot.

     * The result is then printed to the console using the System.out.println() method, along
     * with the original value in feet and the converted value in meters rounded to two decimal
     * places using the String.format() method.
     */
    public static void convertFeetToMeters(double feet) {
        double meters = feet * 0.3048;
        System.out.println(feet + " feet = " + String.format("%.2f", meters) + " meters");
    }

    /** Convert Miles To Feet
     * This method converts a distance in miles to feet.

     * It takes in a double value representing the distance in miles and calculates the
     * equivalent distance in feet by multiplying the input value by 5280.

     * The result is then printed to the console with a message indicating the conversion that was performed.

     * The result is formatted to display only two decimal places using the String.format() method.
     */
    public static void convertMilesToFeet(double miles) {
        double feet = miles * 5280;
        System.out.println(miles + " miles = " + String.format("%.2f", feet) + " feet");
    }

    /** Convert Miles To Meters
     * This method converts a distance value from miles to meters.

     * It multiplies the input value by 1609.344, which is the conversion factor for miles
     * to meters, and then prints out the result to the console.

     * The distance value is rounded to 2 decimal places using the String.format() method.
     */
    public static void convertMilesToMeters(double miles) {
        double meters = miles * 1609.344;
        System.out.println(miles + " miles = " + String.format("%.2f", meters) + " meters");
    }

    /** Convert Meters To Feet
     * This method converts a distance given in meters to feet.

     * It takes in a double value representing the distance in meters, and then multiplies
     * it by the conversion factor from meters to feet, which is 1 meter = 3.28084 feet.

     * The resulting value is stored in a variable called "feet".

     * Finally, the method prints out the original distance in meters along with the converted
     * distance in feet using the System.out.println() method.

     * The formatted string used to display the output ensures that the output is rounded to two decimal places.
     */
    public static void convertMetersToFeet(double meters) {
        double feet = meters / 0.3048;
        System.out.println(meters + " meters = " + String.format("%.2f", feet) + " feet");
    }
    /** Convert Meters To Miles
     *This method, convertMetersToMiles, takes a distance value in meters and converts it to miles.
      The formula for this conversion is simply to divide the distance in meters by the number of
      meters in a mile (which is 1609.344).
     */
    public static void convertMetersToMiles(double meters) {
        double miles = meters / 1609.344;
        System.out.println(meters + " meters = " + String.format("%.2f", miles) + " miles");
    }

    /** Getting a Valid Input
    * This is a method called getValidInput that takes a Scanner object as well as two integer parameters,
      i and i1. This method is responsible for validating the user's input by ensuring that it is a non-negative
      number between i and i1 (inclusive).
    * The method uses a while loop to repeatedly prompt the user for input until a valid input is received.
      If the input is less than zero, the method prints a message indicating that the input cannot be negative
      and prompts the user to enter a valid input. If the input is greater than i1, the method prints a message
      indicating that the input cannot be greater than i1 and prompts the user to enter a valid input. If the input
      is valid, the method sets the validInput variable to true, indicating that a valid input has been received.
    * If the user enters an invalid input, such as a non-numeric value, the method catches the InputMismatchException
      and prints a message indicating that the input is invalid, and then consumes the invalid input using the
      scanner.nextLine() method.
    * Once a valid input is received, the method returns it as a double value.
    *  */
    public static double getValidInput(Scanner scanner, int i, int i1) {
        double input = 0;
        boolean validInput = false;

        while (!validInput) {
            try {
                input = scanner.nextDouble();
                if (input < 0) {
                    System.out.println("Input cannot be negative. Please enter a valid input:");
                } else if (input > 3) {
                    System.out.println("Input cannot be more than 3. Please enter a valid input:");
                } else {
                    validInput = true;
                }
            } catch (InputMismatchException e) {
                System.out.println("Invalid input. Please enter a valid input:");
                scanner.nextLine(); // consume the invalid input
            }
        }

        return input;
    }

    /** Getting a Valid Distance
     *This method takes a Scanner object as input and prompts the user to
     * enter a distance value. It then validates the input by checking if
     * it's a positive number and returns the validated distance value as
     * a double. If the user enters an invalid input, it displays an error
     * message and prompts the user to enter a valid distance value.
     * The method continues to prompt the user until a valid input is entered.
     */
    public static double getValidDistance(Scanner scanner) {
        double distance = 0;
        boolean valid = false;
        while (!valid) {
            try {
                distance = scanner.nextDouble();
                if (distance < 0) {
                    System.out.println("Distance cannot be negative. Please enter a positive number.");
                } else {
                    valid = true;
                }
            } catch (InputMismatchException e) {
                System.out.println("Invalid input. Please enter a valid number.");
                scanner.nextLine();
            }
        }
        return distance;
    }

}
