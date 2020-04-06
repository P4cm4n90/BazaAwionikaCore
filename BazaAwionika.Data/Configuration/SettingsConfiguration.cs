
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class SettingsConfiguration : IEntityTypeConfiguration<SettingsModel>
    {


        public void Configure(EntityTypeBuilder<SettingsModel> builder)
        {
            builder.Property(c => c.SettingsName).IsUnicode(false).HasMaxLength(30).IsRequired();
            builder.HasMany(c => c.Alternators).WithOne(c => c.Settings).HasForeignKey(c => c.SettingsId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.Batteries).WithOne(c => c.Settings).HasForeignKey(c => c.SettingsId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.EgpwsDatabase).WithOne(c => c.Settings).HasForeignKey(c => c.SettingsId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.EltFunctionalTest).WithOne(c => c.Settings).HasForeignKey(c => c.SettingsId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.EltOperationalTest).WithOne(c => c.Settings).HasForeignKey(c => c.SettingsId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.EmergencyLightsBatteries).WithOne(c => c.Settings).HasForeignKey(c => c.SettingsId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.FdrRead).WithOne(c => c.Settings).HasForeignKey(c => c.SettingsId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.Generators).WithOne(c => c.Settings).HasForeignKey(c => c.SettingsId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.GipsenDatabase).WithOne(c => c.Settings).HasForeignKey(c => c.SettingsId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.GpsBatteries).WithOne(c => c.Settings).HasForeignKey(c => c.SettingsId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.GpsPCodes).WithOne(c => c.Settings).HasForeignKey(c => c.SettingsId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.MagneticCompassDeviation).WithOne(c => c.Settings).HasForeignKey(c => c.SettingsId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.OxygenCylinderMain).WithOne(c => c.Settings).HasForeignKey(c => c.SettingsId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.OxygenCylinderPortable).WithOne(c => c.Settings).HasForeignKey(c => c.SettingsId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.OxygenExchange).WithOne(c => c.Settings).HasForeignKey(c => c.SettingsId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.Pbe).WithOne(c => c.Settings).HasForeignKey(c => c.SettingsId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.TestEfis).WithOne(c => c.Settings).HasForeignKey(c => c.SettingsId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.TestDcf).WithOne(c => c.Settings).HasForeignKey(c => c.SettingsId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.TestTru).WithOne(c => c.Settings).HasForeignKey(c => c.SettingsId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.UlbCvr).WithOne(c => c.Settings).HasForeignKey(c => c.SettingsId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.UlbFdr).WithOne(c => c.Settings).HasForeignKey(c => c.SettingsId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.UlbTest).WithOne(c => c.Settings).HasForeignKey(c => c.SettingsId).IsRequired(false).OnDelete(DeleteBehavior.ClientSetNull);

        }

    }
}