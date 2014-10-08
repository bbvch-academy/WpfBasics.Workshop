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
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.Modules.SearchStationModule
{
    using System.ComponentModel.Composition;

    using Microsoft.Practices.Prism.MefExtensions.Modularity;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;

    using MySbbInfo.Infrastructure;
    using MySbbInfo.Modules.SearchStationModule.Content;
    using MySbbInfo.Modules.SearchStationModule.Navigation;

    [ModuleExport(typeof(SearchStationModule))]
    public class SearchStationModule : IModule
    {
        private readonly IRegionManager regionManager;

        [ImportingConstructor]
        public SearchStationModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion(Regions.NavigationRegion, typeof(DisplayContentView));
            this.regionManager.RegisterViewWithRegion(Regions.ContentRegion, typeof(SearchStationView));
        }
    }
}