using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.DTOs.Employees
{
    public class EmployeeUpdateDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
        public Guid SiteId { get; set; }
        public Guid? UserId { get; set; }
    }
}
