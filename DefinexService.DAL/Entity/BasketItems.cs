using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DefinexService.DAL.Entity
{
    public class BasketItems : BaseEntity
    {
        public int Quantity { get; set; }

        public decimal Price { get; set; }

        [Column(TypeName ="varchar(250)")]
        public string Name { get; set; }

        public long BasketId { get; set; }

        #region Relations

        public long ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        #endregion
    }
}
