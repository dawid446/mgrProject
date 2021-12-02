using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace mgrProject.Models.ViewModel
{
    public class StatisticsViewModel
    {
        [Display(Name = "Table")]
        public List<TableInfoMySQL> TableMySQL { get; set; }

        [Display(Name= "Relationship")]
        public List<RelationshipInfoNeo4j> RelationshipNeo4j { get; set; }
        [Display(Name = "Nodes")]
        public List<NodeInfoNeo4j> NodeNeo4j { get; set; }
        public double memoryRelationDatabase { get; set; }
        public double memoryGraphDatabase { get; set; }
    }
}
