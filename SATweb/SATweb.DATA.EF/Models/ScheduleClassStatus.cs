using System;
using System.Collections.Generic;

namespace SATweb.DATA.EF.Models
{
    public partial class ScheduleClassStatus
    {
        public ScheduleClassStatus()
        {
            ScheduledClasses = new HashSet<ScheduledClass>();
        }

        public int Scsid { get; set; }
        public string Scsname { get; set; } = null!;

        public virtual ICollection<ScheduledClass> ScheduledClasses { get; set; }
    }
}
