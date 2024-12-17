using System;
using System.Collections.Generic;

namespace appData.Models
{
    public partial class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
