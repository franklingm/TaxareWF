//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaxareProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Taxi
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Taxi()
        {
            this.ConductoresXtaxis = new HashSet<ConductoresXtaxi>();
            this.GastosVariables = new HashSet<GastosVariable>();
            this.Kilometrajes = new HashSet<Kilometraje>();
            this.Produccions = new HashSet<Produccion>();
            this.Responsabilidades = new HashSet<Responsabilidade>();
            this.Soats = new HashSet<Soat>();
            this.Tecnomecanicas = new HashSet<Tecnomecanica>();
            this.Toperacions = new HashSet<Toperacion>();
        }
    
        public string placa { get; set; }
        public int id_matricula { get; set; }
        public int id_transito { get; set; }
        public int id_marca { get; set; }
        public int modelo { get; set; }
        public int cilindraje { get; set; }
        public string empresa_alfiliadora { get; set; }
        public int avaluo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConductoresXtaxi> ConductoresXtaxis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GastosVariable> GastosVariables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kilometraje> Kilometrajes { get; set; }
        public virtual Marca Marca { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Produccion> Produccions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Responsabilidade> Responsabilidades { get; set; }
        public virtual Secretarias_transito Secretarias_transito { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Soat> Soats { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tecnomecanica> Tecnomecanicas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Toperacion> Toperacions { get; set; }
    }
}
