//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SitesDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class SiteComment
    {
        public int ID { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }
        public int SiteID { get; set; }
    
        public virtual NationalSite NationalSite { get; set; }
    }
}
