using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FantasyBaseballManager.API.Domain
{
    public class League
    {
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public string Type { get; set; }
        public decimal? BuyIn { get; set; }

        public virtual ICollection<Team> Teams { get; set; }


    }
}