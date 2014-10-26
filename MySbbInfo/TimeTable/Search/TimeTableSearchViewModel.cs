// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TimeTableSearchViewModel.cs" company="bbv Software Services AG">
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
//   Defines the TimeTableSearchViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.TimeTable.Search
{
    using System.Collections.Generic;
    using System.Windows.Input;

    using Caliburn.Micro;

    using SbbApi;

    public delegate void NewSearchConnectionResultEventHandler(object sender, SearchConnectionCompletedEventArgs args);

    public class TimeTableSearchViewModel : PropertyChangedBase, ITimeTableSearchViewModel
    {
        private ITransportService transportService;

        public TimeTableSearchViewModel(ITransportService transportService)
        {
            this.transportService = transportService;

            this.SearchParameter = new TimeTableSearchModel();
            this.SearchParameter.PropertyChanged += (sender, args) => this.NotifyOfPropertyChange(() => this.CanSearchStation);
        }

        public event NewSearchConnectionResultEventHandler NewSearchConnectionResult = (sender, args) => { };

        public ICommand SearchConnectionsCommand { get; set; }

        public TimeTableSearchModel SearchParameter { get; set; }

        public bool CanSearchStation
        {
            get
            {
                if (SearchParameter == null)
                {
                    return false;
                }

                return !string.IsNullOrWhiteSpace(SearchParameter.From) && !string.IsNullOrWhiteSpace(SearchParameter.To);
            }
        }

        public IEnumerable<IResult> SearchStation()
        {
            var searchConnection = new SearchConnectionCoroutine(this.transportService, this.SearchParameter);
            searchConnection.SearchConnectionCompleted += (sender, args) => this.NewSearchConnectionResult(sender, args);

            yield return Loader.Show();
            yield return searchConnection;
            yield return Loader.Hide();
        }
    }
}