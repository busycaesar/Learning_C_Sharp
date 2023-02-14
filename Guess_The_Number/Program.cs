using System;

namespace ProgChallenge
{
    class Program
    {
        static void Main(string[] args)
        {

            // VARIABLE DECLARAtION.
            int number = 0, guessed_numb = 0, attempts = 0, points = 0;
            (int min, int max) min_max_range = (0, 0);
            bool solved = false;

            // INITIAL INSTRUCTIONS.
            Console.WriteLine("\nLets play 'Guess The Number' game!\n\n");
            Console.WriteLine("First enter the minimum and maximum number range which you would like to have.\n");

            // GETTING THE MINIMUM AND MAXIMUM NUMBER RANGE.
            min_max_range = get_number_range();

            // GENERATING THE RANDOM NUMBER ACCORDING TO THE RANGE PROVIDED BY THE USER.
            number = new Random().Next(min_max_range.min, min_max_range.max);

            while (!solved)
            {

                print_seperator();

                // THIS SHOWS THE CURRENT POINTS OF THE USER AND ASKS THE USER TO GUESS THE NUMBER.
                Console.WriteLine($"\nCurrent Points: {points}");
                guessed_numb = only_allow_int("Guess the number: [Q to Quit] ");

                // IF THE USER ENTERS Q, THE GAME ENDS.
                if (guessed_numb == -1) break;

                // CHECKING IF THE GUESSED NUMBER IS GREATER, LESSER OR EQUAL TO THE ACTUAL NUMBER.
                string result = is_number_gre_or_less_than((number, guessed_numb, min_max_range.min, min_max_range.max));

                // UPDATING THE POINTS AND ATTEMPTS OF THE USER.
                attempts++;
                points = update_points((new int[] { )points, get_difference((number, guessed_numb)), get_difference(min_max_range)));

                // THIS WILL TAKE ACTION ACCORDING TO THE RESULT.
                if (result == "Success")
                {

                    print_seperator();

                    Console.WriteLine($"\nYou guessed the number correctly.\nScore: {points}\nAttempts: {attempts}\n");
                    solved = true;

                }
                else if (result == "Lesser") Console.WriteLine($"The number is lesser than {guessed_numb}.");
                else if (result == "Greater") Console.WriteLine($"The number is greater than {guessed_numb}.");
                else Console.WriteLine("Error: Number out of range. Try Again!");

                if (solved && only_allow_int("Do you want to play again?\n1: Yes\nQ: Quit") == 1)
                {

                    solved = false;
                    attempts = 0;
                    points = 0;

                    if (only_allow_int("Do you want to change the range?\n1: Change\n0: Use Same Range\n") == 1) min_max_range = get_number_range();

                    number = new Random().Next(min_max_range.min, min_max_range.max);

                }

            }

            print_seperator();

            // GOODBYE MESSAGE.
            Console.WriteLine("\nThanks for playing! Hope you enjoyed it!\n");

        }

        // THIS FUNCTION WILL TAKE A RANGE OF NUMBERS FROM THE USER.
        static (int, int) get_number_range()
        {

            // VARIABLE DECLARATION.
            (int min, int max) numbers = (0, 0);
            bool success = false;

            do
            {

                if (success) Console.WriteLine("Error: Minimum number should be less than maximum number. Try Again!");
                numbers.min = only_allow_int("Enter the minimum number:");
                numbers.max = only_allow_int("Enter the maximum number:");

            } while (success = numbers.min > numbers.max);

            return numbers;

        }

        // THIS FUNCTION WILL PRINT THE QUESTION AND ONLY ALLOW THE USER TO ENTER NUMBERS.
        static int only_allow_int(string question, int min = 0)
        {

            // VARIABLE DECLARATION.
            string given_number = "";
            int number = 0;
            bool success = false;

            do
            {
                if (success) Console.WriteLine("Error: Only numbers are allowed. Try Again!");
                Console.WriteLine(question);
                given_number = Console.ReadLine();
                if (given_number.ToLower() == "q") return -1;
            } while (success = !Int32.TryParse(given_number, out number));

            return number;

        }

        // THIS FUNCTION WILL CHECK IF THE GUESSED NUMBER IS GREATER, LESSER OR EQUAL TO THE ACTUAL NUMBER.
        // In the below argument, the array of number is received and the description of numbers at each index is as follows: [0] Actual Number, [1] Guessed Number, [2] Minimum Number, [3] Maximum Number.
        static string is_number_gre_or_less_than((int actual_number, int guessed_number, int min, int max) numbers)
        {

            if (numbers.guessed_number < numbers.min || numbers.guessed_number > numbers.max) return "Error";
            else if (numbers.actual_number == numbers.guessed_number) return "Success";
            else if (numbers.actual_number > numbers.guessed_number) return "Greater";
            else return "Lesser";

        }

        // THIS FUNCTION WILL RETURN THE DIFFERENCE BETWEEN THE TWO NUMBERS.
        static int get_difference((int min, int max) numbers)
        {

            // VARIABLE DECLARATION.
            int difference = 0;

            if (numbers.min > numbers.max) difference = numbers.min - numbers.max;
            else if (numbers.min < numbers.max) difference = numbers.min - numbers.max;

            return difference;

        }

        // THIS FUNCTION WILL UPDATE THE POINTS OF THE USER ACCORDING TO THE DIFFERENCE BETWEEN THE GUESSED NUMBER AND THE ACTUAL NUMBER.
        // In the below argument, the array of number is received and the description of numbers at each index is as follows: [0] Points, [1] Guessed Difference, [2] Range Difference.
        static int update_points((int points, int guessed_diff, int range_diff) numbers)
        {

            // VARIABLE DECLARATION.
            float ratio = (float)numbers.guessed_diff / numbers.range_diff;

            ratio = 1 - ratio;

            if (ratio < 0.3) return numbers.points + 1;
            else if (ratio < 0.5) return numbers.points + 2;
            else if (ratio < 0.8) return numbers.points + 5;
            else return numbers.points + 10;

        }

        static void print_seperator()
        {

            Console.WriteLine("\n----------------------------------------------------------------");

        }

    }

}