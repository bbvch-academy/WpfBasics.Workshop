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

    // TODO: Base class should be a cond from Conductor<IConnectionViewModel>.Collection.AllActive
    public class ConnectionsViewModel : PropertyChangedBase, IConnectionsViewModel
    {
        private ConnectionModel selectedConnection;

        private IEnumerable<Connection> latestConnections;

        private IEnumerable<ConnectionModel> connections;

        public ConnectionsViewModel()
        {
            this.Connections = new Collection<ConnectionModel>();
            this.Sections = new SectionsViewModel();
        }

        public ISectionsViewModel Sections { get; set; }

        public ConnectionModel SelectedConnection
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

        public IEnumerable<ConnectionModel> Connections
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
                }
            }
        }

        public void UpdateConnections(IEnumerable<Connection> updatedConnections)
        {
            this.latestConnections = updatedConnections;

            var connectionsModels = new Collection<ConnectionModel>();

            foreach (Connection connection in this.latestConnections)
            {
                var model = new ConnectionModel(
                    connection.From.Station.Name,
                    connection.From.Departure,
                    connection.To.Station.Name,
                    connection.To.Arrival,
                    connection.Duration,
                    connection.Capacity2nd);

                connectionsModels.Add(model);

                // TODO: active the connection view model with this.ActivateItem(connectionViewModel);
                //       in order to set the value for the parent property
            }

            this.Connections = connectionsModels;
        }

        public void SelectView(ConnectionViewModel selectedViewModel)
        {
            // TODO: mark selectedViewModel as selected and all others as unselected.
        }
    }
}