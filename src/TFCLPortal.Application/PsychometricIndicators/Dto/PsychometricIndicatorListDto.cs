using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TFCLPortal.PsychometricIndicators.Dto
{
    [AutoMapFrom(typeof(PsychometricIndicator))]
    public class PsychometricIndicatorListDto : EntityDto
    {
        public int ApplicationId { get; set; }
        public int PercentageToSteal { get; set; }
        public int AvoidConflict { get; set; }
        public int MotivationToRunSchool { get; set; }
        public int BusinessLuck { get; set; }
        public int HopefulForFuture { get; set; }
        public int DigitalInitiatives { get; set; }
        public int TeacherTrainings { get; set; }
        public int ParentEngagement { get; set; }
        public string MixExpenses { get; set; }
        public string ComparedFee { get; set; }
    }
}
