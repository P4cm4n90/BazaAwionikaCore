
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class FlightConfiguration : IEntityTypeConfiguration<FlightModel>
    {


        public void Configure(EntityTypeBuilder<FlightModel> builder)
        {
            builder.Property(c => c.AdditionalInfo).IsUnicode(false).HasMaxLength(100);
            builder.Property(c => c.Destination).IsUnicode(false).HasMaxLength(30);
 
        }
    }
}
