namespace MySbbInfo
{
    using System.Text;
    using System.Windows;

    using SbbApi;

    using System.Linq;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly TransportApi transportApi;

        public MainWindow()
        {
            InitializeComponent();
            this.transportApi = new TransportApi();
        }

        private void SearchConnectionsClick(object sender, System.Windows.RoutedEventArgs e)
        {
            var connections = this.transportApi.GetConnections(this.txtFrom.Text, this.txtTo.Text);

            foreach (var connection in connections)
            {
                var from = connection.Sections.First();
                var to = connection.Sections.Last();

                var formatted = string.Format(
                    "Abfahrt: {0:HH:mm} Gleis: {1}, Ankunft: {2:HH:mm} auf: Gleis {3}, Dauer: {4:d'.'hh':'mm':'ss}",
                    from.Departure.Departure,
                    from.Departure.Platform,
                    to.Arrival.Arrival,
                    to.Arrival.Platform,
                    connection.Duration);

                this.resultList.Items.Add(formatted);
            }
        }

        private void LoadStationboardClick(object sender, RoutedEventArgs e)
        {
            var strb = new StringBuilder();

            var stationboard = this.transportApi.GetStationBoard(this.txtStation.Text);
            foreach (var stop in stationboard)
            {
                var part1 = string.Format("Ziel: {0}, Abfahrt: {1}, mittels: {2}", stop.To, stop.Stop.Departure, stop.Name);
                strb.Append(part1);

                if (!string.IsNullOrEmpty(stop.Stop.Delay))
                {
                    var part2 = string.Format(", Verspätung: {0}", stop.Stop.Delay);
                    strb.Append(part2);
                }

                this.stationBoardResult.Items.Add(strb.ToString());
                strb.Clear();
            }
        }
    }
}
