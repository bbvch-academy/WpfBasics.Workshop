// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfirmationView.xaml.cs" company="bbv Software Services AG">
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
    using System.Windows.Controls;

    public partial class ConfirmationView : UserControl
    {
        public ConfirmationView()
        {
            this.InitializeComponent();
        }

        public static ConfirmationViewModel SampleData
        {
            get
            {
                return new ConfirmationViewModel
                {
                    ConfirmationData = new ConfirmationModel
                    {
                        TravelCardOption = "Halbtax",
                        TravelCardPrice = "755.- CHF",
                        CreditCardData = "XXXX XXXX XXXX 7457 : 754",
                        PaymentOption = "Visa",
                        UserPersonalData = "\n\rKristin Reyes\n\r2910 Centennial Farm Road\n\r6000 Luzern"
                    }
                };
            }
        }
    }
}
