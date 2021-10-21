using DefinexService.BL.Dto.Requests;
using DefinexService.BL.Dto.Responses;
using DefinexService.BL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DefinexService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditApplicationController : ControllerBase
    {
        private readonly ICreditApplicationService _creditApplicationService;

        public CreditApplicationController(ICreditApplicationService creditApplicationService)
        {
            _creditApplicationService = creditApplicationService;
        }

        [HttpPost("apply-credit")]
        public async Task<IActionResult> ApplyCredit([FromBody] PaymentRequest request)
        {
            var result = await _creditApplicationService.Proceed(request);

            var returnResponse = result as CreditApplicationPaymentResponse;

            if (returnResponse.IsSuccess)
            {
                return Ok(HttpStatusCode.OK);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
