using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace calc.add.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdditionController : ControllerBase
    {       

        private readonly ILogger<AdditionController> _logger;

        public AdditionController(ILogger<AdditionController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public int Add([FromBody]OperationParameters p)
        {
            return p.op1 + p.op2;
        }
    }
    public class OperationParameters
    {
        public int op1 { get; set; }
        public int op2 { get; set; }
    }
}
