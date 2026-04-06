using Microsoft.VisualBasic;
using SiteManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Entities
{
    public class Announcement : EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid SiteId { get; set; }
        public Guid CreatedById { get; set; }
        public String CreatedBy { get; set; }
        public Site Site { get; set; }
        

    }
}
