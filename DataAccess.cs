using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormProject
{
    public static class DataAccess
    {
        static SqlConnection con = null;

        static DataAccess()
        {
            con = new SqlConnection(@"Data Source=LAPTOP-H4STTIE1\MSSQLSERVER01;Initial Catalog=emp_db; User Id=sa; Password=P@ssw0rd");
        }

        public static DataTable GetData(SqlCommand cmd)
        {
            SqlDataAdapter da = null;
            try
            {
                DataTable dt = new DataTable();
                con.ConnectionString = @"Data Source=LAPTOP-H4STTIE1\MSSQLSERVER01;Initial Catalog=emp_db; User Id=sa; Password=P@ssw0rd";
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
                con.Dispose();
                cmd.Dispose();
                da.Dispose();
            }
        }
        public static int ExecuteNonQuery(SqlCommand cmd)
        {

            try
            {
                DataTable dt = new DataTable();
                con.ConnectionString = @"Data Source=LAPTOP-H4STTIE1\MSSQLSERVER01;Initial Catalog=emp_db; User Id=sa; Password=P@ssw0rd";
                con.Open();
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                con.Close();
                con.Dispose();
                cmd.Dispose();

            }
            }
    }
}
