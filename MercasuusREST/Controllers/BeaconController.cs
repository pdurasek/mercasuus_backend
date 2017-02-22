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
using MercasuusREST.Models;

namespace MercasuusREST.Controllers
{
    public class BeaconController : ApiController
    {
        private BeaconDBContext db = new BeaconDBContext();

        // GET: api/Beacon
        public IQueryable<Beacon> GetBeacons()
        {
            return db.Beacons;
        }

        // GET: api/Beacon/5
        [ResponseType(typeof(Beacon))]
        public IHttpActionResult GetBeacon(int id)
        {
            Beacon beacon = db.Beacons.Find(id);
            if (beacon == null)
            {
                return NotFound();
            }

            return Ok(beacon);
        }

        // PUT: api/Beacon/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBeacon(int id, Beacon beacon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != beacon.beaconID)
            {
                return BadRequest();
            }

            db.Entry(beacon).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BeaconExists(id))
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

        // POST: api/Beacon
        [ResponseType(typeof(Beacon))]
        public IHttpActionResult PostBeacon(Beacon beacon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Beacons.Add(beacon);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = beacon.beaconID }, beacon);
        }

        // DELETE: api/Beacon/5
        [ResponseType(typeof(Beacon))]
        public IHttpActionResult DeleteBeacon(int id)
        {
            Beacon beacon = db.Beacons.Find(id);
            if (beacon == null)
            {
                return NotFound();
            }

            db.Beacons.Remove(beacon);
            db.SaveChanges();

            return Ok(beacon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BeaconExists(int id)
        {
            return db.Beacons.Count(e => e.beaconID == id) > 0;
        }
    }
}