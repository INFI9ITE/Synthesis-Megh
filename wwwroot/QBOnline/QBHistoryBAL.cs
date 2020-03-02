using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using wwwroot.Models;

namespace wwwroot.QBOnline
{
    public class QBHistoryBAL : DAL
    {
        public DataTable GetData()
        {
            DataTable dt = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_QBHistory";
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

        public void Insert_Update(QBHistoryModel obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_QBHistory";
                cmd.Parameters.AddWithValue("@Spara", obj.Para);
                cmd.Parameters.AddWithValue("@StoreId", obj.StoreID);
                cmd.Parameters.AddWithValue("@StartDate", obj.StartDate);
                cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
                cmd.Parameters.AddWithValue("@Operation", obj.Operation);
                cmd.Parameters.AddWithValue("@QBID", obj.QBID);

                Insert_Update_Delete(cmd);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public void Delete(QBHistoryModel obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_QBHistory";
                cmd.Parameters.AddWithValue("@Spara", "Delete");
                cmd.Parameters.AddWithValue("@QBID", obj.QBID);
                Insert_Update_Delete(cmd);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public DataTable SelectById(QBHistoryModel obj)
        {
            DataTable dt = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_QBHistory";
                cmd.Parameters.AddWithValue("@Spara", "SelectById");
                cmd.Parameters.AddWithValue("@QBID", obj.QBID);
                dt = new DataTable();
                dt = Select(cmd);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dt;
        }

        public DataTable SelectTopById(QBHistoryModel obj)
        {
            DataTable dt = null;
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_QBHistory";
                cmd.Parameters.AddWithValue("@Spara", "SelectTopById");
                cmd.Parameters.AddWithValue("@StoreId", obj.StoreID);
                dt = new DataTable();
                dt = Select(cmd);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dt;
        }
        public void UpdateById(QBHistoryModel obj)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SP_QBHistory";
                cmd.Parameters.AddWithValue("@Spara", obj.Para);
                cmd.Parameters.AddWithValue("@EndDate", obj.EndDate);
                cmd.Parameters.AddWithValue("@QBID", obj.QBID);

                Insert_Update_Delete(cmd);
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
    }
}