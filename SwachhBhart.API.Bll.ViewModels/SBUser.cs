﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachhBhart.API.Bll.ViewModels
{
   public class SBUser
    {
        public int userId { get; set; }

        public string userLoginId { get; set; }
         public string userPassword { get; set; }
         public string name { get; set; }
        //public string mobileNumber { get; set; }
        //public string address { get; set; }
        //public string profileImage { get; set; }
        public string imiNo { get; set; }
        public string type { get; set; }

        public string EmpType { get; set; }
        public int typeId { get; set; }
        public string status { get; set; }
        public string message { get; set; }
       public string messageMar { get; set; }
        public bool? gtFeatures { get; set; }
    }
}
