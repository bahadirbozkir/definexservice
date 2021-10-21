using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.BL.Dto.Requests
{
    public class BasketRequest
    {
        public long Id { get; set; }
        public BasketItemRequest BasketItem { get; set; }
    }
}
