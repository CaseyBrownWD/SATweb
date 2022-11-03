using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SATweb.DATA.EF.Models.Metadata;

namespace SATweb.DATA.EF.Models
{
    [ModelMetadataType(typeof(CoursesMetadata))]
    public partial class Courses { }

    [ModelMetadataType(typeof(ScheduledClassStatusMetadata))]
    public partial class ScheduledClassStatus { }

    [ModelMetadataType(typeof(ScheduledClassMetadata))]
    public partial class ScheduledClasses { }

    [ModelMetadataType(typeof(EnrollmentMetadata))]
    public partial class Enrollment { }

    [ModelMetadataType(typeof(StudentStatusMetadata))]
    public partial class StudentStatus { }

    [ModelMetadataType(typeof(StudentMetadata))]
    public partial class Student
    {
        //[NotMapped]
        //public IFormFile? Image { get; set; }
        public string FullName { get { return $"{FirstName} {LastName}"; } }
    }

}


