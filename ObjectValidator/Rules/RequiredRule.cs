namespace ObjectValidator.Rules
{
    public class RequiredRule : RuleBase
    {
        private bool _validateStringEmptyOrWhiteSpace;

        public RequiredRule(string propertyName, string errorMessage) : base(propertyName, errorMessage){}
        public RequiredRule(string propertyName, string errorMessage, bool validateStringEmptyOrWhiteSpace):base(propertyName, errorMessage)
        {
            this._validateStringEmptyOrWhiteSpace = validateStringEmptyOrWhiteSpace;
        }

        public override string ErrorMessage
        {
            get { return string.Format(_errorMessage, _propertyName); }
            set { _errorMessage = value; }
        }

        public bool ValidateStringEmptyOrWhiteSpace
        {
            get { return _validateStringEmptyOrWhiteSpace; }
            set { _validateStringEmptyOrWhiteSpace = value; }
        }

        public override bool IsValid(object o)
        {
            if (_validateStringEmptyOrWhiteSpace) return !string.IsNullOrWhiteSpace(o as string);
            return o != null;
        }
    }
}