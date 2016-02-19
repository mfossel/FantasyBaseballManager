using FantasyBaseballManager.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FantasyBaseballManager.API.Domain
{
    public class Hitter
    {
        [Obsolete]
        public Hitter()
        { }

        public Hitter(HitterModel model)
        {
            this.Update(model);
        }


     
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


        public void Update(HitterModel model)
        {
            HitterId = model.HitterId;
            Name = model.Name;
            TeamId = model.TeamId;
            MLBTeam = model.MLBTeam;
            Position = model.Position;
            Age = model.Age;
            Height = model.Height;
            Weight = model.Weight;
            Average = model.Average;
            HomeRuns = model.HomeRuns;
            RBIs = model.RBIs;
            StolenBases = model.StolenBases;

        }

    }
}