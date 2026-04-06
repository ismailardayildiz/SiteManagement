using SiteManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Entities
{
    public class Site : EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Guid? ManagerId { get; set; }


        public AppUser? Manager { get; set; }
        public ICollection<Block> Blocks { get; set; }
        public ICollection<Apartment> Apartments { get; set; }
        public ICollection<Announcement> Announcements { get; set; }
        public ICollection<Employee> Employees { get; set; }

    }
}
