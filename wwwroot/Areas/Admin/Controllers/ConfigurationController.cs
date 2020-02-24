using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using wwwroot.Areas.Admin.Models;
using wwwrootBL.Entity;

namespace wwwroot.Areas.Admin.Controllers
{
    public class ConfigurationController : Controller
    {
        WestZoneEntities db = new WestZoneEntities();
        protected static string StatusMessage = "";
        // GET: Admin/Configuration
        public ActionResult Index()
        {
            Configuration configuration = new Configuration();

            int storeid = 0;
            if (Convert.ToString(Session["storeid"]) != "0")
            {
                storeid = Convert.ToInt32(Session["storeid"]);
                //configuration.Configrationlist = (from data in db.Get_UniqueTendersInDrawer(storeid)
                //                                  orderby data.title ascending
                //                                  select new Configurationlist
                //                                  {
                //                                      tendername = data.title.ToString(),
                //                                      Storeid = storeid,
                //                                      GroupList = (from a in db.tbl_GroupName
                //                                                   orderby a.name ascending
                //                                                   select new DrpList
                //                                                   {
                //                                                       Id = a.id,
                //                                                       Name = a.name.Replace("&amp;", "&")
                //                                                   }).ToList()
                //                                                  ,

                //                                  }).ToList();
                configuration.Configrationlist = (from data in db.sp_getTenderAccountsStoreWise(storeid)
                                                      //orderby data.id descending
                                                  select new Configurationlist
                                                  {
                                                      Groupname = data.GroupId.ToString(),
                                                      groupid = data.GroupId,
                                                      Storeid = storeid,
                                                      typicalbalid = data.typicalbalid,
                                                      typicalbalance = data.typicalBalName,
                                                      Deptid = data.deptid,
                                                      flag=data.flag,
                                                      GroupList = (from a in db.tbl_GroupName
                                                                   orderby a.name ascending
                                                                   select new DrpList
                                                                   {
                                                                       Id = a.id,
                                                                       Name = a.name.Replace("&amp;", "&")
                                                                   }).ToList(),
                                                      Deptname = data.DeptName,
                                                      memo = data.Memo,
                                                      tendername = data.Title
                                                  }).ToList();
                ViewBag.StatusMessage = StatusMessage;
                StatusMessage = "";
            }
            else
            {
                ViewBag.StatusMessage = "NoStoreSelected";
            }

            return View(configuration);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(int[] Deptid = null, int[] groupid = null, int[] Storeid = null, int[] typicalbalid = null, string[] memoidval = null, string[] tendername = null)
        {
            if (groupid != null && groupid.Count() > 0)
            {
                var success = "";
                for (int i = 0; i < groupid.Count(); i++)
                {
                    //if (Deptid[i] != 0)
                    //{
                    var exists = db.CheckExist_Configuration(groupid[i]).Select(x => x.Value).FirstOrDefault();
                    if (exists == 0)
                    {
                        success = db.Insert_Configuration(Deptid[i], Storeid[i], groupid[i], memoidval[i], typicalbalid[i], tendername[i]).ToString();
                    }
                    else
                    {
                        success = db.Insert_Configuration(Deptid[i], Storeid[i], groupid[i], memoidval[i], typicalbalid[i], tendername[i]).ToString();
                    }
                    //}
                    StatusMessage = "Success";
                }
            }

            return RedirectToAction("Index");
        }

        public JsonResult BindGroupData(string groupid = null)
        {
            if (groupid != "" && groupid != null)
            {
                int groupval = Convert.ToInt32(groupid);
                var GroupData = (from a in db.tbl_GroupName
                                 where a.id == groupval
                                 select new GroupData
                                 {
                                     Deptname = (from b in db.tbl_Department where b.id == a.deptid select b.Name).FirstOrDefault(),
                                     DeptId = a.deptid,
                                     memo = a.memo,
                                     typicalBalId = a.Typicalbalanceid,
                                     typicalbalance = (from c in db.tbl_TypicalBalance_master where c.id == a.Typicalbalanceid select c.Name).FirstOrDefault(),
                                 }).ToList();
                return Json(new { DeptId = GroupData[0].DeptId, typicalBalId = GroupData[0].typicalBalId, Deptname = GroupData[0].Deptname, typicalbalance = GroupData[0].typicalbalance, memo = GroupData[0].memo }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { DeptId = 0, typicalBalId = 0, Deptname = "", typicalbalance = "", memo = "" }, JsonRequestBehavior.AllowGet);
            }
        }
    }

}