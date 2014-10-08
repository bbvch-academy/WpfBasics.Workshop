// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StationTimeTableViewModelTest.cs" company="bbv Software Services AG">
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
//   Defines the StationTimeTableViewModelTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.StationTimeTable
{
    using FakeItEasy;

    using FluentAssertions;

    using NUnit.Framework;

    using SbbApi;

    [TestFixture]
    public class StationTimeTableViewModelTest
    {
        private StationTimeTableViewModel testee;

        private ITransportService transportService;

        [SetUp]
        public void SetUp()
        {
            this.transportService = A.Fake<ITransportService>();

            this.testee = new StationTimeTableViewModel(this.transportService);
        }

        [TestCase("", false)]
        [TestCase("  ", false)]
        [TestCase("Luzern", true)]
        public void ShouldImplementCanExecuteCorrectly(string value, bool expectedResult)
        {
            this.testee.CanExecuteSearch(value).Should().Be(expectedResult);
        }

        [Test]
        public void ShouldIndicateBeginOfExecution()
        {
            this.testee.ExecuteSearch("some station");

            this.testee.IsBusy.Should().BeTrue();
        }
    }
}