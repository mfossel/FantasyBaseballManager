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
    public class PitchersController : ApiController
    {
        private FantasyBaseballManagerDataContext db = new FantasyBaseballManagerDataContext();

        // GET: api/Pitchers
        public IEnumerable<PitcherModel> GetPitchers()
        {
            return Mapper.Map<IEnumerable<PitcherModel>>(db.Pitchers);
        }

        // GET: api/Pitchers/5
        [ResponseType(typeof(PitcherModel))]
        public IHttpActionResult GetPitcher(int id)
        {
            Pitcher pitcher = db.Pitchers.Find(id);
            if (pitcher == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<PitcherModel>(pitcher));
        }

        // PUT: api/Pitchers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPitcher(int id, PitcherModel pitcher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pitcher.PitcherId)
            {
                return BadRequest();
            }

            var dbPitcher = db.Pitchers.Find(id);
            dbPitcher.Update(pitcher);
            db.Entry(dbPitcher).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PitcherExists(id))
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

        // POST: api/Pitchers
        [ResponseType(typeof(Pitcher))]
        public IHttpActionResult PostPitcher(PitcherModel pitcher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var dbPitcher = new Pitcher(pitcher);

            db.Pitchers.Add(dbPitcher);
            db.SaveChanges();

            pitcher.PitcherId = dbPitcher.PitcherId;

            return CreatedAtRoute("DefaultApi", new { id = pitcher.PitcherId }, pitcher);
        }

        // DELETE: api/Pitchers/5
        [ResponseType(typeof(Pitcher))]
        public IHttpActionResult DeletePitcher(int id)
        {
            Pitcher pitcher = db.Pitchers.Find(id);
            if (pitcher == null)
            {
                return NotFound();
            }

            db.Pitchers.Remove(pitcher);
            db.SaveChanges();

            return Ok(Mapper.Map<PitcherModel>(pitcher));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PitcherExists(int id)
        {
            return db.Pitchers.Count(e => e.PitcherId == id) > 0;
        }
    }
}