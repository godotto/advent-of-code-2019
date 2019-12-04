﻿using System;

namespace Day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            // input values for both puzzles are 168630 and 718098
            Console.WriteLine("Number of valid passwords from 168630 to 718098: " + NumberOfValidPasswords(168630, 718098));
        }

        static bool IsWithDoubles(string password)
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
                if (IsWithDoubles(Convert.ToString(password)) && !IsDecreasing(Convert.ToString(password)))
                    numberOfValidPasswords++;

            return numberOfValidPasswords;
        }
    }
}