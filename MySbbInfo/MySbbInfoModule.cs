// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MySbbInfoModule.cs" company="bbv Software Services AG">
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
    using MySbbInfo.TimeTable.Connections;
    using MySbbInfo.TimeTable.Connections.Sections;
    using MySbbInfo.TimeTable.Search;

    using Ninject.Modules;

    public class MySbbInfoModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IMainViewModel>().To<MainViewModel>().InSingletonScope();

            this.SearchStationBinding();
            this.StationTimeTableBinding();
            this.TimeTableBindings();
        }

        private void SearchStationBinding()
        {
            this.Bind<ISearchStationViewModel>().To<SearchStationViewModel>().InSingletonScope();
        }

        private void StationTimeTableBinding()
        {
            this.Bind<IStationTimeTableViewModel>().To<StationTimeTableViewModel>().InSingletonScope();
        }

        private void TimeTableBindings()
        {
            this.Bind<ITimeTableViewModel>().To<TimeTableViewModel>().InSingletonScope();
            this.Bind<ITimeTableSearchViewModel>().To<TimeTableSearchViewModel>().InSingletonScope();
            this.Bind<IConnectionsViewModel>().To<ConnectionsViewModel>().InSingletonScope();
            this.Bind<ISectionsViewModel>().To<SectionsViewModel>().InSingletonScope();
        }
    }
}