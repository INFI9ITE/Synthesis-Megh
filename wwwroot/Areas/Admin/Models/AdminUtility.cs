using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wwwroot.Areas.Admin.Models
{
    public partial class AdminUtility
    {
        public int id { get; set; }
        public string sitename { get; set; }

        //[FileExtensions(Extensions = ".jpg,.jpeg", ErrorMessage = "Enter Valid File")]
        public string sitelogo { get; set; }

        //[RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "Enter Valid URL")]
        public string siteurl { get; set; }

        public string MailServer { get; set; }

        //[RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Enter Valid E-Mail Address")]
        public string from { get; set; }

        //[RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Enter Valid E-Mail Address")]
        public string cc { get; set; }

        public string username { get; set; }
        public string Password { get; set; }
        public Nullable<int> Authenticate { get; set; }

        //[FileExtensions(Extensions = ".jpg,.jpeg", ErrorMessage = "Enter Valid File")]
        public string emailtop { get; set; }

        //[Required, FileExtensions(Extensions = ".jpg,.jpeg", ErrorMessage = "Enter Valid File")]
        public string emailbottom { get; set; }


        //[StringLength(3, ErrorMessage = "Invalid Value")]
        //[DisplayFormat(DataFormatString = "{0:c}")]
        public Nullable<int> port { get; set; }


        //[StringLength(3, ErrorMessage = "Invalid Value")]
        //[DisplayFormat(DataFormatString = "{0:c}")]
        public Nullable<int> pagination { get; set; }


        public string sitebyname { get; set; }

        //[RegularExpression(@"^http(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*)?$", ErrorMessage = "Enter Valid URL")]
        public string sitebyurl { get; set; }
    }
}