using System;
using System.Text.RegularExpressions;

namespace Palindrome
{

    class Utils
    {

        // Constructor.
        public Utils() { }

        // THIS FUNCTION WILL RETURN THE REVERSE OF THE STRING.
        public string reverse_string(string string_input)
        {

            // VARIABLE DECLARATION.
            string reversed_string = "";

            for (int i = string_input.Length - 1; i >= 0; i--) reversed_string += string_input[i];

            return reversed_string;

        }

        // THIS FUNCTION WILL CHECK IF THE STRING IS PALINDROME OR NOT.
        public bool is_palindrome(string string_input) => string_input == reverse_string(string_input);

        // THIS FUNCTION WILL REMOVE SPACES FROM THE STRING.
        public string remove_spaces(string string_input) => string_input.Replace(" ", "");

        // THIS FUNCTION WILL REMOVE SPECIAL CHARACTERS FROM THE STRING.
        public string remove_special_characters(string string_input) => Regex.Replace(string_input, @"[^0-9a-zA-Z\._]", "");

        // THIS FUNCTION WILL KEEP ASKING THE USER TO ENTER A VALID INPUT.
        public string get_valid_input(string question, string option1, string option2)
        {

            // VARIABLE DECLARATION.
            string input = "";
            bool incorrect_input = false;

            do
            {

                if (incorrect_input) Console.WriteLine("Invalid input! Please try again!\n");
                Console.WriteLine(question);
                input = Console.ReadLine();
                Console.WriteLine();

            } while (incorrect_input = (input != option1 && input != option2));

            return input;

        }

    }

}