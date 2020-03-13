
using System;
using System.Linq;
using System.Text;
using BazaAwionika.Model;
using BazaAwionika.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BazaAwionika.Data.Configuration
{
    class AircraftConfiguration : IEntityTypeConfiguration<AircraftModel>
    {
        public void Configure(EntityTypeBuilder<AircraftModel> builder)
        {
            builder.Property(c => c.TailNumber).IsUnicode(false).HasMaxLength(6).IsRequired();
            builder.Property(c => c.FlightHours).IsRequired();
            builder.Property(c => c.SerialNumber).IsUnicode(false).HasMaxLength(6);
            builder.Property(c => c.AdditionalInfo).IsUnicode(false).HasMaxLength(100);
            builder.HasMany(c => c.Alternators).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull); 
            builder.HasMany(c => c.Batteries).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.EgpwsDatabase).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.EltFunctionalTest).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.EltOperationalTest).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.EmergencyLightsBatteries).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.FdrRead).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.Generators).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.GipsenDatabase).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.GpsBatteries).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.GpsPCodes).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.MagneticCompassDeviation).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.OxygenCylinderMain).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.OxygenCylinderPortable).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.OxygenExchange).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.Pbe).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.TestEfis).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.TestDcf).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.TestTru).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.UlbCvr).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.UlbFdr).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.UlbTest).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.AircraftBiuletins).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.AircraftMaintenances).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasMany(c => c.Flights).WithOne(c => c.Aircraft).HasForeignKey(c => c.AircraftId).IsRequired(true).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
    /*


    
     */
}