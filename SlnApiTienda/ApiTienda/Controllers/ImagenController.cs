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
using System.Web.Http.Description;
using BEUBIO;
using BEUBIO.Transaction;

namespace ApiTienda.Controllers
{
    public class ImagenController : ApiController
    {
        //private Entities_Bio db = new Entities_Bio();

        // GET: api/Imagen/idArticulo
        [ResponseType(typeof(Imagen))]
        public IHttpActionResult Get(int idArticulo)
            //enviamos el id del Articulo al que pertenese las imagenes
        {
            try
            {
                List<Imagen> todos = ImagenBLL.GetList(idArticulo);
                if (todos == null)
                {
                    return NotFound();
                }
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        


       

        // POST: api/Imagen
        [ResponseType(typeof(Imagen))]
        public IHttpActionResult Post(Imagen img)
        {
            try
            {
                ImagenBLL.Create(img);
                return Content(HttpStatusCode.Created, "Imagen se a creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Imagen/5
        [ResponseType(typeof(Imagen))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                ImagenBLL.Delete(id);
                return Ok("Imagen se a eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}