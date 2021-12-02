using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mgrProject.Interfaces;
using mgrProject.Models;
using mgrProject.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace mgrProject.API
{
    /// <summary>
    /// V1 Controller resposible for GET/POST
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class V1Controller : ControllerBase
    {
        private readonly INeo4jService _neo4JService;
        private readonly IMySQLService _mySQLService;
        public V1Controller(INeo4jService neo4JService, IMySQLService mySQLService)
        {
            _neo4JService = neo4JService;
            _mySQLService = mySQLService;
        }

        /// <summary>
        ///  This POST method return query Mysql
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("~/queryCypher")]
        public async Task<IActionResult> QueryCypher(string query)
        {
            var result = await _neo4JService.cypher(query);
            return Ok(result);
        }

        /// <summary>
        ///     This POST method return query Mysql
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpPost("~/queryMySQL")]
        public async Task<IActionResult> QueryMySQL(string query)
        {
            var result = await _mySQLService.sql(query);
            return Ok(result);
        }

        [HttpPost("~/CheckConnectionMySQL")]
        public async Task<IActionResult> CheckConnectionMySQL([FromBody] ConnectionValue connection)
        {
            var result = _mySQLService.IsServerConnected(connection);
            return Ok(result);
        }

        [HttpPost("~/CheckConnectionNeo4j")]
        public async Task<IActionResult> CheckConnectionNeo4j([FromBody] ConnectionValueNeo4j connection)
        {
            var result = _neo4JService.IsServerConnected(connection);
            return Ok(result);
        }

    }
}
