using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SiteManagement.Data.Seeds;
using SiteManagement.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteManagement.Data.Mappings
{
    public class VehicleMap
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasData(VehicleSeed.Data);
        }
    }
}
