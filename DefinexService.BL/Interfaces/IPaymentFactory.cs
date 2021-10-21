using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.BL.Interfaces
{
    public interface IPaymentFactory
    {
        IPaymentBankProvider Factory();
    }
}
