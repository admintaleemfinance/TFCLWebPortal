using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.CoApplicantDetails
{
    [Table("CoApplicantDetails")]
    public class CoApplicantDetail:FullAuditedEntity<int>
    {
        public string FullName { get; set; }
        public string SDW { get; set; }
        public string CNICNumber { get; set; }
        public string MobileNumber { get; set; }
        public string PresentAddress { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Tehsil { get; set; }
        public string UCNumber { get; set; }
        public string MouzaOrTown { get; set; }
        public string RealtionshipWithApplicant { get; set; }
        public string BusinessName { get; set; }
        public string BusinessAddress { get; set; }
        public string Profession { get; set; }
        public string EmployerName { get; set; }
        public int ApplicationId { get; set; }
        public string ScreenStatus { get; set; }
        public string Comments { get; set; }

        //NEw

        public DateTime? CnicExpiryDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Age { get; set; }
        public bool? CreditBureauCheck { get; set; }
        public int? CreditBureauStatus { get; set; }
        public bool? AmlCftCheck { get; set; }
        public bool? AmlCftClearance { get; set; }
        public bool? isGuarenteedLoanFi { get; set; }
        public string guarenteedAmountFi { get; set; }
    }
}
