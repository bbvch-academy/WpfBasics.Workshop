// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeTableControl.xaml.cs" company="bbv Software Services AG">
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

namespace MySbbInfo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    using SbbApi;
    using SbbApi.ApiClasses;

    /// <summary>
    /// Interaction logic for TimeTableControl.xaml
    /// </summary>
    public partial class TimeTableControl : UserControl
    {
        private ITransportService transportService;

        public TimeTableControl()
        {
            this.InitializeComponent();
            this.InitializeTimeControls();
        }

        public void Initialize(ITransportService transportService)
        {
            this.transportService = transportService;
        }

        private void InitializeTimeControls()
        {
            this.SelectedDate.SelectedDate = DateTime.Now;

            this.SelectedTime.TimeInterval = TimeSpan.FromMinutes(10);
            this.SelectedTime.Value = DateTime.Now;
        }

        private void SearchConnectionsClick(object sender, RoutedEventArgs e)
        {
            DateTime startTime = this.SelectedDate.SelectedDate.Value.Date.Add(this.SelectedTime.Value.Value.TimeOfDay);

            IEnumerable<Connection> connections = this.transportService.GetConnections(this.txtFrom.Text, this.txtTo.Text, startTime);

            ConnectionsGrid.ItemsSource = connections;
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
    }
}
