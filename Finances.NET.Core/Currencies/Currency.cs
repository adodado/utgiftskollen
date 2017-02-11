#region

using System.Collections.Generic;
using System.Globalization;

#endregion



namespace Finances.NET.Core.Currencies
{
    /// <summary>
    ///     Class Currencies.
    /// </summary>
    public class Currency
    {
        #region Public properties

        /// <summary>
        ///     All
        /// </summary>
        public static List<CurrencyObject> All;

        /// <summary>
        ///     The base unit
        /// </summary>
        public static CurrencyObject BaseUnit;

        /// <summary>
        ///     The euro
        /// </summary>
        public static CurrencyObject Euro;

        /// <summary>
        ///     The svensk_ krona
        /// </summary>
        public static CurrencyObject Svensk_Krona;

        /// <summary>
        ///     The u s_ dollar
        /// </summary>
        public static CurrencyObject US_Dollar;

        /// <summary>
        ///     A u_ dollar
        /// </summary>
        public static CurrencyObject AU_Dollar;

        /// <summary>
        ///     The c a_ dollar
        /// </summary>
        public static CurrencyObject CA_Dollar;

        /// <summary>
        ///     The ch i_ yuan
        /// </summary>
        public static CurrencyObject CHI_Yuan;

        /// <summary>
        ///     The ja p_ yen
        /// </summary>
        public static CurrencyObject JAP_Yen;

        /// <summary>
        ///     The sw i_ franc
        /// </summary>
        public static CurrencyObject SWI_Franc;

        #endregion

        #region Public methods

        /// <summary>
        ///     Initialises this Finanser.NET.Core.Currencies.
        /// </summary>
        public static void Init(CultureInfo language)
        {
            switch (language.ToString())
            {
                case "en-US":

                    Svensk_Krona = new CurrencyObject("Swedish crowns", "kr", "SEK");
                    Euro = new CurrencyObject("Euro", "€", "EUR");
                    US_Dollar = new CurrencyObject("American dollar", "$", "USD");
                    AU_Dollar = new CurrencyObject("Australian dollar", "$", "AUD");
                    CA_Dollar = new CurrencyObject("Canadian dollar", "$", "CAD");
                    CHI_Yuan = new CurrencyObject("Chinese Yuan", "¥", "CNY");
                    JAP_Yen = new CurrencyObject("Japanese Yen", "¥", "JPY");
                    SWI_Franc = new CurrencyObject("Swiss franc", "Fr", "CHF");

                    break;

                default: //case "sv-SE"

                    Svensk_Krona = new CurrencyObject("Svenska kronor", "kr", "SEK");
                    Euro = new CurrencyObject("Euro", "€", "EUR");
                    US_Dollar = new CurrencyObject("Amerikanska dollar", "$", "USD");
                    AU_Dollar = new CurrencyObject("Australiensiska dollar", "$", "AUD");
                    CA_Dollar = new CurrencyObject("Kanadensiska dollar", "$", "CAD");
                    CHI_Yuan = new CurrencyObject("Kinesiska yuan", "¥", "CNY");
                    JAP_Yen = new CurrencyObject("Japanska yen", "¥", "JPY");
                    SWI_Franc = new CurrencyObject("Schweiziska franc", "Fr", "CHF");

                    break;
            }

            BaseUnit = new CurrencyObject("Base unit", "BU", "BU", 1);


            All = new List<CurrencyObject>
            {
                Svensk_Krona,
                Euro,
                US_Dollar,
                AU_Dollar,
                CA_Dollar,
                CHI_Yuan,
                JAP_Yen,
                SWI_Franc
            };
        }

        #endregion
    }
}