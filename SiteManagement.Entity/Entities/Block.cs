using SiteManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Entity.Entities
{
    public class Block : EntityBase
    {
        public string Name { get; set; }
        public int FloorCount { get; set; }
        public Guid SiteId { get; set; }

        public Site Site { get; set; }
        public ICollection<Apartment> Apartments { get; set; }
    }
}
