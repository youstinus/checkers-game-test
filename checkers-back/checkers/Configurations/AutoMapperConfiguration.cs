using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using checkers.Infrastructure.DataBase.Models;
using checkers.Models;

namespace checkers.Configurations
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration() : this("checkers")
        {

        }

        protected AutoMapperConfiguration(string name) : base(name)
        {
            //Squares
            CreateMap<SquareDto, Square>(MemberList.None);
            CreateMap<Square, SquareDto>(MemberList.Destination);
            //Checkers
            CreateMap<CheckerDto, Checker>(MemberList.None);
            CreateMap<Checker, CheckerDto>(MemberList.Destination);
            //Boards
            CreateMap<BoardDto, Board>(MemberList.None);
            CreateMap<Board, BoardDto>(MemberList.Destination);
            /*
            //Participants
            CreateMap<ParticipantDto, Participant>(MemberList.None);
            CreateMap<Participant, ParticipantDto>(MemberList.Destination);
            //Tournaments
            CreateMap<TournamentDto, Tournament>(MemberList.None);
            CreateMap<Tournament, TournamentDto>(MemberList.Destination);
            //Teams
            CreateMap<TeamDto, Team>(MemberList.None);
            CreateMap<Team, TeamDto>(MemberList.Destination);
            //Matches
            CreateMap<MatchDto, Match>(MemberList.None);
            CreateMap<Match, MatchDto>(MemberList.Destination)
                .ForMember(dest => dest.MatchTeams, opt => opt.MapFrom(src => src.Teams.Select(x => x.Team)));*/
        }
    }
}
