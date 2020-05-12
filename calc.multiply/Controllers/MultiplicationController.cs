using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace calc.multiply.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MultiplicationController : ControllerBase
    {        

        private readonly ILogger<MultiplicationController> _logger;

        public MultiplicationController(ILogger<MultiplicationController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public int Multiply([FromBody]OperationParameters p)
        {
            return p.op1 * p.op2;
        }
    }

    public class OperationParameters
    {
        public int op1 { get; set; }
        public int op2 { get; set; }
    }
}
