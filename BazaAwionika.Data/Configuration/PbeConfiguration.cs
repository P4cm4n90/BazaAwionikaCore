
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class PbeConfiguration : IEntityTypeConfiguration<PbeModel>
    {


        public void Configure(EntityTypeBuilder<PbeModel> builder)
        {
            builder.Property(c => c.SerialNumber).IsUnicode(false).HasMaxLength(30);

        }
    }
}