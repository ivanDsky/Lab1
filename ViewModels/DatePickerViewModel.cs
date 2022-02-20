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
        private String _name;
        private DateTimeOffset _date;
        #endregion
        #region fields
        public String Name
        {
            get => _name;
            private set
            {
                _name = value;
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }
        public DateTimeOffset Date
        {
            get => _date;
            set
            {
                _date = value;
                Name = value.ToString();
            }
        }
        #endregion      
    
    }
}
