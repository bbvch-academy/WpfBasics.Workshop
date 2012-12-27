// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OfflineTransportService.cs" company="bbv Software Services AG">
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
//   Defines the OfflineTransportService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SbbApi
{
    using System;
    using System.Collections.Generic;

    using SbbApi.ApiClasses;

    public class OfflineTransportService : ITransportService
    {
        public IEnumerable<Connection> GetConnections(string @from, string to, DateTime departureTime)
        {
            return new List<Connection>
            {
                new Connection
                {
                    Capacity2nd = 1, 
                    Duration = new TimeSpan(1, 46, 0), 
                    From = new StopDeparture { Departure = new DateTime(2012, 12, 17, 18, 10, 0), Station = new Station { Name = "Littau" } }, 
                    To = new StopArrival { Arrival = new DateTime(2012, 12, 17, 19, 56, 0), Station = new Station { Name = "Bern" } },
                    Sections = new Section[0]
                },
                new Connection
                {
                    Capacity2nd = 2, 
                    Duration = new TimeSpan(1, 24, 0), 
                    From = new StopDeparture { Departure = new DateTime(2012, 12, 17, 18, 36, 0), Station = new Station { Name = "Littau" } }, 
                    To = new StopArrival { Arrival = new DateTime(2012, 12, 17, 20, 0, 0), Station = new Station { Name = "Bern" } },
                    Sections = new[]
                    {
                        new Section
                        {
                            Departure = new StopDeparture { Departure = new DateTime(2012, 12, 17, 18, 45, 0), Station = new Station { Name = "Littau" } },
                            Arrival = new StopArrival { Arrival = new DateTime(2012, 12, 17, 18, 47, 0), Station = new Station { Name = "Luzern" }, Platform = "11" },
                            Journey = new Journey { Name = "S6 21665" }
                        },
                        new Section
                        {
                            Departure = new StopDeparture { Departure = new DateTime(2012, 12, 17, 18, 47, 0), Station = new Station { Name = "Luzern" }, Platform = "8" },
                            Arrival = new StopArrival { Arrival = new DateTime(2012, 12, 17, 19, 1, 0), Station = new Station { Name = "Bern" }, Platform = "3" },
                            Journey = new Journey { Name = "IR 2538" }
                        }
                    }
                },
                new Connection
                {
                    Capacity2nd = null, 
                    Duration = new TimeSpan(1, 43, 0), 
                    From = new StopDeparture { Departure = new DateTime(2012, 12, 17, 18, 43, 0), Station = new Station { Name = "Littau, Bahnhof" } }, 
                    To = new StopArrival { Arrival = new DateTime(2012, 12, 17, 20, 26, 0), Station = new Station { Name = "Bern" } },
                    Sections = new Section[0]
                },
                new Connection
                {
                    Capacity2nd = 1, 
                    Duration = new TimeSpan(1, 40, 0), 
                    From = new StopDeparture { Departure = new DateTime(2012, 12, 17, 18, 47, 0), Station = new Station { Name = "Littau" } }, 
                    To = new StopArrival { Arrival = new DateTime(2012, 12, 17, 20, 25, 0), Station = new Station { Name = "Bern" } },
                    Sections = new[]
                    {
                        new Section
                        {
                            Departure = new StopDeparture { Departure = new DateTime(2012, 12, 17, 18, 45, 0), Station = new Station { Name = "Littau" } },
                            Arrival = new StopArrival { Arrival = new DateTime(2012, 12, 17, 18, 47, 0), Station = new Station { Name = "Littau, Bahnhof" } },
                        },
                        new Section
                        {
                            Departure = new StopDeparture { Departure = new DateTime(2012, 12, 17, 18, 47, 0), Station = new Station { Name = "Littau, Bahnhof" } },
                            Arrival = new StopArrival { Arrival = new DateTime(2012, 12, 17, 19, 1, 0), Station = new Station { Name = "Emmenbrücke, Seetalplatz" } },
                            Journey = new Journey { Name = "Bus 13" }
                        },
                        new Section
                        {
                            Departure = new StopDeparture { Departure = new DateTime(2012, 12, 17, 19, 1, 0), Station = new Station { Name = "Emmenbrücke, Seetalplatz" } },
                            Arrival = new StopArrival { Arrival = new DateTime(2012, 12, 17, 19, 8, 0), Station = new Station { Name = "Emmenbrücke" } }
                        },
                        new Section
                        {
                            Departure = new StopDeparture { Departure = new DateTime(2012, 12, 17, 19, 9, 0), Station = new Station { Name = "Emmenbrücke"}, Platform = "1" },
                            Arrival = new StopArrival { Arrival = new DateTime(2012, 12, 17, 19, 52, 0), Station = new Station { Name = "Olten" } },
                            Journey = new Journey { Name = "RE 3588" }
                        },
                        new Section
                        {
                            Departure = new StopDeparture { Departure = new DateTime(2012, 12, 17, 19, 58, 0), Station = new Station { Name = "Olten" }, Platform = "8", Delay = "2 min"},
                            Arrival = new StopArrival { Arrival = new DateTime(2012, 12, 17, 20, 25, 0), Station = new Station { Name = "Bern" } },
                            Journey = new Journey { Name = "IR 1938" },
                        }
                    }
                },
                new Connection
                {
                    Capacity2nd = 1, 
                    Duration = new TimeSpan(1, 46, 0), 
                    From = new StopDeparture { Departure = new DateTime(2012, 12, 17, 19, 10, 0), Station = new Station { Name = "Littau" } }, 
                    To = new StopArrival { Arrival = new DateTime(2012, 12, 17, 20, 56, 0), Station = new Station { Name = "Bern" } },
                    Sections = new Section[0]
                },
            };
        }

        public IEnumerable<Stationboard> GetStationBoard(string station)
        {
            return new List<Stationboard>
            {
                new Stationboard { To = "Luzern", Name = "Tro 1", Stop = new StopDeparture { Departure = new DateTime(2012, 12, 17, 16, 58, 0) } },
                new Stationboard { To = "Luzern, Würzenbach", Name = "Tro 8", Stop = new StopDeparture { Departure = new DateTime(2012, 12, 17, 16, 59, 0) } },
                new Stationboard { To = "Luzern, Hirtenhof", Name = "Tro 8", Stop = new StopDeparture { Departure = new DateTime(2012, 12, 17, 16, 59, 0) } },
                new Stationboard { To = "Genève-Aéroport", Name = "IR 2532", Stop = new StopDeparture { Departure = new DateTime(2012, 12, 17, 17, 0, 0) } },
                new Stationboard { To = "Neuenkirch, Altersheim", Name = "Bus 343", Stop = new StopDeparture { Departure = new DateTime(2012, 12, 17, 17, 0, 0) } },
                new Stationboard { To = "Udligenswil, alte Post", Name = "Bus 69", Stop = new StopDeparture { Departure = new DateTime(2012, 12, 17, 17, 0, 0) } },
                new Stationboard { To = "Luzern, Hubelmatt", Name = "Tro 4", Stop = new StopDeparture { Departure = new DateTime(2012, 12, 17, 17, 0, 0) } },
                new Stationboard { To = "Horw, Biregghof", Name = "Tro 7", Stop = new StopDeparture { Departure = new DateTime(2012, 12, 17, 17, 0, 0) } },
                new Stationboard { To = "Luzern, Bramberg", Name = "Bus 9", Stop = new StopDeparture { Departure = new DateTime(2012, 12, 17, 17, 0, 0) } },
            };
        }

        public IEnumerable<Station> GetLocations(string search)
        {
            return new List<Station>
            {
                new Station { Name = "Brügg BE"},
                new Station { Name = "Blausee BE"},
                new Station { Name = "Brügg BE, Jura"},
                new Station { Name = "Brügg BE, Pfeid"},
                new Station { Name = "Busswil BE, Bahnhof"},
                new Station { Name = "Brienz BE, Engi"},
                new Station { Name = "Brügg BE, Bahnhof"},
                new Station { Name = "Brienz BE, Gärbi"},
            };
        }
    }
}