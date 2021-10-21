using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DefinexService.DAL.Entity
{
    public class BankGateway : BaseEntity
    {
        public long ConfigurationId { get; set; }
        public long TerminalId { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string ClientUsername { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string ClientPassword { get; set; }

        #region Relations
        public long BankListId { get; set; }

        [ForeignKey("BankListId")]
        public BankList BankList { get; set; }

        #endregion
    }
}
