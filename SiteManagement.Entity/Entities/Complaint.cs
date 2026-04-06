using SiteManagement.Core.Entities;
using SiteManagement.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Entities
{
    public class Complaint : EntityBase
    {
        public string Title { get; set; }   
        public string Description { get; set; }
        public ComplaintStatus Status { get; set; } = ComplaintStatus.Pending;
        public Guid UserId { get; set; }
        public Guid ApartmentId { get; set; }


        public AppUser User { get; set; }
        public Apartment Apartment { get; set; }
    }
}
