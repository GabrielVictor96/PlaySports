using AutoMapper;
using PlaySports.Application.ViewModels;
using PlaySports.Domain.Commands.AgendaCommands;
using PlaySports.Domain.Commands.AuthenticationCommands;
using PlaySports.Domain.Commands.MatchCommands;
using PlaySports.Domain.Commands.NotaCommands;
using PlaySports.Domain.Commands.NovoMatchCommands;
using PlaySports.Domain.Commands.UserCommands;
using PlaySports.Domain.Core.ValueObjects;

namespace PlaySports.Application.AutoMapper.Profiles
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<RegisterUserViewModel, AddUserCommand>();
            CreateMap<UserViewModel, EditUserCommand>();
            CreateMap<LoginViewModel, LoginCommand>();


            CreateMap<string, Password>().ConstructUsing(x=> new Password(x));
            CreateMap<LoginViewModel, LoginCommand>();

            CreateMap<MatchViewModel, AddMatchCommand>();

            CreateMap<NovoMatchViewModel, AddNovoMatchCommand>();

            CreateMap<AgendaViewModel, AddAgendaCommand>();
            CreateMap<AgendaViewModel, EditAgendaCommand>();

            CreateMap<NotaViewModel, AddNotaCommand>();
        }
    }
}