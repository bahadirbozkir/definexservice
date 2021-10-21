using DefinexService.BL.Dto.Requests;
using DefinexService.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.BL.Service
{
    public abstract class PaymentMethodFactory
    {
        protected readonly PaymentRequest _request;
        protected PaymentMethodFactory(PaymentRequest request)
        {
            _request = request;
        }

        public abstract IPaymentFactory Factory();
    }
}
