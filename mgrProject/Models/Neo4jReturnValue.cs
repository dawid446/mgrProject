using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mgrProject.Models
{
    public class Neo4jReturnValue
    {
        public List<IRecord> result { get; set; }
        public long timeQuery { get; set; }
    }
}
