using System.Text.RegularExpressions;
using ObjectValidator.Rules;

namespace ObjectValidator.rules
{
    public class RegexRule : RuleBase
    {
        public Regex Regex { get; }
        public override string ErrorMessage
        {
            get { return string.Format(_errorMessage, PropertyName, Regex); }
            set { _errorMessage = value; }
        }

        public RegexRule(string propertyName, string errorMessage, string regularExpresion) : base(propertyName, errorMessage)
        {
            Regex = new Regex(regularExpresion);
        }


        public override bool IsValid(object o)
        {
            return o!=null && Regex.IsMatch(o.ToString());
        }
    }
}