using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FantasyBaseballManager.API.Domain
{
    public class Team
    {
        public int TeamId { get; set; }
        public int LeagueId { get; set; }
        public string Name { get; set; }        
        public string Link { get; set; }
        

        public virtual League League { get; set; }

        public virtual ICollection<Hitter> Hitters { get; set; }
        public virtual ICollection<Pitcher> Pitchers { get; set; }
    }
}