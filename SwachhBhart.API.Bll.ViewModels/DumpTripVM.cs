using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwachhBhart.API.Bll.ViewModels
{
  public  class DumpTripVM
    {
        public String transId { get; set; }
        public String startDateTime { get; set; }
        public String endDateTime { get; set; } /// UserTypeID i.e. 0 = Ghanta Gadi, 1 = Scanify , 2 = Waste Management
        public int userId { get; set; }
        public String dyId { get; set; }
        public String houseList { get; set; }
        public  int tripNo { get; set; }
        public string vehicleNumber { get; set; }
        public decimal totalGcWeight { get; set; }
        public decimal totalDryWeight { get; set; }
        public decimal totalWetWeight { get; set; }
    }
}
