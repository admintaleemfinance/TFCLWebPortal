using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.CoApplicantDetails;
using TFCLPortal.SchoolNonFinancials.Dto;
using TFCLPortal.GuarantorDetails;

namespace TFCLPortal.SchoolNonFinancials
{
    public class SchoolNonFinancialAppService : TFCLPortalAppServiceBase, ISchoolNonFinancialAppService
    {
        private readonly IRepository<SchoolNonFinancial, int> _SchoolNonFinancialRepository;
        private readonly ICoApplicantDetailAppService _coApplicantDetailAppService;
        private readonly IGuarantorDetailAppService _guarantorDetailAppService;
        private readonly IApplicationAppService _applicationAppService;

        public SchoolNonFinancialAppService(IRepository<SchoolNonFinancial, int> SchoolNonFinancialRepository, IApplicationAppService applicationAppService, IGuarantorDetailAppService guarantorDetailAppService, ICoApplicantDetailAppService coApplicantDetailAppService)
        {
            _SchoolNonFinancialRepository = SchoolNonFinancialRepository;
            _applicationAppService = applicationAppService;
            _coApplicantDetailAppService = coApplicantDetailAppService;
            _guarantorDetailAppService = guarantorDetailAppService;

        }

        public async Task<string> CreateSchoolNonFinancial(CreateSchoolNonFinancialDto Input)
        {
            try
            {
                var filUpload = ObjectMapper.Map<SchoolNonFinancial>(Input);
                await _SchoolNonFinancialRepository.InsertAsync(filUpload);
                CurrentUnitOfWork.SaveChanges();

                _applicationAppService.UpdateApplicationLastScreen("Files Upload", Input.ApplicationId);

            }
            catch (Exception)
            {
                return "Failed";
            }
            return "Success";
        }


        public List<SchoolNonFinancialListDto> GetSchoolNonFinancialByApplicationId(int ApplicationId)
        {
            try
            {
                var filesList = _SchoolNonFinancialRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).ToList();
                var files = ObjectMapper.Map<List<SchoolNonFinancialListDto>>(filesList);

                //foreach (var file in files)
                //{
                //    if(file.Fk_idForName!=0)
                //    {
                //        if (file.ScreenCode.StartsWith("co_applicant"))
                //        {
                //            var coapplicantFile=_coApplicantDetailAppService.GetCoApplicantDetailById(file.Fk_idForName).Result.FirstOrDefault();
                //            if(coapplicantFile!=null)
                //            {
                //                file.RespectiveName = coapplicantFile.FullName;
                //            }
                //        }
                //        else if (file.ScreenCode.StartsWith("guarantor"))
                //        {
                //            var guarantorFile = _guarantorDetailAppService.GetGuarantorDetailById(file.Fk_idForName).Result.FirstOrDefault();
                //            if (guarantorFile != null)
                //            {
                //                file.RespectiveName = guarantorFile.FullName;
                //            }
                //        }

                //    }
                //}


                return files;
            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Files"));
            }
        }

        public bool CheckSchoolNonFinancialByApplicationId(int ApplicationId)
        {
            try
            {
                var filesList = _SchoolNonFinancialRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).ToList();
                if (filesList.Count>0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new UserFriendlyException(L("GetMethodError{0}", "Files"));
            }
        }
    }
}
