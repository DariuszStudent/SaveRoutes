using System;
using System.Collections.Generic;

namespace SaveRoutes
{
    public class Helpers
    {
        public int JustNumbersAndRange(int low, int high)
        {
            var result = default(int);
            while (true)
            {
                while (!int.TryParse(Console.ReadLine(), out result))
                {
                    Console.WriteLine($"Musi to być liczba całkowita od {low} - {high}");
                }
                if (result < low || result > high) Console.Write($"Zakres {low} - {high} ");
                else break;
            }
            return result;
        }
    } 
}
