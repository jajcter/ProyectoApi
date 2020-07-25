using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUBIO.Transaction
{
    public class VentaBLL
    {
        //BLL Bussiness Logic Layer
        //Capa de Logica del Negocio

        public static void Create(Venta a)
        {
            using (Entities_Bio db = new Entities_Bio())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Ventas.Add(a);
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

        public static Venta Get(int? id)
        {
            Entities_Bio db = new Entities_Bio();
            return db.Ventas.Find(id);
        }

        public static void Update(Venta Venta)
        {
            using (Entities_Bio db = new Entities_Bio())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Ventas.Attach(Venta);
                        db.Entry(Venta).State = System.Data.Entity.EntityState.Modified;
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
                        Venta venta = db.Ventas.Find(id);
                        db.Entry(venta).State = System.Data.Entity.EntityState.Deleted;
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
         public static List<Venta> GetList(string criterio)
        {
            DBBIOEntities db = new DBBIOEntities();
            return db.Ventas.Where(x => x.nombre.ToLower().Contains(criterio)).ToList();
        }
         */

        public static List<Venta> GetList()
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

            //return db.Ventas.Where(x => x.nombre.ToLower().Contains(criterio)).ToList();
            return db.Ventas.ToList();

            //Los metodos del EntityFramework se denomina Linq, 
            //y la evluacion de condiciones lambda
        }

        public static List<Venta> ListToNames()
        {
            Entities_Bio db = new Entities_Bio();
            List<Venta> result = new List<Venta>();
            db.Ventas.ToList().ForEach(x =>
                result.Add(
                    new Venta
                    {
                        idUsuarioComprador = x.idUsuarioComprador
                    }));
            return result;
        }

        //public static List<Venta> GetDia(string criterio)
        //{
        //    //Http:url/api/venta/25.07.2020
        //    Entities_Bio db = new Entities_Bio();
        //    return db.Ventas.Where(x => x.fechaVenta.Contains(criterio)).ToList();
        //}

        /*
        private static Venta GetAlumno(string cedula)
        {
            Entities_Bio db = new Entities_Bio();
            return db.Alumnoes.FirstOrDefault(x => x.cedula == cedula);
        }
        */
    }
}
