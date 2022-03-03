using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODALLibrary
{
    public class ProductDAL
    {
        SqlConnection conn;
        public ProductDAL()
        {
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        }

        public DataSet GetProducts()
        {
            SqlCommand cmdGetProducts = new SqlCommand();
            cmdGetProducts.Connection = conn;
            cmdGetProducts.CommandText = "proc_getProducts";
            cmdGetProducts.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter daProducts = new SqlDataAdapter(cmdGetProducts);
            DataSet dsProducts = new DataSet();
            daProducts.Fill(dsProducts);
            return dsProducts;            
        }
    }
}
