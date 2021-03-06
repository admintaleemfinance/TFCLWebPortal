using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TFCLPortal.DynamicDropdowns.TeacherTrainings
{
    //NEW DROPDOWN API Addition Table Reference

    [Table("TeacherTraining")]
    public class TeacherTraining : AuditedEntity<Int32>
    {
        public string Name { get; set; }
    }
}
