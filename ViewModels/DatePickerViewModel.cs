using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using Lab1.Tools;

namespace Lab1.ViewModels
{
    class DatePickerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        #region private fields
        private String _age;
        private DateTimeOffset _date;
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
        public DateTimeOffset Date
        {
            get => _date;
            set
            {
                _date = value;
                PersonAge = AgeToString(CalculateAge(_date.DateTime));
            }
        }
        #endregion      
    
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
    }
}
