using SiteManagement.Entity.DTOs.Sites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.DTOs.Announcements
{
    public class AnnouncementAddDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid SiteId { get; set; }
        public Guid CreatedById { get; set; }
        public List<SiteDto>? Sites { get; set; } 
    }
}
