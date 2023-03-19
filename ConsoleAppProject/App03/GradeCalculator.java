import java.util.InputMismatchException;
import java.util.Scanner;

import static java.lang.Math.round;


public class GradeCalculator {
static int maxMark;
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        /** Get number of students and maximum possible mark
         * At the beginning of hte program the user is prompted for the number of students.  This section of code
         * validates that the number entered is an integer and a positive number.
         *
         * The user is then prompted for the maximum possible mark which is then validated to be an integer and is used
         * later to convert the student score into a percentage mark.
         * */
        System.out.print("Enter the number of students: ");
        int numStudents = 0;
        while (true) {
            try {
                numStudents = input.nextInt();
                if (numStudents <= 0) {
                    throw new InputMismatchException();
                }
                break;
            } catch (InputMismatchException e) {
                System.out.println("Please enter a positive integer");
                input.next();
            }
        }

        System.out.println("Enter Maximum possible mark");
        int maxMark = 0;
        while (true) {
            try {
                maxMark = input.nextInt();
                if (maxMark <= 0) {
                    throw new InputMismatchException();
                }
                break;
            } catch (InputMismatchException e) {
                System.out.println("Please enter a positive integer");
                input.next();
            }
        }


        /**Initialize arrays
         * This code initializes three arrays of different data types for a number of students specified by the variable numStudents.

         * The first array studentNames is an array of String type and will store the names of each student.

         * The second array studentMarks is an array of int type and will store the marks obtained by each student.

         * The third array studentGrades is also an array of String type and will store the grades earned by each student.*/
        String[] studentNames = new String[numStudents];
        int[] studentMarks = new int[numStudents];
        String[] studentGrades = new String[numStudents];

        /** Get student names and marks and calculate grades
         * The for loop iterates through each student, where i represents the
         * current student index. The loop will execute for numStudents times.

         * The program prompts the user to enter the name of the current student
         * by using System.out.print() method. The i+1 is added to display a
         * sequential number for each student.

         * The user input for the student name is read using the Scanner object
         * input and stored in the name variable.

         * The name variable is then assigned to the studentNames array at the
         * current index i using the statement studentNames[i] = name;. This stores
         * the name of the current student in the array.

         * The program then prompts the user to enter the mark for the current
         * student using System.out.print() method. The name variable is used to
         * display the name of the current student in the prompt.

         * The program uses a while loop with the condition !input.hasNextInt() to
         * validate the user input. This loop will continue to execute as long as
         * the user input is not an integer. The System.out.print() method is used
         * to prompt the user to enter a valid integer.

         * Once the user enters a valid integer, the Scanner object input is used
         * to read the integer input and store it in the mark variable.

         * The mark variable is then assigned to the studentMarks array at the
         * current index i using the statement studentMarks[i] = mark;. This stores
         * the mark of the current student in the array.

         * The getGrade() method is called with the mark variable as an argument,
         * which returns the corresponding grade for the current mark.

         * The returned grade is then assigned to the studentGrades array at the
         * current index i using the statement studentGrades[i] = getGrade(mark);.
         * This stores the grade of the current student in the array.

         * Overall, this code reads in the name and mark of each student and stores
         * them in separate arrays. The getGrade() method is then used to calculate
         * the corresponding grade for each mark and store it in a third array.
         *
         * */
        for (int i = 0; i < numStudents; i++) {
            System.out.print("Enter the name of student " + (i + 1) + ": ");
            String name = input.next();
            studentNames[i] = name;
            System.out.print("Enter the mark for student " + name + ": ");
            while (!input.hasNextInt()) {  // Validate input as integer
                System.out.print("Please enter a valid integer: ");
                input.next();
            }
        /**  Score Validation and Percentage Mark Calculation
         * This section of code is to check if the student score is >0 or < or equal to the maximum mark.
         * It begins by declaring the scoreCheck boolean variable as false to allow the validation to run.
         * The score variable is then defined.
         * While the scoreCheck variable is false the code will be repeated and ask for a score to be inputted.
         * If the score is<0 then an error message is displayed and the user prompted to re-enter the score.
         * Likewise if the score is < maximum mark, an error message is displayed that also states what the maximum mark is.
         *
         * When the user enters a valid score it is converted into a percentage mark which is rounded to the nearest
         * whole number and is displayed.
         *
         * The student's percentage mark is saved in studentsMarks[i].
         * studentsGrades[i] calls the function getGrade to identify the grade boundary which is then stored.
         * */
            boolean scoreCheck = false;
            double score;
            while (scoreCheck == false) {
                score = input.nextInt();

                if (score < 0) {
                    System.out.println("Please enter a positive integer");
                }
                else if (score > maxMark) {
                    System.out.println("Please enter an integer no higher than"+maxMark);
                }
                else {

                    int mark= (int) round(score/maxMark*100);
                    System.out.println("Percentage mark:  "+mark+"%");
                    studentMarks[i] = mark;
                    studentGrades[i] = getGrade(mark);
                    scoreCheck = true;
                }
            }


        }

        /**Calculate mean mark of the group
         * This code calculates the average mark of a
         * group of students whose marks are stored in
         * an array, and it also finds the index of the
         * highest and lowest marks in the array.

         * It does this by iterating over each mark in the array,
         * adding them together to get the sum, and then dividing
         * the sum by the number of students to get the mean mark.

         * It also keeps track of the index of the highest and
         * lowest marks by comparing each mark to the current
         * highest and lowest marks.
         * */
        double sum = 0.0;
        int highestMarkIndex = 0;
        int lowestMarkIndex = 0;
        for (int i = 0; i < numStudents; i++) {
            sum += studentMarks[i];
            if (studentMarks[i] > studentMarks[highestMarkIndex]) {
                highestMarkIndex = i;
            }
            if (studentMarks[i] < studentMarks[lowestMarkIndex]) {
                lowestMarkIndex = i;
            }
        }
        double meanMark = sum / numStudents;

        /** Calculate grade profile
         * The program initializes an array gradeCounts with 5 elements, each element
         * representing the count of a letter grade (A, B, C, D, and F).

         * The for loop iterates through each student in the studentGrades array.

         * The program uses a switch statement to check the value of the student's
         * grade at the current index. If the grade is an A, B, C, D, or F, it increments
         * the count of that grade in the gradeCounts array.

         * If the grade is not one of these values, the switch statement simply does
         * nothing and moves on to the next student.

         * After the for loop has finished iterating through all of the students'
         * grades, the gradeCounts array contains the number of students who received
         * each possible letter grade.

         * Overall, this code provides a simple way to calculate the number of students
         * who received each letter grade, which can be used to analyze the distribution
         * of grades in the class.
         * */
        int[] gradeCounts = new int[5];
        for (int i = 0; i < numStudents; i++) {
            switch(studentGrades[i]) {
                case "A":
                    gradeCounts[0]++;
                    break;
                case "B":
                    gradeCounts[1]++;
                    break;
                case "C":
                    gradeCounts[2]++;
                    break;
                case "D":
                    gradeCounts[3]++;
                    break;
                case "F":
                    gradeCounts[4]++;
                    break;
                default:
                    break;
            }
        }

        /** Display grade profile with classification
         * This displays the grade profile for each student in the class,
         * along with their grade percentage and classification.

         * The program starts by printing a header with column labels for
         * the name, grade, percentage, and classification of each student.

         * The for loop iterates through each student in the studentNames
         * and studentGrades arrays.

         * For each student, the program prints their name, grade, percentage
         * (calculated using the getGradePercentage() method), and classification (calculated using the getGradeClassification() method).

         * The getGradePercentage() method takes three parameters: the letter
         * grade for the current student, the gradeCounts array containing the count of each grade, and the total number of students. It calculates the percentage of students who received the same grade as the current student and returns it as a string.

         * The getGradeClassification() method takes one parameter: the letter
         * grade for the current student. It uses a switch statement to return the appropriate classification (e.g. "Excellent" for an A grade) based on the letter grade.

         * Overall, this code provides a useful summary of each student's grade
         * and how it compares to the rest of the class.
         * */
        System.out.println("\nGrade Profile:");
        System.out.println("Name\tGrade\tProportion\tClassification");
        for (int i = 0; i < numStudents; i++) {
            System.out.println(studentNames[i] + "\t" + studentGrades[i] + "\t" + getGradePercentage(studentGrades[i], gradeCounts, numStudents) + "%\t\t" + getGradeClassification(studentGrades[i]));
        }

    /** Display mean mark
     * The mean mark of the group is printed using the value stored in the meanMark variable*/
        System.out.println("\nMean percentage mark of the group: " + meanMark);
    /** Display student with highest mark
     * The student with the highest mark is identified by looking up the index of
     * the studentMarks array that contains the highest mark. The program then prints
     * the name and mark of this student using the highestMarkIndex to look up the values
     * in the studentNames and studentMarks arrays.
     * */
        System.out.println("\nStudent with highest percentage mark: " + studentNames[highestMarkIndex] + " (" + studentMarks[highestMarkIndex] + "%)");

    /** Display student with lowest mark
     * the student with the lowest mark is identified by looking up the
     * index of the studentMarks array that contains the lowest mark. The
     * program then prints the name and mark of this student using the
     * lowestMarkIndex to look up the values in the studentNames and
     * studentMarks arrays.*/
        System.out.println("Student with lowest percentage mark: " + studentNames[lowestMarkIndex] + " (" + studentMarks[lowestMarkIndex] + "%)");
}

    /** Function to calculate grade from mark
     * This is a function called getGrade that takes in a student's mark as an integer and returns their letter grade as a string.

     * It does this by checking the mark against different grade thresholds, starting from the highest grade (A) and working down to
     * the lowest grade (F). If the mark is greater than or equal to the threshold for a particular grade, then that grade is returned.

     * If the mark is below the threshold for an F grade, then an F grade is returned.*/

    public static String getGrade(int mark) {
        //mark = mark/maxMark*100;


        if (mark >= 70) {
            return "A";
        } else if (mark >= 60) {
            return "B";
        } else if (mark >= 50) {
            return "C";
        } else if (mark >= 40) {
            return "D";
        } else {
            return "F";
        }
    }
    /** Function to get grade percentage
     * This code defines a function getGradePercentage that takes three arguments:
     * grade, which is a string representing the letter grade (e.g., "A", "B", "C", etc.);
     * gradeCounts, which is an array of integers representing the number of students who received each grade;
     * and numStudents, which is an integer representing the total number of students in the class.

     * The function uses a switch statement to determine which grade is being passed in, and then calculates
     * and returns the percentage of students who received that grade. The percentage is calculated by dividing
     * the number of students who received that grade (looked up in the gradeCounts array) by the total number
     * of students in the class (stored in the numStudents variable), multiplying by 100 and rounded to 2 decimal places.
     * If the grade argument passed to the function is not one of the expected values ("A", "B", "C", "D", "F"), the function returns 0.0.
     */
    public static double getGradePercentage(String grade, int[] gradeCounts, int numStudents) {
        switch(grade) {
            case "A":
                double gradePercent0=100.0 * gradeCounts[0] / numStudents;
                return gradePercent0;
            case "B":
                double gradePercent1=100.0 * gradeCounts[1] / numStudents;
                return gradePercent1;
            case "C":
                double gradePercent2=100.0 * gradeCounts[2] / numStudents;
                return gradePercent2;
            case "D":
                double gradePercent3=100.0 * gradeCounts[3] / numStudents;
                return gradePercent3;
            case "F":
                double gradePercent4=100.0 * gradeCounts[4] / numStudents;
                return gradePercent4;
            default:
                return 0.0;
        }
    }
    /** Function to get grade classification
     *  This function takes in a student grade as a String, and 
     *  returns a String representing the classification of that 
     *  grade based on a traditional British undergraduate degree 
     *  classification system. 
     *  
     *  The classification system ranges from "First Class" for 
     *  the highest grades to "Fail" for the lowest grades. 
     *  
     *  If the input grade is not one of the expected values, the function returns "N/A".
     * */
    public static String getGradeClassification(String grade) {
        switch (grade) {
            case "A":
                return "First Class";
            case "B":
                return "Upper Second Class";
            case "C":
                return "Lower Second Class";
            case "D":
                return "Third Class";
            case "F":
                return "Fail";
            default:
                return "N/A";
        }
    }

}
