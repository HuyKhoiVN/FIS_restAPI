using System;
using System.Collections.Generic;

namespace appData.Models
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? HireDate { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Active { get; set; }

        public virtual Department? Department { get; set; }
        public virtual Position? Position { get; set; }
    }
}
