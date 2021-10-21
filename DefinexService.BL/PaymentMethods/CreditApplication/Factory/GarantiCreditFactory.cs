using DefinexService.BL.Dto.Requests;
using DefinexService.BL.Interfaces;
using DefinexService.BL.PaymentMethods.CreditApplication.Provider;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.BL.PaymentMethods.CreditApplication.Factory
{
    public class GarantiCreditFactory : IPaymentFactory
    {
        protected readonly PaymentRequest _request;

        public GarantiCreditFactory(PaymentRequest request)
        {
            _request = request;
        }

        public IPaymentBankProvider Factory()
        {
            return new GarantiApplicationProvider(_request);
        }
    }
}
