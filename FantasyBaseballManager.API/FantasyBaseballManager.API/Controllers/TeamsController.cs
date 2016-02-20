using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using FantasyBaseballManager.API.Domain;
using FantasyBaseballManager.API.Infrastructure;
using FantasyBaseballManager.API.Models;
using AutoMapper;

namespace FantasyBaseballManager.API.Controllers
{
    public class TeamsController : ApiController
    {
        private FantasyBaseballManagerDataContext db = new FantasyBaseballManagerDataContext();

        // GET: api/Teams
        public IEnumerable<TeamModel> GetTeams()
        {
            return Mapper.Map<IEnumerable<TeamModel>>(db.Teams);
        }

        // GET: api/Teams/5
        [ResponseType(typeof(TeamModel))]
        public IHttpActionResult GetTeam(int id)
        {
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<TeamModel>(team));
        }

        // PUT: api/Teams/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTeam(int id, TeamModel team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != team.TeamId)
            {
                return BadRequest();
            }

            var dbTeam = db.Teams.Find(id);
            dbTeam.Update(team);
            db.Entry(dbTeam).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TeamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Teams
        [ResponseType(typeof(Team))]
        public IHttpActionResult PostTeam(TeamModel team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var dbTeam = new Team(team);

            db.Teams.Add(dbTeam);
            db.SaveChanges();

            team.TeamId = dbTeam.TeamId;


            return CreatedAtRoute("DefaultApi", new { id = team.TeamId }, team);
        }

        // DELETE: api/Teams/5
        [ResponseType(typeof(Team))]
        public IHttpActionResult DeleteTeam(int id)
        {
            Team team = db.Teams.Find(id);
            if (team == null)
            {
                return NotFound();
            }

            db.Teams.Remove(team);
            db.SaveChanges();

            return Ok(Mapper.Map<TeamModel>(team));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TeamExists(int id)
        {
            return db.Teams.Count(e => e.TeamId == id) > 0;
        }
    }
}