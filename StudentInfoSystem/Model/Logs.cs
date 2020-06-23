using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem.Model
{
    public class Logs
    {
        public System.Int32 LogsId { get; set; }
        public string userLog { get; set; }
        
        public Logs(string userLog)
        {
            this.userLog = userLog;
        }
    }
}
