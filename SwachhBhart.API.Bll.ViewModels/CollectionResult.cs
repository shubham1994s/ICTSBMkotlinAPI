using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachhBhart.API.Bll.ViewModels
{
   public class CollectionResult
    {
        public string name { get; set; }
        public string nameMar { get; set; }
        public string mobile { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public string messageMar { get; set; }
        public bool isAttendenceOff { get; set; }
    }

    public class CollectionSyncResult
    {
        public int ID { get; set; }

        public string status { get; set; }
        public string referenceID { get; set; }
        public string message { get; set; }
        public string messageMar { get; set; }
        public bool isAttendenceOff { get; set; }
        public string houseId { get; set; }
        public bool IsExist { get; set; }

        //public Nullable<System.DateTime> startdatetime { get; set; }
        //public Nullable<System.DateTime> enddatetime { get; set; }
        //public Nullable<int> userid { get; set; }
        //public string dyid { get; set; }
        //public string houselist { get; set; }
        //public Nullable<int> tripno { get; set; }
        //public string vehicleNumber { get; set; }
        //public Nullable<decimal> totalGcWeight { get; set; }
        //public Nullable<decimal> totalDryWeight { get; set; }
        //public Nullable<decimal> totalWetWeight { get; set; }

    }

    public class CollectionQRStatusResult
    {
        public  string ReferanceId { get; set; }
        public string status { get; set; }
        public string message { get; set; }
        public string messageMar { get; set; }
    }

    public class CollectionAppAreaLatLong
    {
        public int AppId { get; set; }
        public string AppAreaLatLong { get; set; }

        public bool ? IsAreaActive { get; set; }


    }
}
