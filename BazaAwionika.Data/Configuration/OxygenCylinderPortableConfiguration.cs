
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class OxygenCylinderPortableConfiguration : IEntityTypeConfiguration<OxygenCylinderPortableModel>
    {


        public void Configure(EntityTypeBuilder<OxygenCylinderPortableModel> builder)
        {
            builder.Property(c => c.SerialNumber).IsUnicode(false).HasMaxLength(30);
            builder.Property(c => c.AdditionalInformation).IsUnicode(false).HasMaxLength(100);
        }
    }
}