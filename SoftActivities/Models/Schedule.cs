using System;
using System.Collections.Generic;

namespace SoftActivities.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            Dates = new HashSet<Date>();
        }

        public int IdSchedule { get; set; }
        public string Description { get; set; } = null!;
        public int IdUser { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<Date> Dates { get; set; }
    }
}
