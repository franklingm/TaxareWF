//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TaxareProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class Soat
    {
        public int id { get; set; }
        public string numero { get; set; }
        public string placa_taxi { get; set; }
        public string expedicion { get; set; }
        public string expiracion { get; set; }
        public string valor { get; set; }
    
        public virtual Taxi Taxi { get; set; }
    }
}
