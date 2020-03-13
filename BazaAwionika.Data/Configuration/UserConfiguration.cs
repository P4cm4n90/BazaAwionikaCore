
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {


        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.Property(c => c.FirstName).IsUnicode(false);
            builder.Property(c => c.LastName).IsUnicode(false);
            builder.Property(c => c.Name).IsUnicode(false).IsRequired();
            builder.HasIndex(c => c.Name).IsUnique();
        }
    }
}
