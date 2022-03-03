using ADODALLibrary;
using ADOModelsLibrary;
using System;
using System.Data;

namespace ADBLLibrary
{
    public class UserBL
    {
        UserDAL userDAL;
        public UserBL()
        {
            userDAL = new UserDAL();
        }
        public User CheckLogin(User user)
        {
            if (user.Username != null && user.Password != null)
            {
                string result = userDAL.Login(user);
                if (result == "invalid")
                {
                    return null;
                }
                else
                {
                    user.Role = result;
                    user.Password = "";
                    return user;
                }
            }
            return null;
        }

        public bool CheckRole(User user)
        {
            if (user.Role == "admin") return true;
            else return false;
        }

        public DataSet GetProductsIfRoleAdmin(User user)
        {
            bool urolecheck = CheckRole(user);
            if (urolecheck)
            {
                ProductDAL productDAL = new ProductDAL();
                return productDAL.GetProducts();
            }
            else return null;
        }
    }
}
