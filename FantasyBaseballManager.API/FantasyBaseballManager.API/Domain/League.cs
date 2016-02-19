using FantasyBaseballManager.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FantasyBaseballManager.API.Domain
{
    public class League
    {
        public League()
        { }

        public League(LeagueModel model)
        {
            this.Update(model);
        }


        public int LeagueId { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public string Type { get; set; }
        public decimal? BuyIn { get; set; }

        public virtual ICollection<Team> Teams { get; set; }

        public void Update(LeagueModel model)
        {
            LeagueId = model.LeagueId;
            Name = model.Name;
            Host = model.Host;
            Type = model.Type;
            BuyIn = model.BuyIn;

        }

    }
}