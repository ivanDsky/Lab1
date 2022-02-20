using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Tools
{
    public class AgeCalculator
    {
        private DateTime _dateOfBirth;
        private DateTime _deltaDate;

        public DateTime CurrentAge
        {
            get => _deltaDate;
        }

        public AgeCalculator(DateTime dateOfBirth)
        {
            _dateOfBirth = dateOfBirth;
            try
            {
                _deltaDate = CalculateDeltaAge(_dateOfBirth, DateTime.Today);
            }
            catch (ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException(null,"Age is negative");
            }
            if (_deltaDate.Year >= 135)
                throw new ArgumentOutOfRangeException(null,"Age is greater than 135");

        }

        public DateTime CalculateDeltaAge(DateTime birthDate, DateTime now)
        {
            int months = now.Month - birthDate.Month;
            int years = now.Year - birthDate.Year;

            if (now.Day < birthDate.Day)
            {
                months--;
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            int days = (now - birthDate.AddMonths((years * 12) + months)).Days;

            return new DateTime(years + 1, months + 1, days + 1);
        }
    }
}
