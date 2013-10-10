// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectTravelCardViewModule.cs" company="bbv Software Services AG">
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
    using System.Collections.Generic;

    using MySbbInfo.Modules.TravelCardModule.Properties;

    public class SelectTravelCardViewModel
    {
        private const string GeneralAboOption = "GA";
        private const string HalfFareOption = "Halbtax";
        private const string Track7Option = "Gleis 7";

        private const int GeneralAboPrice = 3550;
        private const int HalfFarePrice = 175;
        private const int Track7Price = 129;

        private static readonly Dictionary<string, string> TravelCardDescriptions = new Dictionary<string, string>
                                                                                    {
                                                                                        { string.Empty, string.Empty },
                                                                                        { GeneralAboOption, Translation.GAOptionDescription },
                                                                                        { HalfFareOption, Translation.HalfPriceOptionDescription },
                                                                                        { Track7Option, Translation.Track7OptionDescription }
                                                                                    };

        private static readonly Dictionary<string, int> TravelCardPrices = new Dictionary<string, int>
                                                                                    {
                                                                                        { string.Empty, 0 },
                                                                                        { GeneralAboOption, GeneralAboPrice },
                                                                                        { HalfFareOption, HalfFarePrice },
                                                                                        { Track7Option, Track7Price }
                                                                                    };

        public SelectTravelCardViewModel()
        {
            this.SelectedOption = new SelectTravelCardModel { IsGASelected = true };
        }

        public SelectTravelCardModel SelectedOption { get; set; }
        
        private string GetSelectedOption()
        {
            if (this.SelectedOption.IsGASelected)
            {
                return GeneralAboOption;
            }

            if (this.SelectedOption.IsHalfFareSelected)
            {
                return HalfFareOption;
            }

            if (this.SelectedOption.IsTrack7Selected)
            {
                return Track7Option;
            }

            return string.Empty;
        }
    }
}