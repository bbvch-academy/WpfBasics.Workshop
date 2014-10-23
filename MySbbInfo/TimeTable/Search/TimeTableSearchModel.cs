// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeTableSearchModel.cs" company="bbv Software Services AG">
//   Copyright (c) 2012 - 2014
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
//   Defines the TimeTableSearchModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.TimeTable.Search
{
    using Caliburn.Micro;
    using System;
    using System.ComponentModel;

    public class TimeTableSearchModel : PropertyChangedBase
    {
        private string to;
        private DateTime departureDateTime;
        private string from;

        public TimeTableSearchModel()
        {
            this.DepartureDateTime = DateTime.Now;
        }

        public string From
        {
            get
            {
                return this.from;
            }

            set
            {
                if (value != this.from)
                {
                    this.from = value;
                    this.NotifyOfPropertyChange();
                }
            }
        }

        public string To
        {
            get
            {
                return this.to;
            }

            set
            {
                if (value != this.to)
                {
                    this.to = value;
                    this.NotifyOfPropertyChange();
                }
            }
        }

        public DateTime DepartureDateTime
        {
            get
            {
                return this.departureDateTime;
            }

            set
            {
                if (value != this.departureDateTime)
                {
                    this.departureDateTime = value;
                    this.NotifyOfPropertyChange();
                }
            }
        }
    }
}