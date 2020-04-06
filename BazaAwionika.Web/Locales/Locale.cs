using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BazaAwionika.Web.Locales;

namespace BazaAwionika.Web
{
    public static class Locale
    {
        private static MainLocales strings;
        public static MainLocales Strings
        {
            get
            {
                if (strings == null)
                    return strings = new PolishLocales();
                else
                    return strings;
            }
        }
    }
}