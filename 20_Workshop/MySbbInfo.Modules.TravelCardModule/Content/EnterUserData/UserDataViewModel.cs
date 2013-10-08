// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserDataViewModel.cs" company="bbv Software Services AG">
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
    using System.ComponentModel.Composition;

    using Microsoft.Practices.Prism.Regions;

    [Export(typeof(IUserDataViewModel))]
    public class UserDataViewModel : IUserDataViewModel, INavigationAware
    {
        public UserDataViewModel()
        {
            this.UserData = new UserDataModel();
        }

        public UserDataModel UserData { get; set; }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            string selectedPayment = navigationContext.Parameters[NavigationParameter.SelectedPaymentOption];

            if (selectedPayment == "Bill")
            {
                this.UserData.IsCreditCardInputVisible = false;
                this.UserData.CreditCardNumber = string.Empty;
                this.UserData.CreditCardVerificationCode = string.Empty;
            }
            else
            {
                this.UserData.IsCreditCardInputVisible = true;
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            navigationContext.Parameters.Add(NavigationParameter.UserDataCity, this.UserData.City);
            navigationContext.Parameters.Add(NavigationParameter.UserDataCrediCardNr, this.UserData.CreditCardNumber);
            navigationContext.Parameters.Add(NavigationParameter.UserDataCrediCardCode, this.UserData.CreditCardVerificationCode);
            navigationContext.Parameters.Add(NavigationParameter.UserDataFirstName, this.UserData.FirstName);
            navigationContext.Parameters.Add(NavigationParameter.UserDataLastName, this.UserData.LastName);
            navigationContext.Parameters.Add(NavigationParameter.UserDataStreet, this.UserData.Street);
            navigationContext.Parameters.Add(NavigationParameter.UserDataZip, this.UserData.Zip);
        }
    }
}