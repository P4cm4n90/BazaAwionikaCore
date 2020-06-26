using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Linq;
using BazaAwionika.Model;
using BazaAwionika.Data.Configuration;
using System.Configuration;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace BazaAwionika.Data
{
    public class MaintenanceEntities : DbContext
    {
        private readonly IConfiguration configuration;
        // Your context has been configured to use a 'MaintenanceEntities' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'BazaAwionika.MaintenanceEntities' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MaintenanceEntities' 
        // connection string in the application configuration file.
        public MaintenanceEntities(IConfiguration configuration) : 
            base()
        {
            this.configuration = configuration;
            RelationalDatabaseCreator databaseCreator =
                 (RelationalDatabaseCreator)Database.GetService<IDatabaseCreator>();
            if (!databaseCreator.Exists())
            {
                databaseCreator.Create();
                databaseCreator.CreateTables();
                GenerateData.Generate(this);
            }

        }
     /*   public MaintenanceEntities()
            : base(GetDbContextOptions())
        {
            
            RelationalDatabaseCreator databaseCreator =
    (RelationalDatabaseCreator)Database.GetService<IDatabaseCreator>();
            if (!databaseCreator.Exists())
            {
                databaseCreator.Create();
                databaseCreator.CreateTables();
                GenerateData.Generate(this);
            }
           
        }*/

        public virtual void Commit()
        {
            base.SaveChanges();
        }


        public virtual DbSet<AircraftModel> Aircraft { get; set; }
        public virtual DbSet<AircraftBiuletinModel> AircraftBiuletins { get; set; }
        public virtual DbSet<AircraftMaintenanceModel> AircraftMaintenances { get; set; }
        public virtual DbSet<AircraftStatusModel> AircraftStatuses { get; set; }
        public virtual DbSet<AlternatorModel> Alternators { get; set; }
        public virtual DbSet<BatteryModel> Batteries { get; set; }
        public virtual DbSet<CountryModel> Countries { get; set; }
        public virtual DbSet<EgpwsDatabaseModel> EgpwsDatabase { get; set; }
        public virtual DbSet<EltFunctionalTestModel> EltFunctionalTest { get; set; }
        public virtual DbSet<EltOperationalTestModel> EltOperationalTest { get; set; }
        public virtual DbSet<EmergencyLightsBatteryModel> EmergencyLightsBatteries { get; set; }
        public virtual DbSet<FlightModel> Flights { get; set; }
        public virtual DbSet<FdrReadModel> FdrRead { get; set; }
        public virtual DbSet<GeneratorModel> Generators { get; set; }
        public virtual DbSet<GipsenDatabaseModel> GipsenDatabase { get; set; }
        public virtual DbSet<GpsBatteriesModel> GpsBatteries { get; set; }
        public virtual DbSet<GpsPCodesModel> GpsPCodes { get; set; }
        public virtual DbSet<MagneticCompassDeviationModel> MagneticCompassDeviation { get; set; }
        public virtual DbSet<OxygenCylinderMainModel> OxygenCylinderMain { get; set; }
        public virtual DbSet<OxygenCylinderPortableModel> OxygenCylinderPortable { get; set; }
        public virtual DbSet<OxygenExchangeModel> OxygenExchange { get; set; }
        public virtual DbSet<PbeModel> Pbe { get; set; }
        public virtual DbSet<SettingsModel> Settings { get; set; }
        public virtual DbSet<TestDcfModel> TestDcf { get; set; }
        public virtual DbSet<TestEfisModel> TestEfis { get; set; }
        public virtual DbSet<TestTruModel> TestTru { get; set; }
        public virtual DbSet<UlbCvrModel> UlbCvr { get; set; }
        public virtual DbSet<UlbFdrModel> UlbFdr { get; set; }
        public virtual DbSet<UlbTestModel> UlbTest { get; set; }
        public virtual DbSet<UserModel> Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1062:Waliduj argumenty metod publicznych", Justification = "<Oczekuj¹ce>")]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _ = modelBuilder.ApplyConfiguration(new AircraftConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new SettingsConfiguration());
            modelBuilder.ApplyConfiguration(new AircraftStatusConfiguration());
            modelBuilder.ApplyConfiguration(new AircraftMaintenanceConfiguration());
            modelBuilder.ApplyConfiguration(new AircraftBiuletinConfiguration());
            modelBuilder.ApplyConfiguration(new AircraftConfiguration());
            modelBuilder.ApplyConfiguration(new AlternatorConfiguration());
            modelBuilder.ApplyConfiguration(new BatteryConfiguration());
            modelBuilder.ApplyConfiguration(new CountryConfiguration());
            modelBuilder.ApplyConfiguration(new EgpwsDatabaseConfiguration());
            modelBuilder.ApplyConfiguration(new EmergencyLightsBatteryConfiguration());
            modelBuilder.ApplyConfiguration(new FdrReadConfiguration());
            modelBuilder.ApplyConfiguration(new FlightConfiguration());
            modelBuilder.ApplyConfiguration(new GeneratorConfiguration());
            modelBuilder.ApplyConfiguration(new OxygenCylinderMainConfiguration());
            modelBuilder.ApplyConfiguration(new OxygenCylinderPortableConfiguration());
            modelBuilder.ApplyConfiguration(new OxygenExchangeConfiguration());
            modelBuilder.ApplyConfiguration(new MagneticCompassDeviationConfiguration());
            modelBuilder.ApplyConfiguration(new PbeConfiguration());
            modelBuilder.ApplyConfiguration(new SettingsConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            //   modelBuilder.Entity<AircraftModel>().has
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            var conntectionString = configuration.GetConnectionString("MaintenanceEntities");
            dbContextOptionsBuilder.UseLazyLoadingProxies();
            dbContextOptionsBuilder.UseSqlServer(conntectionString);
        }

        



        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string FirstName { get; set; }
    //}
}