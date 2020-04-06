using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BazaAwionika.Web.Locales
{
    public abstract class MainLocales
    {
        public string Id = "Id";
        public string UserId = "Nr. użytkownika";
        public string UserName = "Nazwa użytkownika";
        public string AircraftId = "Nr. samolotu";
        public string AircraftName = "Nr. samolotu";
        public string SettingsId = "Nr. ustawień";
        public string SettingsName = "Nazwa ustawień";
        public string FlightHours = "Nalot całkowity";
        public string DateExpiration = "Nast. sprawdzenie";
        public string DateExecution = "Wykonanie";
        public string DaysRemaining = "Pozostało dni";
        public string FlightHoursExecution = "Wykonano";
        public string FlightHoursExpiration = "Nast. sprawdzenie";
        public string FlightHoursRemaining = "Pozostało";
        public string FlightHoursAircraftInstallation = "Nalot samolotu przy zabudowie";
        public string FlightHoursBrushes = "Nalot szczotek przy zabudowie na samolot";
        public string FlightHoursBearings = "Nalot łożysk przy zabudowie na samolot";
        public string FlightHoursOverhaul = "Nalot agregatu przy zabudowie na samolot";
        public string FlightHoursBrushesRemaining = "Pozostałość nalotu szczotek";
        public string FlightHoursBearingsRemaining = "Pozostałość nalotu łożysk";
        public string FlightHoursOverhaulRemaining = "Pozostałość nalotu do remontu";
        public string FlightHoursBrushesExpiration = "Następne sprawdzenie szczotek";
        public string FlightHoursBearingsExpiration = "Następne sprawdzenie łożysk";
        public string FlightHoursOverhaulExpiration = "Następny remont";
        public string SettingsDaysError = "Pozostałośc dni do ostrzeżenie 3";
        public string SettingsDaysWarning = "Pozostałośc dni do ostrzeżenie 2";
        public string SettingsDaysCaution = "Pozostałośc dni do ostrzeżenie 1";
        public string FlightHoursError = "Pozostałość nalotu do ostrzeżenia 3";
        public string FlightHoursWarning = "Pozostałość nalotu do ostrzeżenia 2";
        public string FlightHoursCaution = "Pozostałość nalotu do ostrzeżenia 1";
        public string ServicePeriodFlightHours = "Resurs nalot";
        public string ServicePeriodTimeMonths = "Resurs w miesiącach";
        public string IsInstalled = "Zamontowany na samolocie?";
        public string IsActual = "Wpis aktualny?";
        public string AdditionalInfo = "Dodatowe Informacje";
        public string SerialNumber = "Numer seryjny";
        public string TailNumber = "Numer ogonowy";
        public string DateAdd = "Data modyfikacji";
        public string Performer = "Wykonujący";
        public string DatabaseName = "Nazwa bazy danych";
        public string Name = "Nazwa";
        public string DeleteConfirmation = "Czy napewno chcesz usunąc ten wpis?";
        public string BackList = "Powrót do listy";
        public string BtnDelete = "Usuń wpis";
        public string BtnAdd = "Utwórz nowy";
        public string BtnEdit = "Edytuj";
        public string NotFoundAircraft = "Nie znaleziono samolotu o danym numerze";


    }
}