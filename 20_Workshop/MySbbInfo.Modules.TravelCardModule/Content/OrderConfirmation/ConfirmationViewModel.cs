// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfirmationViewModel.cs" company="bbv Software Services AG">
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

namespace MySbbInfo.Modules.TravelCardModule.Content.OrderConfirmation
{
    using System;
    using System.ComponentModel.Composition;
    using System.Windows;

    using Microsoft.Practices.Prism.Regions;

    [Export]
    public class ConfirmationViewModel : IConfirmNavigationRequest
    {
        public ConfirmationViewModel()
        {
            this.ConfirmationData = new ConfirmationModel();
        }

        public ConfirmationModel ConfirmationData { get; set; }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.ConfirmationData.TravelCardOption = navigationContext.Parameters[NavigationParameter.SummaryTravelCardOption];
            this.ConfirmationData.TravelCardPrice = navigationContext.Parameters[NavigationParameter.SummaryTravelCardPrice] + ".- CHF";
            this.ConfirmationData.CreditCardData = navigationContext.Parameters[NavigationParameter.SummaryCreditCardData];
            this.ConfirmationData.PaymentOption = navigationContext.Parameters[NavigationParameter.SummaryPaymentOption];
            this.ConfirmationData.UserPersonalData = navigationContext.Parameters[NavigationParameter.SummaryUserPersonalData];
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            if (navigationContext.Uri.OriginalString != BuyTravelCardViewModel.ViewNameAfterConfirmation)
            {
                continuationCallback(true);
                return;
            }

            MessageBoxResult result = MessageBox.Show(
                "Your data will be send to the Credit Card Service. Continue?",
                "Finish Order",
                MessageBoxButton.YesNo,
                MessageBoxImage.Information);

            continuationCallback(result == MessageBoxResult.Yes);
        }
    }
}