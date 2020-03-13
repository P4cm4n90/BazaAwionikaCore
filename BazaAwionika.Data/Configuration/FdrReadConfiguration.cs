
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class FdrReadConfiguration : IEntityTypeConfiguration<FdrReadModel>
    {


        public void Configure(EntityTypeBuilder<FdrReadModel> builder)
        {
            builder.Property(c => c.AdditionalInformation).IsUnicode(false).HasMaxLength(100);
        }
    }
}
