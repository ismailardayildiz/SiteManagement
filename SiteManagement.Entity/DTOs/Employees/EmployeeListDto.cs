using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.DTOs.Employees
{
    public class EmployeeListDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string SiteName { get; set; }
    }
}
