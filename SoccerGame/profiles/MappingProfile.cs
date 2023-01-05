using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace SoccerGame.profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Team, TeamDto>().ReverseMap();
            CreateMap<Player, PlayerDto>();

            CreateMap<TeamForCreationDto, Team>().ReverseMap();
            CreateMap<PlayerForCreationDto, Player>().ReverseMap();
            CreateMap<playerForUpdateDto, Player>().ReverseMap();
            CreateMap<TeamForUpdateDto, Team>().ReverseMap();


            CreateMap<UserForRegistrationDto, User>();


        }
    }
}
