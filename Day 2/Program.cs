using System;

namespace Day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = System.IO.File.ReadAllText("input.txt");
            string[] splittedInput = input.Split(',');
            splittedInput[1] = "12";
            splittedInput[2] = "2";

            ExecuteIntcode(ref splittedInput);
            Console.WriteLine("Value at positon 0 after execution of Intcode: " + splittedInput[0]); // solution for the first puzzle
            Console.WriteLine("100 * proper noun + proper verb = " + FindProperInputs(input, "19690720")); // solution the second puzzle
        }

        static int Calculate(string opcode, string first, string second)
        {
            if (opcode == "1")
                return Convert.ToInt32(first) + Convert.ToInt32(second); // if opcode is 1 add values at first and second position
            else
                return Convert.ToInt32(first) * Convert.ToInt32(second); // if opcode is 2 multiply values at first and second position
        }

        static void ExecuteIntcode(ref string[] input)
        {
            for (var i = 0; i < input.Length; i += 4) // loop iterates each fourth element as these are opcodes
            {
                if (input[i] == "99") // if opcode is 99 halt Intcode execution
                    return;
                else
                    input[Convert.ToInt32(input[i + 3])] = Convert.ToString(Calculate(input[i], input[Convert.ToInt32(input[i + 1])], input[Convert.ToInt32(input[i + 2])])); // execute proper operation and change the right value
            }
        }

        static int FindProperInputs(string input, string soughtOutput)
        {
            for (var noun = 0; noun <= 99; noun++) // check all possible nouns
            {
                for (var verb = 0; verb <= 99; verb++) // check all possible verbs
                {
                    string[] splittedInput = input.Split(',');
                    splittedInput[1] = Convert.ToString(noun);
                    splittedInput[2] = Convert.ToString(verb);

                    ExecuteIntcode(ref splittedInput);
                    if (splittedInput[0] == soughtOutput) // if proper noun and verb are found return 100 * noun + verb
                        return 100 * noun + verb;
                }
            }

            return -1; // if proper noun and verb are not found return -1
        }
    }
}
