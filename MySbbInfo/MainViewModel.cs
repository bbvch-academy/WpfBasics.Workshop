// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="bbv Software Services AG">
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
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo
{
    using MySbbInfo.SearchStation;
    using MySbbInfo.StationTimeTable;
    using MySbbInfo.TimeTable;

    using SbbApi;

    public class MainViewModel : IMainViewModel
    {
        public MainViewModel(IStationTimeTableViewModel stationTimeTable, ISearchStationViewModel searchStation, ITimeTableViewModel timeTable)
        {
            this.StationTimeTable = stationTimeTable;
            this.SearchStation = searchStation;
            this.TimeTable = timeTable;
        }

        public IStationTimeTableViewModel StationTimeTable { get; private set; }

        public ISearchStationViewModel SearchStation { get; private set; }

        public ITimeTableViewModel TimeTable { get; private set; }
    }
}