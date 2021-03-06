using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using TFCLPortal.BusinessExpenseSchoolClasses;

namespace TFCLPortal.BusinessExpenses.Dto
{
    [AutoMapTo(typeof(BusinessExpenseSchoolClass))]
    public class CreateBusinessExpenseSchoolClassesDto
    {
        public int Fk_BusinessExpenseSchool { get; set; }
        public string ClassNameOrSubject { get; set; }
        public int? Designation { get; set; }
        public int? Gender { get; set; }
        public string Salary { get; set; }

    }
}
