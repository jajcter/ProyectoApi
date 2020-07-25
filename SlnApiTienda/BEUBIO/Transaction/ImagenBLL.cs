using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUBIO.Transaction
{
    public class ImagenBLL
    {
        //BLL Bussiness Logic Layer
        //Capa de Logica del Negocio

        public static void Create(Imagen a)
        {
            using (Entities_Bio db = new Entities_Bio())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Imagens.Add(a);
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

        public static Imagen Get(int? id)
        {//una imagen especifica del articulo

            Entities_Bio db = new Entities_Bio();
            return db.Imagens.Find(id);
        }

        public static void Update(Imagen Imagen)
        {
            using (Entities_Bio db = new Entities_Bio())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        db.Imagens.Attach(Imagen);
                        db.Entry(Imagen).State = System.Data.Entity.EntityState.Modified;
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

        public static void Delete(int? imgArticulo)
        {
            using (Entities_Bio db = new Entities_Bio())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        //verificar
                        List<Imagen> Imagen = db.Imagens.Where(x => x.idArticulo.Equals(imgArticulo)).ToList(); 
                        db.Entry(Imagen).State = System.Data.Entity.EntityState.Deleted;
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

        
         public static List<Imagen> GetList(int IDimgArticulo)
        {
            Entities_Bio db = new Entities_Bio();
            return db.Imagens.Where(x => x.idArticulo.Equals(IDimgArticulo)).ToList();
        }
         
    }
}
