using System;
using System.Collections.Generic;

namespace appData.Models
{
    public partial class Position
    {
        public Position()
        {
            Employees = new HashSet<Employee>();
        }

        public int PositionId { get; set; }
        public string PositionName { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
