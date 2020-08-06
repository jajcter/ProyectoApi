using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using BEUBIO;
using BEUBIO.Transaction;

namespace ApiTienda.Controllers
{
    public class ArticulosController : ApiController
    {
        [EnableCors(origins: "*", headers: "*", methods: "*")]

        // GET: api/Articulos
        [ResponseType(typeof(Articulo))]
        public IHttpActionResult Get(string criterio)
        {
            try
            {
                List<Articulo> todos = ArticuloBLL.GetList(criterio);
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET: api/Articulos/5
        [ResponseType(typeof(Articulo))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Articulo result = ArticuloBLL.Get(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Content(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        
        public IHttpActionResult Get(int id, string dato)
        {
            try
            {
                List<Articulo> result = ArticuloBLL.Get_id(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Content(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //// PUT: api/Articulos/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutArticulo(int id, Articulo articulo)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != articulo.idArticulo)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(articulo).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!ArticuloExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}






        // POST: api/Articulos
        [ResponseType(typeof(Articulo))]
        public IHttpActionResult Post(Articulo articulo)
        {
            try
            {
                ArticuloBLL.Create(articulo);
                return Content(HttpStatusCode.Created, "Artículo creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public IHttpActionResult Put(Articulo articulo)
        {
            try
            {
                ArticuloBLL.Update(articulo);
                return Content(HttpStatusCode.OK, "Usuario actualizado correctamente");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Articulos/5
        [ResponseType(typeof(Articulo))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                ArticuloBLL.Delete(id);
                return Ok("Alumno eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool ArticuloExists(int id)
        //{
        //    return db.Articuloes.Count(e => e.idArticulo == id) > 0;
        //}
    }
}