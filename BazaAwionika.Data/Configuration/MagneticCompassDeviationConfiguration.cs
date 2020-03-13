
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class MagneticCompassDeviationConfiguration : IEntityTypeConfiguration<MagneticCompassDeviationModel>
    {


        public void Configure(EntityTypeBuilder<MagneticCompassDeviationModel> builder)
        {
            builder.Property(c => c.Performer).IsUnicode(false).HasMaxLength(30);
        }
    }
}