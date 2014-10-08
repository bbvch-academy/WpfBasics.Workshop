// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Connection.cs" company="bbv Software Services AG">
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
//   Defines the Connection type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace SbbApi.ApiClasses
{
    using System;

    public class Connection
    {
        public StopDeparture From { get; set; }
        public StopArrival To { get; set; }
        public TimeSpan? Duration { get; set; }
        public int? Transfers { get; set; }
        public Service Service { get; set; }
        public string[] Products { get; set; }
        public int? Capacity1st { get; set; }
        public int? Capacity2nd { get; set; }
        public Section[] Sections { get; set; }
    }
}