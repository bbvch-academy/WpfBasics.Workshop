// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchStationAsyncCommand.cs" company="bbv Software Services AG">
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
//   Defines the ChangeUiLanguageCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.SearchStation
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Input;

    using SbbApi;
    using SbbApi.ApiClasses;

    public delegate void SearchStationCompletedEventHandler(object sender, SearchStationCompletedEventArgs args);

    public class SearchStationAsyncCommand : ICommand
    {
        private readonly ITransportService transportService;

        public event EventHandler CanExecuteChanged;

        public event EventHandler BeginStationSearch = (sender, args) => { };

        public event SearchStationCompletedEventHandler StationSearchCompleted = (sender, args) => { };

        public SearchStationAsyncCommand(ITransportService transportService)
        {
            this.transportService = transportService;
        }

        public bool CanExecute(object parameter)
        {
            return parameter is string && !string.IsNullOrWhiteSpace((string)parameter);
        }

        public void Execute(object parameter)
        {
            if (!this.CanExecute(parameter))
            {
                return;
            }

            this.BeginStationSearch(this, new EventArgs());

            var worker = new BackgroundWorker();
            worker.RunWorkerCompleted += (o, ea) => this.StationSearchCompleted(this, new SearchStationCompletedEventArgs((IEnumerable<Station>)ea.Result));
            worker.DoWork += (o, ea) => this.Execute(ea);

            var stationQuery = (string)parameter;

            worker.RunWorkerAsync(new BackgroundWorkerArgs(this.transportService, stationQuery));
        }

        public void Execute(DoWorkEventArgs ea)
        {
            var args = (BackgroundWorkerArgs)ea.Argument;

            ITransportService service = args.TransportService;

            IEnumerable<Station> locations = service.GetLocations(args.StationQuery);

            ea.Result = locations;
        }

        private class BackgroundWorkerArgs
        {
            public BackgroundWorkerArgs(ITransportService transportService, string stationQuery)
            {
                this.TransportService = transportService;
                this.StationQuery = stationQuery;
            }

            public ITransportService TransportService { get; private set; }

            public string StationQuery { get; private set; }
        }
    }
}