﻿using System;
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
    public class ParamsController : ApiController
    {
        private ParamCacheDatasContext db = new ParamCacheDatasContext();

        // GET: api/Params
        public IQueryable<Param> GetParams()
        {
            return db.Params;
        }

        // GET: api/Params/5
        [ResponseType(typeof(Param))]
        public IHttpActionResult GetParam(int id)
        {
            Param param = db.Params.Find(id);
            if (param == null)
            {
                return NotFound();
            }

            return Ok(param);
        }

        // PUT: api/Params/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParam(int id, Param param)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != param.ParamId)
            {
                return BadRequest();
            }

            db.Entry(param).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParamExists(id))
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

        // POST: api/Params
        [ResponseType(typeof(Param))]
        public IHttpActionResult PostParam(Param param)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Params.Add(param);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = param.ParamId }, param);
        }

        // DELETE: api/Params/5
        [ResponseType(typeof(Param))]
        public IHttpActionResult DeleteParam(int id)
        {
            Param param = db.Params.Find(id);
            if (param == null)
            {
                return NotFound();
            }

            db.Params.Remove(param);
            db.SaveChanges();

            return Ok(param);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParamExists(int id)
        {
            return db.Params.Count(e => e.ParamId == id) > 0;
        }
    }
}