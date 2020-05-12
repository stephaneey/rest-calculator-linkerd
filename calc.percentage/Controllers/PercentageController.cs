using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace calc.percentage.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PercentageController : ControllerBase
    {
        string MultiplicationEndpoint = null;
        string DivisionEndpoint = null;

        private readonly ILogger<PercentageController> _logger;

        public PercentageController(ILogger<PercentageController> logger)
        {
            _logger = logger;
            
#if DEBUG
            MultiplicationEndpoint = "http://localhost:5003/multiplication";
            DivisionEndpoint = "http://localhost:5002/division";

#else
       MultiplicationEndpoint=Environment.GetEnvironmentVariable("MultiplicationEndpoint");
       DivisionEndpoint=Environment.GetEnvironmentVariable("DivisionEndpoint");                
                
#endif
        }
    
       
        [HttpPost]
        public async Task<int> Percentage([FromBody]OperationParameters p)
        {
            return await Calculate(await Calculate(p.op1, p.op2,MultiplicationEndpoint), 100,DivisionEndpoint);
        }

        async Task<int> Calculate(int op1, int op2,string endpoint)
        {
           using(HttpClient cli = new HttpClient())
            {
                return Convert.ToInt32((await cli.PostAsync(
                    endpoint, new StringContent(JsonConvert.SerializeObject(
                    new OperationParameters
                    {
                        op1=op1,
                        op2=op2
                    }), Encoding.UTF8, "application/json"))).Content.ReadAsStringAsync().Result);
               
            }
        }

      
    }

    public class OperationParameters
    {
        public int op1 { get; set; }
        public int op2 { get; set; }
    }
}
