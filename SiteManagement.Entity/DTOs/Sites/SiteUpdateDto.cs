using SiteManagement.Entity.DTOs.Managers;
using SiteManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.DTOs.Sites
{
    public class SiteUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Guid? ManagerId { get; set; }
        public ManagerAddDto NewManager { get; set; }

        public IList<AppUser>? Managers { get; set; }
    }
}
