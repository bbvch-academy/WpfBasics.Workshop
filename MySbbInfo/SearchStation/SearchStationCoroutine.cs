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
    using System.ComponentModel;

    using Caliburn.Micro;

    using SbbApi;
    using SbbApi.ApiClasses;

    public delegate void SearchStationCompletedEventHandler(object sender, SearchStationCompletedEventArgs args);

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
            var worker = new BackgroundWorker();
            worker.RunWorkerCompleted += (o, ea) => 
            {
                this.StationSearchCompleted(this, new SearchStationCompletedEventArgs((IEnumerable<Station>)ea.Result));
                this.Completed(this, new ResultCompletionEventArgs());
            };
            worker.DoWork += (o, ea) => this.RunSearch(ea);

            worker.RunWorkerAsync(new BackgroundWorkerArgs(this.transportService, this.stationQuery));
        }

        private void RunSearch(DoWorkEventArgs ea)
        {
            var args = (BackgroundWorkerArgs)ea.Argument;

            ITransportService service = args.TransportService;

            IEnumerable<Station> stationboard = service.GetLocations(args.Station);

            ea.Result = stationboard;
        }

        private class BackgroundWorkerArgs
        {
            public BackgroundWorkerArgs(ITransportService transportService, string station)
            {
                this.TransportService = transportService;
                this.Station = station;
            }

            public ITransportService TransportService { get; private set; }

            public string Station { get; private set; }
        }
    }
}