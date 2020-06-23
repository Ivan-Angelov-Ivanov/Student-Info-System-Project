using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem.Model
{
    class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Logs> UserLogs { get; set; }
        public UserContext() : base(Properties.Settings.Default.DbConnect) { }

    }
}
