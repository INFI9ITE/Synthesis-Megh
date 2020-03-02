using System;
using System.Data;
using System.Data.SqlClient;

namespace wwwroot.QBOnline
{
    public class DAL
    {
        private string GetConnectionString()
        {
            string connstr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return connstr;
        }
        public void Insert_Update_Delete(SqlCommand cmd)
        {
            try
            {
                string strConn = GetConnectionString();
                SqlConnection conn = new SqlConnection(strConn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public DataTable Select(SqlCommand cmd)
        {
            DataTable dt = null;
            try
            {
                string strConn = GetConnectionString();
                SqlConnection conn = new SqlConnection(strConn);
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;

                dt = new DataTable();
                SqlDataReader dr;
                conn.Open();
                dr = cmd.ExecuteReader();
                dt.Load(dr);
                conn.Close();
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
            return dt;
        }
    }
}