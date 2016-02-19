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
    public class HittersController : ApiController
    {
        private FantasyBaseballManagerDataContext db = new FantasyBaseballManagerDataContext();

        // GET: api/Hitters
        public IEnumerable<HitterModel> GetHitters()
        {
            return Mapper.Map<IEnumerable<HitterModel>>(db.Hitters);
        }

        // GET: api/Hitters/5
        [ResponseType(typeof(HitterModel))]
        public IHttpActionResult GetHitter(int id)
        {
            Hitter hitter = db.Hitters.Find(id);
            if (hitter == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<HitterModel>(hitter));
        }

        // PUT: api/Hitters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHitter(int id, HitterModel hitter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hitter.HitterId)
            {
                return BadRequest();
            }

            var dbHitter = db.Hitters.Find(id);
            dbHitter.Update(hitter);
            db.Entry(dbHitter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HitterExists(id))
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

        // POST: api/Hitters
        [ResponseType(typeof(Hitter))]
        public IHttpActionResult PostHitter(HitterModel hitter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dbHitter = new Hitter(hitter);

            db.Hitters.Add(dbHitter);
            db.SaveChanges();

            hitter.HitterId = dbHitter.HitterId;

            return CreatedAtRoute("DefaultApi", new { id = hitter.HitterId }, hitter);
        }

        // DELETE: api/Hitters/5
        [ResponseType(typeof(Hitter))]
        public IHttpActionResult DeleteHitter(int id)
        {
            Hitter hitter = db.Hitters.Find(id);
            if (hitter == null)
            {
                return NotFound();
            }

            db.Hitters.Remove(hitter);
            db.SaveChanges();

            return Ok(Mapper.Map<HitterModel>(hitter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HitterExists(int id)
        {
            return db.Hitters.Count(e => e.HitterId == id) > 0;
        }
    }
}