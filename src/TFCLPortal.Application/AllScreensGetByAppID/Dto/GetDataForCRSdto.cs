using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.AssetLiabilityDetails.Dto;
using TFCLPortal.AssociatedIncomeDetails.Dto;
using TFCLPortal.BankAccountDetails.Dto;
using TFCLPortal.BusinessDetails.Dto;
using TFCLPortal.BusinessExpenses.Dto;
using TFCLPortal.BusinessIncomes.Dto;
using TFCLPortal.BusinessPlans.Dto;
using TFCLPortal.CoApplicantDetails.Dto;
using TFCLPortal.CollateralDetails.Dto;
using TFCLPortal.ContactDetails.Dto;
using TFCLPortal.ExposureDetails.Dto;
using TFCLPortal.ForSDES.Dto;
using TFCLPortal.GuarantorDetails.Dto;
using TFCLPortal.HouseholdIncomesExpenses.Dto;
using TFCLPortal.LoanEligibilities.Dto;
using TFCLPortal.NonAssociatedIncomeDetails.Dto;
using TFCLPortal.OtherDetails.Dto;
using TFCLPortal.PersonalDetails.Dto;
using TFCLPortal.Preferences.Dto;
using TFCLPortal.Applications.Dto;
using TFCLPortal.Mobilizations;
using TFCLPortal.ApplicationWiseDeviationVariables.Dto;


using TFCLPortal.DependentEducationDetails.Dto;
using TFCLPortal.TdsInventoryDetails.Dto;
using TFCLPortal.SalesDetails.Dto;
using TFCLPortal.TDSLoanEligibilities.Dto;
using TFCLPortal.BusinessDetailsTDS.Dto;
using TFCLPortal.TDSBusinessExpenses.Dto;
using TFCLPortal.PurchaseDetails.Dto;

using TFCLPortal.EmploymentDetails.Dto;
using TFCLPortal.SalaryDetails.Dto;
using TFCLPortal.TJSLoanEligibilities;
using TFCLPortal.TJSLoanEligibilities.Dto;

namespace TFCLPortal.AllScreensGetByAppID.Dto
{

    public class GetDataForCRSdto
    {
        public int ApplicationId { get; set; }
        public string ClientName { get; set; }
        public string CNICNo { get; set; }
        public string Address { get; set; }
        public string SchoolName { get; set; }
        public string ClientID { get; set; }
        public string BranchCode { get; set; }
        public string LoanPurpose { get; set; }
        public string MarkupApplied { get; set; }
        public string LoanAmountRequested { get; set; }
        public string Tenure { get; set; }

        //Personal Data
        public int Age { get; set; }


        //Financial Data
        public int LoanCycles { get; set; }
    }
}
