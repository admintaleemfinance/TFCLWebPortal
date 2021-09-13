﻿using Abp.Application.Services;
using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TFCLPortal.DynamicDropdowns.Dto;

namespace TFCLPortal.DynamicDropdowns.Qualifications
{
    public  interface IQualificationAppService: IApplicationService
    {
        Task<ListResultDto<QualificationListDto>> GetAllQualification();
        Task CreateQualification(CreateQualificationDto input);
        List<QualificationListDto> GetAllList();
    }
}
