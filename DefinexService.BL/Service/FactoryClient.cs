using DefinexService.BL.Dto.Requests;
using DefinexService.BL.Interfaces;
using DefinexService.BL.PaymentMethods.CreditApplication.Factory;
using DefinexService.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.BL.Service
{
    public class FactoryClient : IFactoryClient
    {
        public FactoryClient()
        {
        }

        public PaymentMethodFactory Factory(PaymentRequest request)
        {
            switch (request.PaymentMethodType)
            {
                case PaymentMethodType.CreditApplication:
                    return new CreditApplicationPaymentFactory(request);
                default:
                    throw new ArgumentOutOfRangeException(nameof(request.PaymentMethodType), request.PaymentMethodType, null);
            }
        }
    }
}
