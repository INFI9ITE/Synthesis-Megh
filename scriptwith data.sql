USE [WestZone]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] DROP CONSTRAINT [fk_UserId]
GO
ALTER TABLE [dbo].[webpages_UsersInRoles] DROP CONSTRAINT [fk_RoleId]
GO
ALTER TABLE [dbo].[webpages_Membership] DROP CONSTRAINT [DF__webpages___Passw__1A14E395]
GO
ALTER TABLE [dbo].[webpages_Membership] DROP CONSTRAINT [DF__webpages___IsCon__1920BF5C]
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
ALTER TABLE [dbo].[tbl_Invoice] DROP CONSTRAINT [DF__tbl_Invoi__IsSyn__40C49C62]
GO
ALTER TABLE [dbo].[tbl_Invoice] DROP CONSTRAINT [DF_tbl_Invoice_IsActive]
GO
ALTER TABLE [dbo].[tbl_Department] DROP CONSTRAINT [DF_tbl_Department_StoreID]
GO
ALTER TABLE [dbo].[tbl_Department] DROP CONSTRAINT [DF_tbl_Department_IsActive]
GO
ALTER TABLE [dbo].[tbl_Activity_log] DROP CONSTRAINT [DF_tbl_Activity_log_IsActive]
GO
/****** Object:  Index [UQ__webpages__8A2B61602BB1CB15]    Script Date: 8/29/2018 2:50:27 PM ******/
ALTER TABLE [dbo].[webpages_Roles] DROP CONSTRAINT [UQ__webpages__8A2B61602BB1CB15]
GO
/****** Object:  Index [UQ__UserProf__C9F28456EE504BDB]    Script Date: 8/29/2018 2:50:27 PM ******/
ALTER TABLE [dbo].[UserProfile] DROP CONSTRAINT [UQ__UserProf__C9F28456EE504BDB]
GO
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP TABLE [dbo].[webpages_UsersInRoles]
GO
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP TABLE [dbo].[webpages_Roles]
GO
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP TABLE [dbo].[webpages_OAuthMembership]
GO
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP TABLE [dbo].[webpages_Membership]
GO
/****** Object:  Table [dbo].[Utilities]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP TABLE [dbo].[Utilities]
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP TABLE [dbo].[UserProfile]
GO
/****** Object:  Table [dbo].[tbl_Vendor]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP TABLE [dbo].[tbl_Vendor]
GO
/****** Object:  Table [dbo].[tbl_user_store]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP TABLE [dbo].[tbl_user_store]
GO
/****** Object:  Table [dbo].[tbl_user]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP TABLE [dbo].[tbl_user]
GO
/****** Object:  Table [dbo].[tbl_Type]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP TABLE [dbo].[tbl_Type]
GO
/****** Object:  Table [dbo].[tbl_Store]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP TABLE [dbo].[tbl_Store]
GO
/****** Object:  Table [dbo].[tbl_Status]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP TABLE [dbo].[tbl_Status]
GO
/****** Object:  Table [dbo].[tbl_Pamentype]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP TABLE [dbo].[tbl_Pamentype]
GO
/****** Object:  Table [dbo].[tbl_Invoice_Department]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP TABLE [dbo].[tbl_Invoice_Department]
GO
/****** Object:  Table [dbo].[tbl_Invoice]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP TABLE [dbo].[tbl_Invoice]
GO
/****** Object:  Table [dbo].[tbl_Department]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP TABLE [dbo].[tbl_Department]
GO
/****** Object:  Table [dbo].[tbl_Activity_log]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP TABLE [dbo].[tbl_Activity_log]
GO
/****** Object:  Table [dbo].[tbl_Activity_action]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP TABLE [dbo].[tbl_Activity_action]
GO
/****** Object:  Table [dbo].[SiteConfiguration]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP TABLE [dbo].[SiteConfiguration]
GO
/****** Object:  Table [dbo].[QBConfig]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP TABLE [dbo].[QBConfig]
GO
/****** Object:  StoredProcedure [dbo].[webpages_Roles_byRolename]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[webpages_Roles_byRolename]
GO
/****** Object:  StoredProcedure [dbo].[Update_tbl_user_Password]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[Update_tbl_user_Password]
GO
/****** Object:  StoredProcedure [dbo].[Update_Employee_Password]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[Update_Employee_Password]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_Storemanager_edit]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_user_Storemanager_edit]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_Storemanager]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_user_Storemanager]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_select_StorebyUser]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_user_store_select_StorebyUser]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_Insert_StoreMan]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_user_store_Insert_StoreMan]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_Insert_DataApp]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_user_store_Insert_DataApp]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_Insert_BackOfficeMan]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_user_store_Insert_BackOfficeMan]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_Insert]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_user_store_Insert]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_delete]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_user_store_delete]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_store_By_Reg_userid]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_user_store_By_Reg_userid]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_name]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_user_name]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_Insert]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_user_Insert]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_GridData_byid]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_user_GridData_byid]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_GridData]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_user_GridData]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_DataApprover_edit]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_user_DataApprover_edit]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_DataApprover]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_user_DataApprover]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_byid]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_user_byid]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_backoffice_edit_new]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_user_backoffice_edit_new]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_backoffice_edit]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_user_backoffice_edit]
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_backoffice]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_user_backoffice]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Store_Update]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_Store_Update]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Store_GridData]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_Store_GridData]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Store_exists]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_Store_exists]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Store_Create]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_Store_Create]
GO
/****** Object:  StoredProcedure [dbo].[tbl_store_byid]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_store_byid]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Insert_StoreManager]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_Insert_StoreManager]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Insert]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_Insert]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_GridData_ForPdf]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_GridData_ForPdf]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_GridData_ForExcel]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_GridData_ForExcel]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_GridData]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_GridData]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_exists_InNo]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_exists_InNo]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Department_Insert]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_Department_Insert]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Dashbord_GridData_StoreManager]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_Dashbord_GridData_StoreManager]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Dashbord_GridData_DataApp]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_Dashbord_GridData_DataApp]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Dashbord_GridData_Administrator]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_Dashbord_GridData_Administrator]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Dashbord_GridData]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_Invoice_Dashbord_GridData]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Activity_log_Insert]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_Activity_log_Insert]
GO
/****** Object:  StoredProcedure [dbo].[tbl_Acivity_Log_GridData]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[tbl_Acivity_Log_GridData]
GO
/****** Object:  StoredProcedure [dbo].[SPVendor]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[SPVendor]
GO
/****** Object:  StoredProcedure [dbo].[SPStore]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[SPStore]
GO
/****** Object:  StoredProcedure [dbo].[SPInvoiceDepartment]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[SPInvoiceDepartment]
GO
/****** Object:  StoredProcedure [dbo].[SPInvoice]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[SPInvoice]
GO
/****** Object:  StoredProcedure [dbo].[SPDepartment]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[SPDepartment]
GO
/****** Object:  StoredProcedure [dbo].[Select_RoleId_ByUserid]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[Select_RoleId_ByUserid]
GO
/****** Object:  StoredProcedure [dbo].[Membership_EnableUser]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[Membership_EnableUser]
GO
/****** Object:  StoredProcedure [dbo].[Membership_DisableUser]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[Membership_DisableUser]
GO
/****** Object:  StoredProcedure [dbo].[getusernames]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[getusernames]
GO
/****** Object:  StoredProcedure [dbo].[GetUser_dataApproval]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[GetUser_dataApproval]
GO
/****** Object:  StoredProcedure [dbo].[GetRoleNameListByUserId]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[GetRoleNameListByUserId]
GO
/****** Object:  StoredProcedure [dbo].[GetRoleNameList]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[GetRoleNameList]
GO
/****** Object:  StoredProcedure [dbo].[getrolebyusername]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[getrolebyusername]
GO
/****** Object:  StoredProcedure [dbo].[GetEmailId]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[GetEmailId]
GO
/****** Object:  StoredProcedure [dbo].[Get_roleid_rolename_byReg_userid]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[Get_roleid_rolename_byReg_userid]
GO
/****** Object:  StoredProcedure [dbo].[Get_ReguserId_edit_storeman]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[Get_ReguserId_edit_storeman]
GO
/****** Object:  StoredProcedure [dbo].[Get_ReguserId_edit_dataapp]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[Get_ReguserId_edit_dataapp]
GO
/****** Object:  StoredProcedure [dbo].[Get_ReguserId_edit]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[Get_ReguserId_edit]
GO
/****** Object:  StoredProcedure [dbo].[Get_InvoiceNotification_Grid]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[Get_InvoiceNotification_Grid]
GO
/****** Object:  StoredProcedure [dbo].[Get_InvoiceNotification]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[Get_InvoiceNotification]
GO
/****** Object:  StoredProcedure [dbo].[delete_multiple_userstores]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[delete_multiple_userstores]
GO
/****** Object:  StoredProcedure [dbo].[delete_multiple_userRole]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[delete_multiple_userRole]
GO
/****** Object:  StoredProcedure [dbo].[BindDataapproval]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[BindDataapproval]
GO
/****** Object:  StoredProcedure [dbo].[BindBackofficemanager]    Script Date: 8/29/2018 2:50:27 PM ******/
DROP PROCEDURE [dbo].[BindBackofficemanager]
GO
/****** Object:  StoredProcedure [dbo].[BindBackofficemanager]    Script Date: 8/29/2018 2:50:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[BindBackofficemanager]
as
select * From tbl_user  where roleid in (3,2) and 
Reg_userid not in  (select Reg_userid from tbl_user_store where Roleid=2)
GO
/****** Object:  StoredProcedure [dbo].[BindDataapproval]    Script Date: 8/29/2018 2:50:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create Procedure [dbo].[BindDataapproval]
@id int 
as
select * From tbl_user  where roleid in (3) and id !=@id
GO
/****** Object:  StoredProcedure [dbo].[delete_multiple_userRole]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[delete_multiple_userstores]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Get_InvoiceNotification]    Script Date: 8/29/2018 2:50:27 PM ******/
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
	 from tbl_Invoice  where IsStatus_id=1 and Store_id=@Store_id and createdby in(select Reg_userid from tbl_user where roleid=2) 
	END
	else if (@roleid = 4)
	BEGIN
		select top(5) *,
	(select name from tbl_Store where id=tbl_Invoice.Store_id) as storename,
	(select Name from tbl_user where Reg_userid=tbl_Invoice.CreatedBy) as fullname
	 from tbl_Invoice  where IsStatus_id=1 and Store_id=@Store_id and createdby in(select Reg_userid from tbl_user where roleid=3) 
	END
	else
	BEGIN
		select top(5) *,
	(select name from tbl_Store where id=tbl_Invoice.Store_id) as storename,
	(select Name from tbl_user where Reg_userid=tbl_Invoice.CreatedBy) as fullname
	 from tbl_Invoice  where id=0
	END
GO
/****** Object:  StoredProcedure [dbo].[Get_InvoiceNotification_Grid]    Script Date: 8/29/2018 2:50:27 PM ******/
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
	 from tbl_Invoice  where IsStatus_id=1 and Store_id=@Store_id and createdby in(select Reg_userid from tbl_user where roleid=2) 
	  order by id desc
	END
	else if (@roleid = 4)
	BEGIN
		select *,
	(select name from tbl_Store where id=tbl_Invoice.Store_id) as storename,
	(select Name from tbl_user where Reg_userid=tbl_Invoice.CreatedBy) as fullname
	 from tbl_Invoice  where IsStatus_id=1 and Store_id=@Store_id and createdby in(select Reg_userid from tbl_user where roleid=3) 
	  order by id desc
	END
	else
	BEGIN
	select *,
	(select name from tbl_Store where id=tbl_Invoice.Store_id) as storename,
	(select Name from tbl_user where Reg_userid=tbl_Invoice.CreatedBy) as fullname
	 from tbl_Invoice  where id=0
	  END
GO
/****** Object:  StoredProcedure [dbo].[Get_ReguserId_edit]    Script Date: 8/29/2018 2:50:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[Get_ReguserId_edit]  
(  
@Storeid int  
)  
as  
select * from tbl_user_store where Storeid=@Storeid and RoleId=2
GO
/****** Object:  StoredProcedure [dbo].[Get_ReguserId_edit_dataapp]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Get_ReguserId_edit_storeman]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Get_roleid_rolename_byReg_userid]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetEmailId]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[getrolebyusername]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetRoleNameList]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetRoleNameListByUserId]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[GetUser_dataApproval]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[getusernames]    Script Date: 8/29/2018 2:50:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[getusernames]  
  
AS  
  
SELECT * from UserProfile   
  
ORDER BY UserId asc  
  
GO
/****** Object:  StoredProcedure [dbo].[Membership_DisableUser]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Membership_EnableUser]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Select_RoleId_ByUserid]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SPDepartment]    Script Date: 8/29/2018 2:50:27 PM ******/
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
END
GO
/****** Object:  StoredProcedure [dbo].[SPInvoice]    Script Date: 8/29/2018 2:50:27 PM ******/
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
			Select I.*,V.Name,V.CompanyName,V.Address,V.IsActive As VIsActive,V.ListID,T.Name as TypeName
			 from tbl_Invoice as I
			INNER JOIN tbl_Vendor as V 
			on V.id=I.Vendor_id
			INNER JOIN tbl_Type as T
			on T.id=I.Type_id
			Where I.IsStatus_id=2 and (IsSync=0 Or IsSync IS Null) --and Store_id=@StoreID
		END
	IF(@Spara=2)
		BEGIN
			UPDATE tbl_Invoice
			Set TxnID=@TxnID,
			IsSync =1
			Where id=@ID --and Store_id=@StoreID
		END
END
GO
/****** Object:  StoredProcedure [dbo].[SPInvoiceDepartment]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[SPStore]    Script Date: 8/29/2018 2:50:27 PM ******/
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
@QBYear nvarchar(100)=null
AS 
BEGIN
	IF(@Spara=1)
		BEGIN
			Select  Id ,Name from tbl_Store where IsActive=1 and Id Not in (Select Store_id from QBConfig)
		END
	IF(@Spara=2)
		BEGIN
			Insert into QBConfig (Store_Id,CompanyFilePath,QBVersion,QBYear,IsActive,CreatedDate) 
			values
			(@Store_Id,@CompanyFilePath,@QBVersion,@QBYear,1,GETDATE())
		END
	IF(@Spara=3)
		BEGIN
			Update QBConfig set [Store_Id]=@Store_Id,[CompanyFilePath]=@CompanyFilePath,[QBVersion]=@QBVersion,[QBYear]=@QBYear,[UpdateDate]=GETDATE()
			Where Id=@Id
		END
	
	IF(@Spara=4)
		BEGIN
			Select s.*,qb.CompanyFilePath,qb.QBVersion,qb.QBYear,qb.Id as QBId from tbl_Store as s
			Inner join QBConfig qb
			on qb.Store_Id=s.Id
			 where s.IsActive=1 
		END
	IF(@Spara=5)
		BEGIN
			DELETE From QBConfig where Id=@Id
		END
	
END
GO
/****** Object:  StoredProcedure [dbo].[SPVendor]    Script Date: 8/29/2018 2:50:27 PM ******/
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
@ListID nvarchar(50)=null
AS
 begin
	 IF (@Spara=1)
	 Begin
		INSERT INTO tbl_Vendor ([Name],[StoreID],[Address],[CompanyName],[CreatedOn],[CreatedBy],[IsActive],[ListID])
		VALUES(@Name,@StoreID,@Address,@CompanyName,GETDATE(),@CreatedBy,@IsActive,@ListID)
	end
    IF(@Spara=2)
	BEGIN
		UPDATE tbl_Vendor SET 
		[Name]=@Name,[Address]=@Address,
		[CompanyName]=@CompanyName,[IsActive]=@IsActive,[ModifiedBy]=@ModifiedBy,[ModifiedOn]=GETDATE()
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
END
GO
/****** Object:  StoredProcedure [dbo].[tbl_Acivity_Log_GridData]    Script Date: 8/29/2018 2:50:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[tbl_Acivity_Log_GridData]   
  
 
  as
SELECT *  
  
 from tbl_Activity_log   
  
 
GO
/****** Object:  StoredProcedure [dbo].[tbl_Activity_log_Insert]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Dashbord_GridData]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Dashbord_GridData_Administrator]    Script Date: 8/29/2018 2:50:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[tbl_Invoice_Dashbord_GridData_Administrator] --2,'vibhusha',3086

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
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Dashbord_GridData_DataApp]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Dashbord_GridData_StoreManager]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Department_Insert]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_exists_InNo]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_GridData]    Script Date: 8/29/2018 2:50:27 PM ******/
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
,(select Amount from tbl_Invoice_Department where Invoice_id=tbl_Invoice.id and Dept_id=@Dept_id) as deptamt
,(select id from tbl_Invoice_Department where Invoice_id =tbl_Invoice.id and Dept_id=@Dept_id) as deptid
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
    --((Invoice_Number like '%'+@Invoice_Number+'%') or (isnull(Invoice_Number,'')='')) and ((tbl_Invoice.Vendor_id=@Vendor) or (isnull(tbl_Invoice.Vendor_id,0)=0))

GO
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_GridData_ForExcel]    Script Date: 8/29/2018 2:50:27 PM ******/
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

select *,convert(varchar,Invoice_Date,101) as Invoice_Date_str,

(select Name from tbl_Store where id=tbl_Invoice.Store_id) as Storename

,(select Name from tbl_Type where id=tbl_Invoice.Type_id) as Typename

,(select Name from tbl_Vendor where id=tbl_Invoice.Vendor_id) as vendorname

,(select Name from tbl_Status where id=tbl_Invoice.IsStatus_id) as Statusname

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
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_GridData_ForPdf]    Script Date: 8/29/2018 2:50:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[tbl_Invoice_GridData_ForPdf] --'','','','',0,1

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

select Invoice_Number,convert(varchar,Invoice_Date,101) as Invoice_Date,TotalAmtByDept,Payment_type,

--(select Name from tbl_Store where id=tbl_Invoice.Store_id) as Storename

(select Name from tbl_Type where id=tbl_Invoice.Type_id) as Typename

,(select Name from tbl_Vendor where id=tbl_Invoice.Vendor_id) as vendorname

,(select Name from tbl_Status where id=tbl_Invoice.IsStatus_id) as Statusname

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
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Insert]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_Invoice_Insert_StoreManager]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_store_byid]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_Store_Create]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_Store_exists]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_Store_GridData]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_Store_Update]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_user_backoffice]    Script Date: 8/29/2018 2:50:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_user_backoffice]  
as  
select * from tbl_user where Roleid=2 and Reg_userid not in(select Reg_userid from tbl_user_store where Roleid=2)
and userid in (select userid from webpages_Membership where IsConfirmed=1)
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_backoffice_edit]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_user_backoffice_edit_new]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_user_byid]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_user_DataApprover]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_user_DataApprover_edit]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_user_GridData]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_user_GridData_byid]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_user_Insert]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_user_name]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_user_store_By_Reg_userid]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_user_store_delete]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_user_store_Insert]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_user_store_Insert_BackOfficeMan]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_user_store_Insert_DataApp]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_user_store_Insert_StoreMan]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_user_store_select_StorebyUser]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[tbl_user_Storemanager]    Script Date: 8/29/2018 2:50:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[tbl_user_Storemanager]  
as  
select * from tbl_user where Roleid=4 and Reg_userid not in(select Reg_userid from tbl_user_store where Roleid=4 ) 
and userid in (select userid from webpages_Membership where IsConfirmed=1)
GO
/****** Object:  StoredProcedure [dbo].[tbl_user_Storemanager_edit]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Update_Employee_Password]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[Update_tbl_user_Password]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  StoredProcedure [dbo].[webpages_Roles_byRolename]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  Table [dbo].[QBConfig]    Script Date: 8/29/2018 2:50:27 PM ******/
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
 CONSTRAINT [PK_QBConfig] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SiteConfiguration]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  Table [dbo].[tbl_Activity_action]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  Table [dbo].[tbl_Activity_log]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  Table [dbo].[tbl_Department]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  Table [dbo].[tbl_Invoice]    Script Date: 8/29/2018 2:50:27 PM ******/
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
 CONSTRAINT [PK_tbl_Invoice] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[tbl_Invoice_Department]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  Table [dbo].[tbl_Pamentype]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  Table [dbo].[tbl_Status]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  Table [dbo].[tbl_Store]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  Table [dbo].[tbl_Type]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  Table [dbo].[tbl_user]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  Table [dbo].[tbl_user_store]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  Table [dbo].[tbl_Vendor]    Script Date: 8/29/2018 2:50:27 PM ******/
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
 CONSTRAINT [PK_tbl_Vendor] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  Table [dbo].[Utilities]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  Table [dbo].[webpages_Membership]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  Table [dbo].[webpages_OAuthMembership]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  Table [dbo].[webpages_Roles]    Script Date: 8/29/2018 2:50:27 PM ******/
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
/****** Object:  Table [dbo].[webpages_UsersInRoles]    Script Date: 8/29/2018 2:50:27 PM ******/
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
SET IDENTITY_INSERT [dbo].[tbl_Activity_action] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Activity_log] ON 

GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1, 3080, N'Store <a href=''/admin/store/detail/1''>d-mart</a> created by System Admin on 06/29/2018 06:27 PM', 1, CAST(0x0000A90E013015FA AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (2, 3080, N'Store <a href=''/admin/store/detail/2''>v-mart</a> created by System Admin on 06/29/2018 06:28 PM', 1, CAST(0x0000A90E01305C9E AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (3, 3086, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/1''>BK0001</a> created by Sonali Surve on 06/29/2018 06:29 PM', 1, CAST(0x0000A90E0130DFCE AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (4, 3089, N'Quick Invoice Number <a href=''/Admin/InvoiceReport/Detail/2''>SM001</a> created by Parth Patel on 06/29/2018 06:31 PM', 1, CAST(0x0000A90E01314AD3 AS DateTime), N'parth', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (5, 3086, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/3''>DA001</a> created by Sonali Surve on 06/29/2018 06:32 PM', 1, CAST(0x0000A90E0131AFDD AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (6, 3089, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/1''>BK0001</a> Approved by Parth Patel on 06/30/2018 10:00 AM', 4, CAST(0x0000A90F00A4EC17 AS DateTime), N'parth', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (7, 3081, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/4''>note1</a> created by Lipsa Ukani on 06/30/2018 04:08 PM', 1, CAST(0x0000A90F0109F191 AS DateTime), N'lipsa', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (8, 3086, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/5''>not2</a> created by Sonali Surve on 06/30/2018 04:08 PM', 1, CAST(0x0000A90F010A20DB AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (9, 3081, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/6''>dfdfdf</a> created by Lipsa Ukani on 06/30/2018 04:57 PM', 1, CAST(0x0000A90F01178D4C AS DateTime), N'lipsa', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (10, 3086, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/7''>DA00001</a> created by Sonali Surve on 07/03/2018 11:34 AM', 1, CAST(0x0000A91200BEC100 AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (11, 3086, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/8''>DA00002</a> created by Sonali Surve on 07/03/2018 11:41 AM', 1, CAST(0x0000A91200C09468 AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (12, 3086, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/9''>DA00003</a> created by Sonali Surve on 07/03/2018 11:44 AM', 1, CAST(0x0000A91200C17953 AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (13, 3086, N'Invoice Note with this Invoice Number <a href=''/Admin/InvoiceReport/Detail/8''>DA00002</a> Edited by Sonali Surve on 07/04/2018 10:31 AM', 2, CAST(0x0000A91300AD922D AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (14, 3089, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/8''>DA00002</a> Approved by Parth Patel on 07/04/2018 10:38 AM', 4, CAST(0x0000A91300AF6020 AS DateTime), N'parth', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (15, 3080, N'Store <a href=''/admin/store/detail/2''>v-mart</a> edited by System Admin on 07/04/2018 03:20 PM', 2, CAST(0x0000A91300FCBCB5 AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (16, 3080, N'Store <a href=''/admin/store/detail/1''>d-mart</a> edited by System Admin on 07/04/2018 03:33 PM', 2, CAST(0x0000A9130100684C AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (17, 3080, N'User <a href=''/admin/user/detail/10''>parth</a> updated by System Admin on 07/04/2018 03:46 PM', 2, CAST(0x0000A9130104021D AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (18, 3080, N'Store <a href=''/admin/store/detail/2''>v-mart</a> edited by System Admin on 07/04/2018 03:54 PM', 2, CAST(0x0000A91301064FFD AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (19, 3080, N'Store <a href=''/admin/store/detail/1''>d-mart</a> edited by System Admin on 07/04/2018 03:55 PM', 2, CAST(0x0000A91301067526 AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (20, 3080, N'Store <a href=''/admin/store/detail/2''>v-mart</a> edited by System Admin on 07/04/2018 03:56 PM', 2, CAST(0x0000A9130106B3B8 AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (21, 3080, N'Store <a href=''/admin/store/detail/1''>d-mart</a> edited by System Admin on 07/04/2018 03:56 PM', 2, CAST(0x0000A9130106BFCC AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (22, 3080, N'Store <a href=''/admin/store/detail/3''>Fbb Mart</a> created by System Admin on 07/05/2018 11:44 AM', 1, CAST(0x0000A91400C1726F AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (23, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/1''>BK0001</a> created by Brinda Ukani on 07/05/2018 11:45 AM', 1, CAST(0x0000A91400C1DE95 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (24, 3081, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/2''>BK0002</a> created by Lipsa Ukani on 07/05/2018 11:58 AM', 1, CAST(0x0000A91400C54BAA AS DateTime), N'lipsa', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (25, 3085, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/3''>DA0001</a> created by Monali Surve on 07/05/2018 12:06 PM', 1, CAST(0x0000A91400C799D0 AS DateTime), N'monali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (26, 3085, N'Quick Invoice Number <a href=''/Admin/InvoiceReport/Detail/4''>DA000_Q1</a> created by Monali Surve on 07/05/2018 12:09 PM', 1, CAST(0x0000A91400C84431 AS DateTime), N'monali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (27, 3087, N'Quick Invoice Number <a href=''/Admin/InvoiceReport/Detail/5''>SM000_q2</a> created by Priyansh rajput on 07/05/2018 12:35 PM', 1, CAST(0x0000A91400CFA6F5 AS DateTime), N'priyansh', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (28, 3082, N'Invoice Note with this Invoice Number <a href=''/Admin/InvoiceReport/Detail/1''>BK0001</a> Edited by Brinda Ukani on 07/05/2018 12:37 PM', 2, CAST(0x0000A91400CFFA53 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (29, 3085, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/1''>BK0001</a> Approved by Monali Surve on 07/05/2018 12:38 PM', 4, CAST(0x0000A91400D06016 AS DateTime), N'monali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (30, 3085, N'Invoice Note with this Invoice Number <a href=''/Admin/InvoiceReport/Detail/3''>DA0001</a> Edited by Monali Surve on 07/05/2018 12:40 PM', 2, CAST(0x0000A91400D0F5FE AS DateTime), N'monali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (31, 3087, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/3''>DA0001</a> Rejected by Priyansh rajput on 07/05/2018 12:41 PM', 5, CAST(0x0000A91400D13D9F AS DateTime), N'priyansh', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (32, 3087, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/3''>DA0001</a> Rejected by Priyansh rajput on 07/05/2018 12:41 PM', 5, CAST(0x0000A91400D14FD6 AS DateTime), N'priyansh', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (33, 3084, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/6''>DA0002</a> created by Vibhusha on 07/05/2018 12:43 PM', 1, CAST(0x0000A91400D19C15 AS DateTime), N'vibhusha', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (34, 3087, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/6''>DA0002</a> Rejected by Priyansh rajput on 07/05/2018 12:43 PM', 5, CAST(0x0000A91400D1C258 AS DateTime), N'priyansh', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (35, 3084, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/7''>DA0003</a> created by Vibhusha on 07/05/2018 12:44 PM', 1, CAST(0x0000A91400D1FA5F AS DateTime), N'vibhusha', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (36, 3087, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/7''>DA0003</a> Rejected by Priyansh rajput on 07/05/2018 12:44 PM', 5, CAST(0x0000A91400D21288 AS DateTime), N'priyansh', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (37, 3084, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/8''>DA0004</a> created by Vibhusha on 07/05/2018 12:48 PM', 1, CAST(0x0000A91400D3095A AS DateTime), N'vibhusha', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (38, 3087, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/8''>DA0004</a> Rejected by Priyansh rajput on 07/05/2018 12:48 PM', 5, CAST(0x0000A91400D32195 AS DateTime), N'priyansh', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (39, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/9''>BK0003</a> created by Brinda Ukani on 07/05/2018 12:52 PM', 1, CAST(0x0000A91400D454EC AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (40, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/10''>Bk0004</a> created by Brinda Ukani on 07/05/2018 12:53 PM', 1, CAST(0x0000A91400D48960 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (41, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/11''>Bk0005</a> created by Brinda Ukani on 07/05/2018 12:54 PM', 1, CAST(0x0000A91400D4ABD0 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (42, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/12''>Bk0006</a> created by Brinda Ukani on 07/05/2018 12:54 PM', 1, CAST(0x0000A91400D4CDBC AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (43, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/13''>Bk0007</a> created by Brinda Ukani on 07/05/2018 12:55 PM', 1, CAST(0x0000A91400D512F5 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (44, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/14''>Bk0008</a> created by Brinda Ukani on 07/05/2018 12:56 PM', 1, CAST(0x0000A91400D540BC AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (45, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/15''>Bk0009</a> created by Brinda Ukani on 07/05/2018 12:56 PM', 1, CAST(0x0000A91400D568D8 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (46, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/16''>BK0009</a> created by Brinda Ukani on 07/05/2018 01:57 PM', 1, CAST(0x0000A91400E62307 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (47, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/17''>BK00010</a> created by Brinda Ukani on 07/05/2018 01:58 PM', 1, CAST(0x0000A91400E65665 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (48, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/18''>BK00010</a> created by Brinda Ukani on 07/05/2018 02:01 PM', 1, CAST(0x0000A91400E74006 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (49, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/19''>BK00012</a> created by Brinda Ukani on 07/05/2018 02:04 PM', 1, CAST(0x0000A91400E7DF68 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (50, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/20''>BK00013</a> created by Brinda Ukani on 07/05/2018 02:04 PM', 1, CAST(0x0000A91400E803D3 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (51, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/21''>BK00014</a> created by Brinda Ukani on 07/05/2018 02:05 PM', 1, CAST(0x0000A91400E8330F AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (52, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/22''>BK00015</a> created by Brinda Ukani on 07/05/2018 02:06 PM', 1, CAST(0x0000A91400E869C6 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (53, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/23''>BK00016</a> created by Brinda Ukani on 07/05/2018 02:06 PM', 1, CAST(0x0000A91400E88E4E AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (54, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/24''>BK00017</a> created by Brinda Ukani on 07/05/2018 02:07 PM', 1, CAST(0x0000A91400E8AE8E AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (55, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/25''>BK00017</a> created by Brinda Ukani on 07/05/2018 02:07 PM', 1, CAST(0x0000A91400E8D6E4 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (56, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/26''>BK00019</a> created by Brinda Ukani on 07/05/2018 02:08 PM', 1, CAST(0x0000A91400E9051F AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (57, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/27''>BK00021</a> created by Brinda Ukani on 07/05/2018 02:08 PM', 1, CAST(0x0000A91400E928C8 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (58, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/28''>BK00022</a> created by Brinda Ukani on 07/05/2018 02:09 PM', 1, CAST(0x0000A91400E96433 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (59, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/29''>BK00023</a> created by Brinda Ukani on 07/05/2018 02:10 PM', 1, CAST(0x0000A91400E9B42A AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (60, 3082, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/30''>BK00024</a> created by Brinda Ukani on 07/05/2018 02:11 PM', 1, CAST(0x0000A91400E9F944 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (61, 3080, N'User <a href=''/admin/user/detail/11''>parh</a> created by System Admin on 07/06/2018 12:38 PM', 1, CAST(0x0000A91500D03A21 AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (62, 3081, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/32''>Invoice No1</a> created by Lipsa Ukani on 08/24/2018 04:37 PM', 1, CAST(0x0000A94601120AC8 AS DateTime), N'lipsa', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1062, 3081, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/1032''>invoice no2</a> created by Lipsa Ukani on 08/24/2018 05:38 PM', 1, CAST(0x0000A9460122BB5A AS DateTime), N'lipsa', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1063, 3086, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/1033''>invoice 3</a> created by Sonali Surve on 08/25/2018 12:21 PM', 1, CAST(0x0000A94700CBDAE7 AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1064, 3086, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/1034''>invoice 4</a> created by Sonali Surve on 08/25/2018 12:23 PM', 1, CAST(0x0000A94700CC3485 AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1065, 3086, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/1035''>invoice 5</a> created by Sonali Surve on 08/25/2018 02:10 PM', 1, CAST(0x0000A94700E9A49E AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1066, 3086, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/1036''>invoice 6</a> created by Sonali Surve on 08/25/2018 02:12 PM', 1, CAST(0x0000A94700EA1C21 AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1067, 3086, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/1037''>DA0001</a> created by Sonali Surve on 08/27/2018 04:24 PM', 1, CAST(0x0000A949010E837A AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1068, 3080, N'Quick Invoice Number <a href=''/Admin/InvoiceReport/Detail/1038''>BK0002</a> created by System Admin on 08/28/2018 10:45 AM', 1, CAST(0x0000A94A00B13B22 AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1069, 3086, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/1040''>BK0002</a> created by Sonali Surve on 08/28/2018 11:53 AM', 1, CAST(0x0000A94A00C3E1B8 AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1070, 3086, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/1041''>vinvoice1</a> created by Sonali Surve on 08/28/2018 11:54 AM', 1, CAST(0x0000A94A00C42767 AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1071, 3086, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/1042''>vinvoice2</a> created by Sonali Surve on 08/28/2018 12:02 PM', 1, CAST(0x0000A94A00C661BD AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1072, 3080, N'Invoice Number BK0002 deleted by System Admin on 08/28/2018 06:52 PM', 3, CAST(0x0000A94A0136F198 AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1073, 3080, N'Invoice Number Bk0004 deleted by System Admin on 08/28/2018 06:56 PM', 3, CAST(0x0000A94A0137F29D AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1074, 3080, N'Quick Invoice Number <a href=''/Admin/InvoiceReport/Detail/1043''>test in1</a> created by System Admin on 08/29/2018 11:54 AM', 1, CAST(0x0000A94B00C43FD2 AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1075, 3080, N'Quick Invoice Number <a href=''/Admin/InvoiceReport/Detail/1044''>test in2</a> created by System Admin on 08/29/2018 11:55 AM', 1, CAST(0x0000A94B00C48646 AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1076, 3080, N'Quick Invoice Number <a href=''/Admin/InvoiceReport/Detail/1045''>test in 3</a> created by System Admin on 08/29/2018 11:56 AM', 1, CAST(0x0000A94B00C4C70D AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1077, 3080, N'Quick Invoice Number <a href=''/Admin/InvoiceReport/Detail/1046''>test in4</a> created by System Admin on 08/29/2018 11:56 AM', 1, CAST(0x0000A94B00C4E330 AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1078, 3086, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/1047''>test in5</a> created by Sonali Surve on 08/29/2018 12:31 PM', 1, CAST(0x0000A94B00CE846D AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1079, 3086, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/1048''>v 0001</a> created by Sonali Surve on 08/29/2018 12:44 PM', 1, CAST(0x0000A94B00D217A4 AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1080, 3086, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/1049''>p 0001</a> created by Sonali Surve on 08/29/2018 12:54 PM', 1, CAST(0x0000A94B00D4B820 AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1081, 3086, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/1050''>P 0002</a> created by Sonali Surve on 08/29/2018 01:57 PM', 1, CAST(0x0000A94B00E5EADB AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1082, 3086, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/1051''>W 0001</a> created by Sonali Surve on 08/29/2018 02:09 PM', 1, CAST(0x0000A94B00E94273 AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Activity_log] ([id], [userid], [Comment], [Action], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1083, 3086, N'Invoice Number <a href=''/Admin/InvoiceReport/Detail/32''>Invoice No1</a> Approved by Sonali Surve on 08/29/2018 02:21 PM', 4, CAST(0x0000A94B00ECA278 AS DateTime), N'sonali', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_Activity_log] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Department] ON 

GO
INSERT [dbo].[tbl_Department] ([id], [Name], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive], [ListID], [StoreID]) VALUES (1, N'Dairy', CAST(0x0000A8F500D7AA7B AS DateTime), N'1', NULL, NULL, 1, NULL, 0)
GO
INSERT [dbo].[tbl_Department] ([id], [Name], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive], [ListID], [StoreID]) VALUES (2, N'Grocery', CAST(0x0000A8F500D7AA7B AS DateTime), N'1', NULL, NULL, 1, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[tbl_Department] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Invoice] ON 

GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (1, 3, 1, N'Cash', 2, CAST(0x0000A91400000000 AS DateTime), N'BK0001', N'BK0001 edit', N'AttachNote_Title', N'1217sampleCopy.pdf', N'1217sampleCopy.pdf', CAST(1000.00 AS Decimal(18, 2)), 2, CAST(0x0000A91400C1DE82 AS DateTime), N'3082', CAST(0x0000A91400CFF40A AS DateTime), N'Brinda Ukani', N'Monali Surve', CAST(0x0000A91400D059CF AS DateTime), 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (2, 1, 1, N'Cash', 2, CAST(0x0000A91400000000 AS DateTime), N'BK0002', N'BK0002 created by lipsa on d-mart', N'AttachNote_Title', N'8123sampleCopy.pdf', N'8123sampleCopy.pdf', CAST(2000.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400C54BA3 AS DateTime), N'3081', NULL, NULL, NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (3, 3, 2, N'Check/ACH', 1, CAST(0x0000A91000000000 AS DateTime), N'DA0001', N'DA0001 by monali on fbb mart edit', N'AttachNote_Title', N'4091sampleCopy.pdf', N'4091sampleCopy.pdf', CAST(30000.00 AS Decimal(18, 2)), 3, CAST(0x0000A91400C799C8 AS DateTime), N'3085', CAST(0x0000A91400D0EFBB AS DateTime), N'Monali Surve', N'Priyansh rajput', CAST(0x0000A91400D1498D AS DateTime), 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (4, 3, 1, N'Check/ACH', 1, CAST(0x0000A91200000000 AS DateTime), N'DA000_Q1', N'DA000_Q1 by monaly in fbb mart which is auto approved so dont show on ntification.only show on grid', N'AttachNote_Title', N'340sampleCopy.pdf', N'340sampleCopy.pdf', CAST(40000.00 AS Decimal(18, 2)), 2, CAST(0x0000A91400C84425 AS DateTime), N'3085', NULL, NULL, N'monali', CAST(0x0000A91400C84425 AS DateTime), 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (5, 3, 2, N'Check/ACH', 1, CAST(0x0000A91200000000 AS DateTime), N'SM000_q2', N'SM000_q2 by priyansh on fbb mart .it is auto PPROVED .', N'AttachNote_Title', N'4869sampleCopy.pdf', N'4869sampleCopy.pdf', CAST(7000.00 AS Decimal(18, 2)), 2, CAST(0x0000A91400CFA6F0 AS DateTime), N'3087', NULL, NULL, N'priyansh', CAST(0x0000A91400CFA6F0 AS DateTime), 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (6, 3, 2, N'Check/ACH', 2, CAST(0x0000A91200000000 AS DateTime), N'DA0002', N'DA0002', N'AttachNote_Title', N'288sampleCopy.pdf', N'288sampleCopy.pdf', CAST(4000.00 AS Decimal(18, 2)), 3, CAST(0x0000A91400D19C0D AS DateTime), N'3084', NULL, NULL, N'Priyansh rajput', CAST(0x0000A91400D1BC03 AS DateTime), 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (7, 3, 1, N'Cash', 2, CAST(0x0000A91800000000 AS DateTime), N'DA0003', N'DA0003', N'AttachNote_Title', N'9817sampleCopy.pdf', N'9817sampleCopy.pdf', CAST(8000.00 AS Decimal(18, 2)), 3, CAST(0x0000A91400D1FA58 AS DateTime), N'3084', NULL, NULL, N'Priyansh rajput', CAST(0x0000A91400D20C45 AS DateTime), 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (8, 3, 1, N'Check/ACH', 2, CAST(0x0000A92200000000 AS DateTime), N'DA0004', N'DA0004', N'AttachNote_Title', N'4162sampleCopy.pdf', N'4162sampleCopy.pdf', CAST(6000.00 AS Decimal(18, 2)), 3, CAST(0x0000A91400D30948 AS DateTime), N'3084', NULL, NULL, N'Priyansh rajput', CAST(0x0000A91400D31B49 AS DateTime), 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (9, 3, 1, N'Check/ACH', 2, CAST(0x0000A91200000000 AS DateTime), N'BK0003', N'BK0003', N'AttachNote_Title', N'6297sampleCopy.pdf', N'6297sampleCopy.pdf', CAST(100.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400D454E4 AS DateTime), N'3082', NULL, NULL, NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (10, 3, 1, N'Cash', 1, CAST(0x0000A92100000000 AS DateTime), N'Bk0004', N'Bk0004', N'AttachNote_Title', N'4607sampleCopy.pdf', N'4607sampleCopy.pdf', CAST(77777.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400D48959 AS DateTime), N'3082', NULL, NULL, NULL, NULL, 0, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (11, 3, 2, N'Check/ACH', 1, CAST(0x0000A92300000000 AS DateTime), N'Bk0005', N'Bk0005', N'AttachNote_Title', N'7043sampleCopy.pdf', N'7043sampleCopy.pdf', CAST(2500.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400D4ABC3 AS DateTime), N'3082', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (12, 3, 1, N'Check/ACH', 1, CAST(0x0000A92000000000 AS DateTime), N'Bk0006', N'Bk0006', N'AttachNote_Title', N'8432sampleCopy.pdf', N'8432sampleCopy.pdf', CAST(15000.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400D4CDB4 AS DateTime), N'3082', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (13, 3, 1, N'Check/ACH', 2, CAST(0x0000A92700000000 AS DateTime), N'Bk0007', N'Bk0006', N'AttachNote_Title', N'9683sampleCopy.pdf', N'9683sampleCopy.pdf', CAST(5000.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400D512E4 AS DateTime), N'3082', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (14, 3, 1, N'Cash', 2, CAST(0x0000A92900000000 AS DateTime), N'Bk0008', N'Bk0008', N'AttachNote_Title', N'2733sampleCopy.pdf', N'2733sampleCopy.pdf', CAST(1200.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400D5409F AS DateTime), N'3082', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (15, 3, 2, N'Check/ACH', 1, CAST(0x0000A92700000000 AS DateTime), N'Bk0009', N'Bk0009', N'AttachNote_Title', N'8576sampleCopy.pdf', N'8576sampleCopy.pdf', CAST(35000.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400D568A6 AS DateTime), N'3082', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (16, 3, 2, N'Check/ACH', 1, CAST(0x0000A91F00000000 AS DateTime), N'BK0009', N'BK0009', N'AttachNote_Title', N'5039sampleCopy.pdf', N'5039sampleCopy.pdf', CAST(650.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400E62302 AS DateTime), N'3082', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (17, 3, 2, N'Check/ACH', 2, CAST(0x0000A91F00000000 AS DateTime), N'BK00010', N'BK00010', N'AttachNote_Title', N'625sampleCopy.pdf', N'625sampleCopy.pdf', CAST(50000.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400E65660 AS DateTime), N'3082', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (18, 3, 2, N'Check/ACH', 2, CAST(0x0000A92600000000 AS DateTime), N'BK00010', N'BK00010', N'AttachNote_Title', N'1161sampleCopy.pdf', N'1161sampleCopy.pdf', CAST(1300.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400E73FFF AS DateTime), N'3082', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (19, 3, 1, N'Cash', 2, CAST(0x0000A91200000000 AS DateTime), N'BK00012', N'BK00012', N'AttachNote_Title', N'1673sampleCopy.pdf', N'1673sampleCopy.pdf', CAST(85000.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400E7DF5D AS DateTime), N'3082', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (20, 3, 1, N'Check/ACH', 1, CAST(0x0000A92600000000 AS DateTime), N'BK00013', N'BK00013', N'AttachNote_Title', N'8927sampleCopy.pdf', N'8927sampleCopy.pdf', CAST(75000.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400E803C9 AS DateTime), N'3082', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (21, 3, 1, N'Check/ACH', 1, CAST(0x0000A91B00000000 AS DateTime), N'BK00014', N'BK00014', N'AttachNote_Title', N'2160sampleCopy.pdf', N'2160sampleCopy.pdf', CAST(21000.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400E8330B AS DateTime), N'3082', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (22, 3, 1, N'Cash', 2, CAST(0x0000A91E00000000 AS DateTime), N'BK00015', N'BK00015', N'AttachNote_Title', N'7763sampleCopy.pdf', N'7763sampleCopy.pdf', CAST(78000.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400E869C1 AS DateTime), N'3082', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (23, 3, 1, N'Check/ACH', 2, CAST(0x0000A91F00000000 AS DateTime), N'BK00016', N'BK00016', N'AttachNote_Title', N'558sampleCopy.pdf', N'558sampleCopy.pdf', CAST(65000.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400E88E40 AS DateTime), N'3082', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (24, 3, 2, N'Check/ACH', 1, CAST(0x0000A92B00000000 AS DateTime), N'BK00017', N'BK00016', N'AttachNote_Title', N'5143sampleCopy.pdf', N'5143sampleCopy.pdf', CAST(95000.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400E8AE85 AS DateTime), N'3082', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (25, 3, 2, N'Check/ACH', 1, CAST(0x0000A92B00000000 AS DateTime), N'BK00017', N'BK00017', N'AttachNote_Title', N'2591sampleCopy.pdf', N'2591sampleCopy.pdf', CAST(65888.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400E8D6D7 AS DateTime), N'3082', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (26, 3, 1, N'Cash', 2, CAST(0x0000A91700000000 AS DateTime), N'BK00019', N'BK00019', N'AttachNote_Title', N'3414sampleCopy.pdf', N'3414sampleCopy.pdf', CAST(95200.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400E90518 AS DateTime), N'3082', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (27, 3, 2, N'Check/ACH', 1, CAST(0x0000A92500000000 AS DateTime), N'BK00021', N'BK00021', N'AttachNote_Title', N'8782sampleCopy.pdf', N'8782sampleCopy.pdf', CAST(65444.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400E928C1 AS DateTime), N'3082', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (28, 3, 1, N'Cash', 1, CAST(0x0000A91A00000000 AS DateTime), N'BK00022', N'BK00022', N'AttachNote_Title', N'8416sampleCopy.pdf', N'8416sampleCopy.pdf', CAST(56000.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400E9642D AS DateTime), N'3082', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (29, 3, 2, N'Check/ACH', 2, CAST(0x0000A92E00000000 AS DateTime), N'BK00023', N'BK00023', N'AttachNote_Title', N'3378sampleCopy.pdf', N'3378sampleCopy.pdf', CAST(33333.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400E9B41C AS DateTime), N'3082', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (30, 3, 2, N'Check/ACH', 1, CAST(0x0000A92100000000 AS DateTime), N'BK00024', N'BK00024', N'AttachNote_Title', N'726sampleCopy.pdf', N'726sampleCopy.pdf', CAST(55555.00 AS Decimal(18, 2)), 1, CAST(0x0000A91400E9F93D AS DateTime), N'3082', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (31, 3, 1, N'Cash', 1, CAST(0x0000A91500000000 AS DateTime), N'BK00016', NULL, N'AttachNote_Title', N'4377sampleCopy.pdf', N'4377sampleCopy.pdf', CAST(1000.00 AS Decimal(18, 2)), 1, CAST(0x0000A91500FDA17B AS DateTime), N'3082', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (32, 1, 1, N'Cash', 2, CAST(0x0000A94600000000 AS DateTime), N'Invoice No1', N'test ', N'AttachNote_Title', N'8661sample.pdf', N'8661sample.pdf', CAST(28.00 AS Decimal(18, 2)), 2, CAST(0x0000A94601120AAC AS DateTime), N'3081', NULL, NULL, N'Sonali Surve', CAST(0x0000A94B00EC9EB9 AS DateTime), 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (1032, 1, 2, N'Check/ACH', 2, CAST(0x0000A94600000000 AS DateTime), N'invoice no2', N'test', N'AttachNote_Title', N'9329sample.pdf', N'9329sample.pdf', CAST(1250000.00 AS Decimal(18, 2)), 1, CAST(0x0000A9460122BB18 AS DateTime), N'3081', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (1033, 2, 1, N'Cash', 2, CAST(0x0000A94300000000 AS DateTime), N'invoice 3', N'test', N'AttachNote_Title', N'841sample.pdf', N'841sample.pdf', CAST(100.00 AS Decimal(18, 2)), 1, CAST(0x0000A94700CBDADD AS DateTime), N'3086', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (1034, 2, 1, N'Cash', 1, CAST(0x0000A93C00000000 AS DateTime), N'invoice 4', N'test', N'AttachNote_Title', N'8290sampleCopy.pdf', N'8290sampleCopy.pdf', CAST(300.00 AS Decimal(18, 2)), 1, CAST(0x0000A94700CC347D AS DateTime), N'3086', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (1035, 2, 1, N'Check/ACH', 2, CAST(0x0000A94700000000 AS DateTime), N'invoice 5', N'test', N'AttachNote_Title', N'8534sampleCopy.pdf', N'8534sampleCopy.pdf', CAST(300.00 AS Decimal(18, 2)), 1, CAST(0x0000A94700E9A494 AS DateTime), N'3086', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (1036, 2, 2, N'Check/ACH', 2, CAST(0x0000A94300000000 AS DateTime), N'invoice 6', N'test', N'AttachNote_Title', N'5785sampleCopy.pdf', N'5785sampleCopy.pdf', CAST(1000.00 AS Decimal(18, 2)), 1, CAST(0x0000A94700EA1C1C AS DateTime), N'3086', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (1037, 2, 1, N'Cash', 2, CAST(0x0000A91400000000 AS DateTime), N'DA0001', N'test', N'AttachNote_Title', N'2195sample.pdf', N'2195sample.pdf', CAST(65000.70 AS Decimal(18, 2)), 1, CAST(0x0000A949010E835B AS DateTime), N'3086', NULL, NULL, NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (1038, 0, 2, N'Check/ACH', 2, CAST(0x0000A94A00000000 AS DateTime), N'BK0002', N'test', N'AttachNote_Title', N'187sampleCopy.pdf', N'187sampleCopy.pdf', CAST(1300.00 AS Decimal(18, 2)), 2, CAST(0x0000A94A00B13B17 AS DateTime), N'3080', NULL, NULL, N'admin', CAST(0x0000A94A00B13B17 AS DateTime), 1, NULL, 0)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (1039, 1, 1, N'Cash', 1, CAST(0x0000A93500000000 AS DateTime), N'BK0002', N'teest', N'AttachNote_Title', N'4022sample.pdf', N'4022sample.pdf', CAST(0.00 AS Decimal(18, 2)), 1, CAST(0x0000A94A00C3579F AS DateTime), N'3086', NULL, NULL, NULL, NULL, 1, NULL, 0)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (1040, 2, 1, N'Cash', 2, CAST(0x0000A94A00000000 AS DateTime), N'BK0002', N'test', N'AttachNote_Title', N'3733sampleCopy.pdf', N'3733sampleCopy.pdf', CAST(0.00 AS Decimal(18, 2)), 1, CAST(0x0000A94A00C3E1B2 AS DateTime), N'3086', NULL, NULL, NULL, NULL, 1, NULL, 0)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (1041, 2, 2, N'Check/ACH', 2, CAST(0x0000A94A00000000 AS DateTime), N'vinvoice1', N'test vinvoice1', N'AttachNote_Title', N'6823sample.pdf', N'6823sample.pdf', CAST(0.00 AS Decimal(18, 2)), 1, CAST(0x0000A94A00C41E92 AS DateTime), N'3086', NULL, NULL, NULL, NULL, 1, NULL, 0)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (1042, 1, 1, N'Cash', 1, CAST(0x0000A94A00000000 AS DateTime), N'vinvoice2', N'test', N'AttachNote_Title', N'6460sampleCopy.pdf', N'6460sampleCopy.pdf', CAST(0.00 AS Decimal(18, 2)), 1, CAST(0x0000A94A00C64073 AS DateTime), N'3086', NULL, NULL, NULL, NULL, 1, NULL, 0)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (1043, 0, 1, N'Cash', 2, CAST(0x0000A94B00000000 AS DateTime), N'test in1', N'test', N'AttachNote_Title', N'1072sample.pdf', N'1072sample.pdf', CAST(200.00 AS Decimal(18, 2)), 2, CAST(0x0000A94B00C43FB6 AS DateTime), N'3080', NULL, NULL, N'admin', CAST(0x0000A94B00C43FB6 AS DateTime), 1, NULL, 0)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (1044, 0, 2, N'Check/ACH', 1, CAST(0x0000A94B00000000 AS DateTime), N'test in2', N'test', N'AttachNote_Title', N'6335sample.pdf', N'6335sample.pdf', CAST(500.00 AS Decimal(18, 2)), 2, CAST(0x0000A94B00C48640 AS DateTime), N'3080', NULL, NULL, N'admin', CAST(0x0000A94B00C48640 AS DateTime), 1, NULL, 0)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (1045, 0, 2, N'Check/ACH', 2, CAST(0x0000A90E00000000 AS DateTime), N'test in 3', N'ts', N'AttachNote_Title', N'6030sample.pdf', N'6030sample.pdf', CAST(300.00 AS Decimal(18, 2)), 2, CAST(0x0000A94B00C4C707 AS DateTime), N'3080', NULL, NULL, N'admin', CAST(0x0000A94B00C4C707 AS DateTime), 1, NULL, 0)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (1046, 0, 2, N'Check/ACH', 2, CAST(0x0000A91400000000 AS DateTime), N'test in4', N's', N'AttachNote_Title', N'9899sampleCopy.pdf', N'9899sampleCopy.pdf', CAST(1000.00 AS Decimal(18, 2)), 2, CAST(0x0000A94B00C4E32B AS DateTime), N'3080', NULL, NULL, N'admin', CAST(0x0000A94B00C4E32B AS DateTime), 1, NULL, 0)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (1047, 2, 1, N'Cash', 2, CAST(0x0000A94B00000000 AS DateTime), N'test in5', N'test', N'AttachNote_Title', N'8633sample.pdf', N'8633sample.pdf', CAST(100.00 AS Decimal(18, 2)), 1, CAST(0x0000A94B00CE825D AS DateTime), N'3086', NULL, NULL, NULL, NULL, 1, NULL, 0)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (1048, 2, 2, N'Check/ACH', 2, CAST(0x0000A94900000000 AS DateTime), N'v 0001', N'test', N'AttachNote_Title', N'4417sample.pdf', N'4417sample.pdf', CAST(300.00 AS Decimal(18, 2)), 1, CAST(0x0000A94B00D2179E AS DateTime), N'3086', NULL, NULL, NULL, NULL, 1, NULL, 0)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (1049, 2, 2, N'Check/ACH', 2, CAST(0x0000A94B00000000 AS DateTime), N'p 0001', N'test', N'AttachNote_Title', N'446sample.pdf', N'446sample.pdf', CAST(100.00 AS Decimal(18, 2)), 1, CAST(0x0000A94B00D4B81D AS DateTime), N'3086', NULL, NULL, NULL, NULL, 1, NULL, 0)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (1050, 2, 1, N'Cash', 2, CAST(0x0000A94A00000000 AS DateTime), N'P 0002', N'test', N'AttachNote_Title', N'3221sampleCopy.pdf', N'3221sampleCopy.pdf', CAST(300.00 AS Decimal(18, 2)), 1, CAST(0x0000A94B00E5EACB AS DateTime), N'3086', NULL, NULL, NULL, NULL, 1, NULL, 0)
GO
INSERT [dbo].[tbl_Invoice] ([id], [Store_id], [Type_id], [Payment_type], [Vendor_id], [Invoice_Date], [Invoice_Number], [Note], [AttachNote], [UploadInvoice], [ScanInvoice], [TotalAmtByDept], [IsStatus_id], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [ApproveRejectBy], [ApproveRejectDate], [IsActive], [TxnID], [IsSync]) VALUES (1051, 2, 1, N'Cash', 2, CAST(0x0000A94B00000000 AS DateTime), N'W 0001', N'test', N'AttachNote_Title', N'440sample.pdf', N'440sample.pdf', CAST(300.00 AS Decimal(18, 2)), 1, CAST(0x0000A94B00E94268 AS DateTime), N'3086', NULL, NULL, NULL, NULL, 1, NULL, 0)
GO
SET IDENTITY_INSERT [dbo].[tbl_Invoice] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Invoice_Department] ON 

GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1, 1, 1, CAST(1000.00 AS Decimal(18, 2)), CAST(0x0000A91400C1DE8E AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (2, 2, 2, CAST(2000.00 AS Decimal(18, 2)), CAST(0x0000A91400C54BA5 AS DateTime), N'lipsa', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (3, 3, 1, CAST(20000.00 AS Decimal(18, 2)), CAST(0x0000A91400C799CA AS DateTime), N'monali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (4, 3, 2, CAST(10000.00 AS Decimal(18, 2)), CAST(0x0000A91400C799CC AS DateTime), N'monali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (5, 4, 2, CAST(40000.00 AS Decimal(18, 2)), CAST(0x0000A91400C84427 AS DateTime), N'monali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (6, 5, 1, CAST(7000.00 AS Decimal(18, 2)), CAST(0x0000A91400CFA6F2 AS DateTime), N'priyansh', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (7, 6, 1, CAST(4000.00 AS Decimal(18, 2)), CAST(0x0000A91400D19C0F AS DateTime), N'vibhusha', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (8, 7, 1, CAST(8000.00 AS Decimal(18, 2)), CAST(0x0000A91400D1FA5A AS DateTime), N'vibhusha', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (9, 8, 2, CAST(6000.00 AS Decimal(18, 2)), CAST(0x0000A91400D3094A AS DateTime), N'vibhusha', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (10, 9, 2, CAST(100.00 AS Decimal(18, 2)), CAST(0x0000A91400D454E7 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (11, 10, 2, CAST(100.00 AS Decimal(18, 2)), CAST(0x0000A91400D4895D AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (12, 11, 2, CAST(2500.00 AS Decimal(18, 2)), CAST(0x0000A91400D4ABC6 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (13, 12, 2, CAST(15000.00 AS Decimal(18, 2)), CAST(0x0000A91400D4CDB7 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (14, 13, 2, CAST(5000.00 AS Decimal(18, 2)), CAST(0x0000A91400D512F0 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (15, 14, 2, CAST(1200.00 AS Decimal(18, 2)), CAST(0x0000A91400D540B0 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (16, 15, 1, CAST(35000.00 AS Decimal(18, 2)), CAST(0x0000A91400D568D0 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (17, 16, 2, CAST(650.00 AS Decimal(18, 2)), CAST(0x0000A91400E62303 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (18, 17, 2, CAST(50000.00 AS Decimal(18, 2)), CAST(0x0000A91400E65662 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (19, 18, 2, CAST(1300.00 AS Decimal(18, 2)), CAST(0x0000A91400E74001 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (20, 19, 2, CAST(85000.00 AS Decimal(18, 2)), CAST(0x0000A91400E7DF64 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (21, 20, 1, CAST(75000.00 AS Decimal(18, 2)), CAST(0x0000A91400E803CD AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (22, 21, 2, CAST(21000.00 AS Decimal(18, 2)), CAST(0x0000A91400E8330C AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (23, 22, 2, CAST(78000.00 AS Decimal(18, 2)), CAST(0x0000A91400E869C2 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (24, 23, 2, CAST(65000.00 AS Decimal(18, 2)), CAST(0x0000A91400E88E48 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (25, 24, 2, CAST(95000.00 AS Decimal(18, 2)), CAST(0x0000A91400E8AE87 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (26, 25, 2, CAST(65888.00 AS Decimal(18, 2)), CAST(0x0000A91400E8D6DE AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (27, 26, 2, CAST(95200.00 AS Decimal(18, 2)), CAST(0x0000A91400E9051A AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (28, 27, 2, CAST(65444.00 AS Decimal(18, 2)), CAST(0x0000A91400E928C3 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (29, 28, 1, CAST(56000.00 AS Decimal(18, 2)), CAST(0x0000A91400E9642F AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (30, 29, 2, CAST(33333.00 AS Decimal(18, 2)), CAST(0x0000A91400E9B41E AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (31, 30, 2, CAST(55555.00 AS Decimal(18, 2)), CAST(0x0000A91400E9F93F AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (32, 31, 1, CAST(1000.00 AS Decimal(18, 2)), CAST(0x0000A91500FDA189 AS DateTime), N'brinda', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (33, 32, 1, CAST(13.00 AS Decimal(18, 2)), CAST(0x0000A94601120AB9 AS DateTime), N'lipsa', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (34, 32, 2, CAST(15.00 AS Decimal(18, 2)), CAST(0x0000A94601120AC4 AS DateTime), N'lipsa', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1033, 1032, 1, CAST(500000.00 AS Decimal(18, 2)), CAST(0x0000A9460122BB49 AS DateTime), N'lipsa', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1034, 1032, 2, CAST(750000.00 AS Decimal(18, 2)), CAST(0x0000A9460122BB51 AS DateTime), N'lipsa', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1035, 1033, 1, CAST(100.00 AS Decimal(18, 2)), CAST(0x0000A94700CBDAE3 AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1036, 1034, 2, CAST(300.00 AS Decimal(18, 2)), CAST(0x0000A94700CC3482 AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1037, 1035, 1, CAST(100.00 AS Decimal(18, 2)), CAST(0x0000A94700E9A499 AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1038, 1035, 2, CAST(200.00 AS Decimal(18, 2)), CAST(0x0000A94700E9A49B AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1039, 1036, 1, CAST(700.00 AS Decimal(18, 2)), CAST(0x0000A94700EA1C1E AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1040, 1036, 2, CAST(300.00 AS Decimal(18, 2)), CAST(0x0000A94700EA1C20 AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1041, 1037, 1, CAST(15000.30 AS Decimal(18, 2)), CAST(0x0000A949010E8367 AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1042, 1037, 2, CAST(50000.40 AS Decimal(18, 2)), CAST(0x0000A949010E8370 AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1043, 1038, 1, CAST(300.00 AS Decimal(18, 2)), CAST(0x0000A94A00B13B1D AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1044, 1038, 2, CAST(1000.00 AS Decimal(18, 2)), CAST(0x0000A94A00B13B1F AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1045, 1043, 1, CAST(200.00 AS Decimal(18, 2)), CAST(0x0000A94B00C43FBD AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1046, 1044, 2, CAST(500.00 AS Decimal(18, 2)), CAST(0x0000A94B00C48642 AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1047, 1045, 1, CAST(300.00 AS Decimal(18, 2)), CAST(0x0000A94B00C4C709 AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1048, 1046, 1, CAST(1000.00 AS Decimal(18, 2)), CAST(0x0000A94B00C4E32D AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1049, 1047, 1, CAST(100.00 AS Decimal(18, 2)), CAST(0x0000A94B00CE8277 AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1050, 1048, 1, CAST(300.00 AS Decimal(18, 2)), CAST(0x0000A94B00D217A0 AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1051, 1049, 1, CAST(100.00 AS Decimal(18, 2)), CAST(0x0000A94B00D4B81E AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1052, 1050, 2, CAST(300.00 AS Decimal(18, 2)), CAST(0x0000A94B00E5EAD7 AS DateTime), N'sonali', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Invoice_Department] ([id], [Invoice_id], [Dept_id], [Amount], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1053, 1051, 1, CAST(300.00 AS Decimal(18, 2)), CAST(0x0000A94B00E9426E AS DateTime), N'sonali', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_Invoice_Department] OFF
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
INSERT [dbo].[tbl_Status] ([id], [Name], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1, N'On Hold', CAST(0x0000A8F500D7AA7B AS DateTime), N'1', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Status] ([id], [Name], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (2, N'Approved', CAST(0x0000A8F500D7AA7B AS DateTime), N'1', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Status] ([id], [Name], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (3, N'Rejected', CAST(0x0000A8F500D7AA7B AS DateTime), N'1', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_Status] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Store] ON 

GO
INSERT [dbo].[tbl_Store] ([Id], [Name], [Address], [Address2], [StoreNo], [FaxNo], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1, N'd-mart', N'makarpura', N'manjalpur', N'(454) 354-5464', N'(465) 464-6464', CAST(0x0000A90E013015E7 AS DateTime), N'admin', CAST(0x0000A9130106BEC8 AS DateTime), N'3080', 1)
GO
INSERT [dbo].[tbl_Store] ([Id], [Name], [Address], [Address2], [StoreNo], [FaxNo], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (2, N'v-mart', N'alkapuri', N'makarpura', N'(343) 434-3343', N'(234) 234-2342', CAST(0x0000A90E01305C94 AS DateTime), N'admin', CAST(0x0000A9130106B203 AS DateTime), N'3080', 1)
GO
INSERT [dbo].[tbl_Store] ([Id], [Name], [Address], [Address2], [StoreNo], [FaxNo], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (3, N'Fbb Mart', N'akota', N'akota road', N'(244) 544-6464', N'(646) 464-6464', CAST(0x0000A91400C17243 AS DateTime), N'admin', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_Store] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Type] ON 

GO
INSERT [dbo].[tbl_Type] ([id], [Name], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1, N'Invoice', CAST(0x0000A8F500D7AA7B AS DateTime), N'1', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_Type] ([id], [Name], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (2, N'Credit Memo', CAST(0x0000A8F500D7AA7B AS DateTime), N'1', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_Type] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_user] ON 

GO
INSERT [dbo].[tbl_user] ([id], [Name], [Email], [UserName], [Password], [Roleid], [Reg_userid], [userid], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (1, N'System Admin', NULL, N'admin', N'Camlin@357', 1, 3080, 3080, NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[tbl_user] ([id], [Name], [Email], [UserName], [Password], [Roleid], [Reg_userid], [userid], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (2, N'Lipsa Ukani', N'', N'lipsa', N'Test@123', 2, 3081, 3080, CAST(0x0000A90D01091E43 AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_user] ([id], [Name], [Email], [UserName], [Password], [Roleid], [Reg_userid], [userid], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (3, N'Brinda Ukani', N'', N'brinda', N'Test@123', 2, 3082, 3080, CAST(0x0000A90D01093C47 AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_user] ([id], [Name], [Email], [UserName], [Password], [Roleid], [Reg_userid], [userid], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (4, N'Richa Gujjar', N'', N'richa', N'Test@123', 2, 3083, 3080, CAST(0x0000A90D0109543A AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_user] ([id], [Name], [Email], [UserName], [Password], [Roleid], [Reg_userid], [userid], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (5, N'Vibhusha', N'', N'Vibhusha', N'Test@123', 3, 3084, 3080, CAST(0x0000A90D0109729E AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_user] ([id], [Name], [Email], [UserName], [Password], [Roleid], [Reg_userid], [userid], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (6, N'Monali Surve', N'', N'monali', N'Test@123', 3, 3085, 3080, CAST(0x0000A90D01098DC0 AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_user] ([id], [Name], [Email], [UserName], [Password], [Roleid], [Reg_userid], [userid], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (7, N'Sonali Surve', N'', N'sonali', N'Test@123', 3, 3086, 3080, CAST(0x0000A90D0109A662 AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_user] ([id], [Name], [Email], [UserName], [Password], [Roleid], [Reg_userid], [userid], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (8, N'Priyansh rajput', N'', N'priyansh', N'Test@123', 4, 3087, 3080, CAST(0x0000A90D0109CAAF AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_user] ([id], [Name], [Email], [UserName], [Password], [Roleid], [Reg_userid], [userid], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (9, N'Dhrumit Devani', N'', N'dhrumit', N'Test@123', 4, 3088, 3080, CAST(0x0000A90D0109E755 AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_user] ([id], [Name], [Email], [UserName], [Password], [Roleid], [Reg_userid], [userid], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (10, N'Parth Patel', N'', N'parth', N'Test@123', 4, 3089, 3089, CAST(0x0000A9130103F920 AS DateTime), N'admin', NULL, NULL, 1)
GO
INSERT [dbo].[tbl_user] ([id], [Name], [Email], [UserName], [Password], [Roleid], [Reg_userid], [userid], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive]) VALUES (11, N'parth', N'', N'parh', N'Test@123', 2, 3090, 3080, CAST(0x0000A91500D03A14 AS DateTime), N'admin', NULL, NULL, 1)
GO
SET IDENTITY_INSERT [dbo].[tbl_user] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_user_store] ON 

GO
INSERT [dbo].[tbl_user_store] ([id], [Storeid], [userid], [Reg_userid], [StoreName], [RoleId], [RoleName]) VALUES (24, 2, 3080, 3083, N'v-mart', 2, N'Back Office Manager')
GO
INSERT [dbo].[tbl_user_store] ([id], [Storeid], [userid], [Reg_userid], [StoreName], [RoleId], [RoleName]) VALUES (25, 2, 3080, 3088, N'v-mart', 4, N'Store Manager')
GO
INSERT [dbo].[tbl_user_store] ([id], [Storeid], [userid], [Reg_userid], [StoreName], [RoleId], [RoleName]) VALUES (26, 2, 3080, 3085, N'v-mart', 3, N'Data Approver')
GO
INSERT [dbo].[tbl_user_store] ([id], [Storeid], [userid], [Reg_userid], [StoreName], [RoleId], [RoleName]) VALUES (27, 2, 3080, 3086, N'v-mart', 3, N'Data Approver')
GO
INSERT [dbo].[tbl_user_store] ([id], [Storeid], [userid], [Reg_userid], [StoreName], [RoleId], [RoleName]) VALUES (28, 1, 3080, 3081, N'd-mart', 2, N'Back Office Manager')
GO
INSERT [dbo].[tbl_user_store] ([id], [Storeid], [userid], [Reg_userid], [StoreName], [RoleId], [RoleName]) VALUES (29, 1, 3080, 3089, N'd-mart', 4, N'Store Manager')
GO
INSERT [dbo].[tbl_user_store] ([id], [Storeid], [userid], [Reg_userid], [StoreName], [RoleId], [RoleName]) VALUES (30, 1, 3080, 3085, N'd-mart', 3, N'Data Approver')
GO
INSERT [dbo].[tbl_user_store] ([id], [Storeid], [userid], [Reg_userid], [StoreName], [RoleId], [RoleName]) VALUES (31, 1, 3080, 3086, N'd-mart', 3, N'Data Approver')
GO
INSERT [dbo].[tbl_user_store] ([id], [Storeid], [userid], [Reg_userid], [StoreName], [RoleId], [RoleName]) VALUES (32, 3, 3080, 3082, N'Fbb Mart', 2, N'Back Office Manager')
GO
INSERT [dbo].[tbl_user_store] ([id], [Storeid], [userid], [Reg_userid], [StoreName], [RoleId], [RoleName]) VALUES (33, 3, 3080, 3087, N'Fbb Mart', 4, N'Store Manager')
GO
INSERT [dbo].[tbl_user_store] ([id], [Storeid], [userid], [Reg_userid], [StoreName], [RoleId], [RoleName]) VALUES (34, 3, 3080, 3085, N'Fbb Mart', 3, N'Data Approver')
GO
INSERT [dbo].[tbl_user_store] ([id], [Storeid], [userid], [Reg_userid], [StoreName], [RoleId], [RoleName]) VALUES (35, 3, 3080, 3084, N'Fbb Mart', 3, N'Data Approver')
GO
SET IDENTITY_INSERT [dbo].[tbl_user_store] OFF
GO
SET IDENTITY_INSERT [dbo].[tbl_Vendor] ON 

GO
INSERT [dbo].[tbl_Vendor] ([id], [Name], [StoreId], [Address], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive], [ListID], [CompanyName]) VALUES (1, N'Vibhusha Devani', 1, N'148 W 24th Steert, Suite 3A, New York, NY 10011', CAST(0x0000A8F500D7AA7B AS DateTime), N'1', NULL, NULL, 1, NULL, NULL)
GO
INSERT [dbo].[tbl_Vendor] ([id], [Name], [StoreId], [Address], [CreatedOn], [CreatedBy], [ModifiedOn], [ModifiedBy], [IsActive], [ListID], [CompanyName]) VALUES (2, N'Akshda Sane', 2, N'32 W 24th Steert, Suite 3A, New York, NY 10011', CAST(0x0000A8F500D7AA7B AS DateTime), N'1', NULL, NULL, 1, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[tbl_Vendor] OFF
GO
SET IDENTITY_INSERT [dbo].[UserProfile] ON 

GO
INSERT [dbo].[UserProfile] ([UserId], [UserName]) VALUES (3080, N'admin')
GO
INSERT [dbo].[UserProfile] ([UserId], [UserName]) VALUES (3082, N'brinda')
GO
INSERT [dbo].[UserProfile] ([UserId], [UserName]) VALUES (3088, N'dhrumit')
GO
INSERT [dbo].[UserProfile] ([UserId], [UserName]) VALUES (3081, N'lipsa')
GO
INSERT [dbo].[UserProfile] ([UserId], [UserName]) VALUES (3085, N'monali')
GO
INSERT [dbo].[UserProfile] ([UserId], [UserName]) VALUES (3090, N'parh')
GO
INSERT [dbo].[UserProfile] ([UserId], [UserName]) VALUES (3089, N'parth')
GO
INSERT [dbo].[UserProfile] ([UserId], [UserName]) VALUES (3087, N'priyansh')
GO
INSERT [dbo].[UserProfile] ([UserId], [UserName]) VALUES (3083, N'richa')
GO
INSERT [dbo].[UserProfile] ([UserId], [UserName]) VALUES (3086, N'sonali')
GO
INSERT [dbo].[UserProfile] ([UserId], [UserName]) VALUES (3084, N'Vibhusha')
GO
SET IDENTITY_INSERT [dbo].[UserProfile] OFF
GO
SET IDENTITY_INSERT [dbo].[Utilities] ON 

GO
INSERT [dbo].[Utilities] ([id], [sitename], [sitelogo], [siteurl], [MailServer], [from], [cc], [username], [Password], [Authenticate], [emailtop], [emailbottom], [port], [pagination], [sitebyname], [sitebyurl]) VALUES (1, N'Synthesis', NULL, N'http://localhost:52227', N'smtp.gmail.com', N'megherrorlog@gmail.com', N'megherrorlog@gmail.com', N'megherrorlog@gmail.com', N'MeghTechGoogle@2017$ErrorLog', 1, NULL, NULL, 857, NULL, N'meghtechnologies', N'http://localhost:52227')
GO
SET IDENTITY_INSERT [dbo].[Utilities] OFF
GO
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (3080, CAST(0x0000A90D00AC91F6 AS DateTime), NULL, 1, CAST(0x0000A94A00DD5D74 AS DateTime), 0, N'AKMIM++MIks//Wh8/msA5VSWz/utfcNehji+beOihiAPRg3qkVOFgEOnCkChvSP0aQ==', CAST(0x0000A90D00AC91F6 AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (3081, CAST(0x0000A90D00AE768B AS DateTime), NULL, 1, NULL, 0, N'APKcMXLILDJGAaT9LWhTUut3jfjfSpGMOjSWb0wPidgyp5texpieP3sSGr+qMBerHA==', CAST(0x0000A90D00AE768B AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (3082, CAST(0x0000A90D00AE94A4 AS DateTime), NULL, 1, NULL, 0, N'ACA1m2OdnQIlRbzZUqE2ngoHuywkGMVNWijMzLhb1lYBlCJZ7J+NKPzkiWwonzjKpw==', CAST(0x0000A90D00AE94A4 AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (3083, CAST(0x0000A90D00AEAC9F AS DateTime), NULL, 1, NULL, 0, N'ADEo4NPEeFPfPiFrvLOKti5baKrQjrCDLzbKGR0vM1Ilk02pcGCZAAfj3pQadDn0rg==', CAST(0x0000A90D00AEAC9F AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (3084, CAST(0x0000A90D00AECAFD AS DateTime), NULL, 1, NULL, 0, N'AIXk8oMrJYxmZAZ5mLuZ0+RuTuL2My36VnECc6iNmb4N9C+Mzf5+HZnOwsuNKP+7gg==', CAST(0x0000A90D00AECAFD AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (3085, CAST(0x0000A90D00AEE623 AS DateTime), NULL, 1, NULL, 0, N'AIuOr+AMPYJ1+NeLguzLoqBH2/AbDGILjOfvFhn3D0xqfMFAZO1em/yZq1wtS/1l9Q==', CAST(0x0000A90D00AEE623 AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (3086, CAST(0x0000A90D00AEFEC3 AS DateTime), NULL, 1, NULL, 0, N'AEOtvU6pMSmqWBj0AOkZE9By8JEmCPjoaFz8hhckvVdAqiwhcXmhv72PuM6B0ADqTQ==', CAST(0x0000A90D00AEFEC3 AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (3087, CAST(0x0000A90D00AF230D AS DateTime), NULL, 1, NULL, 0, N'APcwOFkJ3EKbLFfBXso+jDlN6UDUkZPelSBzbCimsRs+pCmwvPbdKyqjJiPu+AL0lA==', CAST(0x0000A90D00AF230D AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (3088, CAST(0x0000A90D00AF3FB9 AS DateTime), NULL, 1, NULL, 0, N'AMXUzRx86VJKnYM/HWJllMUuQH6qitpSnuMRWPzKLeHalGDsGlE/99KwfO2cJemDNQ==', CAST(0x0000A90D00AF3FB9 AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (3089, CAST(0x0000A90D00AF5B4A AS DateTime), NULL, 1, NULL, 0, N'AHHELrTqOeue0HcABivsn7D228fT/E/4pNu9wr9D1vOt0E2Z6yjzs20TO5UeVCzhwQ==', CAST(0x0000A90D00AF5B4A AS DateTime), N'', NULL, NULL)
GO
INSERT [dbo].[webpages_Membership] ([UserId], [CreateDate], [ConfirmationToken], [IsConfirmed], [LastPasswordFailureDate], [PasswordFailuresSinceLastSuccess], [Password], [PasswordChangedDate], [PasswordSalt], [PasswordVerificationToken], [PasswordVerificationTokenExpirationDate]) VALUES (3090, CAST(0x0000A91500758E08 AS DateTime), NULL, 1, NULL, 0, N'AMNQLCxYG/PKa9pV+kLLLyN2BYoXLavePT236NGZw5gTbGRbIaII0HDD/PJefFNxUw==', CAST(0x0000A91500758E08 AS DateTime), N'', NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[webpages_Roles] ON 

GO
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (1, N'Administrator')
GO
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (2, N'Back Office Manager')
GO
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (3, N'Data Approver')
GO
INSERT [dbo].[webpages_Roles] ([RoleId], [RoleName]) VALUES (4, N'Store Manager')
GO
SET IDENTITY_INSERT [dbo].[webpages_Roles] OFF
GO
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (3080, 1)
GO
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (3081, 2)
GO
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (3082, 2)
GO
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (3083, 2)
GO
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (3084, 3)
GO
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (3085, 3)
GO
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (3086, 3)
GO
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (3087, 4)
GO
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (3088, 4)
GO
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (3089, 4)
GO
INSERT [dbo].[webpages_UsersInRoles] ([UserId], [RoleId]) VALUES (3090, 2)
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__UserProf__C9F28456EE504BDB]    Script Date: 8/29/2018 2:50:27 PM ******/
ALTER TABLE [dbo].[UserProfile] ADD UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UQ__webpages__8A2B61602BB1CB15]    Script Date: 8/29/2018 2:50:27 PM ******/
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
