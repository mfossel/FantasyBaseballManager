using FantasyBaseballManager.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FantasyBaseballManager.API.Domain
{
    public class Pitcher
    {
        public Pitcher()
        { }

        public Pitcher(PitcherModel model)
        {
            this.Update(model);
        }

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

        public virtual Team Team { get; set; }

        public void Update(PitcherModel model)
        {
            PitcherId = model.PitcherId;
            Name = model.Name;
            TeamId = model.TeamId;
            MLBTeam = model.MLBTeam;
            Role = model.Role;
            Age = model.Age;
            Height = model.Height;
            Weight = model.Weight;
            ERA = model.ERA;
            WHIP = model.WHIP;
            Wins = model.Wins;
            Losses = model.Losses;

        }
    }
}