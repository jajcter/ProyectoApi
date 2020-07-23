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
    public class ArticuloController : ApiController
    {
        private EntitiesTienda db = new EntitiesTienda();

        // GET: api/Articulo
        public IQueryable<Articulo> GetArticuloes()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Articuloes;
        }

        // GET: api/Articulo/5
        [ResponseType(typeof(Articulo))]
        public async Task<IHttpActionResult> GetArticulo(int id)
        {
            Articulo articulo = await db.Articuloes.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }

            return Ok(articulo);
        }

        // PUT: api/Articulo/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutArticulo(int id, Articulo articulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != articulo.idArticulo)
            {
                return BadRequest();
            }

            db.Entry(articulo).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticuloExists(id))
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

        // POST: api/Articulo
        [ResponseType(typeof(Articulo))]
        public async Task<IHttpActionResult> PostArticulo(Articulo articulo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Articuloes.Add(articulo);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = articulo.idArticulo }, articulo);
        }

        // DELETE: api/Articulo/5
        [ResponseType(typeof(Articulo))]
        public async Task<IHttpActionResult> DeleteArticulo(int id)
        {
            Articulo articulo = await db.Articuloes.FindAsync(id);
            if (articulo == null)
            {
                return NotFound();
            }

            db.Articuloes.Remove(articulo);
            await db.SaveChangesAsync();

            return Ok(articulo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ArticuloExists(int id)
        {
            return db.Articuloes.Count(e => e.idArticulo == id) > 0;
        }
    }
}