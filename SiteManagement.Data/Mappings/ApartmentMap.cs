using Microsoft.EntityFrameworkCore;
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
    public class ApartmentMap : IEntityTypeConfiguration<Apartment>
    {
        public void Configure(EntityTypeBuilder<Apartment> builder)
        {
            builder.ToTable("Apartments");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.ApartmentNumber).IsRequired().HasMaxLength(10);
            builder.Property(a => a.SquareMeters).HasPrecision(10, 2);

            builder.HasOne(a => a.Block)
                   .WithMany(b => b.Apartments)
                   .HasForeignKey(a => a.BlockId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Site)
                   .WithMany(s => s.Apartments)
                   .HasForeignKey(a => a.SiteId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Owner)
                   .WithMany(u => u.OwnedApartments)
                   .HasForeignKey(a => a.OwnerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(a => a.Tenant)
                   .WithMany(u => u.RentedApartments)
                   .HasForeignKey(a => a.TenantId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasQueryFilter(a => !a.IsDeleted);

            builder.HasData(ApartmentSeed.Data);
        }
    }
}
