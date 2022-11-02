﻿using System;
using System.Collections.Generic;

namespace SATweb.DATA.EF.Models
{
    public partial class Enrollment
    {
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public int ScheduledClassId { get; set; }
        public DateTime EnrollemntDate { get; set; }

        public virtual ScheduledClass ScheduledClass { get; set; } = null!;
        public virtual Student Student { get; set; } = null!;
    }
}