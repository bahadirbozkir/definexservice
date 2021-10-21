using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.BL.Dto.Responses
{
    public class BasketResponse
    {
        public long Id { get; set; }
        public List<BasketItemResponse> BasketItems { get; set; }
    }
}
