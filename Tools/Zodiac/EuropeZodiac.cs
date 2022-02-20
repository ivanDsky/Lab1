using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Tools.Zodiac
{
    public class EuropeZodiac : Zodiac
    {
        private static string[] signs = { "Capricorn", "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Sagittarius", "Capricorn" };
        private static int[] fromDate = { 21, 20, 21, 21, 22, 22, 23, 23, 22, 23, 22, 22 };
        public EuropeZodiac(DateTime birthDate) : base(birthDate)
        {}

        public override string GetSign()
        {
            if (_birthDate.Day < fromDate[_birthDate.Month - 1])
                return signs[_birthDate.Month - 1];
            return signs[_birthDate.Month];
        }
    }
}
