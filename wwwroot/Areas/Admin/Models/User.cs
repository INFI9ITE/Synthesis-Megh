using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace wwwroot.Areas.Admin.Models
{
    public class User_Create
    {
        public int id { get; set; }
        [Required(ErrorMessage = " ")]
        [RegularExpression(@"^([a-zA-Z ]{3,})*$", ErrorMessage = "Minimum 3 letters,No Number or special character")]
        public string Name { get; set; }
        //[Required(ErrorMessage = " ")]
        //[RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Enter Valid E-Mail Address")]
        //public string Email { get; set; }
        [Required(ErrorMessage = " ")]
        [RegularExpression(@"^([A-Za-z0-9-@#&+\w\s]{3,})+$", ErrorMessage = "Minimum 3 letters, User Name can contain only this special characters like   @ # & _ - +   ")]
        public string UserName { get; set; }
        [Required(ErrorMessage = " ")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password required at least 8 characters, 1 capital letter, 1 number, and one special character")]
        public string Password { get; set; }
        [Required(ErrorMessage = " ")]
        [Compare("Password", ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; }

        public Nullable<int> Roleid { get; set; }
        [Required(ErrorMessage = " ")]
        public string rolename { get; set; }
        public List<ddllist> BindRoleList { get; set; }


        //public Nullable<int> Storeid { get; set; }
        //[Required(ErrorMessage = " ")]
        //public string Storename { get; set; }

        //public List<ddllist> BindStoreList { get; set; }

        public Nullable<int> userid { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }

    }
    public class ddllist
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public int selectedvalue { get; set; }
        public bool selected_value { get; set; }
    }
    public class GroupData
    {
        public string Deptname { get; set; }
        public int? DeptId { get; set; }
        public string memo { get; set; }
        public string typicalbalance { get; set; }
        public int? typicalBalId { get; set; }
    }
    public class ddllist1
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public bool selectedvalue { get; set; }
    }
    public class User_Select
    {
        public int id { get; set; }

        public string Name { get; set; }

        //public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public Nullable<int> Roleid { get; set; }

        public string rolename { get; set; }
        public List<ddllist> BindRoleList { get; set; }


        public string Rolename { get; set; }
        //public Nullable<int> Storeid { get; set; }

        //public string Storename { get; set; }

        //public List<ddllist> BindStoreList { get; set; }

        public Nullable<int> userid { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public bool IsLock { get; set; }
        public int Reg_userid { get; set; }

        public List<string> BindStorename { get; set; }
        public List<UserStore> UserStore { get; set; }
    }
    public class User_Store
    {
        public int id { get; set; }

        public string Name { get; set; }

        //public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public Nullable<int> Roleid { get; set; }

        public string rolename { get; set; }
        public List<ddllist> BindRoleList { get; set; }


        //public Nullable<int> Storeid { get; set; }

        //public string Storename { get; set; }

        //public List<ddllist> BindStoreList { get; set; }

        public Nullable<int> userid { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public bool IsLock { get; set; }
        public int Reg_userid { get; set; }

        public List<string> BindStorename { get; set; }
        public List<UserStore> UserStore { get; set; }

        //[Required(ErrorMessage = " ")]
        public List<int> Back_Office_userid { get; set; }
       // [Required(ErrorMessage = " ")]
        public List<ddllist> BindBack_Office { get; set; }
        //[Required(ErrorMessage = " ")]
        public int Store_Man_userid { get; set; }
        public List<ddllist> BindStore_manager { get; set; }
        //[Required(ErrorMessage = " ")]
        public int Data_app_userid { get; set; }
        public List<ddllist> BindData_app { get; set; }
    }
    public class User_Edit
    {
        public int id { get; set; }
        [Required(ErrorMessage = " ")]
        [RegularExpression(@"^([a-zA-Z ]{3,})*$", ErrorMessage = "Minimum 3 letters,No Number or special character")]
        public string Name { get; set; }
        //[Required(ErrorMessage = " ")]
        //[RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Enter Valid E-Mail Address")]
        //public string Email { get; set; }
        [Required(ErrorMessage = " ")]
        [RegularExpression(@"^([A-Za-z0-9-@#&+\w\s]{3,})+$", ErrorMessage = "Minimum 3 letters, User Name can contain only this special characters like   @ # & _ - +   ")]
        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public Nullable<int> Roleid { get; set; }
        [Required(ErrorMessage = " ")]
        public string rolename { get; set; }
        public int flag { get; set; }
        public List<ddllist> BindRoleList { get; set; }


        //public Nullable<int> Storeid { get; set; }
        //[Required(ErrorMessage = " ")]
        //public string Storename { get; set; }

        //public List<ddllist> BindStoreList { get; set; }

        public Nullable<int> userid { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public List<UserStore> UserStore { get; set; }
        public List<UserRole> UserRole { get; set; }
        public int Reg_userid { get; set; }
    }
    public class UserStore
    {
        public string UserStores { get; set; }

    }
    public class UserRole
    {
        public string Value { get; set; }
        public string Text { get; set; }
        public int selectedvalue { get; set; }
    }
    public class User_Resetpassword
    {
        public int Reg_userid { get; set; }
        [Required(ErrorMessage = " ")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password required at least 8 characters, 1 capital letter, 1 number, and one special character")]
        public string Password { get; set; }
        [Required(ErrorMessage = " ")]
        [Compare("Password", ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; }
    }

    #region For Employee
    public class Employee_Create
    {
        public int id { get; set; }
        public string Name { get; set; }
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Enter Valid E-Mail Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = " ")]
        [RegularExpression(@"^([A-Za-z0-9-@#&+\w\s]{3,})+$", ErrorMessage = "Minimum 3 letters, Employee ID can contain only this special characters like   @ # & _ - +   ")]
        public string Employeeid { get; set; }
        [Required(ErrorMessage = " ")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password required at least 8 characters, 1 capital letter, 1 number, and one special character")]
        public string Password { get; set; }
        [Required(ErrorMessage = " ")]
        [Compare("Password", ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; }
        //public Nullable<int> Roleid { get; set; }
        //[Required(ErrorMessage = " ")]
        //public string rolename { get; set; }
        //public List<ddllist> BindRoleList { get; set; }
        public Nullable<int> Reg_userid { get; set; }
        public Nullable<int> userid { get; set; }
        [Required(ErrorMessage = " ")]
        [RegularExpression(@"^([a-zA-Z ]{3,})*$", ErrorMessage = "Minimum 3 letters,No Number or special character")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = " ")]
        [RegularExpression(@"^([a-zA-Z ]{3,})*$", ErrorMessage = "Minimum 3 letters,No Number or special character")]
        public string LastName { get; set; }
        [RegularExpression(@"^([a-zA-Z ]{3,})*$", ErrorMessage = "Minimum 3 letters,No Number or special character")]
        public string SecondName { get; set; }
        [Required(ErrorMessage = " ")]
        public DateTime? Birthday { get; set; }
        [Required(ErrorMessage = " ")]
        public string SocSecurityNo { get; set; }

        [Required(ErrorMessage = " ")]
        public Nullable<int> Genderid { get; set; }
                public string Gender { get; set; }
        public List<ddllist> BindGender{ get; set; }

        public Nullable<int> MaritalStatusid { get; set; }
        public string MaritalStatus { get; set; }
        public List<ddllist> BindMaritalStatus { get; set; }

        public string Photo { get; set; }
        public string EmpDoc { get; set; }
        public string EmpNote { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Street { get; set; }
        public string AptSuiteBuilding { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [RegularExpression(@"^[0-9]{5}(?:-[0-9]{4})?$", ErrorMessage = "Valid Zipcode")]
       
        public string ZipCode { get; set; }
        [Required(ErrorMessage = " ")]
        public Nullable<System.DateTime> HireDate { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }

        [Required(ErrorMessage = " ")]
        public Nullable<int> Storeid { get; set; }
        public string Storename { get; set; }
        public List<ddllist> BindStore { get; set; }

        [Required(ErrorMessage = " ")]
        public Nullable<int> Deptid { get; set; }
        public string Department { get; set; }
        public List<ddllist> BindDepartment { get; set; }

     
       
        [Required(ErrorMessage = " ")]
        public Nullable<int> EmpTypeid { get; set; }
        public string EmploymentType { get; set; }
        public List<ddllist> BindEmploymentType { get; set; }


        
        [Required(ErrorMessage = " ")]
        public Nullable<int> EmpStatusId { get; set; }
        public string EmploymentStatus { get; set; }
        public List<ddllist> BindEmploymentStatus { get; set; }

        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }

    }

    public class Employee_Edit
    {
        public int id { get; set; }
        public string Name { get; set; }
        [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Enter Valid E-Mail Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = " ")]
        [RegularExpression(@"^([A-Za-z0-9-@#&+\w\s]{3,})+$", ErrorMessage = "Minimum 3 letters, Employee ID can contain only this special characters like   @ # & _ - +   ")]
        public string Employeeid { get; set; }
        [Required(ErrorMessage = " ")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$", ErrorMessage = "Password required at least 8 characters, 1 capital letter, 1 number, and one special character")]
        public string Password { get; set; }
        [Required(ErrorMessage = " ")]
        [Compare("Password", ErrorMessage = "Password doesn't match.")]
        public string ConfirmPassword { get; set; }
        //public Nullable<int> Roleid { get; set; }
        //[Required(ErrorMessage = " ")]
        //public string rolename { get; set; }
        //public List<ddllist> BindRoleList { get; set; }
        public Nullable<int> Reg_userid { get; set; }
        public Nullable<int> userid { get; set; }
        [Required(ErrorMessage = " ")]
        [RegularExpression(@"^([a-zA-Z ]{3,})*$", ErrorMessage = "Minimum 3 letters,No Number or special character")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = " ")]
        [RegularExpression(@"^([a-zA-Z ]{3,})*$", ErrorMessage = "Minimum 3 letters,No Number or special character")]
        public string LastName { get; set; }
        [RegularExpression(@"^([a-zA-Z ]{3,})*$", ErrorMessage = "Minimum 3 letters,No Number or special character")]
        public string SecondName { get; set; }
        [Required(ErrorMessage = " ")]
        public DateTime? Birthday { get; set; }
        [Required(ErrorMessage = " ")]
        public string SocSecurityNo { get; set; }

        [Required(ErrorMessage = " ")]
        public Nullable<int> Genderid { get; set; }
        public string Gender { get; set; }
        public List<ddllist> BindGender { get; set; }

        public Nullable<int> MaritalStatusid { get; set; }
        public string MaritalStatus { get; set; }
        public List<ddllist> BindMaritalStatus { get; set; }

        public string Photo { get; set; }
        public string EmpDoc { get; set; }
        public string EmpNote { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Street { get; set; }
        public string AptSuiteBuilding { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        [RegularExpression(@"^[0-9]{5}(?:-[0-9]{4})?$", ErrorMessage = "Valid Zipcode")]

        public string ZipCode { get; set; }
        [Required(ErrorMessage = " ")]
        public Nullable<System.DateTime> HireDate { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }

        [Required(ErrorMessage = " ")]
        public Nullable<int> Storeid { get; set; }
        public string Storename { get; set; }
        public List<ddllist> BindStore { get; set; }

        [Required(ErrorMessage = " ")]
        public Nullable<int> Deptid { get; set; }
        public string Department { get; set; }
        public List<ddllist> BindDepartment { get; set; }



        [Required(ErrorMessage = " ")]
        public Nullable<int> EmpTypeid { get; set; }
        public string EmploymentType { get; set; }
        public List<ddllist> BindEmploymentType { get; set; }



        [Required(ErrorMessage = " ")]
        public Nullable<int> EmpStatusId { get; set; }
        public string EmploymentStatus { get; set; }
        public List<ddllist> BindEmploymentStatus { get; set; }

        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }

    }

    public class Employee_Select
    {
        public int id { get; set; }
        public string Name { get; set; }     
        public string Email { get; set; }       
        public string Employeeid { get; set; }        
        public string Password { get; set; }      
        public string ConfirmPassword { get; set; }
        //public Nullable<int> Roleid { get; set; }
        //[Required(ErrorMessage = " ")]
        //public string rolename { get; set; }
        //public List<ddllist> BindRoleList { get; set; }
        public Nullable<int> Reg_userid { get; set; }
        public Nullable<int> userid { get; set; }      
        public string FirstName { get; set; }       
        public string LastName { get; set; }        
        public string SecondName { get; set; }      
        public DateTime? Birthday { get; set; }
        public string SocSecurityNo { get; set; }
        public Nullable<int> Genderid { get; set; }
        public string Gender { get; set; }
        public List<ddllist> BindGender { get; set; }
        public Nullable<int> MaritalStatusid { get; set; }
        public string MaritalStatus { get; set; }
        public List<ddllist> BindMaritalStatus { get; set; }
        public string Photo { get; set; }
        public string EmpDoc { get; set; }
        public string EmpNote { get; set; }
        public string HomePhone { get; set; }
        public string MobilePhone { get; set; }
        public string Street { get; set; }
        public string AptSuiteBuilding { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public Nullable<System.DateTime> HireDate { get; set; }
        public Nullable<System.DateTime> TerminationDate { get; set; }
        public Nullable<int> Storeid { get; set; }
        public string Storename { get; set; }
        public List<ddllist> BindStore { get; set; }
        public Nullable<int> Deptid { get; set; }
        public string Department { get; set; }
        public List<ddllist> BindDepartment { get; set; }
        public Nullable<int> EmpTypeid { get; set; }
        public string EmploymentType { get; set; }
        public List<ddllist> BindEmploymentType { get; set; }
        public Nullable<int> EmpStatusId { get; set; }
        public string EmploymentStatus { get; set; }
        public List<ddllist> BindEmploymentStatus { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public string rolename { get; set; }
        public bool IsLock { get; set; }
    }
    #endregion
}