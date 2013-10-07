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

namespace MySbbInfo.Modules.StationTimeTableModule
{
    using System.ComponentModel.Composition;

    using Microsoft.Practices.Prism.MefExtensions.Modularity;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;

    using MySbbInfo.Modules.StationTimeTableModule.Content;
    using MySbbInfo.Modules.StationTimeTableModule.Navigation;

    [ModuleExport(typeof(StationTimeTableModule))]
    public class StationTimeTableModule : IModule
    {
        [Import]
        public IRegionManager RegionManager;

        public void Initialize()
        {
            this.RegionManager.RegisterViewWithRegion("NavigationRegion", typeof(DisplayContentView));
            this.RegionManager.RegisterViewWithRegion("ContentRegion", typeof(StationTimeTableView));
        }
    }
}