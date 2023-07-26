using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DomainModels
{
    public class User
    {
       
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public HttpPostedFileBase Image { get; set; }
        public string ImagePath { get; set; }
    }
}
