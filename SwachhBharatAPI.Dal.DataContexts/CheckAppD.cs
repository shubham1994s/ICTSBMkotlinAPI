//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SwachhBharatAPI.Dal.DataContexts
{
    using System;
    using System.Collections.Generic;
    
    public partial class CheckAppD
    {
        public int Id { get; set; }
        public string App_Name { get; set; }
        public bool IsCheked { get; set; }
        public Nullable<int> AppId { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
