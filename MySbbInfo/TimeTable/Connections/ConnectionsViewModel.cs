// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectionsViewModel.cs" company="bbv Software Services AG">
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
// <summary>
//   Defines the ConnectionsViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.TimeTable.Connections
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;

    using Caliburn.Micro;

    using MySbbInfo.TimeTable.Connections.Sections;

    using SbbApi.ApiClasses;

    public class ConnectionsViewModel : Conductor<ConnectionViewModel>.Collection.AllActive, IConnectionsViewModel
    {
        private IEnumerable<Connection> latestConnections;

        private IEnumerable<ConnectionViewModel> connections;

        public ConnectionsViewModel()
        {
            this.Connections = new Collection<ConnectionViewModel>();
            this.Sections = new SectionsViewModel();
        }

        public ISectionsViewModel Sections { get; set; }

        public IEnumerable<ConnectionViewModel> Connections
        {
            get
            {
                return this.connections;
            }

            private set
            {
                if (!value.Equals(this.connections))
                {
                    this.connections = value;
                    this.NotifyOfPropertyChange();

                    ConnectionViewModel viewModel = this.connections.FirstOrDefault();
                    if (viewModel != null)
                    {
                        viewModel.SelectConnection();
                        this.DisplayFirstConnection();
                    }
                }
            }
        }

        public void UpdateConnections(IEnumerable<Connection> updatedConnections)
        {
            this.latestConnections = updatedConnections;

            var connectionsViewModels = new Collection<ConnectionViewModel>();

            foreach (Connection connection in this.latestConnections)
            {
                var connectionViewModel = new ConnectionViewModel
                {
                    Connection = new ConnectionModel(
                        connection.From.Station.Name,
                        connection.From.Departure,
                        connection.To.Station.Name,
                        connection.To.Arrival,
                        connection.Duration,
                        connection.Capacity2nd),
                    ConnectionInformation = connection
                };

                connectionsViewModels.Add(connectionViewModel);
                this.ActivateItem(connectionViewModel);
            }

            this.Connections = connectionsViewModels;
        }

        public void SelectView(ConnectionViewModel selectedViewModel)
        {
            foreach (ConnectionViewModel connection in this.Connections)
            {
                connection.IsSelected = false;
            }

            this.Sections.DisplaySections(selectedViewModel.ConnectionInformation);
            selectedViewModel.IsSelected = true;
        }

        private void DisplayFirstConnection()
        {
            ConnectionViewModel firstConnection = this.Connections.FirstOrDefault();
            if (firstConnection == null)
            {
                return;
            }

            Connection markedCollection =
                this.latestConnections.FirstOrDefault(
                    x =>
                    x.From.Station.Name == firstConnection.Connection.DepartingStationName
                    && x.From.Departure == firstConnection.Connection.DepartureDateTime);

            if (markedCollection != null)
            {
                this.Sections.DisplaySections(markedCollection);
            }
        }
    }
}