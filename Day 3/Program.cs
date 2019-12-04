using System;

namespace Day_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = System.IO.File.ReadAllLines("input.txt");
            string[] line1 = input[0].Split(',');
            string[] line2 = input[1].Split(',');
        }

        static int ReadNumberOfSteps(string instruction)
        {
            string numberOfSteps = "";
            for (var i = 1; i < instruction.Length; i++)
                numberOfSteps += instruction[i];

            return Convert.ToInt32(numberOfSteps);
        }
    }
}
