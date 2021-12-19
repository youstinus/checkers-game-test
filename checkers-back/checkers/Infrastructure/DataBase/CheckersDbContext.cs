using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using checkers.Infrastructure.DataBase.Models;
using Microsoft.EntityFrameworkCore;

namespace checkers.Infrastructure.DataBase
{
    public class CheckersDbContext : DbContext
    {
        public DbSet<Checker> Checkers { get; set; }
        public DbSet<Square> Squares { get; set; }
        public DbSet<Board> Boards { get; set; }
        public CheckersDbContext(DbContextOptions<CheckersDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetUpSquares(modelBuilder);
            SetUpCheckers(modelBuilder);
            SetUpBoards(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void SetUpBoards(ModelBuilder modelBuilder)
        {
            var boards = modelBuilder.Entity<Board>()
                .HasKey(x => new { x.Id });
        }
        private void SetUpCheckers(ModelBuilder modelBuilder)
        {
            var checkers = modelBuilder.Entity<Checker>()
                .HasKey(x => new {x.Id});
        }
        private void SetUpSquares(ModelBuilder modelBuilder)
        {
            var squares = modelBuilder.Entity<Square>()
                .HasKey(x => new { x.Id });
        }

        public object GetSome(object asign)
        {
            if (asign.GetType() == typeof(Board))
            {
                return Boards;
            }
            if (asign.GetType() == typeof(Square))
            {
                return Squares;
            }
            if (asign.GetType() == typeof(Checker))
            {
                return Checkers;
            }

            return null;
        }
        /*
        private void SetUpTournament(ModelBuilder modelBuilder)
        {
            var tournamnetEntity = modelBuilder.Entity<Tournament>();
            tournamnetEntity.HasKey(x => x.Id);
            tournamnetEntity.HasMany(x => x.TournamentTeams)
                .WithOne(pt => pt.Tournament)
                .HasForeignKey(pt => pt.TournamentId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public void SetUpParticipant(ModelBuilder modelBuilder)
        {
            var participantEntity = modelBuilder.Entity<Participant>();
            participantEntity.HasKey(x => x.Id);
            participantEntity.HasMany(x => x.ParticipantTeams)
                .WithOne(pt => pt.Participant)
                .HasForeignKey(pt => pt.TeamId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public void SetUpParticipantTeam(ModelBuilder modelBuilder)
        {
            var participantTeamEntity = modelBuilder.Entity<ParticipantTeam>();
            participantTeamEntity
                .HasKey(x => new { x.ParticipantId, x.TeamId });
        }

        public void SetUpTeam(ModelBuilder modelBuilder)
        {
            var teamEntity = modelBuilder.Entity<Team>();
            teamEntity.HasKey(x => x.Id);
            teamEntity.HasMany(x => x.TournamentTeams)
                .WithOne(pt => pt.Team)
                .HasForeignKey(pt => pt.TeamId)
                .OnDelete(DeleteBehavior.Cascade);
            teamEntity.HasMany(x => x.ParticipantTeams)
                .WithOne(pt => pt.Team)
                .HasForeignKey(pt => pt.TeamId)
                .OnDelete(DeleteBehavior.Cascade);
            teamEntity.HasMany(t => t.Matches)
                .WithOne(t => t.Team)
                .HasForeignKey(t => t.TeamId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public void SetUpTournamentTeam(ModelBuilder modelBuilder)
        {
            var tournamentTeamEntity = modelBuilder.Entity<TournamentTeam>();
            tournamentTeamEntity
                .HasKey(x => new { x.TournamentId, x.TeamId });
        }

        public void SetUpMatch(ModelBuilder modelBuilder)
        {
            var matchEntity = modelBuilder.Entity<Match>();
            matchEntity.HasKey(m => m.Id);
            matchEntity.HasMany(m => m.Teams)
                .WithOne(m => m.Match)
                .HasForeignKey(m => m.MatchId)
                .OnDelete(DeleteBehavior.Cascade);
            matchEntity.HasOne(m => m.Tournament)
                .WithMany(t => t.Matches)
                .HasForeignKey(m => m.TournamentId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public void SetUpMatchTeams(ModelBuilder modelBuilder)
        {
            var matchTeamsEntity = modelBuilder.Entity<MatchTeam>()
                .HasKey(x => new { x.MatchId, x.TeamId });
        }*/

    }
}
