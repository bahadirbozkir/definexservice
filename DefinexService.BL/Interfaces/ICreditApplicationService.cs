using DefinexService.BL.Dto.Requests;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DefinexService.BL.Interfaces
{
    public interface ICreditApplicationService
    {
        Task<IPaymentBankResponse> Proceed(PaymentRequest request);
    }
}
