using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.DTOs.Apartments
{
    public class ApartmentAddDto
    {
        public Guid SiteId { get; set; }
        public Guid BlockId { get; set; }
        public int Floor { get; set; }
        public string ApartmentNumber { get; set; }
        public decimal SquareMeters { get; set; }
        public int RoomCount { get; set; }
        public Guid? OwnerId { get; set; }  
        public Guid? TenantId { get; set; }  
    }
}
