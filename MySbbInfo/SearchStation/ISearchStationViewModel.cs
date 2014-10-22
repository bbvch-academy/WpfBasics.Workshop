﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ISearchStationViewModel.cs" company="bbv Software Services AG">
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
// <summary>
//   Defines the ISearchStationViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.SearchStation
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    using Caliburn.Micro;

    using Microsoft.Maps.MapControl.WPF;

    using SbbApi.ApiClasses;

    public interface ISearchStationViewModel : INotifyPropertyChanged
    {
        ObservableCollection<Station> Stations { get; set; }

        Location StationPosition { get; set; }

        IEnumerable<IResult> SearchStation(string stationQuery);
    }
}