// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BuyTravelCardViewModel.cs" company="bbv Software Services AG">
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
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.ComponentModel.Composition;

    using GalaSoft.MvvmLight.Command;

    using Microsoft.Practices.Prism.Regions;

    using MySbbInfo.Modules.TravelCardModule.Content.EnterUserData;
    using MySbbInfo.Modules.TravelCardModule.Content.OrderConfirmation;
    using MySbbInfo.Modules.TravelCardModule.Content.SelectPayment;
    using MySbbInfo.Modules.TravelCardModule.Content.SelectTravelCard;
    using MySbbInfo.Modules.TravelCardModule.Content.VerifySelectedTravelCard;
    using MySbbInfo.Modules.TravelCardModule.OrderService;

    [Export]
    public class BuyTravelCardViewModel
    {
        public static readonly string ViewNameAfterConfirmation = typeof(SelectTravelCardView).Name;

        private static readonly string StartViewName = typeof(SelectTravelCardView).Name;
        private static readonly string EndViewName = typeof(ConfirmationView).Name;

        private static readonly Dictionary<string, string> NavigationMap = new Dictionary<string, string>
                                                                           {
                                                                               { typeof(SelectTravelCardView).Name, typeof(VerifySelectedTravelCardView).Name },
                                                                               { typeof(VerifySelectedTravelCardView).Name, typeof(SelectPaymentView).Name },
                                                                               { typeof(SelectPaymentView).Name, typeof(UserDataView).Name },
                                                                               { typeof(UserDataView).Name, typeof(ConfirmationView).Name }
                                                                           };

        private readonly IRegionManager regionManager;
        private readonly IOrderService orderService;
        private readonly BuyTravelCardModel sessionData;

        private string currentView;

        [ImportingConstructor]
        public BuyTravelCardViewModel(IRegionManager regionManager, IOrderService orderService)
        {
            this.regionManager = regionManager;
            this.orderService = orderService;
            this.currentView = StartViewName;

            this.regionManager.Regions.CollectionChanged += this.RegionsCollectionChanged;

            this.NavigateToView(StartViewName);

            this.sessionData = new BuyTravelCardModel();
            this.ForwardCommand = new RelayCommand(this.Forward, this.CanGoForward);
            this.BackwardCommand = new RelayCommand(this.Backward, this.CanGoBackward);
        }

        public RelayCommand ForwardCommand { get; private set; }

        public RelayCommand BackwardCommand { get; private set; }

        private IRegionNavigationService NavigationService
        {
            get
            {
                return this.regionManager.Regions[TravelCardRegions.BuyTravelCardContentRegion].NavigationService;
            }
        }

        private void Forward()
        {
            string nextViewName = NavigationMap.ContainsKey(this.currentView) ? NavigationMap[this.currentView] : StartViewName;

            this.NavigateToView(nextViewName);
        }

        private void Backward()
        {
            if (this.NavigationService.Journal.CanGoBack)
            {
                this.NavigationService.Journal.GoBack();
                this.currentView = this.NavigationService.Journal.CurrentEntry.Uri.OriginalString;
            }
            else
            {
                this.NavigationService.Journal.Clear();
                this.NavigateToView(StartViewName);
            }
        }

        private bool CanGoForward()
        {
            return true;
        }

        private bool CanGoBackward()
        {
            return this.NavigationService.Journal.CanGoBack || this.currentView != StartViewName;
        }

        private void NavigateToView(string nextViewName)
        {
            var uri = new Uri(nextViewName, UriKind.Relative);

            bool? wasNavigated = false;
            this.regionManager.RequestNavigate(
                TravelCardRegions.BuyTravelCardContentRegion,
                uri,
                result => wasNavigated = result.Result);

            if (wasNavigated.HasValue && wasNavigated.Value)
            {
                this.currentView = nextViewName;
            }
        }

        private void RegionsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var region = e.NewItems[0] as IRegion;
            if (e.Action != NotifyCollectionChangedAction.Add && region != null && region.Name == TravelCardRegions.BuyTravelCardContentRegion)
            {
                return;
            }

            this.NavigationCommandsRaiseCanExecuteChanged();
            this.NavigationService.Navigating += this.NavigationServiceOnNavigating;
            this.NavigationService.Navigated += this.NavigationServiceOnNavigated;
        }

        private void NavigationServiceOnNavigating(object sender, RegionNavigationEventArgs regionNavigationEventArgs)
        {
            NavigationContext navigationContext = regionNavigationEventArgs.NavigationContext;

            this.UpdateSessionData(regionNavigationEventArgs.NavigationContext);

            // Navigating to EndView
            if (navigationContext.Uri.OriginalString == EndViewName)
            {
                this.PrepareSessionDataForSummary(navigationContext);
            }

            // Navigating from EndView to StartView -> Finish Order
            if (navigationContext.NavigationService.Journal.CurrentEntry != null &&
                navigationContext.NavigationService.Journal.CurrentEntry.Uri.OriginalString == EndViewName && 
                navigationContext.Uri.OriginalString == StartViewName)
            {
                this.orderService.CreateNewOrder(this.sessionData.UserPersonalData, this.sessionData.CreditCardData);
                navigationContext.NavigationService.Journal.Clear();
            }
        }

        private void NavigationServiceOnNavigated(object sender, RegionNavigationEventArgs regionNavigationEventArgs)
        {
            NavigationContext navigationContext = regionNavigationEventArgs.NavigationContext;

            this.NavigationCommandsRaiseCanExecuteChanged();
        }

        private void UpdateSessionData(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters[NavigationParameter.SelectedTravelCardOption] != null)
            {
                this.sessionData.TravelCardOption =
                    navigationContext.Parameters[NavigationParameter.SelectedTravelCardOption];
            }

            if (navigationContext.Parameters[NavigationParameter.TravelCardPrice] != null)
            {
                this.sessionData.TravelCardPrice =
                    navigationContext.Parameters[NavigationParameter.TravelCardPrice];
            }

            if (navigationContext.Parameters[NavigationParameter.SelectedPaymentOption] != null)
            {
                this.sessionData.PaymentOption =
                    navigationContext.Parameters[NavigationParameter.SelectedPaymentOption];
            }

            if (navigationContext.Parameters[NavigationParameter.UserDataFirstName] != null)
            {
                this.sessionData.UserPersonalData =
                    string.Concat(
                        navigationContext.Parameters[NavigationParameter.UserDataFirstName],
                        " ",
                        navigationContext.Parameters[NavigationParameter.UserDataLastName],
                        "\r\n",
                        navigationContext.Parameters[NavigationParameter.UserDataStreet],
                        "\r\n",
                        navigationContext.Parameters[NavigationParameter.UserDataZip],
                        " ",
                        navigationContext.Parameters[NavigationParameter.UserDataCity]);
            }

            string creditCardNr = navigationContext.Parameters[NavigationParameter.UserDataCrediCardNr];
            if (creditCardNr != null)
            {
                string displayedCreditCardNr = creditCardNr.Length > 4 ? "XXXX XXXX XXXX XXXX" + creditCardNr.Substring(creditCardNr.Length - 4) : creditCardNr;
                this.sessionData.CreditCardData = string.Concat(
                    displayedCreditCardNr,
                    "  :  ",
                    navigationContext.Parameters[NavigationParameter.UserDataCrediCardCode]);
            }
        }

        private void PrepareSessionDataForSummary(NavigationContext navigationContext)
        {
            navigationContext.Parameters.Add(NavigationParameter.SummaryCreditCardData, this.sessionData.CreditCardData);
            navigationContext.Parameters.Add(NavigationParameter.SummaryPaymentOption, this.sessionData.PaymentOption);
            navigationContext.Parameters.Add(NavigationParameter.SummaryTravelCardOption, this.sessionData.TravelCardOption);
            navigationContext.Parameters.Add(NavigationParameter.SummaryTravelCardPrice, this.sessionData.TravelCardPrice);
            navigationContext.Parameters.Add(NavigationParameter.SummaryUserPersonalData, this.sessionData.UserPersonalData);
        }

        private void NavigationCommandsRaiseCanExecuteChanged()
        {
            this.ForwardCommand.RaiseCanExecuteChanged();
            this.BackwardCommand.RaiseCanExecuteChanged();
        }
    }
}