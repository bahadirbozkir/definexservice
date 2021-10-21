using DefinexService.BL.Dto.Requests;
using DefinexService.BL.Interfaces;
using DefinexService.BL.PaymentMethods.CreditApplication.Provider;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.BL.PaymentMethods.CreditApplication.Factory
{
    public class IsBankasiCreditFactory : IPaymentFactory
    {
        protected readonly PaymentRequest _request;

        public IsBankasiCreditFactory(PaymentRequest request)
        {
            _request = request;
        }

        public IPaymentBankProvider Factory()
        {
            return new IsBankasiApplicationProvider(_request);
        }
    }
}
