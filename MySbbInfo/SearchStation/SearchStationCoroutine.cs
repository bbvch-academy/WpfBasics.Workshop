// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchStationCoroutine.cs" company="bbv Software Services AG">
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

namespace MySbbInfo.SearchStation
{
    using System;
    using System.Collections.Generic;

    using Caliburn.Micro;

    using SbbApi;
    using SbbApi.ApiClasses;

    public class SearchStationCoroutine : IResult
    {
        private readonly ITransportService transportService;

        private readonly string stationQuery;

        public SearchStationCoroutine(ITransportService transportService, string stationQuery)
        {
            this.transportService = transportService;
            this.stationQuery = stationQuery;
        }

        public event SearchStationCompletedEventHandler StationSearchCompleted = (sender, args) => { };

        public event EventHandler<ResultCompletionEventArgs> Completed;

        public void Execute(CoroutineExecutionContext context)
        {
            IEnumerable<Station> locations = this.transportService.GetLocations(this.stationQuery);

            this.StationSearchCompleted(this, new SearchStationCompletedEventArgs(locations));
            this.Completed(this, new ResultCompletionEventArgs());
        }
    }
}