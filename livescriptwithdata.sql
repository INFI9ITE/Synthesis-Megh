USE [593956_synthesisdb]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] DROP CONSTRAINT [fk_UserId]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] DROP CONSTRAINT [fk_RoleId]
GO
ALTER TABLE [dbo].[webpages_Membership] DROP CONSTRAINT [DF__webpages___Passw__267ABA7A]
GO
ALTER TABLE [dbo].[webpages_Membership] DROP CONSTRAINT [DF__webpages___IsCon__25869641]
GO
ALTER TABLE [dbo].[tbl_Vendor] DROP CONSTRAINT [DF_tbl_Vendor_IsActive]
GO
ALTER TABLE [dbo].[tbl_user] DROP CONSTRAINT [DF_tbl_user_IsActive]
GO
ALTER TABLE [dbo].[tbl_Type] DROP CONSTRAINT [DF_tbl_Type_IsActive]
GO
ALTER TABLE [dbo].[tbl_Store] DROP CONSTRAINT [DF_tbl_Store_IsActive]
GO
ALTER TABLE [dbo].[tbl_Status] DROP CONSTRAINT [DF_tbl_Status_IsActive]
GO
ALTER TABLE [dbo].[tbl_Invoice_Department] DROP CONSTRAINT [DF_tbl_Invoice_Department_IsActive]
GO
ALTER TABLE [dbo].[tbl_Invoice] DROP CONSTRAINT [DF_tbl_Invoice_NotificationColor]
GO
ALTER TABLE [dbo].[tbl_Invoice] DROP CONSTRAINT [DF__tbl_Invoi__IsSyn__3A179ED3]
GO
ALTER TABLE [dbo].[tbl_Invoice] DROP CONSTRAINT [DF_tbl_Invoice_IsActive]
GO
ALTER TABLE [dbo].[tbl_Department] DROP CONSTRAINT [DF_tbl_Department_StoreID]
GO
ALTER TABLE [dbo].[tbl_Department] DROP CONSTRAINT [DF_tbl_Department_IsActive]
GO
ALTER TABLE [dbo].[tbl_Activity_log] DROP CONSTRAINT [DF_tbl_Activity_log_IsActive]
GO
/****** Object:  Index [UQ__webpages__8A2B6160B53DAA49]    Script Date: 10/17/2018 10:15:00 AM ******/
ALTER TABLE [dbo].[webpages_Roles] DROP CONSTRAINT [UQ__webpages__8A2B6160B53DAA49]
GO
/****** Object:  Index [UQ__UserProf__C9F284566316A651]    Script Date: 10/17/2018 10:15:00 AM ******/
ALTER TABLE [dbo].[UserProfile] DROP CONSTRAINT [UQ__UserProf__C9F284566316A651]
GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP TABLE [dbo].[webpages_UsersInRoles]
GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP TABLE [dbo].[webpages_Roles]
GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP TABLE [dbo].[webpages_OAuthMembership]
GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP TABLE [dbo].[webpages_Membership]
GO
/****** Object:  Table [dbo].[Utilities]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP TABLE [dbo].[Utilities]
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP TABLE [dbo].[UserProfile]
GO
/****** Object:  Table [dbo].[tbl_Vendor]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP TABLE [dbo].[tbl_Vendor]
GO
/****** Object:  Table [dbo].[tbl_user_store]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP TABLE [dbo].[tbl_user_store]
GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP TABLE [dbo].[tbl_user]
GO
/****** Object:  Table [dbo].[tbl_Type]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP TABLE [dbo].[tbl_Type]
GO
/****** Object:  Table [dbo].[tbl_Store]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP TABLE [dbo].[tbl_Store]
GO
/****** Object:  Table [dbo].[tbl_Status]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP TABLE [dbo].[tbl_Status]
GO
/****** Object:  Table [dbo].[tbl_Pamentype]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP TABLE [dbo].[tbl_Pamentype]
GO
/****** Object:  Table [dbo].[tbl_Invoice_Department]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP TABLE [dbo].[tbl_Invoice_Department]
GO
/****** Object:  Table [dbo].[tbl_Invoice]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP TABLE [dbo].[tbl_Invoice]
GO
/****** Object:  Table [dbo].[tbl_Department]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP TABLE [dbo].[tbl_Department]
GO
/****** Object:  Table [dbo].[tbl_Activity_log]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP TABLE [dbo].[tbl_Activity_log]
GO
/****** Object:  Table [dbo].[tbl_Activity_action]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP TABLE [dbo].[tbl_Activity_action]
GO
/****** Object:  Table [dbo].[SiteConfiguration]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP TABLE [dbo].[SiteConfiguration]
GO
/****** Object:  Table [dbo].[QBConfig]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP TABLE [dbo].[QBConfig]
GO
/****** Object:  StoredProcedure [dbo].[webpages_Roles_byRolename]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[webpages_Roles_byRolename]
GO
/****** Object:  StoredProcedure [dbo].[Update_tbl_user_Password]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[Update_tbl_user_Password]
GO
/****** Object:  StoredProcedure [dbo].[Update_Employee_Password]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[Update_Employee_Password]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_Storemanager_edit]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_Storemanager_edit]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_Storemanager]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_Storemanager]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_select_StorebyUser]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_store_select_StorebyUser]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_Insert_StoreMan]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_store_Insert_StoreMan]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_Insert_Owner]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_store_Insert_Owner]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_Insert_DataApp]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_store_Insert_DataApp]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_Insert_BackOfficeMan]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_store_Insert_BackOfficeMan]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_Insert]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_store_Insert]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_delete]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_store_delete]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_By_Reg_userid]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_store_By_Reg_userid]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_Selectstore_Admin]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_Selectstore_Admin]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_Selectstore]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_Selectstore]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_Owner_edit]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_Owner_edit]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_Owner]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_Owner]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_name]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_name]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_Insert]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_Insert]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_GridData_byid]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_GridData_byid]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_GridData]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_GridData]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_DataApprover_edit]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_DataApprover_edit]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_DataApprover]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_DataApprover]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_byid]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_byid]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_backoffice_edit_new]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_backoffice_edit_new]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_backoffice_edit]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_backoffice_edit]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_backoffice]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_user_backoffice]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Store_Update]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_Store_Update]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Store_GridData]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_Store_GridData]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Store_exists]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_Store_exists]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Store_Create]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_Store_Create]
GO
/****** Object:  StoredProcedure [dbo].[tbl_store_byid]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_store_byid]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Insert_StoreManager]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_Insert_StoreManager]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Insert]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_Insert]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_GridData_ForPdf]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_GridData_ForPdf]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_GridData_ForExcel]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_GridData_ForExcel]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_GridData]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_GridData]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_exists_InNo_Edit]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_exists_InNo_Edit]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_exists_InNo]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_exists_InNo]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Department_Insert]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_Department_Insert]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Dashbord_GridData_StoreManager]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_Dashbord_GridData_StoreManager]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Dashbord_GridData_DataApp]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_Dashbord_GridData_DataApp]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Dashbord_GridData_Administrator]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_Dashbord_GridData_Administrator]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Dashbord_GridData]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_Dashbord_GridData]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Activity_log_Insert]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_Activity_log_Insert]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Acivity_Log_GridData]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[tbl_Acivity_Log_GridData]
GO
/****** Object:  StoredProcedure [dbo].[SPVendor]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[SPVendor]
GO
/****** Object:  StoredProcedure [dbo].[SPStore]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[SPStore]
GO
/****** Object:  StoredProcedure [dbo].[SPInvoiceDepartment]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[SPInvoiceDepartment]
GO
/****** Object:  StoredProcedure [dbo].[SPInvoice]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[SPInvoice]
GO
/****** Object:  StoredProcedure [dbo].[SPDepartment]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[SPDepartment]
GO
/****** Object:  StoredProcedure [dbo].[Select_RoleId_ByUserid]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[Select_RoleId_ByUserid]
GO
/****** Object:  StoredProcedure [dbo].[Membership_EnableUser]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[Membership_EnableUser]
GO
/****** Object:  StoredProcedure [dbo].[Membership_DisableUser]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[Membership_DisableUser]
GO
/****** Object:  StoredProcedure [dbo].[getusernames]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[getusernames]
GO
/****** Object:  StoredProcedure [dbo].[GetUser_dataApproval]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[GetUser_dataApproval]
GO
/****** Object:  StoredProcedure [dbo].[GetRoleNameListByUserId]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[GetRoleNameListByUserId]
GO
/****** Object:  StoredProcedure [dbo].[GetRoleNameList]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[GetRoleNameList]
GO
/****** Object:  StoredProcedure [dbo].[getrolebyusername]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[getrolebyusername]
GO
/****** Object:  StoredProcedure [dbo].[GetEmailId]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[GetEmailId]
GO
/****** Object:  StoredProcedure [dbo].[Get_roleid_rolename_byReg_userid]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[Get_roleid_rolename_byReg_userid]
GO
/****** Object:  StoredProcedure [dbo].[Get_ReguserId_edit_storeman]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[Get_ReguserId_edit_storeman]
GO
/****** Object:  StoredProcedure [dbo].[Get_ReguserId_edit_Owner]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[Get_ReguserId_edit_Owner]
GO
/****** Object:  StoredProcedure [dbo].[Get_ReguserId_edit_dataapp]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[Get_ReguserId_edit_dataapp]
GO
/****** Object:  StoredProcedure [dbo].[Get_ReguserId_edit]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[Get_ReguserId_edit]
GO
/****** Object:  StoredProcedure [dbo].[Get_InvoiceNotification_Grid]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[Get_InvoiceNotification_Grid]
GO
/****** Object:  StoredProcedure [dbo].[Get_InvoiceNotification]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[Get_InvoiceNotification]
GO
/****** Object:  StoredProcedure [dbo].[delete_multiple_userstores]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[delete_multiple_userstores]
GO
/****** Object:  StoredProcedure [dbo].[delete_multiple_userRole]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[delete_multiple_userRole]
GO
/****** Object:  StoredProcedure [dbo].[BindDataapproval]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[BindDataapproval]
GO
/****** Object:  StoredProcedure [dbo].[BindBackofficemanager]    Script Date: 10/17/2018 10:15:00 AM ******/
DROP PROCEDURE [dbo].[BindBackofficemanager]
GO
/****** Object:  StoredProcedure [dbo].[BindBackofficemanager]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[BindBackofficemanager]
as
select * From tbl_user  where roleid in (3,2) and 
Reg_userid not in  (select Reg_userid from tbl_user_store where Roleid=2)
GO
/****** Object:  StoredProcedure [dbo].[BindDataapproval]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[BindDataapproval]
@id int 
as
select * From tbl_user  where roleid in (3) and id !=@id
GO
/****** Object:  StoredProcedure [dbo].[delete_multiple_userRole]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[delete_multiple_userRole]
(
@userid int
)
as

delete webpages_UsersInRoles where userid=@userid
GO
/****** Object:  StoredProcedure [dbo].[delete_multiple_userstores]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[delete_multiple_userstores]

(

@Reg_userid int,
@Storeid int

)

as



delete tbl_user_store where Reg_userid=@Reg_userid and Storeid=@Storeid
GO
/****** Object:  StoredProcedure [dbo].[Get_InvoiceNotification]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
	CREATE Procedure [dbo].[Get_InvoiceNotification]



	(



	@userid int,



	@Store_id int



	)



	AS



	declare @roleid int



	set @roleid=(select roleid from tbl_user where Reg_userid=@userid)



	if (@roleid = 3)



	BEGIN



	select top(5) *,



	(select name from tbl_Store where id=tbl_Invoice.Store_id) as storename,



	(select Name from tbl_user where Reg_userid=tbl_Invoice.CreatedBy) as fullname



	 from tbl_Invoice  where IsStatus_id=1 and Store_id=@Store_id and IsActive=1 and createdby in(select Reg_userid from tbl_user where roleid=2) 



	END



	else if (@roleid = 4)



	BEGIN



		select top(5) *,



	(select name from tbl_Store where id=tbl_Invoice.Store_id) as storename,



	(select Name from tbl_user where Reg_userid=tbl_Invoice.CreatedBy) as fullname



	 from tbl_Invoice  where IsStatus_id=1 and Store_id=@Store_id and IsActive=1 and createdby in(select Reg_userid from tbl_user where roleid=3) 



	END



	else



	BEGIN



		select top(5) *,



	(select name from tbl_Store where id=tbl_Invoice.Store_id) as storename,



	(select Name from tbl_user where Reg_userid=tbl_Invoice.CreatedBy) as fullname



	 from tbl_Invoice  where id=0 and IsActive=1



	END
GO
/****** Object:  StoredProcedure [dbo].[Get_InvoiceNotification_Grid]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Get_InvoiceNotification_Grid]

	(

	@userid int,

	@Store_id int

	)

	AS

	declare @roleid int

	set @roleid=(select roleid from tbl_user where Reg_userid=@userid)

	if (@roleid = 3)

	BEGIN

	select *,

	(select name from tbl_Store where id=tbl_Invoice.Store_id) as storename,

	(select Name from tbl_user where Reg_userid=tbl_Invoice.CreatedBy) as fullname

	 from tbl_Invoice  where IsStatus_id=1 and IsActive=1 and Store_id=@Store_id and createdby in(select Reg_userid from tbl_user where roleid=2) 

	  order by id desc

	END

	else if (@roleid = 4)

	BEGIN

		select *,

	(select name from tbl_Store where id=tbl_Invoice.Store_id) as storename,

	(select Name from tbl_user where Reg_userid=tbl_Invoice.CreatedBy) as fullname

	 from tbl_Invoice  where IsStatus_id=1 and IsActive=1 and Store_id=@Store_id and createdby in(select Reg_userid from tbl_user where roleid=3) 

	  order by id desc

	END

	else

	BEGIN

	select *,

	(select name from tbl_Store where id=tbl_Invoice.Store_id) as storename,

	(select Name from tbl_user where Reg_userid=tbl_Invoice.CreatedBy) as fullname

	 from tbl_Invoice  where id=0 and IsActive=1

	  END
GO
/****** Object:  StoredProcedure [dbo].[Get_ReguserId_edit]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Get_ReguserId_edit]
(
@Storeid int
)
as
select * from tbl_user_store where Storeid=@Storeid and RoleId=2
GO
/****** Object:  StoredProcedure [dbo].[Get_ReguserId_edit_dataapp]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Get_ReguserId_edit_dataapp] 
(  
@Storeid int  
)  
as  
select * from tbl_user_store where Storeid=@Storeid and RoleId=3
GO
/****** Object:  StoredProcedure [dbo].[Get_ReguserId_edit_Owner]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Get_ReguserId_edit_Owner]

(  

@Storeid int  

)  

as  

select * from tbl_user_store where Storeid=@Storeid and RoleId=7
GO
/****** Object:  StoredProcedure [dbo].[Get_ReguserId_edit_storeman]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[Get_ReguserId_edit_storeman]  
(  
@Storeid int  
)  
as  
select * from tbl_user_store where Storeid=@Storeid and RoleId=4
GO
/****** Object:  StoredProcedure [dbo].[Get_roleid_rolename_byReg_userid]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Get_roleid_rolename_byReg_userid] 
(
@Reg_userid int
)
as
--declare @lstr varchar(200)
--set @lstr = (select RoleId from webpages_UsersInRoles where UserId=@Reg_id)

select *,
(select RoleName from webpages_Roles where RoleId=webpages_UsersInRoles.RoleId) as Rolename
from webpages_UsersInRoles where UserId=@Reg_userid
GO
/****** Object:  StoredProcedure [dbo].[GetEmailId]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[GetEmailId]  
(  
@Role varchar(50),  
@Reg_userid int  
)  
as  
  
select Email from tbl_user where Reg_userid = @Reg_userid
GO
/****** Object:  StoredProcedure [dbo].[getrolebyusername]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[getrolebyusername]  
  
(  
  
@username varchar(200)  
  
)  
  
as  
  
if exists(select userid from userprofile where UserName=@username)  
  
select (select rolename from webpages_roles where RoleId in (select top 1 RoleId from webpages_UsersInRoles where UserId in (select UserId from UserProfile where username=@username)))  
  
else  
  
select 'NoRole'
GO
/****** Object:  StoredProcedure [dbo].[GetRoleNameList]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetRoleNameList] --12  
  
  
--@UserId int  
as  
  
  
--if(@UserId=0)  
  
select * from webpages_roles 
--where RoleName not in ('Administrator' ,'Camlin@357' )  
  
--else  
  
--select *,(select RoleName from webpages_roles where RoleId=webpages_UsersInRoles.RoleId and RoleName not in ('Administrator' ,'Camlin@357' )) as RoleName  
--from webpages_UsersInRoles where UserId=@UserId
GO
/****** Object:  StoredProcedure [dbo].[GetRoleNameListByUserId]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetRoleNameListByUserId] --12


@UserId int
as




select *,(select RoleName from webpages_roles where RoleId=webpages_UsersInRoles.RoleId and RoleName not in ('Administrator' ,'Camlin@357' )) as RoleName
from webpages_UsersInRoles where UserId=@UserId
GO
/****** Object:  StoredProcedure [dbo].[GetUser_dataApproval]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  Procedure [dbo].[GetUser_dataApproval] 
(  
@Reg_userid int  
)  
as  
select *   
,(select StoreName From tbl_user_store where Reg_userid in (select Reg_userid from tbl_user where id=@Reg_userid)) as StoreName  

 from tbl_user where  Roleid=3 and id!=@Reg_userid
GO
/****** Object:  StoredProcedure [dbo].[getusernames]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getusernames]  
  
AS  
  
SELECT * from UserProfile   
  
ORDER BY UserId asc
GO
/****** Object:  StoredProcedure [dbo].[Membership_DisableUser]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Membership_DisableUser] 
(
@userid int
)
as
if exists(select userid from tbl_user where userid=@userid)
Update webpages_membership set IsConfirmed=0 where userid in (select userid from tbl_user where userid=@userid) 
else
Update webpages_membership set IsConfirmed=0 where userid  =@userid


select * from UserProfile
GO
/****** Object:  StoredProcedure [dbo].[Membership_EnableUser]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  procedure [dbo].[Membership_EnableUser]

(

@userid int

)

as

Update webpages_membership set IsConfirmed=1 where userid  =@userid
GO
/****** Object:  StoredProcedure [dbo].[Select_RoleId_ByUserid]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Select_RoleId_ByUserid]
(
@UserId int
)
as
select RoleId from webpages_UsersInRoles where UserId=@UserId
GO
/****** Object:  StoredProcedure [dbo].[SPDepartment]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SPDepartment]
@Spara int=null,
@StoreID int=0,
@Id int=null,
@Name nvarchar(200)=null,
@CreatedBy varchar(50)=null,
@ModifiedBy varchar(50)=null,
@IsActive bit=null,
@ListID nvarchar(50)=null
AS
 begin
	 IF (@Spara=1)
	 Begin
		INSERT INTO tbl_Department ([Name],[CreatedOn],[CreatedBy],[IsActive],[ListID],[StoreID])
		VALUES(@Name,GETDATE(),@CreatedBy,@IsActive,@ListID,@StoreID)
	end
	IF(@Spara=2)
	BEGIN
		UPDATE tbl_Department SET 
		[Name]=@Name,[IsActive]=@IsActive,[ModifiedBy]=@ModifiedBy,[ModifiedOn]=GETDATE()
		Where [ListID]=@ListID and [StoreID]=@StoreID
	END
	IF(@Spara=3)
	BEGIN
		SELECT * FROM tbl_Department Where ListID=@ListID and StoreID=@StoreID
	END

	IF @Spara=4
	BEGIN
		SELECT COUNT(*) FROM tbl_Department WHERE StoreID=@StoreID
	END
END



GO
/****** Object:  StoredProcedure [dbo].[SPInvoice]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SPInvoice]
@Spara int=null,
@TxnID nvarchar(50)=null,
@ID int =null,
@StoreID int =null
As
Begin
	IF(@Spara=1)
		BEGIN
			Select I.*,V.Name,V.CompanyName,V.Address,V.IsActive As VIsActive,V.ListID,T.Name as TypeName,V.PhoneNumber
			 from tbl_Invoice as I
			INNER JOIN tbl_Vendor as V 
			on V.id=I.Vendor_id
			INNER JOIN tbl_Type as T
			on T.id=I.Type_id
			Where I.IsStatus_id=2 and (IsSync=0 Or IsSync IS Null) and Store_id=@StoreID
		END
	IF(@Spara=2)
		BEGIN
			UPDATE tbl_Invoice
			Set TxnID=@TxnID,
			IsSync =1
			Where id=@ID and Store_id=@StoreID
		END
END


GO
/****** Object:  StoredProcedure [dbo].[SPInvoiceDepartment]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SPInvoiceDepartment]
@Spara int=null,
@Invoice_id int=null
AS
BEGIN
	IF(@Spara=1)
		BEGIN
			Select InvDep.*,D.Name,D.ListID from tbl_Invoice_Department as InvDep
			Inner JOIN tbl_Department as D
			On D.id=InvDep.Dept_id
			Where InvDep.Invoice_id=@Invoice_id
		END
END
GO
/****** Object:  StoredProcedure [dbo].[SPStore]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SPStore]
@Spara int =null,
@Id int =null,
@Store_Id int=null,
@CompanyFilePath nvarchar(150)=null,
@QBVersion nvarchar(50)=null,
@QBYear nvarchar(100)=null,
@BillAccListID nvarchar(150)=null,
@BillAccName nvarchar(150)=null,
@SyncDate DateTime=null
AS 
BEGIN
	IF(@Spara=1)
		BEGIN
			Select  Id ,Name from tbl_Store where IsActive=1 and Id Not in (Select Store_id from QBConfig)
		END
	IF(@Spara=2)
		BEGIN
			Insert into QBConfig (Store_Id,CompanyFilePath,QBVersion,QBYear,IsActive,CreatedDate,BillAccListID,BillAccName,SyncDate) 
			values
			(@Store_Id,@CompanyFilePath,@QBVersion,@QBYear,1,GETDATE(),@BillAccListID,@BillAccName,@SyncDate)
		END
	IF(@Spara=3)
		BEGIN
			Update QBConfig set [Store_Id]=@Store_Id,[CompanyFilePath]=@CompanyFilePath,[QBVersion]=@QBVersion,[QBYear]=@QBYear,[UpdateDate]=GETDATE(),[BillAccListID]=@BillAccListID,[BillAccName]=@BillAccName,[SyncDate]=@SyncDate
			Where Id=@Id
		END
	
	IF(@Spara=4)
		BEGIN
			Select s.*,qb.CompanyFilePath,qb.QBVersion,qb.QBYear,qb.Id as QBId,qb.BillAccListID,qb.BillAccName,qb.SyncDate from tbl_Store as s
			Inner join QBConfig qb
			on qb.Store_Id=s.Id
			-- where s.IsActive=1 
		END
	IF(@Spara=5)
		BEGIN
			DELETE From QBConfig where Id=@Id
		END
    IF(@Spara=6)
		BEGIN
			UPDATE QBConfig set SyncDate=@SyncDate where Id=@Id
		END
	
END


GO
/****** Object:  StoredProcedure [dbo].[SPVendor]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SPVendor]
@Spara int=null,
@Id int=null,
@StoreID int=0,
@Name nvarchar(200)=null,
@Address nvarchar(500)=null,
@CompanyName nvarchar(200)=null,
@CreatedBy varchar(50)=null,
@ModifiedBy varchar(50)=null,
@IsActive bit=null,
@ListID nvarchar(50)=null,
@PhoneNumber nvarchar(50)=null
AS
 begin
	 IF (@Spara=1)
	 Begin
		INSERT INTO tbl_Vendor ([Name],[StoreID],[Address],[CompanyName],[CreatedOn],[CreatedBy],[IsActive],[ListID],[PhoneNumber])
		VALUES(@Name,@StoreID,@Address,@CompanyName,GETDATE(),@CreatedBy,@IsActive,@ListID,@PhoneNumber)
	end
    IF(@Spara=2)
	BEGIN
		UPDATE tbl_Vendor SET 
		[Name]=@Name,[Address]=@Address,
		[CompanyName]=@CompanyName,[IsActive]=@IsActive,[ModifiedBy]=@ModifiedBy,[ModifiedOn]=GETDATE(),
		[PhoneNumber]=@PhoneNumber
		Where ListID=@ListID and StoreId=@StoreID
	END
	IF(@Spara=3)
	BEGIN
		SELECT * FROM tbl_Vendor Where ListID=@ListID and StoreId=@StoreID
	END
	 IF(@Spara=4)
	BEGIN
		UPDATE tbl_Vendor SET 
	    ListID=@ListID
		Where id=@Id and StoreId=@StoreID
	END

	IF @SPara=5
	BEGIN
		SELECT COUNT(*) FROM tbl_Vendor WHERE StoreId=@StoreID
	END
END


GO
/****** Object:  StoredProcedure [dbo].[tbl_Acivity_Log_GridData]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[tbl_Acivity_Log_GridData]   
  
 
  as
SELECT *  
  
 from tbl_Activity_log
GO
/****** Object:  StoredProcedure [dbo].[tbl_Activity_log_Insert]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_Activity_log_Insert]  
(  
@userid int,  
@Comment varchar(1000),  
@CreatedBy varchar(50)  ,
@Action int
)  
As  
insert into tbl_Activity_log (userid,Comment,CreatedOn,CreatedBy,Action) values (@userid,@Comment,getdate(),@CreatedBy,@Action)  
select @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Dashbord_GridData]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[tbl_Invoice_Dashbord_GridData] --2,'55555.00',3086

(
--@Invoice_Number varchar(100),
--@Vendor int,
@startdate datetime,
@enddate datetime,
@Payment_type varchar(50),
@Dept_id int,
@Store_id int,
@searchdashbord varchar(200),
@CreatedBy varchar(50)
--@IsStatus_id int
)
as
select top(20) *,
(select Name from tbl_Store where id=tbl_Invoice.Store_id) as Storename
,(select Name from tbl_Type where id=tbl_Invoice.Type_id) as Typename
,(select Name from tbl_Vendor where id=tbl_Invoice.Vendor_id) as vendorname
,(select Name from tbl_Status where id=tbl_Invoice.IsStatus_id) as Statusname
,(select Amount from tbl_Invoice_Department where Invoice_id=tbl_Invoice.id and Dept_id=@Dept_id) as deptamt
,(select id from tbl_Invoice_Department where Invoice_id =tbl_Invoice.id and Dept_id=@Dept_id) as deptid
from tbl_Invoice where IsActive='True'
and ((Store_id=@Store_id) or(isnull(@Store_id,0)=0))
and ((Vendor_id in (select id from tbl_Vendor where ((Name like '%'+@searchdashbord+'%'))))
 or ((Invoice_Number like '%'+@searchdashbord+'%'))
  or ((TotalAmtByDept like @searchdashbord+'%')) or(isnull(@searchdashbord,'')=''))
 and ((CreatedBy=@CreatedBy) or(isnull(@CreatedBy,'')=''))
  and ((Convert(date,Invoice_Date) >=@startdate) or (isnull(@startdate,'')='')) 
     and ((Convert(date,Invoice_Date) <=@enddate) or (isnull(@enddate,'')='')) 
  and ((Payment_type like '%'+@Payment_type+'%') or(isnull(@Payment_type,'')=''))
    and id in(select Invoice_id from tbl_Invoice_Department where ((Dept_id=@Dept_id) or (ISNULL(@Dept_id,0)=0)))
 order by id desc
 --((Invoice_Number like '%'+@Invoice_Number+'%') or(isnull(@Invoice_Number,'')=''))
  --and ((Vendor_id=@Vendor) or(isnull(@Vendor,0)=0))
  -- and ((Convert(date,Invoice_Date) >=@startdate) or (isnull(@startdate,'')='')) 
  --   and ((Convert(date,Invoice_Date) <=@enddate) or (isnull(@enddate,'')='')) 
  --and ((Payment_type like '%'+@Payment_type+'%') or(isnull(@Payment_type,'')=''))
  --  and id in(select Invoice_id from tbl_Invoice_Department where ((Dept_id=@Dept_id) or (ISNULL(@Dept_id,0)=0)))
  
  --  and ((Store_id=@Store_id) or(isnull(@Store_id,0)=0))
  --and ((Vendor_id in (select Vendor_id from tbl_Vendor where ((Name like '%'+@searchdashbord+'%') or(isnull(@searchdashbord,'')=''))))
  --  or ((Invoice_Number like '%'+@searchdashbord+'%') or(isnull(@searchdashbord,'')=''))
  --or ((Convert(varchar(50),TotalAmtByDept) like '%'+@searchdashbord+'%') or(isnull(@searchdashbord,'')='')))
  --and ((CreatedBy=@CreatedBy) or(isnull(@CreatedBy,'')=''))
  ----and ((IsStatus_id=@IsStatus_id) or(isnull(@IsStatus_id,0)=0))
  --((Invoice_Number like '%'+@Invoice_Number+'%') or (isnull(Invoice_Number,'')='')) and ((tbl_Invoice.Vendor_id=@Vendor) or (isnull(tbl_Invoice.Vendor_id,0)=0))
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Dashbord_GridData_Administrator]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[tbl_Invoice_Dashbord_GridData_Administrator] --'09-01-2018','09-30-2018','',0,0,''



(

--@Invoice_Number varchar(100),

--@Vendor int,

@startdate datetime,

@enddate datetime,

@Payment_type varchar(50),

@Dept_id int,

@Store_id int,

@searchdashbord varchar(200)

--@CreatedBy varchar(50)

--@IsStatus_id int

)

as

select *,

(select Name from tbl_Store where id=tbl_Invoice.Store_id) as Storename

,(select Name from tbl_Type where id=tbl_Invoice.Type_id) as Typename

,(select Name from tbl_Vendor where id=tbl_Invoice.Vendor_id) as vendorname

,(select Name from tbl_Status where id=tbl_Invoice.IsStatus_id) as Statusname

,(select sum(Amount) from tbl_Invoice_Department where Invoice_id=tbl_Invoice.id and Dept_id=@Dept_id) as deptamt

--,(select id from tbl_Invoice_Department where Invoice_id =tbl_Invoice.id and Dept_id=@Dept_id) as deptid

from tbl_Invoice where IsActive='True'

and ((Store_id=@Store_id) or(isnull(@Store_id,0)=0))

and ((Vendor_id in (select id from tbl_Vendor where ((Name like '%'+@searchdashbord+'%'))))

 or ((Invoice_Number like '%'+@searchdashbord+'%'))

  --or ((Convert(varchar(50),TotalAmtByDept)=@searchdashbord)) or(isnull(@searchdashbord,'')=''))
  or ((Convert(varchar(50),TotalAmtByDept) like '%'+@searchdashbord+'%')))
   --and ((CreatedBy=@CreatedBy) or(isnull(@CreatedBy,'')=''))

   and ((Convert(date,Invoice_Date) >=@startdate) or (isnull(@startdate,'')='')) 

    and ((Convert(date,Invoice_Date) <=@enddate) or (isnull(@enddate,'')='')) 

	and id in(select Invoice_id from tbl_Invoice_Department where ((Dept_id=@Dept_id) or (ISNULL(@Dept_id,0)=0)))

	 and ((Payment_type like '%'+@Payment_type+'%') or(isnull(@Payment_type,'')=''))

    order by id desc

 --((Invoice_Number like '%'+@Invoice_Number+'%') or(isnull(@Invoice_Number,'')=''))

  --and ((Vendor_id=@Vendor) or(isnull(@Vendor,0)=0))

  -- and ((Convert(date,Invoice_Date) >=@startdate) or (isnull(@startdate,'')='')) 

  --   and ((Convert(date,Invoice_Date) <=@enddate) or (isnull(@enddate,'')='')) 

  --and ((Payment_type like '%'+@Payment_type+'%') or(isnull(@Payment_type,'')=''))

  --  and id in(select Invoice_id from tbl_Invoice_Department where ((Dept_id=@Dept_id) or (ISNULL(@Dept_id,0)=0)))

  

  --  and ((Store_id=@Store_id) or(isnull(@Store_id,0)=0))

  --and ((Vendor_id in (select Vendor_id from tbl_Vendor where ((Name like '%'+@searchdashbord+'%') or(isnull(@searchdashbord,'')=''))))

  --  or ((Invoice_Number like '%'+@searchdashbord+'%') or(isnull(@searchdashbord,'')=''))

  --or ((Convert(varchar(50),TotalAmtByDept) like '%'+@searchdashbord+'%') or(isnull(@searchdashbord,'')='')))

  --and ((CreatedBy=@CreatedBy) or(isnull(@CreatedBy,'')=''))

  ----and ((IsStatus_id=@IsStatus_id) or(isnull(@IsStatus_id,0)=0))

  --((Invoice_Number like '%'+@Invoice_Number+'%') or (isnull(Invoice_Number,'')='')) and ((tbl_Invoice.Vendor_id=@Vendor) or (isnull(tbl_Invoice.Vendor_id,0)=0))
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Dashbord_GridData_DataApp]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[tbl_Invoice_Dashbord_GridData_DataApp] --2,'vibhusha',3086



(

--@Invoice_Number varchar(100),

--@Vendor int,

@startdate datetime,

@enddate datetime,

@Payment_type varchar(50),

@Dept_id int,

@Store_id int,

@searchdashbord varchar(200)

--@CreatedBy varchar(50)

--@IsStatus_id int

)

as

select top(20) *,

(select Name from tbl_Store where id=tbl_Invoice.Store_id) as Storename

,(select Name from tbl_Type where id=tbl_Invoice.Type_id) as Typename

,(select Name from tbl_Vendor where id=tbl_Invoice.Vendor_id) as vendorname

,(select Name from tbl_Status where id=tbl_Invoice.IsStatus_id) as Statusname

,(select Amount from tbl_Invoice_Department where Invoice_id=tbl_Invoice.id and Dept_id=@Dept_id) as deptamt
,(select id from tbl_Invoice_Department where Invoice_id =tbl_Invoice.id and Dept_id=@Dept_id) as deptid

from tbl_Invoice where IsActive='True'

and ((Store_id=@Store_id) or(isnull(@Store_id,0)=0))

and ((Vendor_id in (select id from tbl_Vendor where ((Name like '%'+@searchdashbord+'%'))))

 or ((Invoice_Number like '%'+@searchdashbord+'%'))

  or ((Convert(varchar(50),TotalAmtByDept)=@searchdashbord)) or(isnull(@searchdashbord,'')=''))

   --and ((CreatedBy=@CreatedBy) or(isnull(@CreatedBy,'')=''))

    and ((Convert(date,Invoice_Date) >=@startdate) or (isnull(@startdate,'')='')) 

     and ((Convert(date,Invoice_Date) <=@enddate) or (isnull(@enddate,'')='')) 

  and ((Payment_type like '%'+@Payment_type+'%') or(isnull(@Payment_type,'')=''))

    and id in(select Invoice_id from tbl_Invoice_Department where ((Dept_id=@Dept_id) or (ISNULL(@Dept_id,0)=0)))

  

    order by id desc

 --((Invoice_Number like '%'+@Invoice_Number+'%') or(isnull(@Invoice_Number,'')=''))

  --and ((Vendor_id=@Vendor) or(isnull(@Vendor,0)=0))

  -- and ((Convert(date,Invoice_Date) >=@startdate) or (isnull(@startdate,'')='')) 

  --   and ((Convert(date,Invoice_Date) <=@enddate) or (isnull(@enddate,'')='')) 

  --and ((Payment_type like '%'+@Payment_type+'%') or(isnull(@Payment_type,'')=''))

  --  and id in(select Invoice_id from tbl_Invoice_Department where ((Dept_id=@Dept_id) or (ISNULL(@Dept_id,0)=0)))

  

  --  and ((Store_id=@Store_id) or(isnull(@Store_id,0)=0))

  --and ((Vendor_id in (select Vendor_id from tbl_Vendor where ((Name like '%'+@searchdashbord+'%') or(isnull(@searchdashbord,'')=''))))

  --  or ((Invoice_Number like '%'+@searchdashbord+'%') or(isnull(@searchdashbord,'')=''))

  --or ((Convert(varchar(50),TotalAmtByDept) like '%'+@searchdashbord+'%') or(isnull(@searchdashbord,'')='')))

  --and ((CreatedBy=@CreatedBy) or(isnull(@CreatedBy,'')=''))

  ----and ((IsStatus_id=@IsStatus_id) or(isnull(@IsStatus_id,0)=0))

  --((Invoice_Number like '%'+@Invoice_Number+'%') or (isnull(Invoice_Number,'')='')) and ((tbl_Invoice.Vendor_id=@Vendor) or (isnull(tbl_Invoice.Vendor_id,0)=0))
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Dashbord_GridData_StoreManager]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[tbl_Invoice_Dashbord_GridData_StoreManager] --2,'vibhusha',3086



(

--@Invoice_Number varchar(100),

--@Vendor int,

@startdate datetime,

@enddate datetime,

@Payment_type varchar(50),

@Dept_id int,

@Store_id int,

@searchdashbord varchar(200)

--@CreatedBy varchar(50)

--@IsStatus_id int

)

as

select top(20) *,

(select Name from tbl_Store where id=tbl_Invoice.Store_id) as Storename

,(select Name from tbl_Type where id=tbl_Invoice.Type_id) as Typename

,(select Name from tbl_Vendor where id=tbl_Invoice.Vendor_id) as vendorname

,(select Name from tbl_Status where id=tbl_Invoice.IsStatus_id) as Statusname
,(select Amount from tbl_Invoice_Department where Invoice_id=tbl_Invoice.id and Dept_id=@Dept_id) as deptamt
,(select id from tbl_Invoice_Department where Invoice_id =tbl_Invoice.id and Dept_id=@Dept_id) as deptid
from tbl_Invoice where IsActive='True'

and ((Store_id=@Store_id) or(isnull(@Store_id,0)=0))

and ((Vendor_id in (select id from tbl_Vendor where ((Name like '%'+@searchdashbord+'%'))))

 or ((Invoice_Number like '%'+@searchdashbord+'%'))

  or ((Convert(varchar(50),TotalAmtByDept)=@searchdashbord)) or(isnull(@searchdashbord,'')=''))

    and ((Convert(date,Invoice_Date) >=@startdate) or (isnull(@startdate,'')='')) 

     and ((Convert(date,Invoice_Date) <=@enddate) or (isnull(@enddate,'')='')) 

  and ((Payment_type like '%'+@Payment_type+'%') or(isnull(@Payment_type,'')=''))

    and id in(select Invoice_id from tbl_Invoice_Department where ((Dept_id=@Dept_id) or (ISNULL(@Dept_id,0)=0)))

  

   --and ((CreatedBy=@CreatedBy) or(isnull(@CreatedBy,'')=''))

    order by id desc

 --((Invoice_Number like '%'+@Invoice_Number+'%') or(isnull(@Invoice_Number,'')=''))

  --and ((Vendor_id=@Vendor) or(isnull(@Vendor,0)=0))

  -- and ((Convert(date,Invoice_Date) >=@startdate) or (isnull(@startdate,'')='')) 

  --   and ((Convert(date,Invoice_Date) <=@enddate) or (isnull(@enddate,'')='')) 

  --and ((Payment_type like '%'+@Payment_type+'%') or(isnull(@Payment_type,'')=''))

  --  and id in(select Invoice_id from tbl_Invoice_Department where ((Dept_id=@Dept_id) or (ISNULL(@Dept_id,0)=0)))

  

  --  and ((Store_id=@Store_id) or(isnull(@Store_id,0)=0))

  --and ((Vendor_id in (select Vendor_id from tbl_Vendor where ((Name like '%'+@searchdashbord+'%') or(isnull(@searchdashbord,'')=''))))

  --  or ((Invoice_Number like '%'+@searchdashbord+'%') or(isnull(@searchdashbord,'')=''))

  --or ((Convert(varchar(50),TotalAmtByDept) like '%'+@searchdashbord+'%') or(isnull(@searchdashbord,'')='')))

  --and ((CreatedBy=@CreatedBy) or(isnull(@CreatedBy,'')=''))

  ----and ((IsStatus_id=@IsStatus_id) or(isnull(@IsStatus_id,0)=0))

  --((Invoice_Number like '%'+@Invoice_Number+'%') or (isnull(Invoice_Number,'')='')) and ((tbl_Invoice.Vendor_id=@Vendor) or (isnull(tbl_Invoice.Vendor_id,0)=0))
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Department_Insert]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[tbl_Invoice_Department_Insert]
(
@Invoice_id int,
@Dept_id int,
@Amount decimal(18,2),
@CreatedBy varchar(50)
)
as
insert into tbl_Invoice_Department (Invoice_id,Dept_id,Amount,CreatedOn,CreatedBy)values(@Invoice_id,@Dept_id,@Amount,getdate(),@CreatedBy)
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_exists_InNo]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_Invoice_exists_InNo]

(

@Invoice_Number varchar(100),
@totalamount decimal(18,2),
@invoicedate datetime


)

as

if exists(select * from tbl_Invoice where Invoice_Number=@Invoice_Number and 
TotalAmtByDept=@totalamount and Convert(date,Invoice_Date)=Convert(date,@invoicedate))

select 1

else

select 0
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_exists_InNo_Edit]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_Invoice_exists_InNo_Edit]



(

@id int,
 
@Invoice_Number varchar(100),

@totalamount decimal(18,2),

@invoicedate datetime





)



as



if exists(select * from tbl_Invoice where Invoice_Number=@Invoice_Number and 

TotalAmtByDept=@totalamount and Convert(date,Invoice_Date)=Convert(date,@invoicedate) and id!=@id ) 



select 1



else



select 0
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_GridData]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[tbl_Invoice_GridData] --'','','',1,0,1
(

--@Invoice_Number varchar(100),

--@Vendor int,

@startdate datetime,

@enddate datetime,

@Payment_type varchar(50),

@Dept_id int,

--@CreatedBy varchar(50)

@Store_id int,

@IsStatus_id int

)

as

select *,

(select Name from tbl_Store where id=tbl_Invoice.Store_id) as Storename

,(select Name from tbl_Type where id=tbl_Invoice.Type_id) as Typename

,(select Name from tbl_Vendor where id=tbl_Invoice.Vendor_id) as vendorname

,(select Name from tbl_Status where id=tbl_Invoice.IsStatus_id) as Statusname

,(select sum(Amount) from tbl_Invoice_Department where Invoice_id=tbl_Invoice.id and Dept_id=@Dept_id) as deptamt

--,(select id from tbl_Invoice_Department where Invoice_id =tbl_Invoice.id and Dept_id=@Dept_id) as deptid

from tbl_Invoice where IsActive='True'

 --((Invoice_Number like '%'+@Invoice_Number+'%') or(isnull(@Invoice_Number,'')=''))

  --and ((Vendor_id=@Vendor) or(isnull(@Vendor,0)=0))

   and ((Convert(date,Invoice_Date) >=@startdate) or (isnull(@startdate,'')='')) 

     and ((Convert(date,Invoice_Date) <=@enddate) or (isnull(@enddate,'')='')) 

  and ((Payment_type like '%'+@Payment_type+'%') or(isnull(@Payment_type,'')=''))

    and id in(select Invoice_id from tbl_Invoice_Department where ((Dept_id=@Dept_id) or (ISNULL(@Dept_id,0)=0)))

	  --and ((CreatedBy=@CreatedBy) or(isnull(@CreatedBy,'')=''))

	    and ((Store_id=@Store_id) or(isnull(@Store_id,0)=0))

  and ((IsStatus_id=@IsStatus_id) or(isnull(@IsStatus_id,0)=0)) order by id desc

    --((Invoice_Number like '%'+@Invoice_Number+'%') or (isnull(Invoice_Number,'')='')) and ((tbl_Invoice.Vendor_id=@Vendor) or (isnull(tbl_Invoice.Vendor_id,0)=0))
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_GridData_ForExcel]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[tbl_Invoice_GridData_ForExcel] --'','','','',0,1
(

--@Invoice_Number varchar(100),

--@Vendor int,

@startdate datetime,

@enddate datetime,

@Payment_type varchar(50),

@Dept_id int,

--@CreatedBy varchar(50)

@Store_id int,

@IsStatus_id int

)

as

select *,convert(varchar,Invoice_Date,101) as Invoice_Date_str,convert(varchar,CreatedOn,101) as CreatedOn_str,

(select Name from tbl_Store where id=tbl_Invoice.Store_id) as Storename

,(select Name from tbl_Type where id=tbl_Invoice.Type_id) as Typename

,(select Name from tbl_Vendor where id=tbl_Invoice.Vendor_id) as vendorname

,(select Name from tbl_Status where id=tbl_Invoice.IsStatus_id) as Statusname

,(select sum(Amount) from tbl_Invoice_Department where Invoice_id=tbl_Invoice.id and Dept_id=@Dept_id) as deptamt

from tbl_Invoice where IsActive='True'

 --((Invoice_Number like '%'+@Invoice_Number+'%') or(isnull(@Invoice_Number,'')=''))

 --and ((Vendor_id=@Vendor) or(isnull(@Vendor,0)=0))

 and ((Convert(date,Invoice_Date) >=@startdate) or (isnull(@startdate,'')='')) 

  and ((Convert(date,Invoice_Date) <=@enddate) or (isnull(@enddate,'')='')) 

  and ((Payment_type like '%'+@Payment_type+'%') or(isnull(@Payment_type,'')=''))

  and id in(select Invoice_id from tbl_Invoice_Department where ((Dept_id=@Dept_id) or (ISNULL(@Dept_id,0)=0)))

  --and ((CreatedBy=@CreatedBy) or(isnull(@CreatedBy,'')=''))

  and ((Store_id=@Store_id) or(isnull(@Store_id,0)=0))

  and ((IsStatus_id=@IsStatus_id) or(isnull(@IsStatus_id,0)=0))

  order by id desc

  --((Invoice_Number like '%'+@Invoice_Number+'%') or (isnull(Invoice_Number,'')='')) and ((tbl_Invoice.Vendor_id=@Vendor) or (isnull(tbl_Invoice.Vendor_id,0)=0))
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_GridData_ForPdf]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[tbl_Invoice_GridData_ForPdf] --null,null,'',0,2,0

(

--@Invoice_Number varchar(100),

--@Vendor int,

@startdate datetime,

@enddate datetime,

@Payment_type varchar(50),

@Dept_id int,

--@CreatedBy varchar(50)

@Store_id int,

@IsStatus_id int

)

as

select Invoice_Number,convert(varchar,CreatedOn,101) as CreatedOn,convert(varchar,Invoice_Date,101) as Invoice_Date,TotalAmtByDept,Payment_type,

--(select Name from tbl_Store where id=tbl_Invoice.Store_id) as Storename

(select Name from tbl_Type where id=tbl_Invoice.Type_id) as Typename

,(select Name from tbl_Vendor where id=tbl_Invoice.Vendor_id) as vendorname

,(select Name from tbl_Status where id=tbl_Invoice.IsStatus_id) as Statusname

,(select sum(Amount) from tbl_Invoice_Department where Invoice_id=tbl_Invoice.id and Dept_id=@Dept_id) as deptamt

from tbl_Invoice where IsActive='True'

 --((Invoice_Number like '%'+@Invoice_Number+'%') or(isnull(@Invoice_Number,'')=''))

  --and ((Vendor_id=@Vendor) or(isnull(@Vendor,0)=0))

 and ((Convert(date,Invoice_Date) >=@startdate) or (isnull(@startdate,'')='')) 

   and ((Convert(date,Invoice_Date) <=@enddate) or (isnull(@enddate,'')='')) 

  and ((Payment_type like '%'+@Payment_type+'%') or(isnull(@Payment_type,'')=''))

    and id in(select Invoice_id from tbl_Invoice_Department where ((Dept_id=@Dept_id) or (ISNULL(@Dept_id,0)=0)))

  --and ((CreatedBy=@CreatedBy) or(isnull(@CreatedBy,'')=''))

    and ((Store_id=@Store_id) or(isnull(@Store_id,0)=0))

  and ((IsStatus_id=@IsStatus_id) or(isnull(@IsStatus_id,0)=0))

  order by id desc







  --((Invoice_Number like '%'+@Invoice_Number+'%') or (isnull(Invoice_Number,'')='')) and ((tbl_Invoice.Vendor_id=@Vendor) or (isnull(tbl_Invoice.Vendor_id,0)=0))
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Insert]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_Invoice_Insert]
(
@Store_id int,
@Type_id int,
@Payment_type varchar(50),
@Vendor_id int,
@Invoice_Date datetime,
@Invoice_Number varchar(100),
@Note varchar(2000),
@AttachNote varchar(100),
@UploadInvoice varchar(100),
@ScanInvoice varchar(100),
@IsStatus_id int,
@CreatedBy varchar(50),
@totalamount decimal(18,2)
)
as
insert into tbl_Invoice (Store_id,Type_id,Payment_type,Vendor_id,Invoice_Date,Invoice_Number,Note,AttachNote,UploadInvoice,ScanInvoice,IsStatus_id,CreatedOn,CreatedBy,TotalAmtByDept)values(@Store_id,@Type_id,@Payment_type,@Vendor_id,@Invoice_Date,@Invoice_Number,@Note,
@AttachNote,@UploadInvoice,@ScanInvoice,@IsStatus_id,getdate(),@CreatedBy,@totalamount)
Select @@identity
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Insert_StoreManager]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_Invoice_Insert_StoreManager]

(

@Store_id int,

@Type_id int,

@Payment_type varchar(50),

@Vendor_id int,

@Invoice_Date datetime,

@Invoice_Number varchar(100),

@Note varchar(2000),

@AttachNote varchar(100),

@UploadInvoice varchar(100),

@ScanInvoice varchar(100),

@IsStatus_id int,

@CreatedBy varchar(50),

@totalamount decimal(18,2),

@ApproveRejectBy varchar(50)



)

as

insert into tbl_Invoice (Store_id,Type_id,Payment_type,Vendor_id,Invoice_Date,Invoice_Number,Note,AttachNote,UploadInvoice,ScanInvoice,IsStatus_id,CreatedOn,CreatedBy,TotalAmtByDept,ApproveRejectBy,ApproveRejectDate)values(@Store_id,@Type_id,@Payment_type,@Vendor_id,@Invoice_Date,@Invoice_Number,@Note,@AttachNote,@UploadInvoice,@ScanInvoice,@IsStatus_id,getdate(),@CreatedBy,@totalamount,@ApproveRejectBy,getdate())

Select @@identity
GO
/****** Object:  StoredProcedure [dbo].[tbl_store_byid]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[tbl_store_byid]
(
@id int
)
as
select * from tbl_Store where id=@id
GO
/****** Object:  StoredProcedure [dbo].[tbl_Store_Create]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_Store_Create]  
(  
@Name varchar(500),  
@Address varchar(1000),  
@StoreNo varchar(100),  
@FaxNo varchar(20),  
@CreatedBy varchar(50), 
@Address2 varchar(1000)
)  
as  
  
insert into tbl_Store (Name,Address,StoreNo,FaxNo,CreatedOn,CreatedBy,Address2) values (@Name,@Address,@StoreNo,@FaxNo,getdate(),@CreatedBy,@Address2)  
Select @@identity
GO
/****** Object:  StoredProcedure [dbo].[tbl_Store_exists]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[tbl_Store_exists]
(
@Name varchar(500)
)
as
select * from tbl_Store where Name=@Name and IsActive='True'
GO
/****** Object:  StoredProcedure [dbo].[tbl_Store_GridData]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[tbl_Store_GridData] 

(

@name varchar(100)

)

as

SELECT *

 from tbl_Store 

 where ((Name like '%'+@name+'%') or(isnull(@name,'')='')) and IsActive='True'
GO
/****** Object:  StoredProcedure [dbo].[tbl_Store_Update]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_Store_Update]    
(    
@Id int,    
@Name varchar(500),    
@Address varchar(1000),    
@StoreNo varchar(100),    
@FaxNo varchar(20),    
@ModifiedBy varchar(50),
@Address2 varchar(1000) 
    
)    
as    
    
update tbl_Store set Name=@Name,Address=@Address,StoreNo=@StoreNo,FaxNo=@FaxNo,ModifiedOn=getdate(),ModifiedBy=@ModifiedBy,Address2=@Address2 where Id=@Id
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_backoffice]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_user_backoffice]  
as  
select * from tbl_user where Roleid=2 and Reg_userid not in(select Reg_userid from tbl_user_store where Roleid=2)
and userid in (select userid from webpages_Membership where IsConfirmed=1)
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_backoffice_edit]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_user_backoffice_edit]  
(  
@Reg_userid int  
)    
as    

select * from tbl_user where Roleid=2 and ((Reg_userid not in(select Reg_userid from tbl_user_store)) or Reg_userid=@Reg_userid)
and  userid in (select userid from webpages_Membership where IsConfirmed=1)
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_backoffice_edit_new]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_user_backoffice_edit_new]      
(      
@Reg_userid int,  
@Roleid int  
)        
as        
if(@Roleid!=3)  
Begin  
select * from tbl_user where Roleid=@Roleid  and Reg_userid not in (select Reg_userid from tbl_user_store)  
and Reg_userid!=@Reg_userid and Reg_userid in (select userid from webpages_Membership where IsConfirmed=1)  
End  
else  
Begin  
select * from tbl_user where Roleid=@Roleid   
and Reg_userid!=@Reg_userid and Reg_userid in (select userid from webpages_Membership where IsConfirmed=1)  
End
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_byid]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_user_byid]
(
@Reg_userid int
)
as
select * from tbl_user where Reg_userid=@Reg_userid
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_DataApprover]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_user_DataApprover]    
as    
select * from tbl_user where Roleid=3  
and userid in (select userid from webpages_Membership where IsConfirmed=1)
 --and Reg_userid not in(select Reg_userid from tbl_user_store)
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_DataApprover_edit]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_user_DataApprover_edit]    --3054  
( @Reg_userid int)    
as        
select * from tbl_user where Roleid=3    
and  userid in (select userid from webpages_Membership where IsConfirmed=1)
 --and Reg_userid not in(select Reg_userid from tbl_user_store)
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_GridData]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[tbl_user_GridData]   
(  
@Name varchar(100)  
)  
as  
SELECT id,Name,userid as [userid_val] ,Username,[Password],Email,CreatedOn,Reg_userid, (select IsConfirmed from webpages_Membership where webpages_Membership.UserId=tbl_user.Reg_userid)  as [lockval]  
,(select RoleName from webpages_Roles where RoleId=tbl_user.Roleid) as RoleName  
 from tbl_user    
 where username!='admin' and ((Name like '%'+@Name+'%') or(isnull(Name,'')=''))
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_GridData_byid]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[tbl_user_GridData_byid]   --11
(  
@id int 
)  
as  
SELECT id,Name,userid as [userid_val] ,Username,[Password],Email,CreatedOn,Reg_userid, (select IsConfirmed from webpages_Membership where webpages_Membership.UserId=tbl_user.userid)  as [lockval]  
,(select RoleName from webpages_Roles where RoleId=tbl_user.Roleid) as RoleName  
 from tbl_user    
 where id=@id
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_Insert]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_user_Insert]
(
@Name varchar(500),
@Email varchar(100),
@UserName varchar(100),
@Password varchar(100),
@CreatedBy varchar(50),
@userid int,
@Roleid int,
@Reg_userid int


)
as

insert into tbl_user (Name,Email,UserName,Password,CreatedOn,CreatedBy,userid,Roleid,Reg_userid) values (@Name,@Email,@UserName,@Password,getdate(),@CreatedBy,@userid,@Roleid,@Reg_userid)
Select @@identity
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_name]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_user_name] --11
(
@userid int
)
as
select * from tbl_user where Reg_userid=@userid
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_Owner]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_user_Owner]    

as    

select * from tbl_user where Roleid=7  

and userid in (select userid from webpages_Membership where IsConfirmed=1)

 --and Reg_userid not in(select Reg_userid from tbl_user_store)
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_Owner_edit]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_user_Owner_edit]    --3054  

( @Reg_userid int)    

as        

select * from tbl_user where Roleid=7    

and  userid in (select userid from webpages_Membership where IsConfirmed=1)

 --and Reg_userid not in(select Reg_userid from tbl_user_store)
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_Selectstore]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_user_Selectstore]

as

select * from tbl_Store
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_Selectstore_Admin]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_user_Selectstore_Admin]



as



select Id as Storeid,Name as Storename from tbl_Store
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_By_Reg_userid]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[tbl_user_store_By_Reg_userid]
(
@Reg_userid int
)
as
select * from tbl_user_store where Reg_userid=@Reg_userid
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_delete]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[tbl_user_store_delete]
(
@Storeid int
)
as
delete from tbl_user_store where Storeid=@Storeid
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_Insert]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_user_store_Insert]
(
@userid int,
@StoreName varchar(100),
@Reg_userid int
)
as
insert into tbl_user_store (userid,StoreName,Reg_userid) values (@userid,@StoreName,@Reg_userid)
select @@IDENTITY
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_Insert_BackOfficeMan]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_user_store_Insert_BackOfficeMan]  
(  
@Storeid int,  
@userid int,  
@Reg_userid int,  
@StoreName varchar(100)  ,
@RoleId int,
@RoleName varchar(256)

)  
as  
  
insert into tbl_user_store (Storeid,userid,Reg_userid,StoreName,RoleId,RoleName) values (@Storeid,@userid,@Reg_userid,@StoreName,@RoleId,@RoleName)
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_Insert_DataApp]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_user_store_Insert_DataApp]  
(  
@Storeid int,  
@userid int,  
@Reg_userid int,  
@StoreName varchar(100)  ,
@RoleId int,
@RoleName varchar(256)
)  
as  
  
insert into tbl_user_store (Storeid,userid,Reg_userid,StoreName,RoleId,RoleName) values (@Storeid,@userid,@Reg_userid,@StoreName,@RoleId,@RoleName)
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_Insert_Owner]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_user_store_Insert_Owner]  
(  
@Storeid int,  
@userid int,  
@Reg_userid int,  
@StoreName varchar(100)  ,
@RoleId int,
@RoleName varchar(256)
)  
as  
insert into tbl_user_store (Storeid,userid,Reg_userid,StoreName,RoleId,RoleName)
values (@Storeid,@userid,@Reg_userid,@StoreName,@RoleId,@RoleName)
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_Insert_StoreMan]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_user_store_Insert_StoreMan]  
(  
@Storeid int,  
@userid int,  
@Reg_userid int,  
@StoreName varchar(100)  ,
@RoleId int,
@RoleName varchar(256)
)  
as  
  
insert into tbl_user_store (Storeid,userid,Reg_userid,StoreName,RoleId,RoleName) values (@Storeid,@userid,@Reg_userid,@StoreName,@RoleId,@RoleName)
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_select_StorebyUser]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_user_store_select_StorebyUser]
(
@userid int
)
as
select StoreName from tbl_user_store where Reg_userid=@userid
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_Storemanager]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_user_Storemanager]  
as  
select * from tbl_user where Roleid=4 and Reg_userid not in(select Reg_userid from tbl_user_store where Roleid=4 ) 
and userid in (select userid from webpages_Membership where IsConfirmed=1)
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_Storemanager_edit]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_user_Storemanager_edit]  
(@Reg_userid int)  
as    
select * from tbl_user where Roleid=4 and ((Reg_userid not in(select Reg_userid from tbl_user_store)) or Reg_userid=@Reg_userid)
and  userid in (select userid from webpages_Membership where IsConfirmed=1)
GO
/****** Object:  StoredProcedure [dbo].[Update_Employee_Password]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[Update_Employee_Password]
(
@UserName varchar(100),
@Password varchar(100)
)
as
update Employee set [Password]=@Password where UserName=@UserName
GO
/****** Object:  StoredProcedure [dbo].[Update_tbl_user_Password]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create Procedure [dbo].[Update_tbl_user_Password]  
(  
@UserName varchar(100),  
@Password varchar(100)  
)  
as  
update tbl_user set [Password]=@Password where UserName=@UserName
GO
/****** Object:  StoredProcedure [dbo].[webpages_Roles_byRolename]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[webpages_Roles_byRolename]
(
@RoleName varchar(256)
)
as
select RoleId from webpages_Roles where RoleName=@RoleName
GO
/****** Object:  Table [dbo].[QBConfig]    Script Date: 10/17/2018 10:15:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[QBConfig](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Store_Id] [int] NULL,
	[CompanyFilePath] [nvarchar](150) NULL,
	[QBVersion] [nvarchar](50) NULL,
	[IsActive] [bit] NULL,
	[CreatedDate] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[QBYear] [nvarchar](100) NULL,
	[BillAccListID] [nvarchar](150) NULL,
	[BillAccName] [nvarchar](150) NULL,
	[SyncDate] [datetime] NULL,
 CONSTRAINT [PK_QBConfig] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SiteConfiguration]    Script Date: 10/17/2018 10:15:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SiteConfiguration](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[level] [int] NULL,
	[Currencydigit] [int] NULL,
	[Symbol] [varchar](50) NULL,
	[CategoryLarge] [int] NULL,
	[CategoryMedium] [int] NULL,
	[CategorySmall] [int] NULL,
	[ProductLarge] [int] NULL,
	[ProductMedium] [int] NULL,
	[ProductSmall] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Activity_action]    Script Date: 10/17/2018 10:15:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Activity_action](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[Action] [int] NULL,
 CONSTRAINT [PK_tbl_Activity_action] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Activity_log]    Script Date: 10/17/2018 10:15:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Activity_log](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userid] [int] NULL,
	[Comment] [varchar](1000) NULL,
	[Action] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_tbl_Activity_log] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Department]    Script Date: 10/17/2018 10:15:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Department](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[ListID] [nvarchar](50) NULL,
	[StoreID] [int] NOT NULL,
 CONSTRAINT [PK_tbl_Department] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Invoice]    Script Date: 10/17/2018 10:15:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Invoice](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Store_id] [int] NULL,
	[Type_id] [int] NULL,
	[Payment_type] [varchar](50) NULL,
	[Vendor_id] [int] NULL,
	[Invoice_Date] [datetime] NULL,
	[Invoice_Number] [varchar](100) NULL,
	[Note] [varchar](2000) NULL,
	[AttachNote] [varchar](100) NULL,
	[UploadInvoice] [varchar](100) NULL,
	[ScanInvoice] [varchar](100) NULL,
	[TotalAmtByDept] [decimal](18, 2) NULL,
	[IsStatus_id] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[ApproveRejectBy] [varchar](50) NULL,
	[ApproveRejectDate] [datetime] NULL,
	[IsActive] [bit] NULL,
	[TxnID] [nvarchar](50) NULL,
	[IsSync] [int] NULL,
	[NotificationColor] [bit] NULL,
 CONSTRAINT [PK_tbl_Invoice] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Invoice_Department]    Script Date: 10/17/2018 10:15:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Invoice_Department](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Invoice_id] [int] NULL,
	[Dept_id] [int] NULL,
	[Amount] [decimal](18, 2) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_tbl_Invoice_Department] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Pamentype]    Script Date: 10/17/2018 10:15:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Pamentype](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
 CONSTRAINT [PK_tbl_Pamentype] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Status]    Script Date: 10/17/2018 10:15:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Status](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_tbl_Status] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Store]    Script Date: 10/17/2018 10:15:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Store](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](500) NULL,
	[Address] [varchar](1000) NULL,
	[Address2] [varchar](1000) NULL,
	[StoreNo] [varchar](100) NULL,
	[FaxNo] [varchar](20) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_tbl_Store] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Type]    Script Date: 10/17/2018 10:15:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Type](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_tbl_Type] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 10/17/2018 10:15:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NULL,
	[Email] [varchar](100) NULL,
	[UserName] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[Roleid] [int] NULL,
	[Reg_userid] [int] NULL,
	[userid] [int] NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_tbl_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_user_store]    Script Date: 10/17/2018 10:15:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_user_store](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Storeid] [int] NULL,
	[userid] [int] NULL,
	[Reg_userid] [int] NULL,
	[StoreName] [varchar](100) NULL,
	[RoleId] [int] NULL,
	[RoleName] [varchar](256) NULL,
 CONSTRAINT [PK_tbl_user_store] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Vendor]    Script Date: 10/17/2018 10:15:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[tbl_Vendor](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](200) NULL,
	[StoreId] [int] NULL,
	[Address] [varchar](500) NULL,
	[CreatedOn] [datetime] NULL,
	[CreatedBy] [varchar](50) NULL,
	[ModifiedOn] [datetime] NULL,
	[ModifiedBy] [varchar](50) NULL,
	[IsActive] [bit] NULL,
	[ListID] [nvarchar](50) NULL,
	[CompanyName] [nvarchar](200) NULL,
	[PhoneNumber] [nvarchar](50) NULL,
 CONSTRAINT [PK_tbl_Vendor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 10/17/2018 10:15:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserProfile](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](56) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Utilities]    Script Date: 10/17/2018 10:15:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Utilities](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[sitename] [varchar](100) NULL,
	[sitelogo] [varchar](100) NULL,
	[siteurl] [varchar](100) NULL,
	[MailServer] [varchar](100) NULL,
	[from] [varchar](100) NULL,
	[cc] [varchar](500) NULL,
	[username] [varchar](100) NULL,
	[Password] [varchar](100) NULL,
	[Authenticate] [int] NULL,
	[emailtop] [varchar](100) NULL,
	[emailbottom] [varchar](100) NULL,
	[port] [int] NULL,
	[pagination] [int] NULL,
	[sitebyname] [varchar](200) NULL,
	[sitebyurl] [varchar](100) NULL,
 CONSTRAINT [PK_Utilities] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 10/17/2018 10:15:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Membership](
	[UserId] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[ConfirmationToken] [nvarchar](128) NULL,
	[IsConfirmed] [bit] NULL,
	[LastPasswordFailureDate] [datetime] NULL,
	[PasswordFailuresSinceLastSuccess] [int] NOT NULL,
	[Password] [nvarchar](128) NOT NULL,
	[PasswordChangedDate] [datetime] NULL,
	[PasswordSalt] [nvarchar](128) NOT NULL,
	[PasswordVerificationToken] [nvarchar](128) NULL,
	[PasswordVerificationTokenExpirationDate] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 10/17/2018 10:15:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_OAuthMembership](
	[Provider] [nvarchar](30) NOT NULL,
	[ProviderUserId] [nvarchar](100) NOT NULL,
	[UserId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Provider] ASC,
	[ProviderUserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 10/17/2018 10:15:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_Roles](
	[RoleId] [int] IDENTITY(1,1) NOT NULL,
	[RoleName] [nvarchar](256) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 10/17/2018 10:15:01 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[webpages_UsersInRoles](
	[UserId] [int] NOT NULL,
	[RoleId] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[tbl_Activity_action] ON 

GO
INSERT [dbo].[tbl_Activity_action] ([id], [Name], [Action]) VALUES (1, N'Insert', 1)
GO
INSERT [dbo].[tbl_Activity_action] ([id], [Name], [Action]) VALUES (2, N'Edit', 2)
GO
INSERT [dbo].[tbl_Activity_action] ([id], [Name], [Action]) VALUES (3, N'Delete', 3)
GO
INSERT [dbo].[tbl_Activity_action] ([id], [Name], [Action]) VALUES (4, N'Approved', 4)
GO
INSERT [dbo].[tbl_Activity_action] ([id], [Name], [Action]) VALUES (5, N'Rejected', 5)
GO
INSERT [dbo].[tbl_Activity_action] ([id], [Name], [Action]) VALUES (6, N'Pending', 6)
GO
SET IDENTITY_INSERT [dbo].[tbl_Activity_action] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Pamentype] ON 

GO
INSERT [dbo].[tbl_Pamentype] ([id], [Name]) VALUES (1, N'Cash')
GO
INSERT [dbo].[tbl_Pamentype] ([id], [Name]) VALUES (2, N'Check/ACH')
GO
SET IDENTITY_INSERT [dbo].[tbl_Pamentype] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Status] ON 

GO
INSERT [dbo].[tbl_Status] ([id], [Name], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1, N'Pending', CAST(0x0000A8F500D7AA7B AS DateTime), N'1', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Status] ([id], [Name], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (2, N'Approved', CAST(0x0000A8F500D7AA7B AS DateTime), N'1', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Status] ([id], [Name], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (3, N'Rejected', CAST(0x0000A8F500D7AA7B AS DateTime), N'1', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Status] ([id], [Name], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (4, N'On Hold', CAST(0x0000A8F500D7AA7B AS DateTime), N'1', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_Status] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Type] ON 

GO
INSERT [dbo].[tbl_Type] ([id], [Name], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1, N'Invoice', CAST(0x0000A8F500D7AA7B AS DateTime), N'1', CAST(0x0000A8F500D7AA7B AS DateTime), N'1', 1)
GO
INSERT [dbo].[tbl_Type] ([id], [Name], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (2, N'Credit Memo', NULL, NULL, NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_Type] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_user] ON 

GO
INSERT [dbo].[tbl_user] ([id], [Name], [Email], [UserName], [Password], [Roleid], [Reg_userid], [userid], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1, N'System Admin', NULL, N'admin', N'Qwertyuiop1@', 1, 1009, 1009, CAST(0x0000A903011B43E3 AS DateTime), N'admin', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_user] OFF
GO
SET IDENTITY_INSERT [dbo].[UserProfile] ON 

GO
INSERT [dbo].[UserProfile] ([UserId], [UserName]) VALUES (1009, N'admin')
GO
SET IDENTITY_INSERT [dbo].[UserProfile] OFF
GO
SET IDENTITY_INSERT [dbo].[webpages_Roles] ON 

GO
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (1, N'Administrator')
GO
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (2, N'Back Office Manager')
GO
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (3, N'Data Approver')
GO
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (7, N'Owner')
GO
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (4, N'Store Manager')
GO
SET IDENTITY_INSERT [dbo].[webpages_Roles] OFF
GO
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (1009, 1)
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__UserProf__C9F284566316A651]    Script Date: 10/17/2018 10:15:13 AM ******/
ALTER TABLE [dbo].[UserProfile] ADD UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__webpages__8A2B6160B53DAA49]    Script Date: 10/17/2018 10:15:13 AM ******/
ALTER TABLE [dbo].[webpages_Roles] ADD UNIQUE NONCLUSTERED 
(
	[RoleName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[tbl_Activity_log] ADD  CONSTRAINT [DF_tbl_Activity_log_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Department] ADD  CONSTRAINT [DF_tbl_Department_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Department] ADD  CONSTRAINT [DF_tbl_Department_StoreID]  DEFAULT ((0)) FOR [StoreID]
GO
ALTER TABLE [dbo].[tbl_Invoice] ADD  CONSTRAINT [DF_tbl_Invoice_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Invoice] ADD  DEFAULT ((0)) FOR [IsSync]
GO
ALTER TABLE [dbo].[tbl_Invoice] ADD  CONSTRAINT [DF_tbl_Invoice_NotificationColor]  DEFAULT ((0)) FOR [NotificationColor]
GO
ALTER TABLE [dbo].[tbl_Invoice_Department] ADD  CONSTRAINT [DF_tbl_Invoice_Department_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Status] ADD  CONSTRAINT [DF_tbl_Status_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Store] ADD  CONSTRAINT [DF_tbl_Store_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Type] ADD  CONSTRAINT [DF_tbl_Type_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_user] ADD  CONSTRAINT [DF_tbl_user_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[tbl_Vendor] ADD  CONSTRAINT [DF_tbl_Vendor_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [IsConfirmed]
GO
ALTER TABLE [dbo].[webpages_Membership] ADD  DEFAULT ((0)) FOR [PasswordFailuresSinceLastSuccess]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[webpages_Roles] ([RoleId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_RoleId]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles]  WITH CHECK ADD  CONSTRAINT [fk_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[UserProfile] ([UserId])
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] CHECK CONSTRAINT [fk_UserId]
GO
