using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PlaySports.Domain.CommandHandlers;
using PlaySports.Domain.Commands.AgendaCommands;
using PlaySports.Domain.Commands.AuthenticationCommands;
using PlaySports.Domain.Commands.MatchCommands;
using PlaySports.Domain.Commands.NotaCommands;
using PlaySports.Domain.Commands.NovoMatchCommands;
using PlaySports.Domain.Commands.UserCommands;
using PlaySports.Domain.Core.Notifications;

namespace PlaySports.Infra.CrossCutting.IoC
{
    public class DomainNativeInjectorBootstrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            services.AddScoped<IRequestHandler<AddUserCommand, Unit>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<EditUserCommand, Unit>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteUserCommand, Unit>, UserCommandHandler>();

            services.AddScoped<IRequestHandler<LoginCommand, Unit>, AuthenticationCommandHandler>();

            services.AddScoped<IRequestHandler<AddMatchCommand, Unit>, MatchCommandHandler>();

            services.AddScoped<IRequestHandler<AddNovoMatchCommand, Unit>, NovoMatchCommandHandler>();

            services.AddScoped<IRequestHandler<AddAgendaCommand, Unit>, AgendaCommandHandler>();
            services.AddScoped<IRequestHandler<EditAgendaCommand, Unit>, AgendaCommandHandler>();

            services.AddScoped<IRequestHandler<AddNotaCommand, Unit>, NotaCommandHandler>();

        }
    }
}