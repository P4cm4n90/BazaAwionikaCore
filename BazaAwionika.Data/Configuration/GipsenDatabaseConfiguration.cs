
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class GipsenDatabaseConfiguration : IEntityTypeConfiguration<GipsenDatabaseModel>
    {


        public void Configure(EntityTypeBuilder<GipsenDatabaseModel> builder)
        {
            builder.Property(c => c.DatabaseName).IsUnicode(false).HasMaxLength(30);
        }
    }
}
/*
namespace BazaAwionika.Data.Configuration
{
    class GipsenDatabaseConfiguration : EntityTypeConfiguration<GipsenDatabaseModel>
    {
        public GipsenDatabaseConfiguration()
        {
            Property(c => c.DatabaseName).IsUnicode(false);
            HasMany(c => c.Countries).WithRequired(c => c.GipsenDatabase).HasForeignKey(c => c.GipsenDatabaseId).WillCascadeOnDelete(false);
        }
    }
}*/