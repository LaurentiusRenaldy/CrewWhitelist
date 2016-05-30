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
    
    public partial class project
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public project()
        {
            this.fid_item = new HashSet<fid_item>();
            this.incident_report = new HashSet<incident_report>();
            this.leading_indicator = new HashSet<leading_indicator>();
            this.m_project = new HashSet<m_project>();
            this.m_project_under_study = new HashSet<m_project_under_study>();
            this.outcomes = new HashSet<outcome>();
            this.project_display = new HashSet<project_display>();
            this.project_gallery = new HashSet<project_gallery>();
            this.tasks = new HashSet<task>();
            this.project_under_study = new HashSet<project_under_study>();
            this.weekly_rca = new HashSet<weekly_rca>();
            this.weekly_report = new HashSet<weekly_report>();
            this.contractors = new HashSet<contractor>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> contractor_id { get; set; }
        public string photo { get; set; }
        public string description { get; set; }
        public System.DateTime start_date { get; set; }
        public System.DateTime finish_date { get; set; }
        public Nullable<bool> highlight { get; set; }
        public bool deleted { get; set; }
        public string project_stage { get; set; }
        public Nullable<byte> status { get; set; }
        public Nullable<double> budget { get; set; }
        public string currency { get; set; }
        public Nullable<int> num { get; set; }
        public Nullable<int> pmc_id { get; set; }
        public string summary { get; set; }
        public Nullable<int> company_id { get; set; }
        public string status_non_technical { get; set; }
        public bool is_completed { get; set; }
        public Nullable<System.DateTime> completed_date { get; set; }
        public int spbd_project_id { get; set; }
    
        public virtual company company { get; set; }
        public virtual contractor contractor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fid_item> fid_item { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<incident_report> incident_report { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<leading_indicator> leading_indicator { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<m_project> m_project { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<m_project_under_study> m_project_under_study { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<outcome> outcomes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<project_display> project_display { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<project_gallery> project_gallery { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<task> tasks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<project_under_study> project_under_study { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<weekly_rca> weekly_rca { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<weekly_report> weekly_report { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<contractor> contractors { get; set; }
    }
}