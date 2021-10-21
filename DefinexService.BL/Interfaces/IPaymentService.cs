using DefinexService.BL.Dto.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.BL.Interfaces
{
    public interface IPaymentService
    {
        IPaymentBankResponse ProcessPayment(PaymentRequest request);
    }
}
