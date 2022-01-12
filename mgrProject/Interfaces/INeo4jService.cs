using mgrProject.Models;
using mgrProject.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mgrProject.Interfaces
{
    public interface INeo4jService
    {
        Task<Dictionary<string, string>> nodeCount();
        Task<Dictionary<string, string>> relationshipCount();
        List<RelationshipInfoNeo4j> nodeInfoRelationshipNeo4J(Dictionary<string, string> neo4j);
        List<NodeInfoNeo4j> nodeInfoNeo4Js(Dictionary<string, string> neo4j);
        Task<Neo4jReturnValue> cypher(string query);
        Task<ResponseConnection> IsServerConnected(ConnectionValueNeo4j connectionV);
    }
}