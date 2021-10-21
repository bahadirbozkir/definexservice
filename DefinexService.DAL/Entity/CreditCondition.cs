using DefinexService.DAL.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DefinexService.DAL.Entity
{
    public class CreditCondition : BaseEntity
    {
        public ConditionType ConditionType { get; set; }
        public BankType BankType { get; set; }

        [Column(TypeName ="varchar(250)")]
        public string ConditionValue { get; set; }

        #region Relations
        public long BankGatewayId { get; set; }

        [ForeignKey("BankGatewayId")]
        public BankGateway BankGateway { get; set; }
        #endregion
    }
}
