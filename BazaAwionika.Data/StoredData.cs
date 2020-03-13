using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using BazaAwionika.Model;

namespace BazaAwionika.Data
{
    public class StoredData : DropCreateDatabaseIfModelChanges<MaintenanceEntities>
    {
        protected override void Seed(MaintenanceEntities context)
        {
            GetAircrafts().ForEach(c => context.Aircraft.Add(c));
            GetAircraftStatuses().ForEach(c => context.AircraftStatuses.Add(c));
            GetSettings().ForEach(c => context.Settings.Add(c));
            context.Commit();
            GetAlternators().ForEach(c => context.Alternators.Add(c));
            GetGenerators().ForEach(c => context.Generators.Add(c));
            GetBatteries().ForEach(c => context.Batteries.Add(c));
            GetEmergencyLightsBatteries().ForEach(c => context.EmergencyLightsBatteries.Add(c));

            context.Commit();
        }

        private static List<AircraftStatusModel> GetAircraftStatuses()
        {
            return new List<AircraftStatusModel>
            {
                new AircraftStatusModel
                {
                    Name = "Sprawny",
                },
                new AircraftStatusModel
                {
                    Name = "Sprawny z ograniczeniami"
                },
                new AircraftStatusModel
                {
                    Name = "Niesprawny"
                },
                new AircraftStatusModel
                {
                    Name = "Prace Hangar"
                },
                new AircraftStatusModel
                {
                    Name = "Prace Airbus"
                },
            };
        }

        private static List<SettingsModel> GetSettings()
        {
            return new List<SettingsModel>
            {
                new SettingsModel
                {
                    SettingsName="Ustawienia Alternatora",
                    FlightHoursCaution=60,
                    FlightHoursWarning=30,
                    FlightHoursError=10,
                    ServicePeriodFlightHours=2000
                },
                new SettingsModel
                {
                    SettingsName="Ustawienia Generatora",
                    FlightHoursCaution=60,
                    FlightHoursWarning=30,
                    FlightHoursError=10,
                    ServicePeriodFlightHours=600
                },
                new SettingsModel
                {
                    SettingsName="Ustawienia Baterii",
                    FlightHoursCaution=60,
                    FlightHoursWarning=30,
                    FlightHoursError=10,
                    ServicePeriodFlightHours=300,
                    ServicePeriodTimeMonths=8,
                    DaysCaution=12,
                    DaysWarning=6,
                    DaysError=2                  
                },
                new SettingsModel
                {
                    SettingsName="Ustawienia Baterii emergency",
                    ServicePeriodTimeMonths=8,
                    DaysCaution=12,
                    DaysWarning=6,
                    DaysError=2
                },

            };
        }

        private static List<AircraftModel> GetAircrafts()
        {
            return new List<AircraftModel>
            {
                new AircraftModel
                {
                    TailNumber="011",
                    SerialNumber="009",
                    FlightHours=5173,
                    DateAdd=DateTime.Parse("2019-06-04")
                },
                new AircraftModel
                {
                    TailNumber="012",
                    SerialNumber="010",
                    FlightHours=4973,
                    DateAdd=DateTime.Parse("2019-06-04")
                },
                 new AircraftModel
                {
                    TailNumber="013",
                    SerialNumber="013",
                    FlightHours=4473,
                    DateAdd=DateTime.Parse("2019-06-04")
                },
                new AircraftModel
                {
                    TailNumber="014",
                    SerialNumber="014",
                    FlightHours=4473,
                    DateAdd=DateTime.Parse("2019-06-04")
                },
                new AircraftModel
                {
                    TailNumber="015",
                    SerialNumber="015",
                    FlightHours=4473,
                    DateAdd=DateTime.Parse("2019-06-04")
                },
                new AircraftModel
                {
                    TailNumber="016",
                    SerialNumber="018",
                    FlightHours=4783,
                    DateAdd=DateTime.Parse("2019-06-04")
                },
                 new AircraftModel
                {
                    TailNumber="017",
                    SerialNumber="019",
                    FlightHours=4882,
                    DateAdd=DateTime.Parse("2019-06-04")
                },
                 new AircraftModel
                {
                    TailNumber="018",
                    SerialNumber="020",
                    FlightHours=4473,
                    DateAdd=DateTime.Parse("2019-06-04")
                },
            };
        }

        private static List<AlternatorModel> GetAlternators()
        {
            return new List<AlternatorModel>
            {
                new AlternatorModel
                {
                    SerialNumber = "Y30002",
                    IsActual=true,
                    IsInstalled=true,
                    FlightHoursAircraftInstallation=4000,
                    FlightHoursOverhaul=0,
                    AircraftId=7,
                    SettingsId=1
                },
                new AlternatorModel
                {
                    SerialNumber = "P2003/CA",
                    IsActual=true,
                    IsInstalled=true,
                    FlightHoursAircraftInstallation=3900,
                    FlightHoursOverhaul=15,
                    AircraftId=7,
                    SettingsId=1
                },
                new AlternatorModel
                {
                    SerialNumber = "P2016/CA",
                    IsActual=true,
                    IsInstalled=true,
                    FlightHoursAircraftInstallation=3900,
                    FlightHoursOverhaul=15,
                    AircraftId=6,
                    SettingsId=1
                },
                new AlternatorModel
                {
                    SerialNumber = "Y20005",
                    IsActual=true,
                    IsInstalled=true,
                    FlightHoursAircraftInstallation=3900,
                    FlightHoursOverhaul=15,
                    AircraftId=6,
                    SettingsId=1
                },

            };
        }

        private static List<GeneratorModel> GetGenerators()
        {
            return new List<GeneratorModel>
            {
                new GeneratorModel
                {
                    SerialNumber="2005",
                    AircraftId=7,
                    SettingsId=2,
                    IsActual=true,
                    IsInstalled=true,
                    FlightHoursAircraftInstallation= 3800,
                    FlightHoursBrushes=3800,
                    FlightHoursBearing=3800,
                    FlightHoursOverhaul=3300

                },
                new GeneratorModel
                {
                    SerialNumber="1012",
                    AircraftId=7,
                    SettingsId=2,
                    IsActual=true,
                    IsInstalled=true,
                    FlightHoursAircraftInstallation= 3800,
                    FlightHoursBrushes=3800,
                    FlightHoursBearing=3800,
                    FlightHoursOverhaul=3300
                },
                new GeneratorModel
                {
                    SerialNumber="1002",
                    AircraftId=6,
                    SettingsId=2,
                    IsActual=true,
                    IsInstalled=true,
                    FlightHoursAircraftInstallation= 3800,
                   FlightHoursBrushes=3600,
                    FlightHoursBearing=3100,
                    FlightHoursOverhaul=2700
                },
                new GeneratorModel
                {
                    SerialNumber="1018",
                    AircraftId=6,
                    SettingsId=2,
                    IsActual=true,
                    IsInstalled=true,
                    FlightHoursAircraftInstallation= 3800,
                    FlightHoursBrushes=3600,
                    FlightHoursBearing=3100,
                    FlightHoursOverhaul=2700
                }
            };
        }

        private static List<BatteryModel> GetBatteries()
        {
            return new List<BatteryModel>
            {
                new BatteryModel
                {
                    SerialNumber="B2014",
                    AircraftId=7,
                    SettingsId=3,
                    IsActual=true,
                    IsInstalled=true,
                    FlightHoursExecution=0,
                    FlightHoursAircraftInstallation=4600,
                    DateExecution=DateTime.Now.AddMonths(-3).AddDays(-8)


                },
                new BatteryModel
                {
                    SerialNumber="B2012",
                    AircraftId=7,
                    SettingsId=3,
                    IsActual=true,
                    IsInstalled=true,
                    FlightHoursExecution=0,
                    FlightHoursAircraftInstallation=4600,
                    DateExecution=DateTime.Now.AddMonths(-3).AddDays(-8)

                },
                new BatteryModel
                {
                    SerialNumber="B1014-ab",
                    AircraftId=7,
                    SettingsId=3,
                    IsActual=true,
                    IsInstalled=true,
                    FlightHoursExecution=0,
                    FlightHoursAircraftInstallation=4600,
                    DateExecution=DateTime.Now.AddMonths(-4).AddDays(-15)

                },
                new BatteryModel
                {
                    SerialNumber="B1011-ab",
                    AircraftId=7,
                    SettingsId=3,
                    IsActual=true,
                    IsInstalled=true,
                    FlightHoursExecution=0,
                    FlightHoursAircraftInstallation=4600,
                    DateExecution=DateTime.Now.AddMonths(-4).AddDays(-15)

                }

            };
        }

        private static List<EmergencyLightsBatteryModel> GetEmergencyLightsBatteries()
        {
            return new List<EmergencyLightsBatteryModel>
            {
                new EmergencyLightsBatteryModel
                {
                    SerialNumber="1144",
                    AircraftId=7,
                    SettingsId=4,
                    IsActual=true,
                    IsInstalled=true,
                    DateExecution=DateTime.Now.AddMonths(-4).AddDays(-2)
                },
                new EmergencyLightsBatteryModel
                {
                    SerialNumber="1156",
                    AircraftId=7,
                    SettingsId=4,
                    IsActual=true,
                    IsInstalled=true,
                    DateExecution=DateTime.Now.AddMonths(-4).AddDays(-2)
                 },      
                new EmergencyLightsBatteryModel
                {
                    SerialNumber="1065",
                    AircraftId=7,
                    SettingsId=4,
                    IsActual=true,
                    IsInstalled=true,
                    DateExecution=DateTime.Now.AddMonths(-4).AddDays(-2)
                },
                new EmergencyLightsBatteryModel
                {
                    SerialNumber="2250",
                    AircraftId=7,
                    SettingsId=4,
                    IsActual=true,
                    IsInstalled=true,
                    DateExecution=DateTime.Now.AddMonths(-4).AddDays(-2)
                },
                new EmergencyLightsBatteryModel
                {
                    SerialNumber="1142",
                    AircraftId=6,
                    SettingsId=4,
                    IsActual=true,
                    IsInstalled=true,
                    DateExecution=DateTime.Now.AddMonths(-3).AddDays(-12)
                },
                new EmergencyLightsBatteryModel
                {
                    SerialNumber="1145",
                    AircraftId=6,
                    SettingsId=4,
                    IsActual=true,
                    IsInstalled=true,
                    DateExecution=DateTime.Now.AddMonths(-3).AddDays(-12)
                },
                new EmergencyLightsBatteryModel
                {
                    SerialNumber="1179",
                    AircraftId=6,
                    SettingsId=4,
                    IsActual=true,
                    IsInstalled=true,
                    DateExecution=DateTime.Now.AddMonths(-3).AddDays(-12)
                },
                new EmergencyLightsBatteryModel
                {
                    SerialNumber="1182",
                    AircraftId=6,
                    SettingsId=4,
                    IsActual=true,
                    IsInstalled=true,
                    DateExecution=DateTime.Now.AddMonths(-3).AddDays(-12)
                }
            };
        }
    }
}