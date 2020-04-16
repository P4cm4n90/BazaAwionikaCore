
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class GeneratorConfiguration : IEntityTypeConfiguration<GeneratorModel>
    {


        public void Configure(EntityTypeBuilder<GeneratorModel> builder)
        {
            builder.Property(c => c.AircraftId).IsRequired(false);
            builder.Property(c => c.SerialNumber).IsUnicode(false).HasMaxLength(30);
            builder.Property(c => c.AdditionalInformation).IsUnicode(false).HasMaxLength(100);
        }
    }
}
