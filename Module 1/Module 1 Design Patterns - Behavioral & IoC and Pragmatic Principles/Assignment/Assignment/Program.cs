using Autofac;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using IContainer = Autofac.IContainer;

namespace Assignment
{
    public class Ping : IRequest<string> { }
    public class Pong : IRequestHandler<Ping, string>
    {
        public Task<string> Handle(Ping request, CancellationToken cancellationToken)
        {
            return Task.FromResult("Request handled");
        }
    }

    public class Pinger
    {
        private readonly IMediator _mediator;
        private readonly IPingerService _pingerService;

        public Pinger(IPingerService pingerService, IMediator mediator)
        {
            _mediator = mediator;
            _pingerService = pingerService;
        }
        public string SendPing()
        {
            if (_pingerService.CheckPingerStatus())
            {
                return _mediator.Send(new Ping()).Result;
            }
            else
            {
                return "Pinger service is down!";
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ServiceLocator serviceLocator = new ServiceLocator();

            var mediator = serviceLocator.BuildMediator();
            IPingerService pingerService = new PingerService(true);

            Pinger pinger = new Pinger(pingerService, mediator);

            Console.WriteLine(pinger.SendPing());
        }
    }
}
