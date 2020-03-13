
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class AircraftBiuletinConfiguration : IEntityTypeConfiguration<AircraftBiuletinModel>
    {

        public void Configure(EntityTypeBuilder<AircraftBiuletinModel> builder)
        {
            builder.Property(c => c.Name).IsUnicode(false).HasMaxLength(100).IsRequired();
            builder.Property(c => c.AdditionalInformation).IsUnicode(false).HasMaxLength(100);
        }
    }
}