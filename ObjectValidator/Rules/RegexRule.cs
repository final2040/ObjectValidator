using System.Text.RegularExpressions;
using ObjectValidator.Rules;

namespace ObjectValidator.rules
{
    /// <summary>
    /// Validate if a string matches especified Regular expresion.
    /// </summary>
    public class RegexRule : RuleBase
    {
        private readonly string _pattern;

        /// <summary>
        /// Especifies if empty strings will be ignored.
        /// </summary>
        public bool IgnoreEmptyString { get; }
        /// <summary>
        /// Regex object to validate string.
        /// </summary>
        public Regex Regex { get; }

        /// <summary>
        ///     <para>Error to be show error admits string format with the follow values:</para>
        ///     <para>1. Property name</para>
        ///     <para>2. Pattern to validate</para>
        /// </summary>
        public override string ErrorMessage
        {
            get { return string.Format(_errorMessage, PropertyName, _pattern); }
            set { _errorMessage = value; }
        }

        /// <summary>
        /// Creates a instance of RegexRule.
        /// </summary>
        /// <param name="propertyName">Property to be tested</param>
        /// <param name="errorMessage">
        ///     <para>Error to be show error admits string format with the follow values:</para>
        ///     <para>1. Property name</para>
        ///     <para>2. Pattern to test</para>
        /// </param>
        /// <param name="pattern">Pattern to test</param>
        public RegexRule(string propertyName, string errorMessage, string pattern) : this(propertyName, errorMessage, pattern, false) { }
        /// <summary>
        /// Creates a instance of RegexRule.
        /// </summary>
        /// <param name="propertyName">Property to be tested</param>
        /// <param name="errorMessage">
        ///     <para>Error to be show error admits string format with the follow values:</para>
        ///     <para>1. Property name</para>
        ///     <para>2. Pattern to test</para>
        /// </param>
        /// <param name="pattern">Pattern to test</param>
        /// <param name="ignoreEmptyString">Especifies if empty strings will be ignored</param>
        public RegexRule(string propertyName, string errorMessage, string pattern, bool ignoreEmptyString) : base(propertyName, errorMessage)
        {
            IgnoreEmptyString = ignoreEmptyString;
            _pattern = pattern;
            Regex = new Regex(_pattern);
        }
        /// <summary>
        /// Validate current Rule.
        /// </summary>
        /// <param name="o">Object to validate.</param>
        /// <returns>Validation result.</returns>
        public override bool IsValid(object o)
        {
            if (o == null) return false;
            return IgnoreEmptyString && string.IsNullOrWhiteSpace(o.ToString()) || Regex.IsMatch(o.ToString());
        }
    }
}