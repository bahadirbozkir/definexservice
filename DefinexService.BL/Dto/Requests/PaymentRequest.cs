using DefinexService.DAL.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.BL.Dto.Requests
{
    public class PaymentRequest
    {
        public PaymentMethodType PaymentMethodType { get; set; }
        public BankType BankType { get; set; }
        public OrderRequest Order { get; set; }

    }
}
