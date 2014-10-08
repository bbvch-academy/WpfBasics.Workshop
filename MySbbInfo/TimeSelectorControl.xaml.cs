// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeSelectorControl.xaml.cs" company="bbv Software Services AG">
//   Copyright (c) 2012
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
// <summary>
//   Interaction logic for TimeTableControl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for TimeSelectorControl.xaml
    /// </summary>
    public partial class TimeSelectorControl : UserControl
    {
        public static readonly DependencyProperty SelectedDateTimeProperty =
            DependencyProperty.Register("SelectedDateTime", typeof(DateTime), typeof(TimeSelectorControl));

        public TimeSelectorControl()
        {
            this.InitializeComponent();

            this.TimePicker.TimeInterval = TimeSpan.FromMinutes(10);
            this.TimePicker.Value = DateTime.Now;
            this.DatePicker.SelectedDate = DateTime.Now;
        }

        public DateTime SelectedDateTime
        {
            get
            {
                return (DateTime)GetValue(SelectedDateTimeProperty);
            }

            set
            {
                SetValue(SelectedDateTimeProperty, value); 

                this.DatePicker.SelectedDate = value;
                this.TimePicker.Value = value;
            }
        }

        private void DatePickerDateChanged(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;

            this.UpdateSelectedDateTimeValue();
        }

        private void TimePickerTimeChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            e.Handled = true;

            this.UpdateSelectedDateTimeValue();
        }

        private void UpdateSelectedDateTimeValue()
        {
            if (this.DatePicker.SelectedDate.HasValue && this.TimePicker.Value.HasValue)
            {
                this.SelectedDateTime =
                    this.DatePicker.SelectedDate.Value.Date.Add(this.TimePicker.Value.Value.TimeOfDay);
            }
        }
    }
}
