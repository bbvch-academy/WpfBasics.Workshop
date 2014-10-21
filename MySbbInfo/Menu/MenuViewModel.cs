// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuViewModel.cs" company="bbv Software Services AG">
//   Copyright (c) 2012 - 2014
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
//   Defines the OccupancyToImageSourceConverter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.Menu
{
    using System.Threading;
    using System.Windows.Input;

    using Caliburn.Micro;

    public class MenuViewModel : PropertyChangedBase
    {
        public MenuViewModel()
        {
            this.InitializeChangeToGermanCommand();
            this.InitializeChangeToFrenchCommand();
            this.InitializeChangeToEnglishCommand();
        }

        public ICommand ChangeToGermanCommand { get; private set; }
        
        public ICommand ChangeToFrenchCommand { get; private set; }

        public ICommand ChangeToEnglishCommand { get; private set; }

        public bool IsGermanSelected
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture.LCID == ChangeUiLanguageCommand.SwissGermanLcid;
            }
        }

        public bool IsFrenchSelected
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture.LCID == ChangeUiLanguageCommand.SwissFrenchLcid;
            }
        }

        public bool IsEnglishSelected
        {
            get
            {
                return Thread.CurrentThread.CurrentUICulture.LCID == ChangeUiLanguageCommand.UnitedStatesEnglishLcid;
            }
        }

        private void InitializeChangeToGermanCommand()
        {
            var changeUiLanguageCommand = new ChangeUiLanguageCommand(ChangeUiLanguageCommand.SwissGermanLcid);
            changeUiLanguageCommand.UiLanguageChanged += this.UiLanguageChanged;
            this.ChangeToGermanCommand = changeUiLanguageCommand;
        }

        private void InitializeChangeToFrenchCommand()
        {
            var changeUiLanguageCommand = new ChangeUiLanguageCommand(ChangeUiLanguageCommand.SwissFrenchLcid);
            changeUiLanguageCommand.UiLanguageChanged += this.UiLanguageChanged;
            this.ChangeToFrenchCommand = changeUiLanguageCommand;
        }

        private void InitializeChangeToEnglishCommand()
        {
            var changeUiLanguageCommand = new ChangeUiLanguageCommand(ChangeUiLanguageCommand.UnitedStatesEnglishLcid);
            changeUiLanguageCommand.UiLanguageChanged += this.UiLanguageChanged;
            this.ChangeToEnglishCommand = changeUiLanguageCommand;
        }

        private void UiLanguageChanged(object sender, System.EventArgs e)
        {
            this.NotifyOfPropertyChange(() => this.IsGermanSelected);
            this.NotifyOfPropertyChange(() => this.IsFrenchSelected);
            this.NotifyOfPropertyChange(() => this.IsEnglishSelected);
        }
    }
}