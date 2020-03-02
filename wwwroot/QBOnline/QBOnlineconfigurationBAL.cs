using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using wwwroot.Models;

namespace wwwroot.QBOnline
{
    public class QBOnlineconfigurationBAL : DAL
    {
        public DataTable GetData()
        {
            DataTable dt = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_QBOnlineConfiguration";
                cmd.Parameters.AddWithValue("@Spara", "Select");
                dt = new DataTable();
                dt = Select(cmd);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dt;
        }

        public void Insert_Update(QBOnlineconfigurationModel obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_QBOnlineConfiguration";
                cmd.Parameters.AddWithValue("@Spara", obj.Para);
                cmd.Parameters.AddWithValue("@RealmID", obj.RealmID);
                cmd.Parameters.AddWithValue("@ClientId", obj.ClientId);
                cmd.Parameters.AddWithValue("@ClientSecretKey", obj.ClientSecretKey);
                cmd.Parameters.AddWithValue("@QBToken", obj.QBToken);
                cmd.Parameters.AddWithValue("@QBRefreshToken", obj.QBRefreshToken);
                cmd.Parameters.AddWithValue("@CreatedDate", obj.CreatedDate);
                cmd.Parameters.AddWithValue("@UserID", obj.UserID);
                cmd.Parameters.AddWithValue("@Updateddate", obj.Updateddate);
                cmd.Parameters.AddWithValue("@LastSyncDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@IsActive", obj.IsActive);
                cmd.Parameters.AddWithValue("@StoreId", obj.StoreId);
                cmd.Parameters.AddWithValue("@ID", obj.ID);

                Insert_Update_Delete(cmd);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void Delete(QBOnlineconfigurationModel obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_QBOnlineConfiguration";
                cmd.Parameters.AddWithValue("@Spara", "Delete");
                cmd.Parameters.AddWithValue("@ID", obj.ID);
                Insert_Update_Delete(cmd);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public DataTable SelectById(QBOnlineconfigurationModel obj)
        {
            DataTable dt = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_QBOnlineConfiguration";
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
    }
}