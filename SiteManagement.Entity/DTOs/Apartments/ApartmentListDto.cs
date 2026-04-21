using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.DTOs.Apartments
{
    public class ApartmentListDto
    {
        public Guid Id { get; set; }
        public string SiteName { get; set; }
        public string BlockName { get; set; }
        public int Floor { get; set; }
        public string ApartmentNumber { get; set; }
        public decimal SquareMeters { get; set; }
        public string Status { get; set; } // Boş, Ev Sahibi, Kiracı
    }
}
