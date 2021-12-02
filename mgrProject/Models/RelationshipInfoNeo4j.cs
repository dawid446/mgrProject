using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mgrProject.Models
{
    public class RelationshipInfoNeo4j
    {
        public string relationshipName { get; set; }
        public string count { get; set; }
        public double memoryRelationship { get; set; }
        public double memoryProperty { get; set; }
    }
}
