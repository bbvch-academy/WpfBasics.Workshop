﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeTableView.cs" company="bbv Software Services AG">
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
//   Interaction logic for TimeTableView
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.TimeTable
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    using SbbApi;
    using SbbApi.ApiClasses;

    public partial class TimeTableView : UserControl
    {
        private ITransportService transportService;

        public TimeTableView()
        {
            this.InitializeComponent();
        }

        public void Initialize(ITransportService transportService)
        {
            this.transportService = transportService;
        }
        
        private void SearchConnectionsClick(object sender, RoutedEventArgs e)
        {
            DateTime startTime = this.DepartureTime.SelectedDateTime;

            // see: http://elegantcode.com/2011/10/07/extended-wpf-toolkitusing-the-busyindicator/
            var worker = new BackgroundWorker();
            worker.RunWorkerCompleted += (o, ea) => this.BusySearch.IsBusy = false;
            
            worker.DoWork += (o, ea) =>
            {
                var args = (BackgroundWorkerArgs)ea.Argument;

                ITransportService service = args.TransportService;

                IEnumerable<Connection> connections = service.GetConnections(args.From, args.To, args.StartTime);

                Dispatcher.Invoke(() => ConnectionsGrid.ItemsSource = connections);
            };

            this.BusySearch.IsBusy = true;
            worker.RunWorkerAsync(new BackgroundWorkerArgs(this.transportService, startTime, this.txtFrom.Text, this.txtTo.Text));
        }

        private void ConnectionsGrid_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGridCellInfo selected = e.AddedCells.FirstOrDefault();

            if (!(selected.Item is Connection))
            {
                return;
            }

            var selectedConnection = (Connection)selected.Item;

            this.Connections.Items.Clear();

            foreach (Section section in selectedConnection.Sections)
            {
                this.Connections.Items.Add(section);
            }
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