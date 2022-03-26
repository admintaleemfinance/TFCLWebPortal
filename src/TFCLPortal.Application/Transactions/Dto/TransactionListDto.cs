using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace TFCLPortal.Transactions.Dto
{
    [AutoMapFrom(typeof(Transaction))]
    public class TransactionListDto : FullAuditedEntityDto
    {
        public decimal Amount { get; set; }
        public string Type { get; set; }
        public int Fk_AccountId { get; set; }
        public bool? isAuthorized { get; set; }
        public decimal BalBefore { get; set; }
        public decimal BalAfter { get; set; }
    }
}
