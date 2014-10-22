// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Loader.cs" company="bbv Software Services AG">
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
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo
{
    using System;
    using System.Windows;

    using Caliburn.Micro;

    using Xceed.Wpf.Toolkit;

    public class Loader : PropertyChangedBase, IResult
    {
        private readonly string message;

        private readonly bool hide;

        public Loader(string message)
        {
            this.message = message;
        }

        public Loader(bool hide)
        {
            this.hide = hide;
        }

        public event EventHandler<ResultCompletionEventArgs> Completed;

        public static IResult Show(string message = null)
        {
            return new Loader(message);
        }

        public static IResult Hide()
        {
            return new Loader(true);
        }

        public void Execute(CoroutineExecutionContext context)
        {
            var view = context.View as FrameworkElement;
            while (view != null)
            {
                var busyIndicator = view as BusyIndicator;
                if (busyIndicator != null)
                {
                    if (!string.IsNullOrEmpty(this.message))
                    {
                        busyIndicator.BusyContent = this.message;
                    }

                    busyIndicator.IsBusy = !this.hide;
                    break;
                }

                view = view.Parent as FrameworkElement;
            }

            this.Completed(this, new ResultCompletionEventArgs());
        }
    }
}