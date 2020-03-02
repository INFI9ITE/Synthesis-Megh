using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wwwroot.Models
{
    public class QBWebConnectorMappingModel
    {
        public int ID { get; set; }
        public int WebCompanyID { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string QBCompanyPath { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string Password { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.Guid OwnerID { get; set; }
        public System.Guid FileID { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "This Field is Required")]
        public string AppName { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<int> StoreId { get; set; }
        public string Para { get; set; }
    }
}