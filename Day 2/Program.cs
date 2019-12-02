using System;

namespace Day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = System.IO.File.ReadAllText("input.txt");
            string[] splittedInput = input.Split(',');
            splittedInput[1] = Convert.ToString(12);
            splittedInput[2] = Convert.ToString(2);
            
            ExecuteIntcode(ref splittedInput);
            Console.WriteLine("Value at positon 0 after execution of Intcode: " + splittedInput[0]);
        }

        static int Calculate(string operation, string first, string second)
        {
            if (operation == "1")
                return Convert.ToInt32(first) + Convert.ToInt32(second);
            else
                return Convert.ToInt32(first) * Convert.ToInt32(second);
        }

        static void ExecuteIntcode(ref string[] input)
        {
            for (var i = 0; i < input.Length; i += 4)
            {
                if (input[i] == "99")
                    return;
                else
                    input[Convert.ToInt32(input[i + 3])] = Convert.ToString(Calculate(input[i], input[Convert.ToInt32(input[i + 1])], input[Convert.ToInt32(input[i + 2])]));
            }
        }
    }
}
