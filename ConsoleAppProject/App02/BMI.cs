package aplication_programing;

import java.util.Scanner;
/**
 * This code is a Java program that calculates a person's Body Mass Index (BMI)
 * and displays a message explaining to BAME groups their extra risks.
 *
 * The program prompts the user to choose a unit system: either Imperial
 * (pounds, feet, inches) or Metric (kilograms, meters). It then prompts the user
 * for their weight and height, and calculates their BMI using the appropriate
 * formula based on their unit system.
 *
 * If the user enters an invalid weight or height (i.e. a negative number), the
 * program displays an error message and prompts the user to enter a valid number.
 *
 * If the user chooses Imperial units, the program loops until the user enters a
 * valid input for feet and inches (i.e. positive numbers for feet and inches
 * less than 12).
 *
 * If the user chooses Metric units, the program loops until the user enters a
 * valid input for meters (i.e. positive numbers).
 *
 * After calculating the BMI, the program displays the user's BMI value and a
 * message explaining to BAME groups their extra risks based on their BMI value.
 * If the user's BMI is 30 or higher, the program displays a message indicating that
 * the user is obese and at extra risk for health complications, particularly for
 * some BAME groups. If the user's BMI is between 25 and 30, the program displays a
 * message indicating that the user is overweight and at increased risk for health
 * complications.
 * */


public class BMICalculator {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        // Displays a Welcome message and a table from the WHO showing the meaning of different BMI values
        System.out.println("""
                --------------------------------------------
                BNU CO453 Applications Programming 2022-2023
                --------------------------------------------
                                
                ===========================
                   App02 BMI Converter
                      By John Barker
                ===========================
                                
                                
                """);
        System.out.println("Welcome to the BMI calculator!");
        System.out.println("""
                    
                            +----------------------------------+
                            | WHO Weight Status | BMI kg / m^2 |
                            |-------------------|--------------|
                            | Underweight       | 0    - 18.5  |
                            | Normal            | 18.5 - 24.9  |
                            | Overweight        | 25.0 - 29.9  |
                            | Obese Class 1     | 30.0 - 34.9  |
                            | Obese Class 2     | 35.0 - 39.9  |
                            | Obese Class 3     | 40.0 +       |
                            +----------------------------------+
                            """);

        // Prompt user to choose unit system
        System.out.println("Please choose a unit system:\n1. Imperial (pounds, feet, inches)\n2. Metric (kilograms, meters)");
        int unitChoice;
        do {
            System.out.print("Enter your choice (1 or 2): ");
            unitChoice = scanner.nextInt();
            if (unitChoice != 1 && unitChoice != 2) {
                System.out.println("Invalid choice. Please choose 1 or 2.");
            }
        } while (unitChoice != 1 && unitChoice != 2);


        // Prompt user for weight and height
        double weight, height = 0;
        /** Imperial Height and Weight
         * First it prompts the user to enter their weight in pounds and loops until a
         * valid weight is entered (i.e., a positive number).

         * Then, it prompts the user to enter their height in feet and inches, separated
         * by a space. It checks the input to make sure it is a positive number and loops
         * until a valid height is entered (i.e., positive numbers for feet and inches
         * less than 12).

         * Finally, it calculates the user's BMI using the
         * formula BMI = (weight in kg) / (height in metres)^2
         * after converting weight from pounds to kilograms and height from feet and inches
         * to meters.

         * The program uses a do-while loop for the input validation to ensure that the user
         * inputs valid values for weight and height. If the user inputs an invalid value,
         * the program displays an error message and continues prompting the user until valid
         * values are inputted. The loop will only exit when a valid value is entered.

         * Once valid inputs are obtained, the program then calculates the user's BMI and
         * displays a message explaining to BAME groups their extra risks based on their BMI
         * value. If the user's BMI is 30 or higher, the program displays a message indicating
         * that the user is obese and at extra risk for health complications, particularly for
         * some BAME groups. If the user's BMI is between 25 and 30, the program displays a
         * message indicating that the user is overweight and at increased risk for health
         * complications.
         */
        if (unitChoice == 1) {
            do {
                System.out.print("Enter your weight in pounds: ");
                weight = scanner.nextDouble();
                if (weight <= 0) {
                    System.out.println("Invalid weight. Please enter a positive number.");
                }
                weight = weight / 2.205; // converts LB to KG
            } while (weight <= 0);


            double feet, inches;
            boolean validHeight = false;
            do {
                System.out.print("Enter your height in feet and inches, separated by a space E.G. (5 10): ");
                if (!scanner.hasNextDouble()) {
                    scanner.next();  // discard invalid input
                    System.out.println("Invalid height. Please enter a positive number for feet and inches less than 12.");
                    continue;
                }
                feet = scanner.nextDouble();
                if (!scanner.hasNextDouble()) {
                    scanner.next();  // discard invalid input
                    System.out.println("Invalid height. Please enter a positive number for feet and inches less than 12.");
                    continue;
                }
                inches = scanner.nextDouble();
                if (feet <= 0 || inches < 0 || inches >= 12) {
                    System.out.println("Invalid height. Please enter positive numbers for feet and inches less than 12.");
                } else {
                    height = (feet * 12 + inches) * 0.0254;  // convert to meters
                    validHeight = true;
                }
            } while (!validHeight);
        }


        /** Metric Height and Weight
         *It prompts the user to enter their weight in kilograms and loops
         * until a valid weight is entered (i.e., a positive number).
         *
         * Next, it prompts the user to enter their height in meters and loops
         * until a valid height is entered (i.e., a positive number).
         *
         * Finally, it calculates the user's BMI using the
         * formula BMI = (weight in kg) / (height in metres)2.
         *
         * The program uses a do-while loop for the input validation to ensure
         * that the user inputs valid values for weight and height. If the user
         * inputs an invalid value, the program displays an error message and
         * continues prompting the user until valid values are inputted. The
         * loop will only exit when a valid value is entered.
         *
         * Once valid inputs are obtained, the program then calculates the
         * user's BMI and displays a message explaining to BAME groups their
         * extra risks based on their BMI value. If the user's BMI is 30 or higher,
         * the program displays a message indicating that the user is obese and
         * at extra risk for health complications, particularly for some BAME
         * groups. If the user's BMI is between 25 and 30, the program displays a
         * message indicating that the user is overweight and at increased risk for
         * health complications.
         *
         */
        else {  // unitChoice == 2
            do {
                System.out.print("Enter your weight in kilograms: ");
                weight = scanner.nextDouble();
                if (weight <= 0) {
                    System.out.println("Invalid weight. Please enter a positive number.");
                }
            } while (weight <= 0);

            do {
                System.out.print("Enter your height in meters: ");
                height = scanner.nextDouble();
                if (height <= 0) {
                    System.out.println("Invalid height. Please enter a positive number.");
                }
            } while (height <= 0);
        }

        // Calculate BMI
        double bmi = weight / (height * height);

        // Display BMI value and explanation for BAME groups
        System.out.printf("Your BMI is %.2f\n", bmi);
        if (bmi >= 30) {

            System.out.println("""
                    
                    +----------------------------------+
                    | WHO Weight Status | BMI kg / m^2 |
                    |----------------------------------|
                    | Underweight       | 0    - 18.5  |
                    | Normal            | 18.5 - 24.9  |
                    | Overweight        | 25.0 - 29.9  |
                    |----------------------------------|
                    | Obese Class 1     | 30.0 - 34.9  |
                    | Obese Class 2     | 35.0 - 39.9  |
                    | Obese Class 3     | 40.0 +       |
                    |----------------------------------|
                    +----------------------------------+
                    
                    """);

            System.out.println("You are obese, which puts you at extra risk for health complications.");
            System.out.println("This risk is higher for some BAME (Black, Asian, and minority ethnic) groups.");
        } else if (bmi >= 25) {
            System.out.println("""
                    
                            +----------------------------------+
                            | WHO Weight Status | BMI kg / m^2 |
                            |-------------------|--------------|
                            | Underweight       | 0    - 18.5  |
                            | Normal            | 18.5 - 24.9  |
                            |----------------------------------|
                            | Overweight        | 25.0 - 29.9  |
                            |----------------------------------|
                            | Obese Class 1     | 30.0 - 34.9  |
                            | Obese Class 2     | 35.0 - 39.9  |
                            | Obese Class 3     | 40.0 +       |
                            +----------------------------------+
                            """);

            System.out.println("You are overweight, which puts you at increased risk for health complications.");
            System.out.println("This risk is higher for some BAME (Black, Asian, and minority ethnic) groups.");
        } else if (bmi >= 18.5) {
            System.out.println("""
                    
                            +----------------------------------+
                            | WHO Weight Status | BMI kg / m^2 |
                            |-------------------|--------------|
                            | Underweight       | 0    - 18.5  |
                            |----------------------------------|
                            | Normal            | 18.5 - 24.9  |
                            |----------------------------------|
                            | Overweight        | 25.0 - 29.9  |
                            | Obese Class 1     | 30.0 - 34.9  |
                            | Obese Class 2     | 35.0 - 39.9  |
                            | Obese Class 3     | 40.0 +       |
                            +----------------------------------+
                            """);
            System.out.println("Your weight is normal, which is good for your overall health.");
        } else {
            System.out.println("""
                    
                            +----------------------------------+
                            | WHO Weight Status | BMI kg / m^2 |
                            |-------------------|--------------|
                            |----------------------------------|
                            | Underweight       | 0    - 18.5  |
                            |----------------------------------|
                            | Normal            | 18.5 - 24.9  |
                            | Overweight        | 25.0 - 29.9  |
                            | Obese Class 1     | 30.0 - 34.9  |
                            | Obese Class 2     | 35.0 - 39.9  |
                            | Obese Class 3     | 40.0 +       |
                            +----------------------------------+
                            """);
            System.out.println("You are underweight, which puts you at risk for health complications.");
        }
    }
}
