using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mgrProject.Models
{
    public class TableInfoMySQL
    {
        public string tableName { get; set; }
        public string count { get; set; }
        public string memoryUse { get; set; }
    }
}
