// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuyTravelCardModel.cs" company="bbv Software Services AG">
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

namespace MySbbInfo.Modules.TravelCardModule.Content
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using MySbbInfo.Modules.TravelCardModule.Annotations;

    public class BuyTravelCardModel : INotifyPropertyChanged
    {
        private string travelCardOption;

        private string travelCardPrice;

        private string paymentOption;

        private string userPersonalData;

        private string creditCardData;

        public event PropertyChangedEventHandler PropertyChanged = (sender, args) => { };

        public string TravelCardOption
        {
            get
            {
                return this.travelCardOption;
            }

            set
            {
                this.travelCardOption = value;
                this.OnPropertyChanged();
            }
        }

        public string TravelCardPrice
        {
            get
            {
                return this.travelCardPrice;
            }

            set
            {
                this.travelCardPrice = value;
                this.OnPropertyChanged();
            }
        }

        public string PaymentOption
        {
            get
            {
                return this.paymentOption;
            }

            set
            {
                this.paymentOption = value;
                this.OnPropertyChanged();
            }
        }

        public string UserPersonalData
        {
            get
            {
                return this.userPersonalData;
            }

            set
            {
                this.userPersonalData = value;
                this.OnPropertyChanged();
            }
        }

        public string CreditCardData
        {
            get
            {
                return this.creditCardData;
            }

            set
            {
                this.creditCardData = value;
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