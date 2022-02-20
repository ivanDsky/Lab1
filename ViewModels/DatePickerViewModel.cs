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
        #region Private fields
        private DateTime _date;
        private String _age;
        private String _chineseSign;
        private String _westSign;
        private int _birthdayYears;
        #endregion
        #region Fields
        public String PersonAge
        {
            get => _age;
            private set
            {
                _age = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("PersonAge"));
            }
        }
        public String ChineseSign
        {
            get => "Chinese Zodiak Sign: " + _chineseSign;
            private set
            {
                _chineseSign = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ChineseSign"));
            }
        }
        public String EuropeSign
        {
            get => "West Zodiak Sign: " + _westSign;
            private set
            {
                _westSign = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("EuropeSign"));
            }
        }
        public DateTime Date
        {
            get => _date;
            set
            {
                SetDate(value);
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Date"));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        public DatePickerViewModel()
        {
            SetDate(DateTime.Today);
        }

        #region Private methods
        private void SetDate(DateTime date)
        {
            DateTime age = CalculateAge(date);
            _date = date;
            _birthdayYears = (age.Day == 1 && age.Month == 1) ? age.Year - 1 : -1;
            PersonAge = AgeToString(age) + ((_birthdayYears == -1) ? "" : "\nHappy Birthday!!!");
            ChineseSign = new ChinaZodiac(_date).GetSign();
            EuropeSign = new EuropeZodiac(_date).GetSign();
        }
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
        #endregion

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
