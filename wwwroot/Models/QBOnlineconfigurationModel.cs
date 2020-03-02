using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wwwroot.Models
{
    public class QBOnlineconfigurationModel
    {
        public int ID { get; set; }
        public string RealmID { get; set; }
        public string ClientId { get; set; }
        public string ClientSecretKey { get; set; }
        public string QBToken { get; set; }
        public string QBRefreshToken { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UserID { get; set; }
        public Nullable<System.DateTime> Updateddate { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> StoreId { get; set; }
        public string LogStatus
        {
            get;
            set;
        }
        public string Para { get; set; }
    }
}