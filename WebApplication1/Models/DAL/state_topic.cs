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
    
    public partial class state_topic
    {
        public state_topic()
        {
            this.artist = new HashSet<artist>();
            this.stage1 = new HashSet<stage>();
        }
    
        public int id_st { get; set; }
        public double budget { get; set; }
        public string time_begin { get; set; }
        public string title { get; set; }
        public string time_end { get; set; }
        public string id_artist { get; set; }
    
        public virtual ICollection<artist> artist { get; set; }
        public virtual artist artist1 { get; set; }
        public virtual ICollection<stage> stage1 { get; set; }
    }
}
