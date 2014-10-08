// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SectionsModel.cs" company="bbv Software Services AG">
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
//   Defines the SectionsModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MySbbInfo.TimeTable.Connections.Sections
{
    using System;

    public class SectionsModel
    {
        public SectionsModel(
            string departingStationName,
            string departingPlatform,
            DateTime? departureDateTime,
            string arrivingStationName,
            string arrivingPlatform,
            DateTime? arrivalDateTime,
            string transportMedium,
            string delayAtDeparture,
            string delayAtArrival)
        {
            this.DepartingStationName = departingStationName;
            this.DepartingPlatform = departingPlatform;
            this.DepartureDateTime = departureDateTime;
            this.ArrivingStationName = arrivingStationName;
            this.ArrivingPlatform = arrivingPlatform;
            this.ArrivalDateTime = arrivalDateTime;
            this.TransportMedium = transportMedium;
            this.DelayAtDeparture = delayAtDeparture;
            this.DelayAtArrival = delayAtArrival;
        }

        public string DepartingStationName { get; private set; }

        public string DepartingPlatform { get; set; }

        public DateTime? DepartureDateTime { get; private set; }

        public string ArrivingStationName { get; private set; }

        public string ArrivingPlatform { get; set; }

        public DateTime? ArrivalDateTime { get; private set; }

        public string TransportMedium { get; private set; }

        public string DelayAtDeparture { get; set; }

        public string DelayAtArrival { get; set; }

        public bool IsBusVisible
        {
            get
            {
                return this.TransportMedium.StartsWith("bus", StringComparison.OrdinalIgnoreCase);
            }
        }

        public bool IsPedestrianVisible
        {
            get
            {
                return string.IsNullOrWhiteSpace(this.TransportMedium);
            }
        }

        public bool IsTrainVisible
        {
            get
            {
                return this.TransportMedium.StartsWith("i", StringComparison.OrdinalIgnoreCase)
                       || this.TransportMedium.StartsWith("s", StringComparison.OrdinalIgnoreCase)
                       || this.TransportMedium.StartsWith("r", StringComparison.OrdinalIgnoreCase);
            }
        }

        public bool IsTramVisible
        {
            get
            {
                return this.TransportMedium.StartsWith("tram", StringComparison.OrdinalIgnoreCase);
            }
        }
    }
}