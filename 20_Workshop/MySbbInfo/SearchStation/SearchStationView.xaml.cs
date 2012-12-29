// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchStation.cs" company="bbv Software Services AG">
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
//   Interaction logic for SearchStation
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.SearchStation
{
    using System.Windows.Controls;

    public partial class SearchStation : UserControl
    {
        public SearchStation()
        {
            this.InitializeComponent();
        }

        protected override void OnRender(System.Windows.Media.DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            var searchStationViewModel = this.DataContext as ISearchStationViewModel;
            if (searchStationViewModel != null)
            {
                searchStationViewModel.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == "StationPosition" && searchStationViewModel.StationPosition != null)
                    {
                        this.map.SetView(searchStationViewModel.StationPosition, this.map.ZoomLevel);
                    }
                };
            }
        }
    }
}
