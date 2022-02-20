using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using Lab1.Tools;
using Lab1.Tools.Zodiac;

namespace Lab1.ViewModels
{
    class DatePickerViewModel : INotifyPropertyChanged
    {
        #region private fields
        private DateTime _date;
        private String _age;
        private int _birthdayYears;
        #endregion
        #region fields
        public String PersonAge
        {
            get => _age;
            private set
            {
                _age = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("PersonAge"));
            }
        }
        public String ChineseSign
        {
            get => _age;
            private set
            {
                _age = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("ChineseSign"));
            }
        }
        public String EuropeSign
        {
            get => _age;
            private set
            {
                _age = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("EuropeSign"));
            }
        }
        public DateTime Date
        {
            get => _date;
            set
            {
                DateTime age = CalculateAge(value);
                _date = value;
                _birthdayYears = (age.Day == 1 && age.Month == 1) ? age.Year - 1 : -1;
                PersonAge = AgeToString(age) + ((_birthdayYears == -1) ? "" : "\nHappy Birthday!!!");
                ChineseSign = new ChinaZodiac(_date).GetSign();
                EuropeSign = new EuropeZodiac(_date).GetSign();
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Date"));
            }
        }
        #endregion

        public DatePickerViewModel()
        {
            _date = DateTime.Today;
            _age = AgeToString(CalculateAge(_date));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private String AgeToString(DateTime age)
        {
            return String.Format("{0} year{1}, {2} month{3}, {4} day{5}", 
                age.Year - 1, (age.Year - 1 > 1) ? "s" : "",
                age.Month - 1, (age.Month - 1 > 1) ? "s" : "", 
                age.Day - 1, (age.Day - 1 > 1) ? "s" : "");
        }
        private DateTime CalculateAge(DateTime birthDate)
        {
            return new AgeCalculator(birthDate).CurrentAge;
        }

        public void onDateChanged(DateTime? newDate)
        {
            if (newDate == null)
            {
                MessageBox.Show("Empty date");
                Date = _date;
                return;
            }
            DateTime x = newDate!.Value;
            try
            {
                Date = x;
            }
            catch (ArgumentOutOfRangeException exception)
            {
                MessageBox.Show(exception.Message);
                Date = _date;
            }
        }
    }
}
