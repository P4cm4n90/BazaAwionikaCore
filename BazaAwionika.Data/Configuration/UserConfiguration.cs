
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
            builder.HasMany(c => c.Alternators).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.Batteries).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.EgpwsDatabase).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.EltFunctionalTest).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.EltOperationalTest).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.EmergencyLightsBatteries).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.FdrRead).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.Generators).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.GipsenDatabase).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.GpsBatteries).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.GpsPCodes).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.MagneticCompassDeviation).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.OxygenCylinderMain).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.OxygenCylinderPortable).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.OxygenExchange).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.Pbe).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.TestEfis).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.TestDcf).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.TestTru).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.UlbCvr).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.UlbFdr).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.UlbTest).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.AircraftBiuletins).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.AircraftMaintenances).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.AircraftStatuses).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.Flights).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.Countries).WithOne(c => c.User).HasForeignKey(c => c.UserId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
