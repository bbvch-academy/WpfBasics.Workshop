// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TravelCardModule.cs" company="bbv Software Services AG">
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

namespace MySbbInfo.Modules.TravelCardModule
{
    using System.ComponentModel.Composition;

    using Microsoft.Practices.Prism.MefExtensions.Modularity;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;

    using MySbbInfo.Infrastructure;
    using MySbbInfo.Modules.TravelCardModule.Content;
    using MySbbInfo.Modules.TravelCardModule.Content.SelectPayment;
    using MySbbInfo.Modules.TravelCardModule.Content.SelectTravelCard;
    using MySbbInfo.Modules.TravelCardModule.Content.VerifySelectedTravelCard;
    using MySbbInfo.Modules.TravelCardModule.Navigation;

    [ModuleExport(typeof(TravelCardModule))]
    public class TravelCardModule : IModule
    {
        private readonly IRegionManager regionManager;

        [ImportingConstructor]
        public TravelCardModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion(Regions.NavigationRegion, typeof(DisplayContentView));
            this.regionManager.RegisterViewWithRegion(Regions.ContentRegion, typeof(BuyTravelCardView));

            this.regionManager.RegisterViewWithRegion(
                TravelCardRegions.BuyTravelCardContentRegion,
                typeof(SelectTravelCardView));

            this.regionManager.RegisterViewWithRegion(
                TravelCardRegions.BuyTravelCardContentRegion,
                typeof(VerifySelectedTravelCardView));

            this.regionManager.RegisterViewWithRegion(
                TravelCardRegions.BuyTravelCardContentRegion,
                typeof(SelectPaymentView));
        }
    }
}