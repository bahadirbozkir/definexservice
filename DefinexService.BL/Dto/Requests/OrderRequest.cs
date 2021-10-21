using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.BL.Dto.Requests
{
    public class OrderRequest
    {
        public decimal Total { get; set; }
        public List<long> CategoryList { get; set; }
    }
}
