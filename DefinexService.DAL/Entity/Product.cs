using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DefinexService.DAL.Entity
{
    public class Product : BaseEntity
    {
        [Column(TypeName ="varchar(250)")]
        public string Name { get; set; }
        public decimal Price { get; set; }

        #region Relations
        public long CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        #endregion
    }
}
