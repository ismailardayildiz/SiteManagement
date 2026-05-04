using SiteManagement.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.DTOs.Complaints
{
    public class ComplaintUpdateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; } 
        public ComplaintStatus Status { get; set; }
        public DateTime CreatedDate { get; set; } 
    }
}
