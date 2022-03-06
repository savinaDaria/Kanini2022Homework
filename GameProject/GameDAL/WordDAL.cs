using GameModelsLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDAL
{
    public class WordDAL
    {
        SqlConnection conn;
        public WordDAL()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        }
        
        public int AddWord(string word)
        {
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = conn;
            cmdLogin.CommandText = "proc_AddWord";
            cmdLogin.CommandType = CommandType.StoredProcedure;
            cmdLogin.Parameters.Add("@Word", SqlDbType.VarChar, 20);
            cmdLogin.Parameters.Add("@Id", SqlDbType.Int);
            cmdLogin.Parameters[0].Value = word;
            cmdLogin.Parameters[1].Direction = ParameterDirection.Output;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            cmdLogin.ExecuteScalar();
            int id = (int)cmdLogin.Parameters[1].Value;
            conn.Close();
            return id;
        }

        public DataSet GetAllWords()
        {
           
            SqlCommand cmdGetWords= new SqlCommand();
            cmdGetWords.Connection = conn;
            cmdGetWords.CommandText = "proc_GetAllWords";
            cmdGetWords.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter daWords = new SqlDataAdapter(cmdGetWords);
            DataSet dsWords = new DataSet();
            daWords.Fill(dsWords);            
            return dsWords;
        }

        public int RemoveWord(int wordId)//returns affected rows
        {
            SqlCommand cmdLogin = new SqlCommand();
            cmdLogin.Connection = conn;
            cmdLogin.CommandText = "proc_RemoveWord";
            cmdLogin.CommandType = CommandType.StoredProcedure;
            cmdLogin.Parameters.Add("@Id", SqlDbType.Int);
            cmdLogin.Parameters[0].Value = wordId;
            if (conn.State == ConnectionState.Open)
                conn.Close();
            conn.Open();
            int res=cmdLogin.ExecuteNonQuery();
            conn.Close();
            return res;
        }
    }
}
