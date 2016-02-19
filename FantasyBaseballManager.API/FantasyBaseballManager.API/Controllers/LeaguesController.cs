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
    public class LeaguesController : ApiController
    {
        private FantasyBaseballManagerDataContext db = new FantasyBaseballManagerDataContext();

        // GET: api/Leagues
        public IEnumerable<LeagueModel> GetLeagues()
        {
            return Mapper.Map<IEnumerable<LeagueModel>>(db.Leagues);
        }

        // GET: api/Leagues/5
        [ResponseType(typeof(LeagueModel))]
        public IHttpActionResult GetLeague(int id)
        {
            League league = db.Leagues.Find(id);
            if (league == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<LeagueModel>(league));
        }

        // PUT: api/Leagues/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLeague(int id, LeagueModel league)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != league.LeagueId)
            {
                return BadRequest();
            }


            var dbLeague = db.Leagues.Find(id);
            dbLeague.Update(league);
            db.Entry(dbLeague).State = EntityState.Modified;


            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeagueExists(id))
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

        // POST: api/Leagues
        [ResponseType(typeof(League))]
        public IHttpActionResult PostLeague(LeagueModel league)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbLeague = new League(league);

            db.Leagues.Add(dbLeague);
            db.SaveChanges();

            league.LeagueId = dbLeague.LeagueId;

            return CreatedAtRoute("DefaultApi", new { id = league.LeagueId }, league);
        }

        // DELETE: api/Leagues/5
        [ResponseType(typeof(League))]
        public IHttpActionResult DeleteLeague(int id)
        {
            League league = db.Leagues.Find(id);
            if (league == null)
            {
                return NotFound();
            }

            db.Leagues.Remove(league);
            db.SaveChanges();

            return Ok(Mapper.Map<LeagueModel>(league));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LeagueExists(int id)
        {
            return db.Leagues.Count(e => e.LeagueId == id) > 0;
        }
    }
}