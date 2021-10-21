using DefinexService.BL.Dto.Requests;
using DefinexService.BL.Interfaces;
using DefinexService.BL.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.BL.PaymentMethods.CreditApplication.Factory
{
    public class CreditApplicationPaymentFactory : PaymentMethodFactory
    {
        public CreditApplicationPaymentFactory(PaymentRequest request) : base(request)
        {

        }

        public override IPaymentFactory Factory()
        {
            var paymentBankType = _request.BankType;

            switch (paymentBankType)
            {
                case DAL.Enum.BankType.IsBankasi:
                    return new IsBankasiCreditFactory(_request);
                case DAL.Enum.BankType.Garanti:
                    return new GarantiCreditFactory(_request);
                case DAL.Enum.BankType.Akbank:
                    return new AkbankCreditFactory(_request);
                default:
                    return null;
            }
        }
    }
}
