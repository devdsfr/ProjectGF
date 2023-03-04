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
    public class gratificacaoFiscalAtoLiberacaoProcessoesController : ApiController
    {
        private GfEntities1 db = new GfEntities1();

        // GET: api/gratificacaoFiscalAtoLiberacaoProcessoes
        public IQueryable<gratificacaoFiscalAtoLiberacaoProcesso> GetgratificacaoFiscalAtoLiberacaoProcesso()
        {
            return db.gratificacaoFiscalAtoLiberacaoProcesso;
        }

        // GET: api/gratificacaoFiscalAtoLiberacaoProcessoes/5
        [ResponseType(typeof(gratificacaoFiscalAtoLiberacaoProcesso))]
        public IHttpActionResult GetgratificacaoFiscalAtoLiberacaoProcesso(string id)
        {
            gratificacaoFiscalAtoLiberacaoProcesso gratificacaoFiscalAtoLiberacaoProcesso = db.gratificacaoFiscalAtoLiberacaoProcesso.Find(id);
            if (gratificacaoFiscalAtoLiberacaoProcesso == null)
            {
                return NotFound();
            }

            return Ok(gratificacaoFiscalAtoLiberacaoProcesso);
        }

        // PUT: api/gratificacaoFiscalAtoLiberacaoProcessoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutgratificacaoFiscalAtoLiberacaoProcesso(string id, gratificacaoFiscalAtoLiberacaoProcesso gratificacaoFiscalAtoLiberacaoProcesso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gratificacaoFiscalAtoLiberacaoProcesso.num_ato_liberacao)
            {
                return BadRequest();
            }

            db.Entry(gratificacaoFiscalAtoLiberacaoProcesso).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gratificacaoFiscalAtoLiberacaoProcessoExists(id))
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

        // POST: api/gratificacaoFiscalAtoLiberacaoProcessoes
        [ResponseType(typeof(gratificacaoFiscalAtoLiberacaoProcesso))]
        public IHttpActionResult PostgratificacaoFiscalAtoLiberacaoProcesso(gratificacaoFiscalAtoLiberacaoProcesso gratificacaoFiscalAtoLiberacaoProcesso)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.gratificacaoFiscalAtoLiberacaoProcesso.Add(gratificacaoFiscalAtoLiberacaoProcesso);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (gratificacaoFiscalAtoLiberacaoProcessoExists(gratificacaoFiscalAtoLiberacaoProcesso.num_ato_liberacao))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gratificacaoFiscalAtoLiberacaoProcesso.num_ato_liberacao }, gratificacaoFiscalAtoLiberacaoProcesso);
        }

        // DELETE: api/gratificacaoFiscalAtoLiberacaoProcessoes/5
        [ResponseType(typeof(gratificacaoFiscalAtoLiberacaoProcesso))]
        public IHttpActionResult DeletegratificacaoFiscalAtoLiberacaoProcesso(string id)
        {
            gratificacaoFiscalAtoLiberacaoProcesso gratificacaoFiscalAtoLiberacaoProcesso = db.gratificacaoFiscalAtoLiberacaoProcesso.Find(id);
            if (gratificacaoFiscalAtoLiberacaoProcesso == null)
            {
                return NotFound();
            }

            db.gratificacaoFiscalAtoLiberacaoProcesso.Remove(gratificacaoFiscalAtoLiberacaoProcesso);
            db.SaveChanges();

            return Ok(gratificacaoFiscalAtoLiberacaoProcesso);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool gratificacaoFiscalAtoLiberacaoProcessoExists(string id)
        {
            return db.gratificacaoFiscalAtoLiberacaoProcesso.Count(e => e.num_ato_liberacao == id) > 0;
        }
    }
}