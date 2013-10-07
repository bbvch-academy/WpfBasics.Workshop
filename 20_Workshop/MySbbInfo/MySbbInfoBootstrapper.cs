// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MySbbInfoBootstrapper.cs" company="bbv Software Services AG">
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
//   Defines the MainViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo
{
    using System.ComponentModel.Composition.Hosting;
    using System.Windows;

    using Microsoft.Practices.Prism.MefExtensions;

    using SearchStationModule = MySbbInfo.Modules.SearchStationModule.SearchStationModule;
    using StationTimeTableModule = MySbbInfo.Modules.StationTimeTableModule.StationTimeTableModule;
    using TimeTableModule = MySbbInfo.Modules.TimeTableModule.TimeTableModule;

    public class MySbbInfoBootstrapper : MefBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return this.Container.GetExportedValue<MainView>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (Window)this.Shell;
            Application.Current.MainWindow.Show();
        }

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();

            this.AggregateCatalog.Catalogs.Add(new TypeCatalog(new[] { typeof(MainView) }));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(SearchStationModule).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(StationTimeTableModule).Assembly));
            this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(TimeTableModule).Assembly));
        }
    }
}