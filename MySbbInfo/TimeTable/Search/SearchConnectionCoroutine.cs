using System;
using System.ComponentModel;
using System.Collections.Generic;

using Caliburn.Micro;

using SbbApi;
using SbbApi.ApiClasses;

namespace MySbbInfo.TimeTable.Search
{
    public class SearchConnectionCoroutine : IResult
    {
        private ITransportService transportService;

        private TimeTableSearchModel timeTableSearchParameter;

        public event EventHandler<ResultCompletionEventArgs> Completed;

        public event SearchConnectionCompletedEventHandler SearchConnectionCompleted = (sender, args) => { };

        public SearchConnectionCoroutine(ITransportService transportService, TimeTableSearchModel timeTableSearchParameter)
        {
            this.transportService = transportService;
            this.timeTableSearchParameter = timeTableSearchParameter;
        }

        public void Execute(CoroutineExecutionContext context)
        {
            var worker = new BackgroundWorker();
            worker.RunWorkerCompleted += (o, ea) =>
            {
                this.SearchConnectionCompleted(this, new SearchConnectionCompletedEventArgs((IEnumerable<Connection>)ea.Result));
                this.Completed(this, new ResultCompletionEventArgs());
            };

            worker.DoWork += (o, ea) => this.RunSearch(ea);

            TimeTableSearchModel searchParameter = this.timeTableSearchParameter;

            worker.RunWorkerAsync(
                new BackgroundWorkerArgs(this.transportService, searchParameter.DepartureDateTime, searchParameter.From, searchParameter.To));
        }

        public void RunSearch(DoWorkEventArgs ea)
        {
            var args = (BackgroundWorkerArgs)ea.Argument;

            ITransportService service = args.TransportService;

            IEnumerable<Connection> connections = service.GetConnections(args.From, args.To, args.StartTime);

            ea.Result = connections;
        }

        private class BackgroundWorkerArgs
        {
            public BackgroundWorkerArgs(ITransportService transportService, DateTime startTime, string from, string to)
            {
                this.TransportService = transportService;
                this.StartTime = startTime;
                this.From = @from;
                this.To = to;
            }

            public ITransportService TransportService { get; private set; }

            public DateTime StartTime { get; private set; }

            public string From { get; private set; }

            public string To { get; private set; }
        }
    }
}
