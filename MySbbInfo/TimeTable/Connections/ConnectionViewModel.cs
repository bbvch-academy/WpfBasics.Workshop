// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConnectionViewModel.cs" company="bbv Software Services AG">
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
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.TimeTable.Connections
{
    using Caliburn.Micro;

    public class ConnectionViewModel : Screen, IConnectionViewModel
    {
        private bool isSelected;

        private ConnectionModel connection;

        public bool IsSelected
        {
            get
            {
                return this.isSelected;
            }

            set
            {
                if (value != this.isSelected)
                {
                    this.isSelected = value;
                    this.NotifyOfPropertyChange();
                }
            }
        }

        // TODO: create a property for the connection information of type SbbApi.ApiClasses.Connection.

        public ConnectionModel Connection
        {
            get
            {
                return this.connection;
            }

            set
            {
                this.connection = value;
                this.NotifyOfPropertyChange();
            }
        }

        public void SelectConnection()
        {
            var parent = (IConnectionsViewModel)Parent;

            // TODO: inform the parent that this is now the selected view.
        }
    }
}
