//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Business.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Whitelist
    {
        public int id { get; set; }
        public long barcode { get; set; }
        public System.DateTime tanggal_awal { get; set; }
        public System.DateTime tanggal_akhir { get; set; }
    
        public virtual Crew Crew { get; set; }
    }
}