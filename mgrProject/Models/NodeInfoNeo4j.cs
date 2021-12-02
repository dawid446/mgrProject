using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mgrProject.Models
{
    public class NodeInfoNeo4j
    {
        public string nodeName { get; set; }
        public string count { get; set; }
        public double memoryNode { get; set; }
        public double memoryProperty { get; set; }
    }
}
