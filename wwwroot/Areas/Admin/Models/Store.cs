using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace wwwroot.Areas.Admin.Models
{
    public class Store_Create
    {
        public int Id { get; set; }
        [RegularExpression(@"^([A-Za-z0-9-@#&+\w\s]{3,})+$", ErrorMessage = "Minimum 3 letters, Store Name can contain only this special characters like   @ # & _ - +  Space ")]
        [Required(ErrorMessage = " ")]
        public string Name { get; set; }
        [Required(ErrorMessage = " ")]
        public string Address { get; set; }
        
        public string Address2 { get; set; }
        [Required(ErrorMessage = " ")]
        //[RegularExpression(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}", ErrorMessage = "Not valid Phone number")]
        public string StoreNo { get; set; }
        [Required(ErrorMessage = " ")]
        //[RegularExpression(@"^(\+?\d{1,}(\s?|\-?)\d*(\s?|\-?)\(?\d{2,}\)?(\s?|\-?)\d{3,}\s?\d{3,})$", ErrorMessage = "Not valid Fax Number")]
        public string FaxNo { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
        [Required(ErrorMessage = " ")]
        public int Back_Office_userid { get; set; }
        public List<ddllist> BindBack_Office { get; set; }
        [Required(ErrorMessage = " ")]
        public int Store_Man_userid { get; set; }
        public List<ddllist> BindStore_manager { get; set; }
        [Required(ErrorMessage = " ")]
        public int Data_app_userid { get; set; }
        public List<ddllist> BindData_app { get; set; }
        [Required(ErrorMessage = " ")]
        public int Owner_userid { get; set; }
        public List<ddllist> BindData_Owner { get; set; }
        [Required(ErrorMessage = " ")]
        public string Storename_Data_app { get; set; }
        [Required(ErrorMessage = " ")]
        public string Storename_Owner { get; set; }
        public int rolefalg { get; set; }

        [Required(ErrorMessage = " ")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Enter Valid E-Mail Address")]
        public string EmailId { get; set; }
        //[Required(ErrorMessage = " ")]
        [DataType(DataType.Password)]        
        public string Password { get; set; }
        
    }
    public class Store_Edit
    {
        public int Id { get; set; }
        [RegularExpression(@"^([A-Za-z0-9-@#&+\w\s]{3,})+$", ErrorMessage = "Minimum 3 letters, Store Name can contain only this special characters like   @ # & _ - +   ")]
        [Required(ErrorMessage = " ")]
        public string Name { get; set; }
        [Required(ErrorMessage = " ")]
        public string Address { get; set; }
       
        public string Address2 { get; set; }
        [Required(ErrorMessage = " ")]
        //[RegularExpression(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}", ErrorMessage = "Not valid Phone number")]
        public string StoreNo { get; set; }

        //[RegularExpression(@"^(\+?\d{1,}(\s?|\-?)\d*(\s?|\-?)\(?\d{2,}\)?(\s?|\-?)\d{3,}\s?\d{3,})$", ErrorMessage = "Not valid Fax Number")]
        public string FaxNo { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
        [Required(ErrorMessage = " ")]
        public int Back_Office_userid { get; set; }
        public List<ddllist> BindBack_Office { get; set; }
        [Required(ErrorMessage = " ")]
        public int Store_Man_userid { get; set; }
        public List<ddllist> BindStore_manager { get; set; }
        [Required(ErrorMessage = " ")]
        public int Data_app_userid { get; set; }
        public List<ddllist> BindData_app { get; set; }
        [Required(ErrorMessage = " ")]
        public int Owner_userid { get; set; }
        public List<ddllist> BindData_Owner { get; set; }
        public List<UserBackoffice> UserBackoffice { get; set; }

        public List<UserStoreMan> UserStoreMan { get; set; }

        public List<UserDataApp> UserDataApp { get; set; }
        [Required(ErrorMessage = " ")]
        public string Storename_Data_app { get; set; }
        public List<UserDataAppmulti> Storename_Data_app_list { get; set; }

        public List<UserDataApp> UserOwner { get; set; }
        [Required(ErrorMessage = " ")]
        public string Storename_Owner { get; set; }
        public List<UserOwnermulti> Storename_Owner_list { get; set; }
        public int storeflag { get; set; }

        [Required(ErrorMessage = " ")]
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Enter Valid E-Mail Address")]
        public string EmailId { get; set; }
        //[Required(ErrorMessage = " ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
    public class UserDataAppmulti
    {
        public string UserDataAppmultis { get; set; }

    }
    public class UserOwnermulti
    {
        public string UserOwnermultis { get; set; }

    }
    public class UserBackoffice
    {
        public string UserBackoffices { get; set; }

    }
    public class UserStoreMan
    {
        public string UserStoreMans { get; set; }
    }
    public class UserDataApp
    {
        public string UserDataApps { get; set; }
    }
    public class Store_Select
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string StoreNo { get; set; }
  
        public string Address2 { get; set; }
        public string FaxNo { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public int Back_Office_userid { get; set; }
        public List<ddllist> BindBack_Office { get; set; }
        public int Store_Man_userid { get; set; }
        public List<ddllist> BindStore_manager { get; set; }
        public int Data_app { get; set; }
        public List<ddllist> BindData_app { get; set; }
        public string rolename { get; set; }
        public string username { get; set; }

        public string EmailId { get; set; }
    }
}