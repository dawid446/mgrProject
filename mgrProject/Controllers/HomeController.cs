using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mgrProject.Models;
using Domain.Entity;
using Neo4j.Driver;
using mgrProject.Services;
using mgrProject.Models.ViewModel;
using mgrProject.Interfaces;

namespace mgrProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMySQLService _mySQLService;
        private readonly INeo4jService _neo4JService;

        public HomeController(ILogger<HomeController> logger, IMySQLService mySQLService, INeo4jService neo4JService)
        {
            _logger = logger;
            _mySQLService = mySQLService;
            _neo4JService = neo4JService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Benchmark()
        {
            var tableinfo = _mySQLService.TableInfoMySQLs("SELECT table_name as TableName, CAST(TABLE_ROWS as CHAR(50)) as TableRow FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'shop'");
            var memoryInfoMySQL = _mySQLService.TableInfoMySQLs(@"SELECT table_name AS TableName,
CAST(ROUND(((data_length + index_length) / 1024 / 1024), 2) as CHAR(50)) AS TableRow
FROM information_schema.TABLES
WHERE table_schema = 'shop'
ORDER BY(data_length + index_length) DESC;");

            
            var nodeInfoLabel = _neo4JService.nodeCount();
            var relInfo = _neo4JService.relationshipCount();

            var nodeInfoResult = _neo4JService.nodeInfoNeo4Js(nodeInfoLabel.Result);
            var relInfoResult = _neo4JService.nodeInfoRelationshipNeo4J(relInfo.Result);
            var mySQLInfoResult = _mySQLService.tableInfoMySQLs(tableinfo.Result, memoryInfoMySQL.Result);


            var result = new StatisticsViewModel()
            {
                NodeNeo4j = nodeInfoResult,
                RelationshipNeo4j = relInfoResult,
                TableMySQL = mySQLInfoResult,


            };
            return View(result);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
