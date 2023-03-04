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
    public class gratificacaoFiscalTipoLiberacaosController : ApiController
    {
        private GfEntities1 db = new GfEntities1();

        // GET: api/gratificacaoFiscalTipoLiberacaos
        public IQueryable<gratificacaoFiscalTipoLiberacao> GetgratificacaoFiscalTipoLiberacao()
        {
            return db.gratificacaoFiscalTipoLiberacao;
        }

        // GET: api/gratificacaoFiscalTipoLiberacaos/5
        [ResponseType(typeof(gratificacaoFiscalTipoLiberacao))]
        public IHttpActionResult GetgratificacaoFiscalTipoLiberacao(int id)
        {
            gratificacaoFiscalTipoLiberacao gratificacaoFiscalTipoLiberacao = db.gratificacaoFiscalTipoLiberacao.Find(id);
            if (gratificacaoFiscalTipoLiberacao == null)
            {
                return NotFound();
            }

            return Ok(gratificacaoFiscalTipoLiberacao);
        }

        // PUT: api/gratificacaoFiscalTipoLiberacaos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutgratificacaoFiscalTipoLiberacao(int id, gratificacaoFiscalTipoLiberacao gratificacaoFiscalTipoLiberacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gratificacaoFiscalTipoLiberacao.num_tipo_liberacao)
            {
                return BadRequest();
            }

            db.Entry(gratificacaoFiscalTipoLiberacao).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!gratificacaoFiscalTipoLiberacaoExists(id))
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

        // POST: api/gratificacaoFiscalTipoLiberacaos
        [ResponseType(typeof(gratificacaoFiscalTipoLiberacao))]
        public IHttpActionResult PostgratificacaoFiscalTipoLiberacao(gratificacaoFiscalTipoLiberacao gratificacaoFiscalTipoLiberacao)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.gratificacaoFiscalTipoLiberacao.Add(gratificacaoFiscalTipoLiberacao);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (gratificacaoFiscalTipoLiberacaoExists(gratificacaoFiscalTipoLiberacao.num_tipo_liberacao))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = gratificacaoFiscalTipoLiberacao.num_tipo_liberacao }, gratificacaoFiscalTipoLiberacao);
        }

        // DELETE: api/gratificacaoFiscalTipoLiberacaos/5
        [ResponseType(typeof(gratificacaoFiscalTipoLiberacao))]
        public IHttpActionResult DeletegratificacaoFiscalTipoLiberacao(int id)
        {
            gratificacaoFiscalTipoLiberacao gratificacaoFiscalTipoLiberacao = db.gratificacaoFiscalTipoLiberacao.Find(id);
            if (gratificacaoFiscalTipoLiberacao == null)
            {
                return NotFound();
            }

            db.gratificacaoFiscalTipoLiberacao.Remove(gratificacaoFiscalTipoLiberacao);
            db.SaveChanges();

            return Ok(gratificacaoFiscalTipoLiberacao);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool gratificacaoFiscalTipoLiberacaoExists(int id)
        {
            return db.gratificacaoFiscalTipoLiberacao.Count(e => e.num_tipo_liberacao == id) > 0;
        }
    }
}