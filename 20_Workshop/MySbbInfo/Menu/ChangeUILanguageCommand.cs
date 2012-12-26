// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ChangeUILanguageCommand.cs" company="bbv Software Services AG">
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
//   Defines the ChangeUiLanguageCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.Menu
{
    using System;
    using System.Globalization;
    using System.Threading;
    using System.Windows.Input;

    using WPFLocalizeExtension.Engine;

    public class ChangeUiLanguageCommand : ICommand
    {
        public const int SwissGermanLcid = 2055;
        public const int UnitedStatesEnglishLcid = 1033;
        public const int SwissFrenchLcid = 4108;

        public event EventHandler CanExecuteChanged;

        public event EventHandler UiLanguageChanged = (s, obj) => { };

        private readonly int lcid;

        public ChangeUiLanguageCommand(int lcid)
        {
            this.lcid = lcid;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var culture = new CultureInfo(this.lcid);

            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            LocalizeDictionary.Instance.Culture = culture;

            this.UiLanguageChanged(this, new EventArgs());
        }
    }
}