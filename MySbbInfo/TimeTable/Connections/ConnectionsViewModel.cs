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
    using System.Linq;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using Caliburn.Micro;

    using MySbbInfo.TimeTable.Connections.Sections;

    using SbbApi.ApiClasses;

    public class ConnectionsViewModel : PropertyChangedBase, IConnectionsViewModel
    {
        private IEnumerable<Connection> latestConnections;

        private IEnumerable<ConnectionsModel> connections;

        private ConnectionsModel selectedConnection;

        public ConnectionsViewModel()
        {
            this.Connections = new Collection<ConnectionsModel>();
            this.Sections = new SectionsViewModel();
        }

        public ISectionsViewModel Sections { get; set; }

        public ConnectionsModel SelectedConnection
        {
            get
            {
                return this.selectedConnection;
            }

            set
            {
                this.selectedConnection = value;
                Connection markedCollection = null;

                if (value != null)
                {
                    markedCollection = this.latestConnections.FirstOrDefault(
                        x => x.From.Station.Name == value.DepartingStationName && x.From.Departure == value.DepartureDateTime);
                }

                this.Sections.DisplaySections(markedCollection);
                this.NotifyOfPropertyChange();
            }
        }

        public IEnumerable<ConnectionsModel> Connections
        {
            get
            {
                return this.connections;
            }

            private set
            {
                if (value != this.connections)
                {
                    this.connections = value;
                    this.NotifyOfPropertyChange();
                }
            }
        }

        public void UpdateConnections(IEnumerable<Connection> updatedConnections)
        {
            this.latestConnections = updatedConnections;

            var connectionModels = new Collection<ConnectionsModel>();

            foreach (Connection connection in this.latestConnections)
            {
                connectionModels.Add(new ConnectionsModel(
                    connection.From.Station.Name,
                    connection.From.Departure,
                    connection.To.Station.Name,
                    connection.To.Arrival,
                    connection.Duration,
                    connection.Capacity2nd));
            }

            this.Connections = connectionModels;
        }
    }
}