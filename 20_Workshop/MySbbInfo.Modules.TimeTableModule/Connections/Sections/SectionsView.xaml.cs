// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SectionsView.cs" company="bbv Software Services AG">
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
//   Interaction logic for SectionsView.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.Modules.TimeTableModule.Connections.Sections
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Controls;

    using SbbApi.ApiClasses;

    public partial class SectionsView : UserControl
    {
        public SectionsView()
        {
            this.InitializeComponent();
        }

        public static ISectionsViewModel SampleData
        {
            get
            {
                var sections = new List<Section>
                {
                    new Section
                    {
                        Departure = new StopDeparture { Departure = new DateTime(2012, 12, 17, 18, 45, 0), Station = new Station { Name = "Littau" } },
                        Arrival = new StopArrival { Arrival = new DateTime(2012, 12, 17, 18, 47, 0), Station = new Station { Name = "Littau, Bahnhof" } },
                    },
                    new Section
                    {
                        Departure = new StopDeparture { Departure = new DateTime(2012, 12, 17, 18, 47, 0), Station = new Station { Name = "Littau, Bahnhof" } },
                        Arrival = new StopArrival { Arrival = new DateTime(2012, 12, 17, 19, 1, 0), Station = new Station { Name = "Emmenbrücke, Seetalplatz" } },
                        Journey = new Journey { Name = "Bus 13" }
                    },
                    new Section
                    {
                        Departure = new StopDeparture { Departure = new DateTime(2012, 12, 17, 19, 1, 0), Station = new Station { Name = "Emmenbrücke, Seetalplatz" } },
                        Arrival = new StopArrival { Arrival = new DateTime(2012, 12, 17, 19, 8, 0), Station = new Station { Name = "Emmenbrücke" } }
                    },
                    new Section
                    {
                        Departure = new StopDeparture { Departure = new DateTime(2012, 12, 17, 19, 9, 0), Station = new Station { Name = "Emmenbrücke"}, Platform = "1" },
                        Arrival = new StopArrival { Arrival = new DateTime(2012, 12, 17, 19, 52, 0), Station = new Station { Name = "Olten" } },
                        Journey = new Journey { Name = "RE 3588" }
                    },
                    new Section
                    {
                        Departure = new StopDeparture { Departure = new DateTime(2012, 12, 17, 19, 58, 0), Station = new Station { Name = "Olten" }, Platform = "8", Delay = "2 min"},
                        Arrival = new StopArrival { Arrival = new DateTime(2012, 12, 17, 20, 25, 0), Station = new Station { Name = "Bern" } },
                        Journey = new Journey { Name = "IR 1938" },
                    }
                };

                var sectionsViewModel = new SectionsViewModel();

                sectionsViewModel.DisplaySections(new Connection { Sections = sections.ToArray() });

                return sectionsViewModel;
            }
        }
    }
}
