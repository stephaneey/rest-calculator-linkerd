using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace calc.divide.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DivisionController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<DivisionController> _logger;

        public DivisionController(ILogger<DivisionController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public int Divide([FromBody]OperationParameters p)
        {
            return p.op1 / p.op2;
        }
    }

    public class OperationParameters
    {
        public int op1 { get; set; }
        public int op2 { get; set; }
    }
}
