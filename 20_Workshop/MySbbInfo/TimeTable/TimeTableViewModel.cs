// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeTableViewModel.cs" company="bbv Software Services AG">
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

namespace MySbbInfo.TimeTable
{
    using System.Linq;
    using System.Windows.Controls;

    using MySbbInfo.TimeTable.Connections;
    using MySbbInfo.TimeTable.Search;

    using SbbApi;
    using SbbApi.ApiClasses;
    
    public class TimeTableViewModel
    {
        public TimeTableViewModel(ITransportService transportService)
        {
            this.TimeTableSearch = new TimeTableSearchViewModel(transportService);
            this.FoundConnections = new ConnectionsViewModel();

            this.TimeTableSearch.NewSearchConnectionResult += (sender, args) => this.FoundConnections.UpdateConnections(args.ConnectionsResult);
        }

        public ITimeTableSearchViewModel TimeTableSearch { get; private set; }

        public IConnectionsViewModel FoundConnections { get; private set; }
        
        private void ConnectionsGrid_OnSelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGridCellInfo selected = e.AddedCells.FirstOrDefault();

            if (!(selected.Item is Connection))
            {
                return;
            }

            var selectedConnection = (Connection)selected.Item;

            //this.Connections.Clear();

            //foreach (Section section in selectedConnection.Sections)
            //{
            //    this.Connections.Add(section);
            //}
        }
    }
}