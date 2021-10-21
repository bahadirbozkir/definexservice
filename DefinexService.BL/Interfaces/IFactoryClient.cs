using DefinexService.BL.Dto.Requests;
using DefinexService.BL.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.BL.Interfaces
{
    public interface IFactoryClient
    {
        PaymentMethodFactory Factory(PaymentRequest request);
    }
}
