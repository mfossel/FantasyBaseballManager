using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FantasyBaseballManager.API.Models
{
    public class LeagueModel
    {
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public string Host { get; set; }
        public string Type { get; set; }
        public decimal? BuyIn { get; set; }


    }
}