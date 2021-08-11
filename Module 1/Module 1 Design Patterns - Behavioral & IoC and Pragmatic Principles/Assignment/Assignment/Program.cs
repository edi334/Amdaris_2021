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

        public Pinger(IMediator mediator)
        {
            _mediator = mediator;
        }

        public string SendPing()
        {
            return _mediator.Send(new Ping()).Result;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ServiceLocator serviceLocator = new ServiceLocator();

            var mediator = serviceLocator.BuildMediator();

            Pinger pinger = new Pinger(mediator);

            Console.WriteLine(pinger.SendPing());
        }
    }
}
