﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using MercasuusREST.Models;

namespace MercasuusREST.Controllers
{
    [RoutePrefix("api/Stores")]
    public class StoresController : ApiController
    {
        private StoreDBContext db = new StoreDBContext();

        // GET: api/Stores
        public IQueryable<Store> GetStores()
        {
            return db.Stores;
        }

        // GET: api/Stores/5
        [ResponseType(typeof(Store))]
        public async Task<IHttpActionResult> GetStore(int id)
        {
            Store store = await db.Stores.FindAsync(id);
            if (store == null)
            {
                return NotFound();
            }

            return Ok(store);
        }

        // PUT: api/Stores/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStore(int id, Store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != store.storeID)
            {
                return BadRequest();
            }

            db.Entry(store).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoreExists(id))
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

        // POST: api/Stores
        [ResponseType(typeof(Store))]
        public async Task<IHttpActionResult> PostStore(Store store)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stores.Add(store);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = store.storeID }, store);
        }

        // DELETE: api/Stores/5
        [ResponseType(typeof(Store))]
        public async Task<IHttpActionResult> DeleteStore(int id)
        {
            Store store = await db.Stores.FindAsync(id);
            if (store == null)
            {
                return NotFound();
            }

            db.Stores.Remove(store);
            await db.SaveChangesAsync();

            return Ok(store);
        }

        /// <summary>
        /// GET: api/Stores/Company/1
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        [Route("Company/{companyID}")]
        public IQueryable<Store> GetStoresByCompany(int companyID)
        {
            return db.Stores.Where(s => s.companyID == companyID);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StoreExists(int id)
        {
            return db.Stores.Count(e => e.storeID == id) > 0;
        }
    }
}