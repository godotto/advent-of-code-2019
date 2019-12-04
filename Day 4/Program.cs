using System;

namespace Day_4
{
    class Program
    {
        static void Main(string[] args)
        {
            
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
    }
}
