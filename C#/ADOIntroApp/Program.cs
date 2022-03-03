using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace ADOIntroApp
{  

    class Program
    {
        SqlConnection conn;
        public Program()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);            
            Console.WriteLine("connected");
        }
        //connected arch
        void FetchProductData()
        {
            SqlCommand cmd = new SqlCommand("Select * from Products");
            cmd.Connection = conn;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Console.Write("Product ID " + dr[0].ToString());
                Console.Write("\tProduct Name " + dr[1].ToString());
                Console.Write("\tProduct quantity pre unit " + dr[4].ToString());
                Console.WriteLine();
            }
            conn.Close();

        }

        void FetchProductDataDisCon()
        {
            SqlDataAdapter daProducts = new SqlDataAdapter("Select * from Products",conn);
            DataSet dsProducts = new DataSet();
            daProducts.Fill(dsProducts);
            conn.Close();
            foreach(DataRow dr in dsProducts.Tables[0].Rows)
            {
                Console.Write("Product ID " + dr[0].ToString());
                Console.Write("\tProduct Name " + dr[1].ToString());
                Console.Write("\tProduct quantity pre unit " + dr[4].ToString());
                Console.WriteLine();
            }
            
        }

        void InsertUserToTable()
        {
            string username, password, role;
            int age;
            Console.WriteLine("Please enter the username");
            username = Console.ReadLine();
            Console.WriteLine("Please enter the password");
            password = Console.ReadLine();
            Console.WriteLine("Please enter the Role");
            role = Console.ReadLine();
            Console.WriteLine("Please enter the age");
            age = Convert.ToInt32(Console.ReadLine());
            SqlCommand cmd = new SqlCommand("insert into tblUSer values(@uname,@upass,@urole,@uage)");
            cmd.Parameters.Add("@uname", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@upass", SqlDbType.VarChar, 20);
            //cmd.Parameters.Add("@urole", SqlDbType.VarChar, 20);
            //cmd.Parameters.Add("@uage", SqlDbType.Int);
            cmd.Parameters[0].Value = username;
            cmd.Parameters[1].Value = password;
            //cmd.Parameters[2].Value = role;
            //cmd.Parameters[3].Value = age;
            cmd.Parameters.AddWithValue("@urole", role);
            cmd.Parameters.AddWithValue("@uage", age);
            cmd.Connection = conn;
            conn.Open();
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
                Console.WriteLine("USer created");
            conn.Close();
        }

        void InsertUserToTableDisCon()
        {
            string username, password, role;
            int age;
            Console.WriteLine("Please enter the username");
            username = Console.ReadLine();
            Console.WriteLine("Please enter the password");
            password = Console.ReadLine();
            Console.WriteLine("Please enter the Role");
            role = Console.ReadLine();
            Console.WriteLine("Please enter the age");
            age = Convert.ToInt32(Console.ReadLine());
            SqlCommand cmd = new SqlCommand("insert into tblUSer values(@uname,@upass,@urole,@uage)");
            cmd.Parameters.Add("@uname", SqlDbType.VarChar, 20);
            cmd.Parameters.Add("@upass", SqlDbType.VarChar, 20);
            //cmd.Parameters.Add("@urole", SqlDbType.VarChar, 20);
            //cmd.Parameters.Add("@uage", SqlDbType.Int);
            cmd.Parameters[0].Value = username;
            cmd.Parameters[1].Value = password;
            //cmd.Parameters[2].Value = role;
            //cmd.Parameters[3].Value = age;
            cmd.Parameters.AddWithValue("@urole", role);
            cmd.Parameters.AddWithValue("@uage", age);
            SqlDataAdapter daInsert = new SqlDataAdapter();
            DataSet ds = new DataSet();
            daInsert.InsertCommand = cmd;
            daInsert.InsertCommand.Connection = conn;
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();
            dt.Columns.Add("username");
            dt.Columns.Add("password");
            dt.Columns.Add("role");
            dt.Columns.Add("age");
            dr[0] = username;
            dr[1] = password;
            dr[2] = role;
            dr[3] = age;
            dt.Rows.Add(dr);
            daInsert.Update(dt);
            Console.WriteLine("Done");
            conn.Close();
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.InsertUserToTable();
            //program.FetchProductDataDisCon();
            program.InsertUserToTableDisCon();
            Console.ReadKey();
        }
    }
}
