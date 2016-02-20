using FantasyBaseballManager.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FantasyBaseballManager.API.Domain
{
    public class Team
    {
        public Team()
        { }

        public Team(TeamModel model)
        {
            this.Update(model);
        }

        public int TeamId { get; set; }
        public int LeagueId { get; set; }
        public string Name { get; set; }        
        public string Link { get; set; }
        

        public virtual League League { get; set; }

        public virtual ICollection<Hitter> Hitters { get; set; }
        public virtual ICollection<Pitcher> Pitchers { get; set; }

        public void Update(TeamModel model)
        {
            LeagueId = model.LeagueId;
            TeamId = model.TeamId;
            Name = model.Name;
            Link = model.Link;

        }
    }
}