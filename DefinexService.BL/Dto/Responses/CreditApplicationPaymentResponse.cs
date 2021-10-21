using DefinexService.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.BL.Dto.Responses
{
    public class CreditApplicationPaymentResponse : IPaymentBankResponse
    {
        public bool IsSuccess { get; set; }
    }
}
