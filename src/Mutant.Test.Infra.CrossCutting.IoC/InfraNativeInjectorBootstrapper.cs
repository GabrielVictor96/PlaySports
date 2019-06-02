using Microsoft.Extensions.DependencyInjection;
using PlaySports.Domain.Core.Bus;
using PlaySports.Domain.Interfaces;
using PlaySports.Infra.CrossCutting.Bus;
using PlaySports.Infra.Data.Context;
using PlaySports.Infra.Data.Repository;

namespace PlaySports.Infra.CrossCutting.IoC
{
    public class InfraNativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<ApplicationDbContext>();

            services.AddScoped<IAuthenticationRepository, AuthenticationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IMatchRepository, MatchRepository>();

            services.AddScoped<INovoMatchRepository, NovoMatchRepository>();

            services.AddScoped<IAgendaRepository, AgendaRepository>();

            services.AddScoped<INotaRepository, NotaRepository>();
        }   
    }
}