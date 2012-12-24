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
    using System.Linq;
    using System.Windows.Controls;

    using SbbApi;

    /// <summary>
    /// Interaction logic for TimeTableControl.xaml
    /// </summary>
    public partial class TimeTableControl : UserControl
    {
        private ITransportApi transportApi;

        public TimeTableControl()
        {
            InitializeComponent();
        }

        public void Initialize(ITransportApi transportApi)
        {
            this.transportApi = transportApi;
        }

        private void SearchConnectionsClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var connections = this.transportApi.GetConnections(this.txtFrom.Text, this.txtTo.Text);

            foreach (var connection in connections)
            {
                var from = connection.Sections.First();
                var to = connection.Sections.Last();

                var formatted = string.Format(
                    "Abfahrt: {0:HH:mm} Gleis: {1}, Ankunft: {2:HH:mm} auf: Gleis {3}, Dauer: {4:d'.'hh':'mm':'ss}",
                    from.Departure.Departure,
                    from.Departure.Platform,
                    to.Arrival.Arrival,
                    to.Arrival.Platform,
                    connection.Duration);

                this.resultList.Items.Add(formatted);
            }
        }
    }
}
