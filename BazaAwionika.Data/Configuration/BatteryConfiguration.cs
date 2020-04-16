
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class BatteryConfiguration : IEntityTypeConfiguration<BatteryModel>
    {


        public void Configure(EntityTypeBuilder<BatteryModel> builder)
        {
            builder.Property(c => c.AircraftId).IsRequired(false);
            builder.Property(c => c.SerialNumber).IsUnicode(false).HasMaxLength(30);
            builder.Property(c => c.AdditionalInformation).IsUnicode(false).HasMaxLength(100);

        }        
    }
}
