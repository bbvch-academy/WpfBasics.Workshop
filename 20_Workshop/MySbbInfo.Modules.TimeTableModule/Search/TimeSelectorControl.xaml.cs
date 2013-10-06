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
//   Interaction logic for TimeSelectorView.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.Modules.TimeTableModule.Search
{
    using System;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for TimeSelectorView.xaml
    /// </summary>
    public partial class TimeSelectorControl : UserControl
    {
        public static readonly DependencyProperty SelectedDateTimeProperty =
            DependencyProperty.Register("SelectedDateTime", typeof(DateTime), typeof(TimeSelectorControl));

        public TimeSelectorControl()
        {
            this.InitializeComponent();

            this.DatePicker.SelectedDate = DateTime.Now;
            this.TimePicker.Value = DateTime.Now;
        }

        public DateTime SelectedDateTime
        {
            get
            {
                return this.DatePicker.SelectedDate.Value.Date.Add(this.TimePicker.Value.Value.TimeOfDay);
            }

            set
            {
                this.DatePicker.SelectedDate = value;
                this.TimePicker.Value = value;
            }
        }
    }
}
