using MeghMailUtility;
using wwwrootBL.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace wwwroot.Class
{
    public class GlobalStore
    {
        public static string GlobalStore_id { get; set; }
        public static string GlobalStore_name { get; set; }
        //[HttpPost]
        //public static bool GetGlobalStore(string GlobalStoreid)
        //{
        //    GlobalStore_id = GlobalStoreid;

        //    return true;
        //}
        //public static string GetId()
        //{
        //    return GlobalStore_id;
        //}
    }

}