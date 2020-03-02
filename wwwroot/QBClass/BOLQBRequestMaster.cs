using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace wwwroot.QBClass
{
    public class BOLQBRequestMaster
    {
        public int? ID
        {
            get;
            set;
        }

        public int? IsSync
        {
            get;
            set;
        }

        public int? IsUpdate
        {
            get;
            set;
        }

        public string ListID
        {
            get;
            set;
        }

        public DateTime? QBSyncDate
        {
            get;
            set;
        }

        public DateTime? LastSyncDate
        {
            get;
            set;
        }

        public bool? IsActive
        {
            get; set;
        }

    }
}