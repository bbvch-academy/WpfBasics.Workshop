// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectTravelCardModel.cs" company="bbv Software Services AG">
//   Copyright (c) 2013
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

namespace MySbbInfo.Modules.TravelCardModule.Content.SelectTravelCard
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using MySbbInfo.Modules.TravelCardModule.Annotations;

    public class SelectTravelCardModel : INotifyPropertyChanged
    {
        private bool isTrack7Selected;

        private bool isHalfFareSelected;

        private bool isGASelected;

        public event PropertyChangedEventHandler PropertyChanged = (sender, args) => { };

        public bool IsGASelected
        {
            get
            {
                return this.isGASelected;
            }

            set
            {
                this.isGASelected = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsHalfFareSelected
        {
            get
            {
                return this.isHalfFareSelected;
            }

            set
            {
                this.isHalfFareSelected = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsTrack7Selected
        {
            get
            {
                return this.isTrack7Selected;
            }

            set
            {
                this.isTrack7Selected = value;
                this.OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}