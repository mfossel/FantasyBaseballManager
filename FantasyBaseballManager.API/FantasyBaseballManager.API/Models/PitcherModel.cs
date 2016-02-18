using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FantasyBaseballManager.API.Models
{
    public class PitcherModel
    {
        public int PitcherId { get; set; }
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string MLBTeam { get; set; }
        public string Role { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public decimal ERA { get; set; }
        public decimal WHIP { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public int Strikeouts { get; set; }

        public TeamModel Team { get; set; }
    }
}