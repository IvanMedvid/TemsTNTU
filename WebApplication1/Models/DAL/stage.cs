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
    
    public partial class stage
    {
        public stage()
        {
            this.report = new HashSet<report>();
            this.artist = new HashSet<artist>();
        }
    
        public int id_stage { get; set; }
        public int number { get; set; }
        public string time_begin { get; set; }
        public string title { get; set; }
        public string type_end_value { get; set; }
        public int id_st { get; set; }
        public string time_end { get; set; }
        public string id_artist { get; set; }
    
        public virtual ICollection<report> report { get; set; }
        public virtual state_topic state_topic { get; set; }
        public virtual ICollection<artist> artist { get; set; }
    }
}
