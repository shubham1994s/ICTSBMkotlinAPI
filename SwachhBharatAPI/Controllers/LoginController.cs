using Newtonsoft.Json;
using SwachhBharat.API.Bll.Repository.Repository;
using SwachhBhart.API.Bll.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace SwachhBharatAPI.Controllers
{
 
    [RoutePrefix("api/Account")]
    public class LoginController : ApiController
    {
        IRepository objRep;

        // GET: api/users

      //  [Authorize]
        [Route("Login")]
        [HttpPost]
        public SBUser GetLogin(SBUser objlogin)
        {
            IEnumerable<string> headerValue1 = Request.Headers.GetValues("appId");
            var id = headerValue1.FirstOrDefault();
            int AppId = int.Parse(id);

            objRep = new Repository();
            SBUser objresponse = objRep.CheckUserLogin(objlogin.userLoginId, objlogin.userPassword, objlogin.imiNo, AppId, objlogin.EmpType);
            return objresponse;
        }

        //Added By Saurbh
        // GET: api/admins
        [Route("AdminLogin")]
        [HttpPost]
        public SBAdmin GetAdminLogin(SBAdmin objadminlogin)
        {
            //IEnumerable<string> headerValue1 = Request.Headers.GetValues("appId");
            //var id = headerValue1.FirstOrDefault();
            //int AppId = int.Parse(id);
            
            objRep = new Repository();

            SBAdmin objresponse = objRep.CheckAdminLogin(objadminlogin.adminLoginId,objadminlogin.adminPassword);
            return objresponse;
        }


        ////Added By Saurbh (16 May 19)
        //// GET: api/admins
        //[Route("EmployeeLogin")]
        //[HttpPost]
        //public BigVQrEmployeeVM GetQrEmployeeLogin(BigVQrEmployeeVM objEmployeeLogin)
        //{
        //    //IEnumerable<string> headerValue1 = Request.Headers.GetValues("appId");
        //    //var id = headerValue1.FirstOrDefault();
        //    //int AppId = int.Parse(id);

        //    objRep = new Repository();

        //    BigVQrEmployeeVM objresponse = objRep.CheckQrEmployeeLogin(objEmployeeLogin.qrEmpLoginId, objEmployeeLogin.qrEmpPassword);
        //    return objresponse;
        //}

        [Route("HouseTrail")]

        [HttpPost]
        public List<DumpTripStatusResult> HouseTrail([FromBody] List<Trial> obj)
        {

            Trial tn = new Trial();
            List<DumpTripStatusResult> objres = new List<DumpTripStatusResult>();
            HttpClient client = new HttpClient();
            foreach (var item in obj)
            {
                tn.startTs = item.startTs;
                tn.endTs = item.endTs;
                tn.createUser = item.createUser;
                tn.geom = item.geom;             
                var json = JsonConvert.SerializeObject(tn, Formatting.Indented);
                var stringContent = new StringContent(json);
                stringContent.Headers.ContentType.MediaType = "application/json";
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsync("http://114.143.244.130:9091/house-map-trail/add", stringContent);
                HttpResponseMessage rs = response.Result;    
                var responseString = rs.Content.ReadAsStringAsync().Result;
                var dynamicobject = JsonConvert.DeserializeObject<dynamic>(responseString);
                objres.Add(new DumpTripStatusResult()
                {
                    code = dynamicobject.code.ToString(),
                    status = dynamicobject.status.ToString(),
                    message = dynamicobject.message.ToString(),
                    errorMessages = dynamicobject.errorMessages.ToString(),
                    timestamp = dynamicobject.timestamp.ToString(),
                    data = dynamicobject.data.ToString()
                });

            }          
            return objres;

        }


        [Route("HouseAdd")]

        [HttpPost]
        public List<DumpTripStatusResult> HouseAdd([FromBody] List<AddHouse> obj)
        {

            AddHouse tn = new AddHouse();
            List<DumpTripStatusResult> objres = new List<DumpTripStatusResult>();
            HttpClient client = new HttpClient();
            foreach (var item in obj)
            {
                tn.houseId = item.houseId;
                tn.createUser = item.createUser;
                tn.geom = item.geom;
                var json = JsonConvert.SerializeObject(tn, Formatting.Indented);
                var stringContent = new StringContent(json);
                stringContent.Headers.ContentType.MediaType = "application/json";
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var response = client.PostAsync("http://114.143.244.130:9091/house/add", stringContent);
                HttpResponseMessage rs = response.Result;
                var responseString = rs.Content.ReadAsStringAsync().Result;
                var dynamicobject = JsonConvert.DeserializeObject<dynamic>(responseString);
                var datalist= JsonConvert.DeserializeObject<dynamic>(dynamicobject.data.ToString());

                objres.Add(new DumpTripStatusResult()
                {
                    code = dynamicobject.code.ToString(),
                    status = dynamicobject.status.ToString(),
                    message = dynamicobject.message.ToString(),
                    errorMessages = dynamicobject.errorMessages.ToString(),
                    timestamp = dynamicobject.timestamp.ToString(),
                    data = datalist
                });

            }
            return objres;

        }




    }
}
