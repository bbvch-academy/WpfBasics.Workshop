// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SelectPaymentViewModel.cs" company="bbv Software Services AG">
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

namespace MySbbInfo.Modules.TravelCardModule.Content.SelectPayment
{
    public class SelectPaymentViewModel
    {
        private const string VisaOption = "Visa";
        private const string MasterCardOption = "MasterCard";
        private const string BillOption = "Bill";

        public SelectPaymentViewModel()
        {
            this.SelectedPayment = new SelectPaymentModel { IsVisaSelected = true };
        }

        public SelectPaymentModel SelectedPayment { get; set; }
        
        private string GetSelectedOption()
        {
            if (this.SelectedPayment.IsVisaSelected)
            {
                return VisaOption;
            }

            if (this.SelectedPayment.IsMasterCardSelected)
            {
                return MasterCardOption;
            }

            if (this.SelectedPayment.IsBillSelected)
            {
                return BillOption;
            }

            return string.Empty;
        }
    }
}