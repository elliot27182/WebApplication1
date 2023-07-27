using DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_DataAccessLayer
{
    public class UserDbContext : DbContext
    {
        public UserDbContext()
            : base("Data Source=DESKTOP-RQ3BRI1\\SQLEXPRESS;Initial Catalog=master;User ID=sa;Password=123456;Connect Timeout=30")
        {
        }

        public virtual DbSet<User> Users { get; set; }
    }
}
