// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuControl.xaml.cs" company="bbv Software Services AG">
//   Copyright (c) 2012
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
// <summary>
//   Interaction logic for MenuControl.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo
{
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;

    /// <summary>
    /// Interaction logic for MenuControl.xaml
    /// </summary>
    public partial class MenuControl : UserControl
    {
        private readonly ICommand changeUiLanguageCommand;

        public MenuControl()
        {
            this.InitializeComponent();

            this.changeUiLanguageCommand = new ChangeUiLanguageCommand();
            this.VerifyLanguageItemChecking();
        }

        private void ChangeToGermanItem_OnClick(object sender, RoutedEventArgs e)
        {
            this.changeUiLanguageCommand.Execute(ChangeUiLanguageCommand.SwissGermanLcid);
            this.VerifyLanguageItemChecking();
        }

        private void ChangeToEnglishItem_OnClick(object sender, RoutedEventArgs e)
        {
            this.changeUiLanguageCommand.Execute(ChangeUiLanguageCommand.UnitedStatesEnglishLcid);
            this.VerifyLanguageItemChecking();
        }

        private void ChangeToFrenchItem_OnClick(object sender, RoutedEventArgs e)
        {
            this.changeUiLanguageCommand.Execute(ChangeUiLanguageCommand.SwissFrenchLcid);
            this.VerifyLanguageItemChecking();
        }

        private void VerifyLanguageItemChecking()
        {
            this.ChangeToFrenchItem.IsChecked = Thread.CurrentThread.CurrentUICulture.LCID == ChangeUiLanguageCommand.SwissFrenchLcid;
            this.ChangeToGermanItem.IsChecked = Thread.CurrentThread.CurrentUICulture.LCID == ChangeUiLanguageCommand.SwissGermanLcid;
            this.ChangeToEnglishItem.IsChecked = Thread.CurrentThread.CurrentUICulture.LCID == ChangeUiLanguageCommand.UnitedStatesEnglishLcid;
        }
    }
}
