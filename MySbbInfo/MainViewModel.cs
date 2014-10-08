// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="bbv Software Services AG">
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
//   Defines the MainViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo
{
    using MySbbInfo.SearchStation;
    using MySbbInfo.StationTimeTable;

    using SbbApi;

    public class MainViewModel : IMainViewModel
    {
        public MainViewModel()
        {
            ITransportService transportService = new TransportService();

            // this.StationTimeTable = new StationTimeTableViewModel(transportService);
            // this.SearchStation = new SearchStationViewModel(transportService);
            // this.TimeTable = new TimeTableViewModel(transportService);
        }

        // public IStationTimeTableViewModel StationTimeTable { get; private set; }

        // public ISearchStationViewModel SearchStation { get; private set; }

        // public ITimeTableViewModel TimeTable { get; private set; }
    }
}