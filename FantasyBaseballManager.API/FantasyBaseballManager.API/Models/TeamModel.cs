using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FantasyBaseballManager.API.Models
{
    public class TeamModel
    {
        public int TeamId { get; set; }
        public int LeagueId { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
    }
}