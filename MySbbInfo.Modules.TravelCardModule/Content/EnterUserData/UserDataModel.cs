// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserDataModel.cs" company="bbv Software Services AG">
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

namespace MySbbInfo.Modules.TravelCardModule.Content.EnterUserData
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using MySbbInfo.Modules.TravelCardModule.Annotations;

    public class UserDataModel : INotifyPropertyChanged
    {
        private bool isCreditCardInputVisible;
        private string creditCardNumber;
        private string creditCardVerificationCode;
        private string city;
        private string zip;
        private string street;
        private string lastName;
        private string firstName;

        public event PropertyChangedEventHandler PropertyChanged = (sender, args) => { };

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            set
            {
                this.firstName = value;
                this.OnPropertyChanged();
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            set
            {
                this.lastName = value;
                this.OnPropertyChanged();
            }
        }

        public string Street
        {
            get
            {
                return this.street;
            }

            set
            {
                this.street = value;
                this.OnPropertyChanged();
            }
        }

        public string Zip
        {
            get
            {
                return this.zip;
            }

            set
            {
                this.zip = value;
                this.OnPropertyChanged();
            }
        }

        public string City
        {
            get
            {
                return this.city;
            }

            set
            {
                this.city = value;
                this.OnPropertyChanged();
            }
        }

        public bool IsCreditCardInputVisible
        {
            get
            {
                return this.isCreditCardInputVisible;
            }

            set
            {
                this.isCreditCardInputVisible = value;
                this.OnPropertyChanged();
            }
        }

        public string CreditCardNumber
        {
            get
            {
               return this.creditCardNumber;
            }

            set
            {
                this.creditCardNumber = value;
                this.OnPropertyChanged();
            }
        }

        public string CreditCardVerificationCode
        {
            get
            {
                return this.creditCardVerificationCode;
            }

            set
            {
                this.creditCardVerificationCode = value;
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