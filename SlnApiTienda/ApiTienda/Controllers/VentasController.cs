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
    public class VentasController : ApiController
    {
        private EntitiesTienda db = new EntitiesTienda();

        // GET: api/Ventas
        public IQueryable<Venta> GetVentas()
        {
            return db.Ventas;
        }

        // GET: api/Ventas/5
        [ResponseType(typeof(Venta))]
        public async Task<IHttpActionResult> GetVenta(int id)
        {
            Venta venta = await db.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }

            return Ok(venta);
        }

        // PUT: api/Ventas/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVenta(int id, Venta venta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != venta.idVenta)
            {
                return BadRequest();
            }

            db.Entry(venta).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(id))
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

        // POST: api/Ventas
        [ResponseType(typeof(Venta))]
        public async Task<IHttpActionResult> PostVenta(Venta venta)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ventas.Add(venta);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = venta.idVenta }, venta);
        }

        // DELETE: api/Ventas/5
        [ResponseType(typeof(Venta))]
        public async Task<IHttpActionResult> DeleteVenta(int id)
        {
            Venta venta = await db.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }

            db.Ventas.Remove(venta);
            await db.SaveChangesAsync();

            return Ok(venta);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VentaExists(int id)
        {
            return db.Ventas.Count(e => e.idVenta == id) > 0;
        }
    }
}