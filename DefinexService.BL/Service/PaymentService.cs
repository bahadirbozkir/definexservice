using DefinexService.BL.Dto.Requests;
using DefinexService.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.BL.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IFactoryClient _factoryClient;

        public PaymentService(IFactoryClient factoryClient)
        {
            _factoryClient = factoryClient;
        }
        public IPaymentBankResponse ProcessPayment(PaymentRequest request)
        {
            var methodFactory = _factoryClient.Factory(request);
            var paymentFactory = methodFactory.Factory();
            var providerFactory = paymentFactory.Factory();
            return providerFactory.ProceedPayment();
        }
    }
}
