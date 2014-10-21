// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchStationViewModel.cs" company="bbv Software Services AG">
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
//   Defines the ChangeUiLanguageCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.SearchStation
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    using Caliburn.Micro;

    using Microsoft.Maps.MapControl.WPF;

    using SbbApi;
    using SbbApi.ApiClasses;

    public class SearchStationViewModel : PropertyChangedBase, ISearchStationViewModel
    {
        private static readonly Location LocationBern = new Location(46.948429107666, 7.44046020507813);

        private readonly ITransportService transportService;

        private bool isBusy;

        private Location stationPosition;

        private Station selectedStation;

        public SearchStationViewModel(ITransportService transportService)
        {
            this.transportService = transportService;
            this.InitializeSearchStationCommand(transportService);
            this.Stations = new ObservableCollection<Station>();

            this.stationPosition = LocationBern;
        }

        public Station SelectedStation
        {
            get
            {
                return this.selectedStation;
            }

            set
            {
                if ((value != null && value.Equals(this.selectedStation)) || (value == null && this.selectedStation != null))
                {
                    this.selectedStation = value;
                    this.NotifyOfPropertyChange();

                    if (value != null && value.Coordinate.X.HasValue && value.Coordinate.Y.HasValue)
                    {
                        this.StationPosition = new Location(value.Coordinate.Y.Value, value.Coordinate.X.Value);
                    }
                }
            }
        }

        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }

            set
            {
                if (value != this.isBusy)
                {
                    this.isBusy = value;
                    this.NotifyOfPropertyChange();
                }
            }
        }

        public ObservableCollection<Station> Stations { get; set; }

        public Location StationPosition
        {
            get
            {
                return this.stationPosition;
            }

            set
            {
                if (value != this.stationPosition)
                {
                    this.stationPosition = value;
                    this.NotifyOfPropertyChange();
                }
            }
        }

        public IEnumerable<IResult> SearchStation(string stationQuery)
        {
            var searchStationCoroutine = new SearchStationCoroutine(this.transportService, stationQuery);
            searchStationCoroutine.StationSearchCompleted += this.StationSearchCompletedHandler;

            yield return Loader.Show("loading stations");
            yield return searchStationCoroutine;
            yield return Loader.Hide();
        }

        private void BeginStationSearchHandler(object sender, System.EventArgs e)
        {
            this.IsBusy = true;
        }

        private void StationSearchCompletedHandler(object sender, SearchStationCompletedEventArgs args)
        {
            this.Stations.Clear();

            foreach (Station station in args.StationsResult)
            {
                this.Stations.Add(station);
            }

            this.IsBusy = false;
        }

        private void InitializeSearchStationCommand(ITransportService transportService)
        {
            var searchStationCommand = new SearchStationAsyncCommand(transportService);

            searchStationCommand.StationSearchCompleted += this.StationSearchCompletedHandler;
            searchStationCommand.BeginStationSearch += this.BeginStationSearchHandler;
        }
    }
}