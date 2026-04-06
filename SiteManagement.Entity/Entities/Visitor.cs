using SiteManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Entities
{
    public class Visitor : EntityBase
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }
        public Guid ApartmentId { get; set; }
        public Guid RegisteredById { get; set; }


        public Apartment Apartment { get; set; }
        public AppUser RegisteredBy { get; set; }
    }
}
