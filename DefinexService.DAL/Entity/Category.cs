using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DefinexService.DAL.Entity
{
    public class Category : BaseEntity
    {
        [Column(TypeName ="varchar(250)")]
        public string Name { get; set; }
    }
}
