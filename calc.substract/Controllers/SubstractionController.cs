using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace calc.substract.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SubstractionController : ControllerBase
    {
       
        private readonly ILogger<SubstractionController> _logger;

        public SubstractionController(ILogger<SubstractionController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public int Substract([FromBody]OperationParameters p)
        {
            return p.op1 - p.op2;
        }
    }

    public class OperationParameters
    {
        public int op1 { get; set; }
        public int op2 { get; set; }
    }
}
