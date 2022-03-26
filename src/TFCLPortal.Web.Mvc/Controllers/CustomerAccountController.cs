using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using TFCLPortal.Controllers;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Abp.AspNetCore.Mvc.Controllers;
using TFCLPortal.CustomerAccounts;
using TFCLPortal.FileTypes;
using TFCLPortal.Web.Models.UploadFiles;
using Microsoft.AspNetCore.Http;
using TFCLPortal.CustomerAccounts.Dto;
using System;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using TFCLPortal.GuarantorDetails;
using TFCLPortal.CoApplicantDetails;
using System.Collections.Generic;
using TFCLPortal.Transactions;
using TFCLPortal.Transactions.Dto;
using TFCLPortal.Applications;
using TFCLPortal.Applications.Dto;

namespace TFCLPortal.Web.Controllers
{
    public class CustomerAccountController : AbpController
    {
        private readonly ICustomerAccountAppService _CustomerAccountAppService;
        private readonly ITransactionAppService _TransactionAppService;
        public CustomerAccountController(ITransactionAppService TransactionAppService, ICustomerAccountAppService CustomerAccountAppService, IHostingEnvironment env, IFileTypeAppService fileTypeAppService, IGuarantorDetailAppService guarantorDetailAppService, ICoApplicantDetailAppService coApplicantDetailAppService)
        {
            _TransactionAppService = TransactionAppService;
            _CustomerAccountAppService = CustomerAccountAppService;
        }
        public ActionResult Index()
        {
            var getCustomerAccounts = _CustomerAccountAppService.GetAllCustomerAccounts();
            return View(getCustomerAccounts);
        }

        public IActionResult ViewTransactions(int accountId)
        {
            List<TransactionListDto> transactions = new List<TransactionListDto>();
            if (accountId != 0)
            {
                transactions = _TransactionAppService.GetTransactionByAccountId(accountId);
            }
            ViewBag.AccountId = accountId;
            return View(transactions);
        }
        public IActionResult CreditForm(int accountId)
        {

            List<TransactionListDto> transactions = new List<TransactionListDto>();
            if (accountId != 0)
            {
                transactions = _TransactionAppService.GetTransactionByAccountId(accountId);
            }
            ViewBag.AccountId = accountId;

            var appDetails = _CustomerAccountAppService.GetApplicationDetailsByAccountId(accountId);
            ApplicationListDto latestLoan = new ApplicationListDto();
            if (appDetails.Count > 0)
            {
                latestLoan = appDetails[appDetails.Count - 1];
                ViewBag.ClientID = latestLoan.ClientID;
                ViewBag.ClientName = latestLoan.ClientName;
                ViewBag.SchoolName = latestLoan.SchoolName;
                ViewBag.CNICNo = latestLoan.CNICNo;

            }


            return View();
        }
    }
}
