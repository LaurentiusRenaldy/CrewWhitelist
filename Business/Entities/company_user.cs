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
    
    public partial class company_user
    {
        public int id { get; set; }
        public int company_id { get; set; }
        public string mobidig_username { get; set; }
        public System.Guid mobidig_user_id { get; set; }
    
        public virtual company company { get; set; }
    }
}
