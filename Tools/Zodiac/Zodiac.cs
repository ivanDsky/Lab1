using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.Tools.Zodiac
{
    public abstract class Zodiac
    {
        protected DateTime _birthDate;
        public Zodiac(DateTime birthDate)
        {
            _birthDate = birthDate;
        }

        public abstract String GetSign();
    }
}
