using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mgrProject.Models
{
    public class MySQLReturnValue
    {
        public List<dynamic> result { get; set; }
        public long timeQuery { get; set; }
    }
}
