﻿using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.DynamicDropdowns.CompanyTypes;

namespace TFCLPortal.DynamicDropdowns.Dto
{
    [AutoMapTo(typeof(CompanyType))]
    public class CreateCompanyTypeDto
    {
        public string Name { get; set; }
    }
}
