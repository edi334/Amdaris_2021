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

    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyTypes(typeof(IMediator)
                .GetType().Assembly)
                .AsImplementedInterfaces();

            builder
                .RegisterAssemblyTypes(typeof(Ping).GetType().Assembly)
                .AsClosedTypesOf(typeof(IRequestHandler<,>))
                .AsImplementedInterfaces();

            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });

            var container = builder.Build();
            var mediator = container.Resolve<IMediator>();

            Console.WriteLine(mediator.Send(new Ping()));
        }
    }
}
