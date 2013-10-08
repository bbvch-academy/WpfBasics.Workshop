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
    using System.Windows.Input;

    using GalaSoft.MvvmLight.Command;

    using Microsoft.Practices.Prism.Regions;

    using MySbbInfo.Modules.TravelCardModule.Content.SelectPayment;
    using MySbbInfo.Modules.TravelCardModule.Content.SelectTravelCard;
    using MySbbInfo.Modules.TravelCardModule.Content.VerifySelectedTravelCard;

    [Export]
    public class BuyTravelCardViewModel
    {
        private static readonly string StartViewName = typeof(SelectTravelCardView).Name;
        private static readonly string EndViewName = typeof(SelectPaymentView).Name;

        private static readonly Dictionary<string, string> NavigationMap = new Dictionary<string, string>
                                                                           {
                                                                               { typeof(SelectTravelCardView).Name, typeof(VerifySelectedTravelCardView).Name },
                                                                               { typeof(VerifySelectedTravelCardView).Name, typeof(SelectPaymentView).Name }
                                                                           };

        private readonly IRegionManager regionManager;

        private string currentView;

        [ImportingConstructor]
        public BuyTravelCardViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.NavigateToView(StartViewName);

            this.regionManager.Regions.CollectionChanged += this.RegionsCollectionChanged;

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
            return this.currentView != EndViewName;
        }

        private bool CanGoBackward()
        {
            return this.NavigationService.Journal.CanGoBack || this.currentView != StartViewName;
        }

        private void NavigateToView(string nextViewName)
        {
            var uri = new Uri(nextViewName, UriKind.Relative);

            this.regionManager.RequestNavigate(TravelCardRegions.BuyTravelCardContentRegion, uri);

            this.currentView = nextViewName;
        }

        private void RegionsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            var region = e.NewItems[0] as IRegion;
            if (e.Action != NotifyCollectionChangedAction.Add && region != null && region.Name == TravelCardRegions.BuyTravelCardContentRegion)
            {
                return;
            }

            this.NavigationCommandsRaiseCanExecuteChanged();
            this.NavigationService.Navigated += (s, args) => this.NavigationCommandsRaiseCanExecuteChanged();
        }

        private void NavigationCommandsRaiseCanExecuteChanged()
        {
            this.ForwardCommand.RaiseCanExecuteChanged();
            this.BackwardCommand.RaiseCanExecuteChanged();
        }
    }
}