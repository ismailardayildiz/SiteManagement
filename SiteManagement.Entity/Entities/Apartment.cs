using SiteManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Entities
{
    public class Apartment : EntityBase
    {
        public string ApartmentNumber { get; set; }
        public int Floor { get; set; }
        public decimal SquareMeters { get; set; }
        public bool IsRented { get; set; }
        public int RoomCount { get; set; }
        public Guid BlockId { get; set; }
        public Guid? SiteId { get; set; }
        public Guid? OwnerId { get; set; }
        public Guid? TenantId { get; set; }



        public Block Block { get; set; }
        public Site Site { get; set; }
        public AppUser? Owner { get; set; }
        public AppUser? Tenant { get; set; }
        public ICollection<Due> Dues { get; set; }
        public ICollection<Complaint> Complaints { get; set; }
        public ICollection<Visitor> Visitors { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
