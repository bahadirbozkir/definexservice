using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DefinexService.DAL.Entity
{
    public class Basket : BaseEntity
    {
        [Column(TypeName ="varchar(250)")]
        public string Guid { get; set; }

        [ForeignKey("BasketId")]
        public ICollection<BasketItems> BasketItems { get; set; }
    }
}
