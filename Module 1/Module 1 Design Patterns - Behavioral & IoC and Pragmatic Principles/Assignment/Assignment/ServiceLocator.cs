using Autofac;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment
{
    public class ServiceLocator
    {
        private readonly ServiceCollection services = new ServiceCollection();

        public IMediator BuildMediator()
        {
            services.AddMediatR(typeof(Ping));
            services.AddScoped(typeof(IRequestHandler<Ping,string>), typeof(Pong));

            var provider = services.BuildServiceProvider();

            return provider.GetRequiredService<IMediator>();
        }

        
    }
}
