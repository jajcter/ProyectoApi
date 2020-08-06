using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUBIO.Transaction
{
    public class ArticuloBLL
    {
        //BLL Bussiness Logic Layer
        //Capa de Logica del Negocio

        public static void Create(Articulo a)
        {
            using (Entities_Bio db = new Entities_Bio())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Articuloes.Add(a);
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static Articulo Get(int? id)
        {
            Entities_Bio db = new Entities_Bio();
            return db.Articuloes.Find(id);
        }

        public static List<Articulo> Get_id(int? id)
        {
            Entities_Bio db = new Entities_Bio();
            return db.Articuloes.Where(x => x.idUsuario == id).ToList();
        }

        public static void Update(Articulo articulo)
        {
            using (Entities_Bio db = new Entities_Bio())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Articuloes.Attach(articulo);
                        db.Entry(articulo).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        public static void Delete(int? id)
        {
            using (Entities_Bio db = new Entities_Bio())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Articulo alumno = db.Articuloes.Find(id);
                        db.Entry(alumno).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw ex;
                    }
                }
            }
        }

        /*
         public static List<Articulo> GetList(string criterio)
        {
            DBBIOEntities db = new DBBIOEntities();
            return db.Articuloes.Where(x => x.nombre.ToLower().Contains(criterio)).ToList();
        }
         */

        public static List<Articulo> GetList(string criterio)
        {
            Entities_Bio db = new Entities_Bio();
            //Instancia del contexto

            /*List<Alumno> alumons = db.Alumnoes.ToList();
            List<Alumno> resultado = new List<Alumno>();
            foreach (Alumno a in alumons) {
                if (a.sexo == "M") {
                    resultado.Add(a);
                }
            }
            return resultado;*/
            //SQL -> SELECT * FROM dbo.Alumno WHERE sexo = 'M'
            //return db.Alumnoes.Where(x => x.sexo == "M").ToList();

            return db.Articuloes.Where(x => x.categoria.ToLower().Contains(criterio)).ToList();
            //return db.Articuloes.ToList();

            //Los metodos del EntityFramework se denomina Linq, 
            //y la evluacion de condiciones lambda
        }

        public static List<Articulo> ListToNames()
        {
            Entities_Bio db = new Entities_Bio();
            List<Articulo> result = new List<Articulo>();
            db.Articuloes.ToList().ForEach(x =>
                result.Add(
                    new Articulo
                    {
                        nombre = x.nombre,
                        idArticulo = x.idArticulo
                    }));
            return result;
        }

        public static List<Articulo> GetArticulos(string criterio)
        {
            //Ejemplo: criterio = 'quin'
            //Posibles resultados => Quintana, Quintero, Pulloquinga, Quingaluisa...
            Entities_Bio db = new Entities_Bio();
            return db.Articuloes.Where(x => x.nombre.ToLower().Contains(criterio)).ToList();
        }
        /*
        private static Articulo GetAlumno(string cedula)
        {
            Entities_Bio db = new Entities_Bio();
            return db.Alumnoes.FirstOrDefault(x => x.cedula == cedula);
        }
        */
    }
}
