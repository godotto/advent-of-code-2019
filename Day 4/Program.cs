using System;

namespace Day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // input values for both puzzles are 168630 and 718098
            Console.WriteLine("Number of valid passwords from 168630 to 718098: " + NumberOfValidPasswords(168630, 718098)); // solution for 1st puzzle
            Console.WriteLine("Number of valid passwords for new criteria from 168630 to 718098: " + ImprovedNumberOfValidPasswords(168630, 718098)); // solution for 2nd puzzle
        }

        static bool IsWithDouble(string password)
        {
            for (var i = 0; i < 5; i++)
                if (password[i] == password[i + 1])
                    return true;

            return false;
        }

        static bool IsDecreasing(string password)
        {
            for (var i = 0; i < 5; i++)
                if (password[i] > password[i + 1])
                    return true;

            return false;
        }

        static int NumberOfValidPasswords(int beginningOfRange, int endOfRange)
        {
            var numberOfValidPasswords = 0;

            for (var password = beginningOfRange; password <= endOfRange; password++)
                if (IsWithDouble(Convert.ToString(password)) && !IsDecreasing(Convert.ToString(password)))
                    numberOfValidPasswords++;

            return numberOfValidPasswords;
        }

        static bool ImprovedIsWithDouble(string password)
        {
            int[] occurances = new int[10];
            for (var i = 0; i < 6; i++)
                occurances[Convert.ToInt32(Char.GetNumericValue(password[i]))]++;

            foreach (var digitOccurance in occurances)
                if (digitOccurance == 2)
                    return true;

            return false;
        }

        static int ImprovedNumberOfValidPasswords(int beginningOfRange, int endOfRange)
        {
            var numberOfValidPasswords = 0;

            for (var password = beginningOfRange; password <= endOfRange; password++)
                if (ImprovedIsWithDouble(Convert.ToString(password)) && !IsDecreasing(Convert.ToString(password)))
                    numberOfValidPasswords++;

            return numberOfValidPasswords;
        }
    }
}
