using net.openstack.Core.Domain;
using net.openstack.Providers.Rackspace;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace wwwroot.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string foldername = Path.Combine("product", "small");
            //Clouduploader.UploadDocument(foldername, "test.png", "wsmanagementsys", Request.PhysicalApplicationPath + "/userfiles/test.png");
            //Clouduploader.UploadDocument("scanimage", "1158QuotationOrderConfirmationFormat.pdf", "wsmanagementsys", Request.PhysicalApplicationPath + "/userfiles/scanimage/1158QuotationOrderConfirmationFormat.pdf");
            DeleteDocument("scanimage", "668BuildingDetail.pdf", "wsmanagementsys");

            return View();
        }
        public static bool DeleteDocument(string foldername, string filename, string chosenContainer)
        {
            GC.Collect();
            string region = "ORD";
            string username = "nitinrpatel";
            string api_key = "8492a8ec4a36138aeb469a2a5df07ff5";
            var cloudIdentity = new CloudIdentity() { APIKey = api_key, Username = username };
            var cloudFilesProvider = new CloudFilesProvider(cloudIdentity);
            
            if (!string.IsNullOrEmpty(filename))
            {
                if (foldername != "")
                {
                    chosenContainer = Path.Combine(chosenContainer, foldername);
                }
                cloudFilesProvider.DeleteObject(chosenContainer, filename);
            }
            try
            {

            }
            catch
            {
            }
            return true;
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}