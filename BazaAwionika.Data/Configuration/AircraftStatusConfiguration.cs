
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class AircraftStatusConfiguration : IEntityTypeConfiguration<AircraftStatusModel>
    {
        public void Configure(EntityTypeBuilder<AircraftStatusModel> builder)
        {
            builder.HasMany(c => c.Aircrafts)
                .WithOne(c => c.AircraftStatus)
                .IsRequired(false)
                .HasForeignKey(c => c.AircraftStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Property(c => c.Name).IsUnicode(false).HasMaxLength(30);
        }
    }
}