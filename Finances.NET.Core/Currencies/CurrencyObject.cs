#region

using System.Linq;

#endregion

namespace Finances.NET.Core.Currencies
{
    /// <summary>
    ///     Class CurrencyObject.
    /// </summary>
    public class CurrencyObject
    {
        #region Fields

        /// <summary>
        ///     Long name of the currency
        /// </summary>
        private readonly string _name = "";

        /// <summary>
        ///     (for debugging purposes) Exchange rate from this currency to Euro
        /// </summary>
        private readonly double _rapp = -1;

        /// <summary>
        ///     Short name (example : EUR, USD)
        /// </summary>
        private readonly string _sname = "";

        /// <summary>
        ///     Symbol of the currency (example : kr)
        /// </summary>
        private readonly string _symbol = "";

        #endregion

        #region Constructors

        /// <summary>
        ///     Default constructor
        /// </summary>
        public CurrencyObject()
        {
        }

        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="n">Name</param>
        /// <param name="s">Symbol</param>
        /// <param name="abb">Short name</param>
        /// <param name="rapp">Exchange rate to Euro</param>
        public CurrencyObject(string n, string s, string abb, double rapp = -1)
        {
            _symbol = s;
            _name = n;
            if (rapp != -1)
                _rapp = rapp;
            _sname = abb;
        }

        #endregion

        #region Public properties

        /// <summary>
        ///     Gets the symbol.
        /// </summary>
        /// <value>The symbol.</value>
        public string Symbol
        {
            get { return _symbol; }
        }

        /// <summary>
        ///     Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get { return _name + " (" + _sname + ")"; }
        }

        /// <summary>
        ///     Gets the rapp base.
        /// </summary>
        /// <value>The rapp base.</value>
        public double RappBase
        {
            get
            {
                if (_rapp == -1)
                    return CurrencyExtensions.ExchangeRate(Currency.Euro, this);
                return _rapp;
            }
        }

        /// <summary>
        ///     Gets the short name.
        /// </summary>
        /// <value>The short name.</value>
        public string ShortName
        {
            get { return _sname; }
        }

        #endregion

        #region Operators

        /// <summary>
        ///     Implements the ==.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator ==(CurrencyObject a, CurrencyObject b)
        {
            if (ReferenceEquals(a, b))
                return true;

            if (((object) a == null) || ((object) b == null))
                return false;

            return (a.Name == b.Name) &&
                   (a.RappBase == b.RappBase) &&
                   (a.Symbol == b.Symbol) &&
                   (a.ShortName == b.ShortName);
        }

        /// <summary>
        ///     Determines whether the specified <see cref="System.Object" /> is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is CurrencyObject)) return false;
            return this == (CurrencyObject) obj;
        }


        /// <summary>
        ///     Implements the !=.
        /// </summary>
        /// <param name="a">A.</param>
        /// <param name="b">The b.</param>
        /// <returns>The result of the operator.</returns>
        public static bool operator !=(CurrencyObject a, CurrencyObject b)
        {
            return !(a == b);
        }

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        ///     Performs an implicit conversion from <see cref="System.String" /> to <see cref="CurrencyObject" />.
        /// </summary>
        /// <param name="d">The d.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator CurrencyObject(string d)
        {
            return Currency.All.First(x => x.ShortName == d);
        }

        /// <summary>
        ///     Performs an explicit conversion from <see cref="CurrencyObject" /> to <see cref="System.String" />.
        /// </summary>
        /// <param name="f">The f.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator string(CurrencyObject f)
        {
            return f.ShortName;
        }

        #endregion
    }
}