// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MainViewModelTest.cs" company="bbv Software Services AG">
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
//   Defines the MainViewModelTest type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo
{
    using FluentAssertions;

    using NUnit.Framework;

    [TestFixture]
    public class MainViewModelTest
    {
        private MainViewModel testee;

        [SetUp]
        public void SetUp()
        {
            this.testee = new MainViewModel();
        }

        [Test]
        public void ShouldInitializeSearchStationFeature()
        {
            // this.testee.SearchStation.Should().NotBeNull();
        }

        [Test]
        public void ShouldInitializeTimeTableFeature()
        {
            // this.testee.TimeTable.Should().NotBeNull();
        }

        [Test]
        public void ShouldInitializeStationTimeTableFeature()
        {
            this.testee.StationTimeTable.Should().NotBeNull();
        }
    }
}
