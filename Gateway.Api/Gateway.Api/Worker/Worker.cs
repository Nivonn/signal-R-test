


using Gateway.Api.Hubs;
using Gateway.Model.Dtos;
using Microsoft.AspNetCore.SignalR;


namespace Gateway.Api.Consumers
{
    public class Worker : IDisposable, IWorker
    {
        private readonly IHubContext<ParamHub, IParamHubContext> _hubContext;

        private Timer _timer;

        private Random random;
        public Worker(IHubContext<ParamHub, IParamHubContext> hubContext)
        {
            _hubContext = hubContext;
           

            this.random = new Random();

            this._timer = new Timer(DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        }

        private void DoWork(object state)
        {
            List<ParameterDto> resList = new List<ParameterDto>();

            resList.Add(new ParameterDto() { PacketId = 1, ParameterId = "A000", ParameterTime = DateTime.UtcNow, ParameterValue = this.random.Next(-20, 20) });

            _hubContext.Clients.All.UpdateParam(resList);
        }


        public void Dispose() { _timer.Dispose(); }
    }
}
