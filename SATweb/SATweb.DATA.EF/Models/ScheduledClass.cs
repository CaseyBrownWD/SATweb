using System;
using System.Collections.Generic;

namespace SATweb.DATA.EF.Models
{
    public partial class ScheduledClass
    {
        public ScheduledClass()
        {
            Enrollments = new HashSet<Enrollment>();
        }

        public int ScheduleClassId { get; set; }
        public int CourseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string InstructorName { get; set; } = null!;
        public string Location { get; set; } = null!;
        public int Scsid { get; set; }

        public virtual Course Course { get; set; } = null!;
        public virtual ScheduleClassStatus Scs { get; set; } = null!;
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}
