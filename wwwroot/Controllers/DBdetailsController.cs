using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Routing;

namespace wwwroot.Controllers
{
    public class DBdetailsController : ApiController
    {
        public HttpResponseMessage Get(string id)
        {
            var response = this.Request.CreateResponse(HttpStatusCode.OK);
            if (id == "a579bc73-72b5-483d-bfeb-4b5822fde918")
            {
                CLSCredentail Data = new CLSCredentail();
                //Data.Hostname = "mssql1405/inst1";
                //Data.ManagementIP = "207.246.248.242,4120";
                //Data.Username = "350147_wsmgusr";
                //Data.Password = "Google$2018";
                //Data.Databasename = "350147_wsmanagementdb";
                //string json_String = JsonConvert.SerializeObject(Data, Formatting.Indented);
                //response.Content = new StringContent(json_String, Encoding.UTF8, "application/json");

                Data.Hostname = "mssql1401/inst1";
                Data.ManagementIP = "207.246.242.241,4120";
                Data.Username = "593956_syndbusr";
                Data.Password = "Google$2018";
                Data.Databasename = "593956_synthesisdb";
                string json_String = JsonConvert.SerializeObject(Data, Formatting.Indented);
                response.Content = new StringContent(json_String, Encoding.UTF8, "application/json");
            }
            else
            {
                string json_String = "";
                response.Content = new StringContent(json_String, Encoding.UTF8, "application/json");
            }
            return response;
        }
        public class CLSCredentail
        {
            public string Hostname { get; set; }
            public string ManagementIP { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Databasename { get; set; }
        }
    }
}
