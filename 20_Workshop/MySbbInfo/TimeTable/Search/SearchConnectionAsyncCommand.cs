// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchConnectionAsyncCommand.cs" company="bbv Software Services AG">
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
//   Interaction logic for TimeTableControl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.TimeTable.Search
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Input;

    using SbbApi;
    using SbbApi.ApiClasses;

    public delegate void SearchConnectionCompletedEventHandler(object sender, SearchConnectionCompletedEventArgs args);

    public class SearchConnectionAsyncCommand : ICommand
    {
        private readonly ITransportService transportService;

        public SearchConnectionAsyncCommand(ITransportService transportService)
        {
            this.transportService = transportService;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public event EventHandler BeginStationSearch = (sender, args) => { };

        public event SearchConnectionCompletedEventHandler SearchConnectionCompleted = (sender, args) => { };

        public bool CanExecute(object parameter)
        {
            if (parameter == null || !(parameter is TimeTableSearchModel))
            {
                return false;
            }

            var searchParameter = (TimeTableSearchModel)parameter;

            return !string.IsNullOrWhiteSpace(searchParameter.From) && !string.IsNullOrWhiteSpace(searchParameter.To);
        }

        public void Execute(object parameter)
        {
            this.BeginStationSearch(this, new EventArgs());

            var worker = new BackgroundWorker();
            worker.RunWorkerCompleted += (o, ea) => this.SearchConnectionCompleted(this, new SearchConnectionCompletedEventArgs((IEnumerable<Connection>)ea.Result));
            worker.DoWork += (o, ea) => this.Execute(ea);

            var searchParameter = (TimeTableSearchModel)parameter;

            worker.RunWorkerAsync(
                new BackgroundWorkerArgs(this.transportService, searchParameter.DepartureDateTime, searchParameter.From, searchParameter.To));
        }

        public void Execute(DoWorkEventArgs ea)
        {
            var args = (BackgroundWorkerArgs)ea.Argument;

            ITransportService service = args.TransportService;

            IEnumerable<Connection> connections = service.GetConnections(args.From, args.To, args.StartTime);

            ea.Result = connections;
        }

        private class BackgroundWorkerArgs
        {
            public BackgroundWorkerArgs(ITransportService transportService, DateTime startTime, string from, string to)
            {
                this.TransportService = transportService;
                this.StartTime = startTime;
                this.From = @from;
                this.To = to;
            }

            public ITransportService TransportService { get; private set; }

            public DateTime StartTime { get; private set; }

            public string From { get; private set; }

            public string To { get; private set; }
        }
    }
}