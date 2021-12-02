using mgrProject.Interfaces;
using mgrProject.Models;
using mgrProject.Models.Dictionary;
using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mgrProject.Services
{
    public class Neo4jService : INeo4jService
    {
        private readonly INodeRelationship _nodeRelationship;
        private readonly IDriver _driver;
        public Neo4jService(IDriver driver, INodeRelationship nodeRelationship)
        {
            _driver = driver;
            _nodeRelationship = nodeRelationship;
        }
        public async Task<Neo4jReturnValue> cypher(string query)
        {
            IResultCursor cursor;
            var records = new Neo4jReturnValue();
            IAsyncSession session = _driver.AsyncSession(o => o.WithDatabase("neo4j"));
            try
            {

                var watch = System.Diagnostics.Stopwatch.StartNew();
                cursor = await session.RunAsync(query);
                records.result =  cursor.ToListAsync().Result;
                watch.Stop();
                records.timeQuery = watch.ElapsedMilliseconds;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                await session.CloseAsync();
            }

            return records;
        }

        public async Task<Dictionary<string,string>> relationshipCount()
        {
            IResultCursor cursor;
            var records = new Dictionary<string, string>();

            IAsyncSession session = _driver.AsyncSession(o => o.WithDatabase("neo4j"));
            try
            {
                cursor = await session.RunAsync(@"MATCH ()-[relationship]->() 
RETURN TYPE(relationship) AS type, COUNT(relationship) AS amount
ORDER BY amount DESC");

                while (await cursor.FetchAsync())
                {
                    string type = cursor.Current[0].As<string>("anymous");
                    string count = cursor.Current[1].As<string>("0");

                    records.Add(type, count);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                await session.CloseAsync();
            }

            return records;
        }

        public async Task<Dictionary<string, string>> nodeCount()
        {
            IResultCursor cursor;
            var records = new Dictionary<string, string>();

            IAsyncSession session = _driver.AsyncSession(o => o.WithDatabase("neo4j"));
            try
            {
                cursor = await session.RunAsync(@"MATCH (n) 
RETURN DISTINCT count(labels(n)) as count, labels(n) as label");

                while (await cursor.FetchAsync())
                {
                    string count = cursor.Current[0].As<string>("anymous");
                    string type= cursor.Current[1].As<List<string>>().FirstOrDefault();

                    records.Add(type, count);
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                await session.CloseAsync();
            }

            return records;
        }


        public List<NodeInfoNeo4j> nodeInfoNeo4Js(Dictionary<string,string> neo4j)
        {

            var list = new List<NodeInfoNeo4j>();
            foreach (var item in neo4j)
            {
                var element = new NodeInfoNeo4j();
                element.nodeName = item.Key;
                element.count = item.Value;
                var propCount = _nodeRelationship.getDictionary().Where(s=> s.Key == item.Key).FirstOrDefault();
                double count = Convert.ToDouble(element.count);
                element.memoryNode = Math.Round(((propCount.Value * 15) * count) * 0.000001, 4);
                element.memoryProperty = Math.Round(((propCount.Value * 41) * count) * 0.000001, 4);
                list.Add(element);
            }
            return list;

        }

        public List<RelationshipInfoNeo4j> nodeInfoRelationshipNeo4J(Dictionary<string, string> neo4j)
        {

            var list = new List<RelationshipInfoNeo4j>();
            foreach (var item in neo4j)
            {
                var element = new RelationshipInfoNeo4j();
                element.relationshipName = item.Key;
                element.count = item.Value;
                var propCount = _nodeRelationship.getDictionary().Where(s => s.Key == item.Key).FirstOrDefault();
                double count = Convert.ToDouble(element.count);
                element.memoryProperty = Math.Round(((propCount.Value * 41) * count) * 0.000001, 4);
                element.memoryRelationship = Math.Round(((propCount.Value * 43) * count) * 0.000001, 4);
                list.Add(element);
            }

            return list;

        }
        public bool IsServerConnected(ConnectionValueNeo4j connectionV)
        {
            try
            {
                var _driver1 = GraphDatabase.Driver(connectionV.bolt, AuthTokens.Basic(connectionV.userName, connectionV.password));
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }
    }
}
