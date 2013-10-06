// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StationControl.xaml.cs" company="bbv Software Services AG">
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
//   Interaction logic for StationControl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.Modules.StationTimeTableModule
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Text;
    using System.Windows.Input;

    using GalaSoft.MvvmLight.Command;

    using SbbApi;
    using SbbApi.ApiClasses;

    public class StationTimeTableViewModel : IStationTimeTableViewModel
    {
        private readonly ITransportService transportService;

        private bool isBusy;

        public StationTimeTableViewModel(ITransportService transportService)
        {
            this.transportService = transportService;

            this.StationBoard = new ObservableCollection<string>();
            this.LoadStationBoardCommand = new RelayCommand<string>(this.ExecuteSearch, this.CanExecuteSearch);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand LoadStationBoardCommand { get; private set; }

        public ObservableCollection<string> StationBoard { get; set; }

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

        public bool CanExecuteSearch(string stationQuery)
        {
            return !string.IsNullOrWhiteSpace(stationQuery);
        }

        public void ExecuteSearch(string stationQuery)
        {
            this.IsBusy = true;

            var worker = new BackgroundWorker();
            worker.RunWorkerCompleted += (o, ea) => this.SearchCompleted((IEnumerable<Stationboard>)ea.Result);
            worker.DoWork += (o, ea) => this.RunSearch(ea);

            worker.RunWorkerAsync(new BackgroundWorkerArgs(this.transportService, stationQuery));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void RunSearch(DoWorkEventArgs ea)
        {
            var args = (BackgroundWorkerArgs)ea.Argument;

            ITransportService service = args.TransportService;

            IEnumerable<Stationboard> stationboard = service.GetStationBoard(args.Station);

            ea.Result = stationboard;
        }

        private void SearchCompleted(IEnumerable<Stationboard> stationboard)
        {
            foreach (var stop in stationboard)
            {
                var stationboardOutputBuilder = new StringBuilder();

                var part = string.Format("Ziel: {0}, Abfahrt: {1}, mittels: {2}", stop.To, stop.Stop.Departure, stop.Name);
                stationboardOutputBuilder.Append(part);

                if (!string.IsNullOrEmpty(stop.Stop.Delay))
                {
                    part = string.Format(", Verspätung: {0}", stop.Stop.Delay);
                    stationboardOutputBuilder.Append(part);
                }

                this.StationBoard.Add(stationboardOutputBuilder.ToString());
            }

            this.IsBusy = false;
        }

        private class BackgroundWorkerArgs
        {
            public BackgroundWorkerArgs(ITransportService transportService, string station)
            {
                this.TransportService = transportService;
                this.Station = station;
            }

            public ITransportService TransportService { get; private set; }

            public string Station { get; private set; }
        }
    }
}