using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUBIO.Transaction
{
    public class UsuarioBLL
    {
        //BLL Bussiness Logic Layer
        //Capa de Logica del Negocio

        public static void Create(Usuario a)
        {
            using (Entities_Bio db = new Entities_Bio())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Usuarios.Add(a);
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

        public static Usuario Get(int? id)
        {
            Entities_Bio db = new Entities_Bio();
            return db.Usuarios.Find(id);
        }

        public static void Update(Usuario Usuario)
        {
            using (Entities_Bio db = new Entities_Bio())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Usuarios.Attach(Usuario);
                        db.Entry(Usuario).State = System.Data.Entity.EntityState.Modified;
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
                        Usuario alumno = db.Usuarios.Find(id);
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
         public static List<Usuario> GetList(string criterio)
        {
            DBBIOEntities db = new DBBIOEntities();
            return db.Usuarios.Where(x => x.nombre.ToLower().Contains(criterio)).ToList();
        }
         */

        public static List<Usuario> GetList()
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

            //return db.Usuarios.Where(x => x.nombre.ToLower().Contains(criterio)).ToList();
            return db.Usuarios.ToList();

            //Los metodos del EntityFramework se denomina Linq, 
            //y la evluacion de condiciones lambda
        }

        public static List<Usuario> ListToNames()
        {
            Entities_Bio db = new Entities_Bio();
            List<Usuario> result = new List<Usuario>();
            db.Usuarios.ToList().ForEach(x =>
                result.Add(
                    new Usuario
                    {
                        nombres = x.nombres,
                        idUsuario = x.idUsuario
                    }));
            return result;
        }

        public static List<Usuario> GetUsuario(string criterio)
        {
            //Ejemplo: criterio = 'quin'
            //Posibles resultados => Quintana, Quintero, Pulloquinga, Quingaluisa...
            Entities_Bio db = new Entities_Bio();
            return db.Usuarios.Where(x => x.nombres.ToLower().Contains(criterio)).ToList();
        }
        /*
        private static Usuario GetAlumno(string cedula)
        {
            Entities_Bio db = new Entities_Bio();
            return db.Alumnoes.FirstOrDefault(x => x.cedula == cedula);
        }
        */
    }
}
