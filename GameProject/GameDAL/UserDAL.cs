using GameModelsLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace GameDAL
{
    public class UserDAL
    {
        SqlConnection conn;
        public UserDAL()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        }
        public int RegisterUser(User user)//return user id
        {
            int id = -1;
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = conn;
            cmdLogin.CommandText = "proc_createUser";
            cmdLogin.CommandType = CommandType.StoredProcedure;
            cmdLogin.Parameters.Add("@uname", SqlDbType.VarChar, 20);
            cmdLogin.Parameters.Add("@uage", SqlDbType.Int);
            cmdLogin.Parameters.Add("@uid", SqlDbType.Int);
            cmdLogin.Parameters[0].Value = user.Name;
            cmdLogin.Parameters[1].Value = user.Age;
            cmdLogin.Parameters[2].Direction = ParameterDirection.Output;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            cmdLogin.ExecuteScalar();
            id = (int) cmdLogin.Parameters[2].Value;
            conn.Close();
            return id;
        }


        public string LoginUser(User user)
        {
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = conn;
            cmdLogin.CommandText = "proc_checkUserRole";
            cmdLogin.CommandType = CommandType.StoredProcedure;
            cmdLogin.Parameters.Add("@uid", SqlDbType.Int);
            cmdLogin.Parameters.Add("@upassword", SqlDbType.VarChar, 30);
            cmdLogin.Parameters.Add("@username", SqlDbType.VarChar, 30);
            cmdLogin.Parameters[0].Value = user.Id;
            cmdLogin.Parameters[1].Value = user.Password;
            cmdLogin.Parameters[2].Direction = ParameterDirection.Output;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            cmdLogin.ExecuteScalar();
            string name = cmdLogin.Parameters[2].Value.ToString();
            conn.Close();
            return name;
        }
        public int GetAllUsersCount()
        {
            SqlCommand cmdGetUsers = new SqlCommand();
            cmdGetUsers.Connection = conn;
            cmdGetUsers.CommandText = "proc_GetAllUsersCount";
            cmdGetUsers.CommandType = CommandType.StoredProcedure;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            int count = (int)cmdGetUsers.ExecuteScalar();
            return count;
        }

    }
}
