using DefinexService.BL.Dto.Requests;
using DefinexService.BL.Dto.Responses;
using DefinexService.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.BL.Dto.RequestHelper
{
    public interface IRequestHelper
    {
        IPaymentBankResponse CreateApplicationPaymentRequest(PaymentRequest request);
    }
}
