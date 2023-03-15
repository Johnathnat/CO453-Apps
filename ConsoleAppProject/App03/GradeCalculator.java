import java.util.Scanner;

public class GradeCalculator {
    public static void main(String[] args) {
        Scanner input = new Scanner(System.in);

        // Get number of students
        System.out.print("Enter the number of students: ");
        int numStudents = input.nextInt();

        // Initialize arrays
        String[] studentNames = new String[numStudents];
        int[] studentMarks = new int[numStudents];
        String[] studentGrades = new String[numStudents];

        // Get student names and marks and calculate grades
        for (int i = 0; i < numStudents; i++) {
            System.out.print("Enter the name of student " + (i+1) + ": ");
            String name = input.next();
            studentNames[i] = name;
            System.out.print("Enter the mark for student " + name + ": ");
            int mark = input.nextInt();
            studentMarks[i] = mark;
            studentGrades[i] = getGrade(mark);
        }

        // Calculate mean mark of the group
        double sum = 0.0;
        for (int i = 0; i < numStudents; i++) {
            sum += studentMarks[i];
        }
        double meanMark = sum / numStudents;

        // Display mean mark
        System.out.println("\nMean mark of the group: " + meanMark);

        // Calculate grade profile
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

        // Display grade profile with classification
        // Display grade profile with classification
        System.out.println("\nGrade Profile:");
        System.out.println("Name\tGrade\tPercentage\tClassification");
        for (int i = 0; i < numStudents; i++) {
            System.out.println(studentNames[i] + "\t" + studentGrades[i] + "\t" + getGradePercentage(studentGrades[i], gradeCounts, numStudents) + "%\t\t" + getGradeClassification(studentGrades[i]));
        }
    }

    // Function to calculate grade from mark
    public static String getGrade(int mark) {
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
    // Function to get grade percentage
    public static double getGradePercentage(String grade, int[] gradeCounts, int numStudents) {
        switch(grade) {
            case "A":
                return 100.0 * gradeCounts[0] / numStudents;
            case "B":
                return 100.0 * gradeCounts[1] / numStudents;
            case "C":
                return 100.0 * gradeCounts[2] / numStudents;
            case "D":
                return 100.0 * gradeCounts[3] / numStudents;
            case "F":
                return 100.0 * gradeCounts[4] / numStudents;
            default:
                return 0.0;
        }
    }
    // Function to get grade classification
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
