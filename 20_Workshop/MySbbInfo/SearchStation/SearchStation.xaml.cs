// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchStation.xaml.cs" company="bbv Software Services AG">
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
//   Interaction logic for SearchStation.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.SearchStation
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Controls;

    using SbbApi;
    using SbbApi.ApiClasses;

    /// <summary>
    /// Interaction logic for SearchStation.xaml
    /// </summary>
    public partial class SearchStation : UserControl
    {
        private ITransportService transportService;

        public SearchStation()
        {
            this.InitializeComponent();
        }

        public void Initialize(ITransportService transportService)
        {
            this.transportService = transportService;
        }

        private void SearchStationClick(object sender, RoutedEventArgs e)
        {
            this.stationResult.Items.Clear();

            // see: http://elegantcode.com/2011/10/07/extended-wpf-toolkitusing-the-busyindicator/
            var worker = new BackgroundWorker();
            worker.RunWorkerCompleted += (o, ea) => this.BusySearch.IsBusy = false;

            worker.DoWork += (o, ea) =>
            {
                var args = (BackgroundWorkerArgs)ea.Argument;

                ITransportService service = args.TransportService;

                IEnumerable<Station> locations = service.GetLocations(args.StationQuery);

                this.Dispatcher.Invoke(() =>
                {
                    foreach (var location in locations)
                    {
                        this.stationResult.Items.Add(location.Name);
                    }
                });
            };

            this.BusySearch.IsBusy = true;
            worker.RunWorkerAsync(new BackgroundWorkerArgs(this.transportService, this.txtStationQuery.Text));
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
