using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using ApiTienda.Models;

namespace ApiTienda.Controllers
{
    [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class NegocioController : ApiController
    {
        private EntitiesTienda db = new EntitiesTienda();

        // GET: api/Negocio
        public IQueryable<Negocio> GetNegocios()
        {
            return db.Negocios;
        }

        // GET: api/Negocio/5
        [ResponseType(typeof(Negocio))]
        public async Task<IHttpActionResult> GetNegocio(int id)
        {
            Negocio negocio = await db.Negocios.FindAsync(id);
            if (negocio == null)
            {
                return NotFound();
            }

            return Ok(negocio);
        }

        // PUT: api/Negocio/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutNegocio(int id, Negocio negocio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != negocio.idNegocio)
            {
                return BadRequest();
            }

            db.Entry(negocio).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NegocioExists(id))
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

        // POST: api/Negocio
        [ResponseType(typeof(Negocio))]
        public async Task<IHttpActionResult> PostNegocio(Negocio negocio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Negocios.Add(negocio);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = negocio.idNegocio }, negocio);
        }

        // DELETE: api/Negocio/5
        [ResponseType(typeof(Negocio))]
        public async Task<IHttpActionResult> DeleteNegocio(int id)
        {
            Negocio negocio = await db.Negocios.FindAsync(id);
            if (negocio == null)
            {
                return NotFound();
            }

            db.Negocios.Remove(negocio);
            await db.SaveChangesAsync();

            return Ok(negocio);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NegocioExists(int id)
        {
            return db.Negocios.Count(e => e.idNegocio == id) > 0;
        }
    }
}