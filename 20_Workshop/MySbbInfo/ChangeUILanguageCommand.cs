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

namespace MySbbInfo
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

        public event EventHandler CanExecuteChanged = delegate { };

        public bool CanExecute(object parameter)
        {
            if (parameter is int)
            {
                var lcid = (int)parameter;
                return lcid == SwissGermanLcid || lcid == UnitedStatesEnglishLcid || lcid == SwissFrenchLcid;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            if (!this.CanExecute(parameter))
            {
                return;
            }

            var lcid = (int)parameter;
            var swissGermanCulture = new CultureInfo(lcid);

            Thread.CurrentThread.CurrentCulture = swissGermanCulture;
            Thread.CurrentThread.CurrentUICulture = swissGermanCulture;

            LocalizeDictionary.Instance.Culture = swissGermanCulture;
        }
    }
}