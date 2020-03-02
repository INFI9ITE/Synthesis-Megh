using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using wwwroot.Models;

namespace wwwroot.QBOnline
{
    public class QBWebConnectorMappingModelBAL : DAL
    {
        public DataTable GetData()
        {
            DataTable dt = null;
            try
            {
                SqlCommand Cmd = new SqlCommand();
                Cmd.CommandText = "SP_QBWebConnectorMapping";
                Cmd.Parameters.AddWithValue("@Spara", "Select");
                dt = new DataTable();
                dt = Select(Cmd);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dt;
        }

        public DataTable SelectById(QBWebConnectorMappingModel obj)
        {
            DataTable dt = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_QBWebConnectorMapping";
                cmd.Parameters.AddWithValue("@Spara", "SelectById");
                cmd.Parameters.AddWithValue("@ID", obj.ID);
                dt = new DataTable();
                dt = Select(cmd);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dt;
        }

        public void Insert_Update(QBWebConnectorMappingModel obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_QBWebConnectorMapping";
                cmd.Parameters.AddWithValue("@Spara", obj.Para);
                cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
                cmd.Parameters.AddWithValue("@ID", obj.ID);
                Insert_Update_Delete(cmd);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public DataTable SelectByStoreId(QBWebConnectorMappingModel obj)
        {
            DataTable dt = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_QBWebConnectorMapping";
                cmd.Parameters.AddWithValue("@Spara", "SelectByStoreId");
                cmd.Parameters.AddWithValue("@StoreId", obj.StoreId);
                dt = new DataTable();
                dt = Select(cmd);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dt;
        }


        public DataTable SelectByStoreIdAndID(QBWebConnectorMappingModel obj)
        {
            DataTable dt = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_QBWebConnectorMapping";
                cmd.Parameters.AddWithValue("@Spara", "SelectByStoreIdAndID");
                cmd.Parameters.AddWithValue("@StoreId", obj.StoreId);
                cmd.Parameters.AddWithValue("@ID", obj.ID);
                dt = new DataTable();
                dt = Select(cmd);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dt;
        }

        public DataTable SelectByStoreIdAndAppName(QBWebConnectorMappingModel obj)
        {
            DataTable dt = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_QBWebConnectorMapping";
                cmd.Parameters.AddWithValue("@Spara", "SelectByStoreIdAndAppName");
                cmd.Parameters.AddWithValue("@StoreId", obj.StoreId);
                cmd.Parameters.AddWithValue("@AppName", obj.AppName);
                dt = new DataTable();
                dt = Select(cmd);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dt;
        }
        public DataTable SelectByIDAndAppName(QBWebConnectorMappingModel obj)
        {
            DataTable dt = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_QBWebConnectorMapping";
                cmd.Parameters.AddWithValue("@Spara", "SelectByIDAndAppName");
                cmd.Parameters.AddWithValue("@ID", obj.ID);
                cmd.Parameters.AddWithValue("@AppName", obj.AppName);
                dt = new DataTable();
                dt = Select(cmd);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dt;
        }

        public void Update(QBWebConnectorMappingModel obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_QBWebConnectorMapping";
                cmd.Parameters.AddWithValue("@Spara", obj.Para);
                cmd.Parameters.AddWithValue("@QBCompanyPath", obj.QBCompanyPath);
                cmd.Parameters.AddWithValue("@Description", obj.Description);
                cmd.Parameters.AddWithValue("@UserName", obj.UserName);
                cmd.Parameters.AddWithValue("@Password", obj.Password);
                cmd.Parameters.AddWithValue("@OwnerID", obj.OwnerID);
                cmd.Parameters.AddWithValue("@FileID", obj.FileID);
                cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
                cmd.Parameters.AddWithValue("@DateCreated", obj.DateCreated);
                cmd.Parameters.AddWithValue("@AppName", obj.AppName);
                cmd.Parameters.AddWithValue("@ID", obj.ID);
                Insert_Update_Delete(cmd);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void Insert(QBWebConnectorMappingModel obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_QBWebConnectorMapping";
                cmd.Parameters.AddWithValue("@Spara", obj.Para);
                cmd.Parameters.AddWithValue("@AppName", obj.AppName);
                cmd.Parameters.AddWithValue("@QBCompanyPath", obj.QBCompanyPath);
                cmd.Parameters.AddWithValue("@UserName", obj.UserName);
                cmd.Parameters.AddWithValue("@Description", obj.Description);
                cmd.Parameters.AddWithValue("@Password", obj.Password);
                cmd.Parameters.AddWithValue("@OwnerID", obj.OwnerID);
                cmd.Parameters.AddWithValue("@FileID", obj.FileID);
                cmd.Parameters.AddWithValue("@DateCreated", obj.DateCreated);
                cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
                cmd.Parameters.AddWithValue("@StoreId", obj.StoreId);
                Insert_Update_Delete(cmd);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void UpdateIsActive(QBWebConnectorMappingModel obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_QBWebConnectorMapping";
                cmd.Parameters.AddWithValue("@Spara", "UpdateIsActive");
                cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
                cmd.Parameters.AddWithValue("@StoreId", obj.StoreId);
                Insert_Update_Delete(cmd);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public DataTable SelectByUserNameAndPassword(QBWebConnectorMappingModel obj)
        {
            DataTable dt = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_QBWebConnectorMapping";
                cmd.Parameters.AddWithValue("@Spara", "SelectByUserNameAndPassword");
                cmd.Parameters.AddWithValue("@UserName", obj.UserName);
                cmd.Parameters.AddWithValue("@Password", obj.Password);
                cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
                dt = new DataTable();
                dt = Select(cmd);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dt;
        }
    }
}