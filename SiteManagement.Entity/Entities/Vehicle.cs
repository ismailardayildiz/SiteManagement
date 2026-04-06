using SiteManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Entities
{
    public class Vehicle : EntityBase
    {
        public string LicensePlate { get; set; }    
        public Guid ApartmentId { get; set; }
        public Guid UserId { get; set; }

        public AppUser User { get; set; }
        public Apartment Apartment { get; set; }
    }
}
