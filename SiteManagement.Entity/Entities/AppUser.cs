using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }



        public ICollection<Apartment> OwnedApartments { get; set; }
        public ICollection<Apartment> RentedApartments { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
        public ICollection<Complaint> Complaints { get; set; }
        public ICollection<Announcement> Announcements { get; set; }
        public Employee? Employee { get; set; }
    }
}
