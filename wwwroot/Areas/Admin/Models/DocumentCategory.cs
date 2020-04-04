using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace wwwroot.Areas.Admin.Models
{
    public class DocumentCategory1
    {
        public int Id { get; set; }
        [RegularExpression(@"^([A-Za-z0-9-@#&+\w\s]{3,})+$", ErrorMessage = "Minimum 3 letters,Category Name can contain only this special characters like   @ # & _ - +  Space ")]
        [Required(ErrorMessage = " ")]
        public string Name { get; set; }
    }
}