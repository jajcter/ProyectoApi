//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BEUBIO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Articulo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Articulo()
        {
            this.Negocios = new HashSet<Negocio>();
        }
    
        public int idArticulo { get; set; }
        public string nombre { get; set; }
        public Nullable<decimal> precio { get; set; }
        public string categoria { get; set; }
        public string detalle { get; set; }
        public string estado { get; set; }
        public string imgPortada { get; set; }
        public string estadoStock { get; set; }
        public Nullable<int> idUsuario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Negocio> Negocios { get; set; }
        public virtual Usuario Usuario1 { get; set; }
    }
}
