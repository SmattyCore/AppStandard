﻿using System;
using System.Threading;
using AppStandard.Interfaces;
using Xamarin.Forms;

[assembly:Dependency(typeof(AppStandard.Android.Locale_Android))]
namespace AppStandard.Android
{
    public class Locale_Android : ILocale
    {
        public void SetLocale ()
        {

            var androidLocale = Java.Util.Locale.Default; // user's preferred locale
            var netLocale = androidLocale.ToString().Replace ("_", "-"); 
            var ci = new System.Globalization.CultureInfo (netLocale);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;
        }

        /// <remarks>
        /// Not sure if we can cache this info rather than querying every time
        /// </remarks>
        public string GetCurrent() 
        {
            var androidLocale = Java.Util.Locale.Default; // user's preferred locale

            // en, es, ja
            var netLanguage = androidLocale.Language.Replace ("_", "-"); 
            // en-US, es-ES, ja-JP
            var netLocale = androidLocale.ToString().Replace ("_", "-"); 

            #region Debugging output
            Console.WriteLine ("android:  " + androidLocale.ToString());
            Console.WriteLine ("netlang:  " + netLanguage);
            Console.WriteLine ("netlocale:" + netLocale);

            var ci = new System.Globalization.CultureInfo (netLocale);
            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            Console.WriteLine ("thread:  "+Thread.CurrentThread.CurrentCulture);
            Console.WriteLine ("threadui:"+Thread.CurrentThread.CurrentUICulture);
            #endregion

            return netLocale;
        }
    }
}

