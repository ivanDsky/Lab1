using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Tools.Zodiac
{
    public class ChinaZodiac : Zodiac
    {
        private static string[] signs = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };
        public ChinaZodiac(DateTime birthDate) : base(birthDate)
        { }

        public override string GetSign()
        {
            return signs[(_birthDate.Year + 8) % 12];
        }
    }
}
