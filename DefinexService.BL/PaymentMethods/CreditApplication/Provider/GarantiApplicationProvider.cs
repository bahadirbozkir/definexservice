using DefinexService.BL.Dto.Requests;
using DefinexService.BL.Dto.Responses;
using DefinexService.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.BL.PaymentMethods.CreditApplication.Provider
{
    public class GarantiApplicationProvider : IPaymentBankProvider
    {
        protected readonly PaymentRequest _request;
        public GarantiApplicationProvider(PaymentRequest request)
        {
            _request = request;
        }
        public IPaymentBankResponse ProceedPayment()
        {
            return new CreditApplicationPaymentResponse { IsSuccess = true };
        }
    }
}
