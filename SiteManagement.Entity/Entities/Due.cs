using SiteManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Entities
{
    public class Due : EntityBase
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public Guid ApartmentId { get; set; }

        public Apartment Apartment { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
