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
    
    public partial class report
    {
        public report()
        {
            this.report_card = new HashSet<report_card>();
        }
    
        public int id_report { get; set; }
        public string id_artist { get; set; }
        public int id_stage { get; set; }
        public string stage { get; set; }
    
        public virtual artist artist { get; set; }
        public virtual stage stage1 { get; set; }
        public virtual ICollection<report_card> report_card { get; set; }
    }
}
