using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserLogin;

namespace StudentInfoSystem.Model
{
    class StudentInfoContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Logs> UserLogs { get; set; }
        public StudentInfoContext() : base(Properties.Settings.Default.DbConnect) { }

        
    }
}
