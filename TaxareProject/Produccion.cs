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
    
    public partial class Produccion
    {
        public int id { get; set; }
        public string placa { get; set; }
        public int id_taxista { get; set; }
        public System.DateTime inicio { get; set; }
        public System.DateTime final { get; set; }
        public double valor { get; set; }
    
        public virtual Taxi Taxi { get; set; }
    }
}
