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
using BEUBIO;
using BEUBIO.Transaction;

namespace ApiTienda.Controllers
{
    public class UsuariosController : ApiController
    {
        [EnableCors(origins: "https://localhost:4200/", headers: "*", methods: "*")]

        // GET: api/Articulos
        public IHttpActionResult Get()
        {
            try
            {
                List<Usuario> todos = UsuarioBLL.GetList();
                return Content(HttpStatusCode.OK, todos);
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        // GET: api/Articulos/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult Get(int id)
        {
            try
            {
                Usuario result = UsuarioBLL.Get(id);
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


        // POST: api/Articulos
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult Post(Usuario Usuario)
        {
            try
            {
                UsuarioBLL.Create(Usuario);
                return Content(HttpStatusCode.Created, "Usuario creado correctamente");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/Articulos/5
        [ResponseType(typeof(Usuario))]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                UsuarioBLL.Delete(id);
                return Ok("Usuario eliminado correctamente");
            }
            catch (Exception ex)
            {
                return Content(HttpStatusCode.BadRequest, ex);
            }
        }

        
    }
}