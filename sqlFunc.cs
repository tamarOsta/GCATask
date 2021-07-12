using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace loginApi.Common
{
    public class sqlFunc
    {
        SecurityHelper sec = new SecurityHelper();
        String SqlconString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
        SqlConnection conn = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        private DataTable dataTable = new DataTable();

        public bool InsertLoginDtl(string userName, string password)
        {
            try
            {

                using (conn = new SqlConnection(SqlconString))
                {

                    conn.ConnectionString = SqlconString;
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "spInsertLoginDtl";
                    cmd.Parameters.AddWithValue("@pLogin", SqlDbType.NVarChar).Value = userName;
                    cmd.Parameters.AddWithValue("@pPassword", SqlDbType.NVarChar).Value = password;


                    try
                    {
                        conn.Open();
                        int i = cmd.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
                return true;


            }
            catch (Exception ex)
            {
                throw ex;

            }

        }



        public bool GetLoginData(string userEnc, ref string userN, ref string pass)
        {

            try
            {
                conn.ConnectionString = SqlconString;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "spGetLoginDtl";
                cmd.Parameters.AddWithValue("@LoginName", SqlDbType.NVarChar).Value = userEnc;
                
                try
                {
                    conn.Open();

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dataTable);

                    if (dataTable.Rows.Count > 0)
                    {
                        pass = sec.DecodeFrom64(dataTable.Rows[0]["PasswordHash"].ToString());
                        userN = sec.DecodeFrom64(dataTable.Rows[0]["LoginName"].ToString());
                        return true;
                    }
                    return false;



                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }




            }
            catch (Exception ex)
            {
                throw ex;

            }

        }



    }
}


