// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainWindow.xaml.cs" company="bbv Software Services AG">
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
//   Interaction logic for MainWindow.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo
{
    using System.Collections.Generic;
    using System.Text;
    using System.Windows;

    using SbbApi;
    using SbbApi.ApiClasses;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly TransportApi transportApi;

        public MainWindow()
        {
            InitializeComponent();

            this.transportApi = new TransportApi();

            this.TimeTable.Initialize(this.transportApi);
            this.Station.Initialize(this.transportApi);
        }

        private void SearchStationClick(object sender, RoutedEventArgs e)
        {
            IEnumerable<Station> locations = this.transportApi.GetLocations(this.txtStationQuery.Text);

            foreach (var location in locations)
            {
                this.stationResult.Items.Add(location.Name);
            }
        }
    }
}
