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
    
    public partial class task_activity
    {
        public int id { get; set; }
        public int weekly_report_id { get; set; }
        public int task_id { get; set; }
        public string current_activity { get; set; }
        public string next_activity { get; set; }
    
        public virtual task task { get; set; }
        public virtual weekly_report weekly_report { get; set; }
    }
}
