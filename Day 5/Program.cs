using System;

namespace Day_5
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = System.IO.File.ReadAllText("input.txt");
            string[] splittedInput = input.Split(',');

            ExecuteIntcode(splittedInput); // solution for the first puzzle
        }

        static void ExecuteOneParameterOpcode(ref string[] input, string opcode, string parameter)
        {
            if (opcode == "3")                                          // read value from input and store in postiton passed as parameter
            {
                Console.WriteLine("Please provide an input value:");
                input[Convert.ToInt32(parameter)] = Console.ReadLine();
            }
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
            else if (opcode == "7")
                input[Convert.ToInt32(third)] = Convert.ToString(Convert.ToInt32(Convert.ToInt32(first) < Convert.ToInt32(second)));
            else if (opcode == "8")
                input[Convert.ToInt32(third)] = Convert.ToString(Convert.ToInt32(Convert.ToInt32(first) == Convert.ToInt32(second)));
        }

        static void ExecuteThreeParametersOpcodeWithModes(ref string[] input, string opcode, string first, string second, string third)
        {
            int left, right;

            if (opcode[opcode.Length - 1] == '1') // add and store in positon passed as third parameter
            {
                if (opcode[opcode.Length - 3] == '0') // positon mode                               
                    left = Convert.ToInt32(input[Convert.ToInt32(first)]);
                else                  // immediate mode
                    left = Convert.ToInt32(first);

                if (opcode.Length == 3 || opcode[0] == '0') // position mode
                    right = Convert.ToInt32(input[Convert.ToInt32(second)]);
                else                  // immediate mode
                    right = Convert.ToInt32(second);

                input[Convert.ToInt32(third)] = Convert.ToString(left + right);
            }
            else // multiply and store in positon passed as third parameter
            {
                if (opcode[opcode.Length - 3] == '0') // position mode
                    left = Convert.ToInt32(input[Convert.ToInt32(first)]);
                else                  // immediate mode
                    left = Convert.ToInt32(first);

                if (opcode.Length == 3 || opcode[0] == '0') // position mode
                    right = Convert.ToInt32(input[Convert.ToInt32(second)]);
                else                  // immediate mode
                    right = Convert.ToInt32(second);

                input[Convert.ToInt32(third)] = Convert.ToString(left * right);
            }
        }

        static void ExecuteIntcode(string[] input)
        {
            var i = 0;

            while (i < input.Length)
            {
                if (input[i].Length == 1)
                {
                    if (input[i] == "3" || input[i] == "4")
                    {
                        ExecuteOneParameterOpcode(ref input, input[i], input[i + 1]);
                        i += 2;
                    }
                    else
                    {
                        ExecuteThreeParametersOpcode(ref input, input[i], input[i + 1], input[i + 2], input[i + 3]);
                        i += 4;
                    }
                }
                else
                {
                    if (input[i] == "104")
                    {
                        ExecuteOneParameterOpcode(ref input, input[i], input[i + 1]);
                        i += 2;
                    }
                    else if (input[i] == "99")
                        return;
                    else
                    {
                        ExecuteThreeParametersOpcodeWithModes(ref input, input[i], input[i + 1], input[i + 2], input[i + 3]);
                        i += 4;
                    }
                }
            }
        }
    }
}
