﻿using Abp.AutoMapper;
using System;
using TFCLPortal.BankAccountChildDetails;

namespace TFCLPortal.BankAccountDetails.Dto
{
    [AutoMapTo(typeof(BankAccountChildDetail))]
    public class BankAccountChildDto
    {
        public int Fk_BankAccountDetail { get; set; }
        public string MonthName { get; set; }
        public DateTime? LowestBalanceDate1 { get; set; }
        public string LowestBalance1 { get; set; }
        public DateTime? LowestBalanceDate2 { get; set; }
        public string LowestBalance2 { get; set; }
        public DateTime? LowestBalanceDate3 { get; set; }
        public string LowestBalance3 { get; set; }
        public string avgLowestBalance { get; set; }

        public DateTime? HighestBalanceDate1 { get; set; }
        public string HighestBalance1 { get; set; }
        public DateTime? HighestBalanceDate2 { get; set; }
        public string HighestBalance2 { get; set; }
        public DateTime? HighestBalanceDate3 { get; set; }
        public string HighestBalance3 { get; set; }
        public string avgHighestBalance { get; set; }
        public string OverallAvgBalance { get; set; }
        public string AbbToEMI { get; set; }

    }
}