//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FormatoEwo.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class lineas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public lineas()
        {
            this.kpis = new HashSet<kpis>();
        }
    
        public int id { get; set; }
        public string nombre { get; set; }
        public Nullable<int> id_planta { get; set; }
        public string image_path { get; set; }
        public Nullable<int> id_tipo_linea { get; set; }
        public Nullable<int> tiempo_carga { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<kpis> kpis { get; set; }
    }
}
