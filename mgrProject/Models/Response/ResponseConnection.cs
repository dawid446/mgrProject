using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mgrProject.Models.Response
{
    public class ResponseConnection
    {
        public bool isConnection { get; set; }
        public bool error { get; set; }
        public string message { get; set; }
    }
}
