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
    
    public partial class EmployeeMaster
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpNameMar { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public string EmpMobileNumber { get; set; }
        public string EmpAddress { get; set; }
        public string type { get; set; }
        public Nullable<bool> isActive { get; set; }
        public string isActiveULB { get; set; }
        public Nullable<System.DateTime> lastModifyDateEntry { get; set; }
    }
}
