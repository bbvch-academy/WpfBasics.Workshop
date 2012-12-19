namespace MySbbInfo
{
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
    }
}
