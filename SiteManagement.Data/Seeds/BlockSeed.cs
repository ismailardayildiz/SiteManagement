using SiteManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Data.Seeds
{
    public static class BlockSeed
    {
        public static readonly Guid Block1Id = Guid.Parse("448D9760-5B48-450D-8297-C25C88E7BE2F");
        public static readonly Guid Block2Id = Guid.Parse("41712748-F3E8-4540-9F19-200E5A1F095D");
        public static readonly Guid Block3Id = Guid.Parse("ACCF19A5-B677-4E03-996E-EF32EB2C93D5");

        public static readonly IEnumerable<Block> Data = new List<Block>
        {
            new Block
            {
                Id          = Block1Id,
                Name        = "A Blok",
                FloorCount  = 8,
                SiteId      = SiteSeed.Site1Id,
                CreatedBy   = "seed",
                CreatedDate = new DateTime(2024, 1, 1),
                IsDeleted   = false
            },
            new Block
            {
                Id          = Block2Id,
                Name        = "B Blok",
                FloorCount  = 6,
                SiteId      = SiteSeed.Site1Id,
                CreatedBy   = "seed",
                CreatedDate = new DateTime(2024, 1, 1),
                IsDeleted   = false
            },
            new Block
            {
                Id          = Block3Id,
                Name        = "A Blok",
                FloorCount  = 10,
                SiteId      = SiteSeed.Site2Id,
                CreatedBy   = "seed",
                CreatedDate = new DateTime(2024, 1, 1),
                IsDeleted   = false
            }
        };
    }
}
