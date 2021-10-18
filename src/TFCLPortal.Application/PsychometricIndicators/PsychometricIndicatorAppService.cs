using Abp.Domain.Repositories;
using Abp.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.Applications;
using TFCLPortal.CoApplicantDetails;
using TFCLPortal.PsychometricIndicators.Dto;
using TFCLPortal.GuarantorDetails;

namespace TFCLPortal.PsychometricIndicators
{
    public class PsychometricIndicatorAppService : TFCLPortalAppServiceBase, IPsychometricIndicatorAppService
    {
        private readonly IRepository<PsychometricIndicator, int> _PsychometricIndicatorRepository;
        private readonly ICoApplicantDetailAppService _coApplicantDetailAppService;
        private readonly IGuarantorDetailAppService _guarantorDetailAppService;
        private readonly IApplicationAppService _applicationAppService;

        public PsychometricIndicatorAppService(IRepository<PsychometricIndicator, int> PsychometricIndicatorRepository, IApplicationAppService applicationAppService, IGuarantorDetailAppService guarantorDetailAppService, ICoApplicantDetailAppService coApplicantDetailAppService)
        {
            _PsychometricIndicatorRepository = PsychometricIndicatorRepository;
            _applicationAppService = applicationAppService;
            _coApplicantDetailAppService = coApplicantDetailAppService;
            _guarantorDetailAppService = guarantorDetailAppService;

        }

        public async Task<string> CreatePsychometricIndicator(CreatePsychometricIndicatorDto Input)
        {
            try
            {
                var filUpload = ObjectMapper.Map<PsychometricIndicator>(Input);
                await _PsychometricIndicatorRepository.InsertAsync(filUpload);
                CurrentUnitOfWork.SaveChanges();

                _applicationAppService.UpdateApplicationLastScreen("Files Upload", Input.ApplicationId);

            }
            catch (Exception)
            {
                return "Failed";
            }
            return "Success";
        }


        public List<PsychometricIndicatorListDto> GetPsychometricIndicatorByApplicationId(int ApplicationId)
        {
            try
            {
                var filesList = _PsychometricIndicatorRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).ToList();
                var files = ObjectMapper.Map<List<PsychometricIndicatorListDto>>(filesList);

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

        public bool CheckPsychometricIndicatorByApplicationId(int ApplicationId)
        {
            try
            {
                var filesList = _PsychometricIndicatorRepository.GetAllList().Where(x => x.ApplicationId == ApplicationId).ToList();
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
