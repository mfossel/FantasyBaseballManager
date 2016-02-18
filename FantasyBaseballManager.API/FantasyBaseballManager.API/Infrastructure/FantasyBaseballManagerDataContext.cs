namespace FantasyBaseballManager.API.Infrastructure
{
    using Domain;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class FantasyBaseballManagerDataContext : DbContext
    {

        public FantasyBaseballManagerDataContext()
            : base("FantasyBaseballManager")
        {   }

        //SQL Tables
        public IDbSet<League> Leagues { get; set; }
        public IDbSet<Team> Teams { get; set; }
        public IDbSet<Pitcher> Pitchers { get; set; }
        public IDbSet<Hitter> Hitters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<League>()
                .HasMany(l => l.Teams)
                .WithRequired(t => t.League)
                .HasForeignKey(t => t.LeagueId);

            modelBuilder.Entity<Team>()
              .HasMany(t => t.Hitters)
              .WithRequired(h => h.Team)
              .HasForeignKey(h => h.TeamId);

            modelBuilder.Entity<Team>()
              .HasMany(t => t.Pitchers)
              .WithRequired(p=> p.Team)
              .HasForeignKey(p => p.TeamId);


        }
    }

}