using loginApi.Bl;
using loginApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mime;
using System.Web;
using System.Web.Http;
using System.DirectoryServices.AccountManagement;

namespace loginApi.Controllers
{

    public class LoginController : ApiController
    {

        
        [Route("Api/Login/InsertLoginDtl")]
        [HttpPost]
        public HttpResponseMessage InsertLoginDtl([FromBody]UserDetails dtl)
        {

            //string response = "";
            LoginBl bl = new LoginBl();
            if (bl.InsertLoginDtl(dtl.userName, dtl.password))
                return Request.CreateResponse(HttpStatusCode.OK);
            else
                return Request.CreateResponse(HttpStatusCode.InternalServerError);


        }
        
        [Route("Api/Login/CheckLoginDtl")]
        [HttpPost]
        public HttpResponseMessage CheckLoginDtl([FromBody]UserDetails dtl)
        {
            
            //string response = "";
            LoginBl bl = new LoginBl();
            if (bl.CheckLoginDtl(dtl.userName, dtl.password)) 
           
            return Request.CreateResponse(HttpStatusCode.OK); 
       else
                return Request.CreateResponse(HttpStatusCode.MethodNotAllowed);
        }

        

    }
}