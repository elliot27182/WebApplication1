using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_DataAccessLayer;
using DomainModels;

namespace MVC_BusinessLogicLayer
{
    public class UserService
    {
        private UserDataAccess userDataAccess = new UserDataAccess();

        public void AddUser(User user)
        {

            userDataAccess.AddUser(user);
        }

        public User GetUserByUsername(string username)
        {
          
            return userDataAccess.GetUserByUsername(username);
        }
    }
}
