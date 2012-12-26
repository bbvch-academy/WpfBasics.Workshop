// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchStationViewModel.cs" company="bbv Software Services AG">
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
//   Defines the ChangeUiLanguageCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.SearchStation
{
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;

    using SbbApi;
    using SbbApi.ApiClasses;

    public class SearchStationViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool isBusy;

        public SearchStationViewModel(ITransportService transportService)
        {
            this.InitializeSearchStationCommand(transportService);
            this.Stations = new ObservableCollection<string>();
        }

        public ICommand SearchStationCommand { get; private set; }

        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }
            set
            {
                this.isBusy = value;
                this.OnPropertyChanged("IsBusy");
            }
        }

        public ObservableCollection<string> Stations { get; set; }

        public void BeginStationSearchHandler(object sender, System.EventArgs e)
        {
            this.IsBusy = true;
        }

        public void StationSearchCompletedHandler(object sender, SearchStationCompletedEventArgs args)
        {
            this.Stations.Clear();

            foreach (Station station in args.StationsResult)
            {
                this.Stations.Add(station.Name);
            }

            this.IsBusy = false;
        }

        private void InitializeSearchStationCommand(ITransportService transportService)
        {
            var searchStationCommand = new SearchStationAsyncCommand(transportService);
            
            searchStationCommand.StationSearchCompleted += this.StationSearchCompletedHandler;
            searchStationCommand.BeginStationSearch += this.BeginStationSearchHandler;

            this.SearchStationCommand = searchStationCommand;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}