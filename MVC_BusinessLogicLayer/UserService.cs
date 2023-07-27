using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_DataAccessLayer;


namespace MVC_BusinessLogicLayer
{
    public class UserService
    {
        private UserDataAccess userDataAccess = new UserDataAccess();

        public void AddUser(UserViewModel user)
        {

            userDataAccess.AddUser(user);
        }

        public UserViewModel GetUserByUsername(string username)
        {
          
            return userDataAccess.GetUserByUsername(username);
        }
    }
}
