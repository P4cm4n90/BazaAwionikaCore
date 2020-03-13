
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class CountryConfiguration : IEntityTypeConfiguration<CountryModel>
    {


        public void Configure(EntityTypeBuilder<CountryModel> builder)
        {
            builder.Property(c => c.Name).IsUnicode(false).HasMaxLength(30);
        }
    }
}
