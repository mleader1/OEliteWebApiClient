using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace OElite.OEliteWebApiClient.Sample.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost("")]
        public async Task<IActionResult> Index(string methodBtn, string param1, string param2)
        {

            Web.Utils.OEliteWebApiClient client = new Web.Utils.OEliteWebApiClient(string.Format("http{0}://{1}", Request.IsHttps ? "s" : "", Request.Host));
            CalcResult result = null;
            switch (methodBtn)
            {
                case "get1":
                    result = await client.GetJsonAsync<CalcResult>("/api/Calc",
                        new KeyValuePair<string, string>("param1", param1),
                        new KeyValuePair<string, string>("param2", param2));
                    break;
                case "get2":
                    result = await client.GetAsync<CalcResult>(string.Format("/api/Calc/{0}/{1}", param1, param2));
                    break;
                case "post1":
                    result = await client.PostAsync<CalcRequest, CalcResult>("/api/Calc", new CalcRequest() { Param1 = param1, Param2 = param2 });
                    break;
                case "post2":
                    result = await client.PostJsonAsync<CalcResult>("/api/Calc/form",
                        new KeyValuePair<string, string>("param1", param1),
                        new KeyValuePair<string, string>("param2", param2));
                    break;
                case "put1":
                    result = await client.PutAsync<CalcRequest, CalcResult>("/api/Calc", new CalcRequest() { Param1 = param1, Param2 = param2 });
                    break;
                case "put2":
                    result = await client.PutJsonAsync<CalcResult>("/api/Calc/form",
                        new KeyValuePair<string, string>("param1", param1),
                        new KeyValuePair<string, string>("param2", param2));
                    break;
                case "del1":
                    result = await client.DeleteJsonAsync<CalcResult>("/api/Calc",
                        new KeyValuePair<string, string>("param1", param1),
                        new KeyValuePair<string, string>("param2", param2));
                    break;
                case "del2":
                    result = await client.DeleteAsync<CalcResult>(string.Format("/api/Calc/{0}/{1}", param1, param2));
                    break;
                default:
                    break;
            }

            ViewData.Model = result;
            return View();
        }
    }
}
