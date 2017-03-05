using System.Text.RegularExpressions;
using ObjectValidator.Rules;

namespace ObjectValidator.rules
{
    public class RegexRule : RuleBase
    {
        public bool IgnoreEmptyString { get; } = false;
        public Regex Regex { get; }
        public override string ErrorMessage
        {
            get { return string.Format(_errorMessage, PropertyName, Regex); }
            set { _errorMessage = value; }
        }

        public RegexRule(string propertyName, string errorMessage, string pattern) : this(propertyName, errorMessage, pattern,false){ }
        public RegexRule(string propertyName, string errorMessage, string pattern, bool ignoreEmptyString) : base(propertyName, errorMessage)
        {
            IgnoreEmptyString = ignoreEmptyString;
            Regex = new Regex(pattern);
        }

        public override bool IsValid(object o)
        {
            if (o == null) return false;
            return IgnoreEmptyString && string.IsNullOrWhiteSpace(o.ToString()) || Regex.IsMatch(o.ToString());
        }
    }
}