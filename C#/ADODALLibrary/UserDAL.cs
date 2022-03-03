using ADOModelsLibrary;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ADODALLibrary
{
    public class UserDAL
    {
        SqlConnection conn;
        public UserDAL()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        }

        public string Login(User user)
        {
            string role = null;
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = conn;
            cmdLogin.CommandText = "proc_checkUserRole";
            cmdLogin.CommandType = CommandType.StoredProcedure;
            cmdLogin.Parameters.Add("@uname", SqlDbType.VarChar, 20);
            cmdLogin.Parameters.Add("@upassword", SqlDbType.VarChar, 20);
            cmdLogin.Parameters.Add("@urole", SqlDbType.VarChar, 20);
            cmdLogin.Parameters[0].Value = user.Username;
            cmdLogin.Parameters[1].Value = user.Password;
            cmdLogin.Parameters[2].Direction = ParameterDirection.Output;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            cmdLogin.ExecuteScalar();
            role = cmdLogin.Parameters[2].Value.ToString();
            conn.Close();
            return role;
        }

        
    }
}
