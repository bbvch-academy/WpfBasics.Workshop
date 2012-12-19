namespace SbbApi
{
    using System;
    using System.Globalization;

    using ServiceStack.ServiceHost;

    [Route("connections")]
    public class ConnectionRequest : IReturn<ConnectionResponse>
    {
        /// <summary>
        /// Gets or sets the bike.
        /// </summary>
        /// <remarks>
        /// defaults to 0, if set to 1 only trains allowing the transport of bicycles are allowed
        /// </remarks>
        /// <value>
        /// The bike.
        /// </value>
        public int? Bike { get; set; }

        /// <summary>
        /// Gets or sets the couchette.
        /// </summary>
        /// <remarks>
        /// defaults to 0, if set to 1 only night trains containing couchettes are allowed, implies direct=1
        /// </remarks>
        /// <value>
        /// The couchette.
        /// </value>
        public int? Couchette { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <remarks>
        /// Date of the connection, in the format YYYY-MM-DD 	
        /// </remarks>
        /// <value>
        /// The date.
        /// </value>
        public string Date { get; set; }

        /// <summary>
        /// Gets or sets the time.
        /// </summary>
        /// <remarks>
        /// Time of the connection, in the format hh:mm
        /// </remarks>
        /// <value>
        /// The time.
        /// </value>
        public string Time { get; set; }

        public DateTime? DateTime
        {
            get
            {
                if (string.IsNullOrEmpty(Date) || string.IsNullOrEmpty(Time))
                {
                    return null;
                }

                var dt = System.DateTime.ParseExact(Date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                var time = TimeSpan.ParseExact(Time, @"hh\:mm", CultureInfo.InvariantCulture);

                return dt.Add(time);
            }
            set
            {
                if (!value.HasValue)
                {
                    this.Date = null;
                    this.Time = null;
                    return;
                }

                this.Date = string.Format("{0:yyyy-MM-dd}", value.Value);
                this.Time = string.Format("{0:HH:mm}", value.Value);
            }
        }

        /// <summary>
        /// Gets or sets the direct.
        /// </summary>
        /// <remarks>
        /// defaults to 0, if set to 1 only direct connections are allowed
        /// </remarks>
        /// <value>
        /// The direct.
        /// </value>
        public int? Direct { get; set; }

        public string From { get; set; }

        public bool? IsArrivalTime { get; set; }

        /// <summary>
        /// Gets or sets the limit.
        /// </summary>
        /// <remarks>
        /// 1 - 6. Specifies the number of connections to return. If several connections depart at the same time they are counted as 1.
        /// </remarks>
        /// <value>
        /// The limit.
        /// </value>
        public int? Limit { get; set; }

        /// <summary>
        /// Gets or sets the page.
        /// </summary>
        /// <remarks>
        /// 0 - 10. Allows pagination of connections. Zero-based, so first page is 0, second is 1, third is 2 and so on.
        /// </remarks>
        /// <value>
        /// The page.
        /// </value>
        public int? Page { get; set; }

        /// <summary>
        /// Gets or sets the sleeper.
        /// </summary>
        /// <remarks>
        /// defaults to 0, if set to 1 only night trains containing beds are allowed, implies direct=1
        /// </remarks>
        /// <value>
        /// The sleeper.
        /// </value>
        public int? Sleeper { get; set; }

        public string To { get; set; }

        /// <summary>
        /// Gets or sets the transportations.
        /// </summary>
        /// <remarks>
        /// Transportation means; one or more of ice_tgv_rj, ec_ic, ir, re_d, ship, s_sn_r, bus, cableway, arz_ext, tramway_underground
        /// </remarks>
        /// <value>
        /// The transportations.
        /// </value>
        public string[] Transportations { get; set; }

        public string Via { get; set; }
    }
}