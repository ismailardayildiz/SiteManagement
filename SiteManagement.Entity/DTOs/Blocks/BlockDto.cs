using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.DTOs.Blocks
{
    public class BlockDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int FloorCount { get; set; }
        public string SiteName { get; set; }
    }
}

