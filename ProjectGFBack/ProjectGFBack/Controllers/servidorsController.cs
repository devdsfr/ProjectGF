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
using ProjectGFBack.Models;

namespace ProjectGFBack.Controllers
{
    public class servidorsController : ApiController
    {
        private GfEntities1 db = new GfEntities1();

        // GET: api/servidors
        public IQueryable<servidor> Getservidor()
        {
            return db.servidor;
        }

        // GET: api/servidors/5
        [ResponseType(typeof(servidor))]
        public IHttpActionResult Getservidor(int id)
        {
            servidor servidor = db.servidor.Find(id);
            if (servidor == null)
            {
                return NotFound();
            }

            return Ok(servidor);
        }

        // PUT: api/servidors/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putservidor(int id, servidor servidor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != servidor.num_servidor)
            {
                return BadRequest();
            }

            db.Entry(servidor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!servidorExists(id))
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

        // POST: api/servidors
        [ResponseType(typeof(servidor))]
        public IHttpActionResult Postservidor(servidor servidor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.servidor.Add(servidor);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (servidorExists(servidor.num_servidor))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = servidor.num_servidor }, servidor);
        }

        // DELETE: api/servidors/5
        [ResponseType(typeof(servidor))]
        public IHttpActionResult Deleteservidor(int id)
        {
            servidor servidor = db.servidor.Find(id);
            if (servidor == null)
            {
                return NotFound();
            }

            db.servidor.Remove(servidor);
            db.SaveChanges();

            return Ok(servidor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool servidorExists(int id)
        {
            return db.servidor.Count(e => e.num_servidor == id) > 0;
        }
    }
}