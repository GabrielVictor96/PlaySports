using AutoMapper;
using PlaySports.Application.ViewModels;
using PlaySports.Domain.Commands.UserCommands;
using PlaySports.Domain.Entities;

namespace PlaySports.Application.AutoMapper.Profiles
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<ListUserCommand, UserViewModel>();

            CreateMap<Match, MatchViewModel>();

            CreateMap<NovoMatch, NovoMatchViewModel>();

            CreateMap<Agenda, AgendaViewModel>();
        }
    }
}