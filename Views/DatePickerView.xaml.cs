using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Lab1.ViewModels;

namespace Lab1.Views
{
    
    public partial class DatePickerView : UserControl
    {
        private DatePickerViewModel _viewModel;
        public DatePickerView()
        {
            InitializeComponent();
            DataContext = _viewModel = new DatePickerViewModel();
        }


        private void datePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.Date = (DateTimeOffset)((DatePicker)sender).SelectedDate;
        }
    }
}
