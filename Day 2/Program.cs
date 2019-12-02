using System;

namespace Day_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = System.IO.File.ReadAllText("input.txt");
            string[] splittedInput = input.Split(',');
        }

        static int Calculate(string operation, string first, string second)
        {
            if (operation == "1")
                return Convert.ToInt32(first) + Convert.ToInt32(second);
            else
                return Convert.ToInt32(first) * Convert.ToInt32(second); 
        }
    }
}
