// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SectionsViewModel.cs" company="bbv Software Services AG">
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
//   Defines the SectionsViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.Modules.TimeTableModule.Content.Connections.Sections
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using SbbApi.ApiClasses;

    public class SectionsViewModel : ISectionsViewModel
    {
        private IEnumerable<SectionsModel> sections;

        public event PropertyChangedEventHandler PropertyChanged = (sender, args) => { };

        public IEnumerable<SectionsModel> Sections
        {
            get
            {
                return this.sections;
            }

            private set
            {
                this.sections = value;
                this.OnPropertyChanged();
            }
        }

        public void DisplaySections(Connection connection)
        {
            var newSections = new Collection<SectionsModel>();

            if (connection != null && connection.Sections != null && connection.Sections.Length != 0)
            {
                foreach (Section section in connection.Sections)
                {
                    newSections.Add(
                        new SectionsModel(
                            section.Departure.Station.Name,
                            section.Departure.Platform,
                            section.Departure.Departure,
                            section.Arrival.Station.Name,
                            section.Arrival.Platform,
                            section.Arrival.Arrival,
                            section.Journey != null ? section.Journey.Name : string.Empty,
                            section.Departure.Delay,
                            section.Arrival.Delay));
                }
            }

            this.Sections = newSections;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}