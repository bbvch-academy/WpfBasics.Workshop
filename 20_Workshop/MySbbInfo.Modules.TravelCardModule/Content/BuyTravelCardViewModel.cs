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
    using System.ComponentModel.Composition;

    using GalaSoft.MvvmLight.Command;

    using Microsoft.Practices.Prism.Regions;

    using MySbbInfo.Modules.TravelCardModule.Content.OrderConfirmation;
    using MySbbInfo.Modules.TravelCardModule.Content.SelectTravelCard;
    using MySbbInfo.Modules.TravelCardModule.OrderService;

    [Export]
    public class BuyTravelCardViewModel
    {
        private static readonly string StartViewName = typeof(SelectTravelCardView).Name;
        private static readonly string EndViewName = typeof(ConfirmationView).Name;

        private readonly IRegionManager regionManager;
        private readonly IOrderService orderService;
        private readonly BuyTravelCardModel sessionData;

        private string currentView;

        public BuyTravelCardViewModel(IOrderService orderService)
        {
            this.orderService = orderService;
            this.currentView = StartViewName;

            this.sessionData = new BuyTravelCardModel();
            this.ForwardCommand = new RelayCommand(this.Forward, this.CanGoForward);
            this.BackwardCommand = new RelayCommand(this.Backward, this.CanGoBackward);
        }

        public RelayCommand ForwardCommand { get; private set; }

        public RelayCommand BackwardCommand { get; private set; }

        private void Forward()
        {
        }

        private void Backward()
        {
        }

        private bool CanGoForward()
        {
            return true;
        }

        private bool CanGoBackward()
        {
            return false;
        }
    }
}