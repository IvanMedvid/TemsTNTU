//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication1.Models.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class artist
    {
        public artist()
        {
            this.report = new HashSet<report>();
            this.stage = new HashSet<stage>();
        }
    
        public string id_artist { get; set; }
        public string PIB { get; set; }
        public Nullable<int> id_degree { get; set; }
        public Nullable<int> id_rank { get; set; }
        public Nullable<int> id_post { get; set; }
        public string diploma { get; set; }
        public string date_diploma { get; set; }
        public string certificate { get; set; }
        public string date_certificate { get; set; }
        public Nullable<int> id_st { get; set; }
        public Nullable<int> id_stage { get; set; }
    
        public virtual ICollection<report> report { get; set; }
        public virtual degree degree { get; set; }
        public virtual post post { get; set; }
        public virtual rank rank { get; set; }
        public virtual state_topic state_topic { get; set; }
        public virtual ICollection<stage> stage { get; set; }
    }
}
