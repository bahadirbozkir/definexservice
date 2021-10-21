using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.BL.Dto.Requests
{
    public class BasketItemRequest
    {
        public long Id { get; set; }
        public int Quantity { get; set; }
    }
}
