using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.Transactions
{
    [Table("Transaction")]
    public class Transaction : FullAuditedEntity<int>
    {
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public int Fk_AccountId { get; set; }
        public bool? isAuthorized { get; set; }
        public decimal BalBefore { get; set; }
        public decimal BalAfter { get; set; }
    }
}
