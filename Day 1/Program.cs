using System;

namespace Day_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines("input.txt");
            Console.WriteLine(CalculateAllFuel(lines)); // answer for the first puzzle
            Console.WriteLine(ImprovedCalculateAllFuel(lines)); // answer for the second puzzle
        }

        static int CalculateFuel(int mass)
        {
            return (mass / 3) - 2; // fuel required for one module of a certain mass
        }

        static int CalculateAllFuel(string[] masses)
        {
            var sumOfFuel = 0;
            foreach (var line in masses)
                sumOfFuel += CalculateFuel(Convert.ToInt32(line));
            return sumOfFuel;
        }

        static int ImprovedCalculateFuel(int mass)
        {
            int calculatedMass = mass / 3 - 2;
            if (calculatedMass <= 0) // if no more fuel needed returns 0
                return 0;
            else return calculatedMass + ImprovedCalculateFuel(calculatedMass); // calculate fuel for already calculated fuel
        }

        static int ImprovedCalculateAllFuel(string[] masses)
        {
            var sumOfFuel = 0;
            foreach (var line in masses)
                sumOfFuel += ImprovedCalculateFuel(Convert.ToInt32(line));
            return sumOfFuel;
        }
    }
}
