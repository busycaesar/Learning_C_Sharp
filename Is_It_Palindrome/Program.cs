using System;

namespace Palindrome
{

    class Program
    {

        static void Main(string[] args)
        {

            // VARIABLE DECLARATION.
            string original_string = "", used_string = "";
            bool is_palindrome = false, exit = false;
            Utils util_functions = new Utils();

            Console.WriteLine("\nIs It Palindrome?\nLets find out!\n");

            while (!exit)
            {

                Console.WriteLine("Enter the string: ");
                original_string = Console.ReadLine();

                // REMOVING SPACES AND SPECIAL CHARACTERS FROM THE STRING.
                used_string = util_functions.remove_spaces(original_string.ToLower());
                used_string = util_functions.remove_special_characters(used_string);

                // CHECKING IF THE STRING IS PALINDROME OR NOT.
                is_palindrome = util_functions.is_palindrome(used_string);

                // PRINTING THE RESULT.
                Console.WriteLine($"\nThe string '{original_string}' is {(is_palindrome ? "a Palindrome" : "not a Palindrome")}.");

                Console.WriteLine();

                if (util_functions.get_valid_input("Do you want to check another one? (yes/exit)?", "yes", "exit") == "exit") exit = true;
                else Console.WriteLine("Awesome! Lets try one more!\n");

            }

            Console.WriteLine("Thank you for using this program! :)\nHope you liked it!\n");

        }

    }

}