// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SearchStationAsyncCommandTest.cs" company="bbv Software Services AG">
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
//   Defines the SearchStationAsyncCommandTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.SearchStation
{
    using System.ComponentModel;

    using FakeItEasy;

    using FluentAssertions;

    using NUnit.Framework;

    using SbbApi;
    using SbbApi.ApiClasses;

    [TestFixture]
    public class SearchStationAsyncCommandTest
    {
        /*
        private SearchStationAsyncCommand testee;

        private ITransportService transportService;

        [SetUp]
        public void SetUp()
        {
            this.transportService = A.Fake<ITransportService>();

            this.testee = new SearchStationAsyncCommand(this.transportService);
        }

        [TestCase(null, false)]
        [TestCase(2, false)]
        [TestCase("", false)]
        [TestCase("Luzern", true)]
        public void ShouldImplementCanExecuteCorrectly(object value, bool expectedResult)
        {
            this.testee.CanExecute(value).Should().Be(expectedResult);
        }

        [Test]
        public void ShouldIndicateBeginOfExecution()
        {
            this.testee.MonitorEvents();

            this.testee.Execute("Luzern");

            this.testee.ShouldRaise("BeginStationSearch");
        }

        [Test]
        public void ShouldSearchStationOnExecution()
        {
            const string StationName = "some station";
            var resultingStations = new[] { new Station() };

            A.CallTo(() => this.transportService.GetLocations(StationName)).Returns(resultingStations);

            var doWorkEventArgs = new DoWorkEventArgs(new SearchStationAsyncCommand.BackgroundWorkerArgs(this.transportService, StationName));

            this.testee.Execute(doWorkEventArgs);

            doWorkEventArgs.Result.Should().Be(resultingStations);
        }*/
    }
}