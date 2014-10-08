// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeTableSearchViewModel.cs" company="bbv Software Services AG">
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
//   Defines the TimeTableSearchViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.Modules.TimeTableModule.Content.Search
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;

    using SbbApi;

    public delegate void NewSearchConnectionResultEventHandler(object sender, SearchConnectionCompletedEventArgs args);

    public class TimeTableSearchViewModel : ITimeTableSearchViewModel
    {
        private bool isBusy;

        public TimeTableSearchViewModel(ITransportService transportService)
        {
            this.SearchParameter = new TimeTableSearchModel();
            this.InitializeSearchConnectionCommand(transportService);
        }

        public event PropertyChangedEventHandler PropertyChanged = (sender, args) => { };

        public event NewSearchConnectionResultEventHandler NewSearchConnectionResult = (sender, args) => { };

        public ICommand SearchConnectionsCommand { get; set; }

        public TimeTableSearchModel SearchParameter { get; set; }

        public bool IsBusy
        {
            get
            {
                return this.isBusy;
            }

            set
            {
                this.isBusy = value;
                this.OnPropertyChanged();
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void InitializeSearchConnectionCommand(ITransportService transportService)
        {
            var searchConnectionsCommand = new SearchConnectionAsyncCommand(transportService);
            searchConnectionsCommand.BeginStationSearch += (sender, args) => this.IsBusy = true;
            searchConnectionsCommand.SearchConnectionCompleted += (sender, args) =>
            {
                this.NewSearchConnectionResult(sender, args);
                this.IsBusy = false;
            };

            this.SearchConnectionsCommand = searchConnectionsCommand;
        }
    }
}