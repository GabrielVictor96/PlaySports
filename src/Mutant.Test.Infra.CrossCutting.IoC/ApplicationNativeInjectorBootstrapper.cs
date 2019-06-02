using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PlaySports.Application.Interfaces;
using PlaySports.Application.Services;

namespace PlaySports.Infra.CrossCutting.IoC
{
    public class ApplicationNativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));
            services.AddScoped<IAuthenticationAppService, AuthenticationAppService>();
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IMatchAppService, MatchAppService>();
            services.AddScoped<INovoMatchAppService, NovoMatchAppService>();
            services.AddScoped<IAgendaAppService, AgendaAppService>();
        }
    }
}