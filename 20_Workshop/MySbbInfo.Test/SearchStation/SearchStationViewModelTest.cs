// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchStationViewModelTest.cs" company="bbv Software Services AG">
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
//   Defines the SearchStationViewModelTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.SearchStation
{
    using FakeItEasy;

    using FluentAssertions;

    using NUnit.Framework;

    using SbbApi;
    using SbbApi.ApiClasses;

    [TestFixture]
    public class SearchStationViewModelTest
    {
        private SearchStationViewModel testee;

        private ITransportService transportService;

        [SetUp]
        public void SetUp()
        {
            this.transportService = A.Fake<ITransportService>();

            this.testee = new SearchStationViewModel(this.transportService);
        }

        [Test]
        public void ShouldInitializeSearchStationCommand()
        {
            this.testee.SearchStationCommand.Should().NotBeNull();
        }

        [Test]
        public void ShouldInitializeStations()
        {
            this.testee.Stations.Should().NotBeNull();
        }

        [TestCase(true)]
        [TestCase(false)]
        public void ShouldRaisePropertyChangForIsBusy(bool newValue)
        {
            this.testee.MonitorEvents();

            this.testee.IsBusy = newValue;

            this.testee.ShouldRaisePropertyChangeFor(x => x.IsBusy);
        }

        [Test]
        public void ShouldRaiseCollectionChangedForStations()
        {
            this.testee.Stations.MonitorEvents();

            this.testee.Stations.Add(new Station { Name = "some station" });

            this.testee.Stations.ShouldRaise("CollectionChanged");
        }
    }
}