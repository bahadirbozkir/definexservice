using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.BL.Interfaces
{
    public interface IPaymentBankProvider
    {
        IPaymentBankResponse ProceedPayment();
    }
}
