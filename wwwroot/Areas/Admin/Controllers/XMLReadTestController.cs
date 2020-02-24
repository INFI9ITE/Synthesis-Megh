using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using wwwroot.Areas.Admin.Models;

namespace wwwroot.Areas.Admin.Controllers
{
    public class XMLReadTestController : Controller
    {
        // GET: Admin/XMLReadTest
        public ActionResult Index()
        {
            List<CustomerModel> customers = new List<CustomerModel>();

            //Load the XML file in XmlDocument.
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/userfiles/PO_21a_SalesActivitySummary.xml"));

            //Loop through the selected Nodes.1
            foreach (XmlNode node in doc.SelectNodes("/Group level/Group level"))
            {
                //Fetch the Node values and assign it to Model.
                customers.Add(new CustomerModel
                {
                    CustomerId = int.Parse(node["Id"].InnerText),
                    Name = node["Name"].InnerText,
                    Country = node["Country"].InnerText
                });
            }

            //Loop through the selected Nodes.2
            //XmlNodeList elemList = doc.GetElementsByTagName("Group Level");
            //for (int i = 0; i < elemList.Count; i++)
            //{
            //    Console.WriteLine(elemList[i].InnerXml);
            //}

            return View(customers);
        }
    }
}