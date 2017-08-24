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
using DeathValley.Models;

namespace DeathValley.Controllers
{
    public class CacheDatasController : ApiController
    {
        private ParamCacheDatasContext db = new ParamCacheDatasContext();

        // GET: api/CacheDatas
        public IQueryable<CacheData> GetCacheDatas()
        {
            return db.CacheDatas;
        }

        // GET: api/CacheDatas/5
        [ResponseType(typeof(CacheData))]
        public IHttpActionResult GetCacheData(int id)
        {
            CacheData cacheData = db.CacheDatas.Find(id);
            if (cacheData == null)
            {
                return NotFound();
            }

            return Ok(cacheData);
        }

        // PUT: api/CacheDatas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCacheData(int id, CacheData cacheData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cacheData.CacheDataId)
            {
                return BadRequest();
            }

            db.Entry(cacheData).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CacheDataExists(id))
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

        // POST: api/CacheDatas
        [ResponseType(typeof(CacheData))]
        public IHttpActionResult PostCacheData(CacheData cacheData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CacheDatas.Add(cacheData);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cacheData.CacheDataId }, cacheData);
        }

        // DELETE: api/CacheDatas/5
        [ResponseType(typeof(CacheData))]
        public IHttpActionResult DeleteCacheData(int id)
        {
            CacheData cacheData = db.CacheDatas.Find(id);
            if (cacheData == null)
            {
                return NotFound();
            }

            db.CacheDatas.Remove(cacheData);
            db.SaveChanges();

            return Ok(cacheData);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CacheDataExists(int id)
        {
            return db.CacheDatas.Count(e => e.CacheDataId == id) > 0;
        }
    }
}