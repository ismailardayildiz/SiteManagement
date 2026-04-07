using SiteManagement.Entity.DTOs.Sites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.DTOs.Blocks
{
    public class BlockAddDto
    {
        public string Name { get; set; }
        public int FloorCount { get; set; }
        public Guid SiteId { get; set; }
        public IList<SiteDto>? Sites { get; set; }
    }
}
