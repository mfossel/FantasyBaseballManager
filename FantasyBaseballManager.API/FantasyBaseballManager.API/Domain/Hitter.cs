using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FantasyBaseballManager.API.Domain
{
    public class Hitter
    {
        public int HitterId { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public string MLBTeam { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public decimal Average { get; set; }
        public int HomeRuns { get; set; }
        public int RBIs { get; set; }
        public int StolenBases { get; set; }

        public virtual Team Team { get; set; }


    }
}