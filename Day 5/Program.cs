using System;

namespace Day_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = System.IO.File.ReadAllText("input.txt");
            string[] splittedInput = input.Split(',');
        }

        static void ExecuteOneParameterOpcode(ref string[] input, string opcode, string parameter)
        {
            if (opcode == "3")                                          // read value from input and store in postiton passed as parameter
                input[Convert.ToInt32(parameter)] = Console.ReadLine();
            else if (opcode == "4")                                     // print value in postion passed as parameter
                Console.WriteLine(input[Convert.ToInt32(parameter)]);
            else if (opcode == "104")                                   // print value passed as parameter
                Console.WriteLine(parameter);
        }

        static void ExecuteThreeParametersOpcode(ref string[] input, string opcode, string first, string second, string third)
        {
            int left = Convert.ToInt32(input[Convert.ToInt32(first)]);
            int right = Convert.ToInt32(input[Convert.ToInt32(second)]);

            if (opcode == "1")
                input[Convert.ToInt32(third)] = Convert.ToString(left + right);
            else if (opcode == "2")
                input[Convert.ToInt32(third)] = Convert.ToString(left * right);
        }
    }
}
