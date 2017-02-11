#region

using System.Globalization;
using System.IO;
using System.Net;
using System.Xml;

#endregion

namespace Finances.NET.Core.Currencies
{
    /// <summary>
    ///     Class CurrencyExtensions.
    /// </summary>
    public static class CurrencyExtensions
    {
        #region Public methods

        /// <summary>
        ///     Gets the exchange rates of the specified currencies
        /// </summary>
        /// <param name="FromCurrency">First currency</param>
        /// <param name="ToCurrency">Second currency</param>
        /// <returns>The exchange rate from the first currency to the second</returns>
        public static double ExchangeRate(CurrencyObject FromCurrency, CurrencyObject ToCurrency)
        {
            var webrequest =
                WebRequest.Create("http://www.webservicex.net/CurrencyConvertor.asmx/ConversionRate?FromCurrency=" +
                                  FromCurrency.ShortName + "&ToCurrency=" + ToCurrency.ShortName);
            var response = (HttpWebResponse) webrequest.GetResponse();
            var dataStream = response.GetResponseStream();
            var reader = new StreamReader(dataStream);
            var responseFromServer = reader.ReadToEnd();
            var doc = new XmlDocument();
            doc.LoadXml(responseFromServer);
            var value = double.Parse(doc.InnerText, CultureInfo.InvariantCulture);
            reader.Close();

            if (dataStream != null)
                dataStream.Close();

            response.Close();
            return value;
        }

        /// <summary>
        ///     Convert an amount from a currency to another
        /// </summary>
        /// <param name="b">From this currency</param>
        /// <param name="d">To this currency</param>
        /// <param name="amount">Amount</param>
        /// <returns>Amount in the destination currency</returns>
        public static decimal FromCurrency(this CurrencyObject b, CurrencyObject d, double amount)
        {
            var rt = ExchangeRate(d, b);
            return (decimal) (amount*rt);
        }

        /// <summary>
        ///     Currency converter
        /// </summary>
        /// <param name="b">From this currency</param>
        /// <param name="d">To this currency</param>
        /// <param name="amount">Amount</param>
        /// <returns>Amount in the destination currency</returns>
        public static decimal ToCurrency(this CurrencyObject b, CurrencyObject d, double amount)
        {
            var rt = ExchangeRate(b, d);
            return (decimal) (amount*rt);
        }

        #endregion
    }
}