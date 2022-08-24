using System;
using System.Collections.Generic;

namespace SoftActivities.Models
{
    public partial class User
    {
        public User()
        {
            Schedules = new HashSet<Schedule>();
        }

        public int IdUser { get; set; }
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
