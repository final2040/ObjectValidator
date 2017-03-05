using System;
using System.Text.RegularExpressions;

namespace ObjectValidator.Rules
{
    public class EmailAddressRule:RuleBase
    {
        private const string Pattern = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";
        private const RegexOptions Options =
            RegexOptions.Compiled | RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture;
        private readonly TimeSpan _regexTimeout = TimeSpan.FromSeconds(2);

        /// <summary>
        /// Create and instance of the email address validator.
        /// </summary>
        /// <param name="propertyName">Name of the property to validate.</param>
        /// <param name="errorMessage">Error message to show when rule fail, it accepts text formating
        /// <para>1. Show the property name.</para>
        /// </param>
        public EmailAddressRule(string propertyName, string errorMessage) : base(propertyName, errorMessage){}

        /// <summary>
        /// <para>Error message to show when rule fail, it accepts text formating</para>
        /// <para>1. Show the property name.</para>
        /// </summary>
        public override string ErrorMessage
        {
            get { return string.Format(_errorMessage, _propertyName); }
            set { _errorMessage = value; }
        }

        /// <summary>
        /// Validate current Rule.
        /// </summary>
        /// <param name="o">Object to validate.</param>
        /// <returns>Validation result.</returns>
        public override bool IsValid(object o)
        {
            if (o == null) return false;
            string objectToVallidate = o as string;
            return !string.IsNullOrWhiteSpace(objectToVallidate) && GetRegex().IsMatch(objectToVallidate);
        }

        /// <summary>
        /// Create regex to be tested
        /// </summary>
        /// <returns>Regex to be tested</returns>
        private Regex GetRegex()
        {
            return new Regex(Pattern,Options, _regexTimeout);
        }
    }
}