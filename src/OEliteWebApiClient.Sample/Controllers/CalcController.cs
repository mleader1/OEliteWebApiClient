using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace OElite.OEliteWebApiClient.Sample.Controllers
{
    [Route("api/calc")]
    public class CalcController : Controller
    {
        private static List<OElite.CalcResult> memResult = new List<OElite.CalcResult>();

        [Route("{param1}/{param2}")]
        [Route("")]
        [HttpGet, HttpDelete]
        public OElite.CalcResult Get(string param1, string param2)
        {
            return ReturnResult(param1, param2);
        }

        [Route("form")]
        [HttpPost, HttpPut]
        public OElite.CalcResult PostViaForm(string param1, string param2)
        {
            return ReturnResult(param1, param2);
        }

        [HttpPost, HttpPut]
        public OElite.CalcResult PostViaJson([FromBody] CalcRequest request)
        {
            return ReturnResult(request.Param1, request.Param2);
        }


        private OElite.CalcResult ReturnResult(string param1, string param2)
        {
            return new CalcResult
            {
                Param1 = param1,
                Param2 = param2,
                Result = param1 + " " + param2,
                TimeExecuted = DateTime.UtcNow,
                RequestMethod = Request.Method,
                RequestUrl = Request.Path,
                RequestQuery = Request.QueryString.Value
            };

        }
    }
}
