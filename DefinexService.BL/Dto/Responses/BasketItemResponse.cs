using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.BL.Dto.Responses
{
    public class BasketItemResponse
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public long BasketId { get; set; }
    }
}
