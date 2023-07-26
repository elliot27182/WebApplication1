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
            // Here, you can add any business rules or logic before passing to the DataAccessLayer

            userDataAccess.AddUser(user);
        }

        public User GetUserByUsername(string username)
        {
            // Again, any business logic or rules could go here...

            return userDataAccess.GetUserByUsername(username);
        }
    }
}
