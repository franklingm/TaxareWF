//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Datamodel
{
    using System;
    using System.Collections.Generic;
    
    public partial class Inventario
    {
        public Inventario()
        {
            this.Gasto_Inventario = new HashSet<Gasto_Inventario>();
        }
    
        public int id { get; set; }
        public string item { get; set; }
        public int cantidad { get; set; }
        public double valorUnitario { get; set; }
        public double valorTotal { get; set; }
    
        public virtual ICollection<Gasto_Inventario> Gasto_Inventario { get; set; }
    }
}