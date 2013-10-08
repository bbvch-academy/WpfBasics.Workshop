// --------------------------------------------------------------------------------------------------------------------
// <copyright file="VerifySelectedTravelCardViewModel.cs" company="bbv Software Services AG">
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

namespace MySbbInfo.Modules.TravelCardModule.Content.VerifySelectedTravelCard
{
    using System.ComponentModel.Composition;

    using Microsoft.Practices.Prism.Regions;

    [Export]
    public class VerifySelectedTravelCardViewModel : INavigationAware
    {
        public VerifySelectedTravelCardViewModel()
        {
            this.SelectedOption = new VerifySelectedTravelCardModel();
        }

        public VerifySelectedTravelCardModel SelectedOption { get; set; }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            string selectedOption = navigationContext.Parameters[NavigationParameter.SelectedTravelCardOption];
            if (!string.IsNullOrEmpty(selectedOption))
            {
                this.SelectedOption.SelectedOption = selectedOption;
            }

            string optionDescription = navigationContext.Parameters[NavigationParameter.TravelCardDescription];
            if (!string.IsNullOrEmpty(optionDescription))
            {
                this.SelectedOption.OptionDescription = optionDescription;
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}