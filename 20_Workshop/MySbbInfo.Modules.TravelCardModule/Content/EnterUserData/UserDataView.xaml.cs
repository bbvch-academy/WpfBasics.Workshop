// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserDataView.xaml.cs" company="bbv Software Services AG">
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
    using System.Windows.Controls;

    [Export]
    public partial class UserDataView : UserControl
    {
        public UserDataView()
        {
            this.InitializeComponent();
        }

        public static IUserDataViewModel SampleData
        {
            get
            {
                return new UserDataViewModel
                {
                    UserData = new UserDataModel
                    {
                        City = "Zug",
                        CreditCardNumber = "4532 6026 2718 6366",
                        CreditCardVerificationCode = "531",
                        FirstName = "Clifton",
                        IsCreditCardInputVisible = true,
                        LastName = "Torres",
                        Street = "848 Felosa Drive",
                        Zip = "79535"
                    }
                };
            }
        }

        [Import]
        public IUserDataViewModel ViewModel
        {
            set
            {
                this.DataContext = value;
            }
        }
    }
}
