using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.DTOs.Dues
{
    public class DueUpdateDto
    {
        public Guid Id { get; set; }
        public int Year { get; set; }
        public int Month { get; set; }
        public decimal Amount { get; set; }
        public DateTime DueDate { get; set; }
        public Guid ApartmentId { get; set; }
    }
}
