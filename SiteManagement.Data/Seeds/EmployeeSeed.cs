using SiteManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Data.Seeds
{
    public static class EmployeeSeed
    {
        public static readonly IEnumerable<Employee> Data = new List<Employee>
        {
            new Employee
            {
                Id          = Guid.Parse("1A153EA7-321A-4F30-AB2D-1BAFD40D0B76"),
                FirstName   = "Hasan",
                LastName    = "Güvenlik",
                Position    = "Security",
                Phone       = "05551112233",
                StartDate   = new DateTime(2023, 6, 1),
                EndDate     = null,
                IsActive    = true,
                SiteId      = SiteSeed.Site1Id,
                UserId      = null,
                CreatedBy   = "seed",
                CreatedDate = new DateTime(2023, 6, 1),
                IsDeleted   = false
            },
            new Employee
            {
                Id          = Guid.Parse("65470101-88DC-4FF4-AC60-6E9A02035F51"),
                FirstName   = "Nurcan",
                LastName    = "Temizlik",
                Position    = "Cleaning Staff",
                Phone       = "05554445566",
                StartDate   = new DateTime(2023, 9, 1),
                EndDate     = null,
                IsActive    = true,
                SiteId      = SiteSeed.Site1Id,
                UserId      = null,
                CreatedBy   = "seed",
                CreatedDate = new DateTime(2023, 9, 1),
                IsDeleted   = false
            }
        };
    }
}
