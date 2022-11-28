using Newtonsoft.Json;
using SwachhBharat.API.Bll.Repository.Repository;
using SwachhBhart.API.Bll.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;


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

        [Route("Post")]
       
        [HttpPost]
        public  IHttpActionResult Post([FromBody] Trial obj)
        {

            List<Trial> obj2 = new List<Trial>();
            //var values = new Dictionary<string, string>{
            //                                                 obj.
            //                                            };
            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(obj, Formatting.Indented);
            var stringContent = new StringContent(json);
          
            stringContent.Headers.ContentType.MediaType = "application/json";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

          

            var response =  client.PostAsync("http://114.143.244.130:9091/house-map-trail/add", stringContent);
            // var responseString =  response();

            //    var responseString =  response.con.ReadAsStringAsync();

            // var res= Ok(responseString);
            //  return responseString;
            HttpResponseMessage rs = response.Result;
            

            var responseString = rs.Content.ReadAsStringAsync().Result;
            obj2 = JsonConvert.DeserializeObject<List<Trial>>(responseString);

           //return View(EmpDetails);
         //   var rse = responseString.d;
            return Ok(obj2);

        }


    }
}
