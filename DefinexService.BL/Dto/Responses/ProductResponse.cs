using DefinexService.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DefinexService.BL.Dto.Responses
{
    public class ProductResponse
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public long Id { get; set; }
        public Category Category { get; set; }
    }
}
