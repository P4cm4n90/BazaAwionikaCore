
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class EgpwsDatabaseConfiguration : IEntityTypeConfiguration<EgpwsDatabaseModel>
    {


        public void Configure(EntityTypeBuilder<EgpwsDatabaseModel> builder)
        {
            builder.Property(c => c.DatabaseName).IsUnicode(false).HasMaxLength(30);
        }
    }
}
