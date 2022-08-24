using System;
using System.Collections.Generic;

namespace SoftActivities.Models
{
    public partial class Date
    {
        public int IdDate { get; set; }
        public DateTime DateS { get; set; }
        public int Hour { get; set; }
        public int IdSchedule { get; set; }

        public virtual Schedule IdScheduleNavigation { get; set; } = null!;
    }
}
