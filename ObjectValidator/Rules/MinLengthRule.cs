namespace ObjectValidator.Rules
{
    public class MinLengthRule:RuleBase
    {
        private int _minLength;

        public MinLengthRule(string propertyName, int minLength, string errorMessage):base(propertyName, errorMessage)
        {
            this._minLength = minLength;
        }

        public override string ErrorMessage
        {
            get { return string.Format(_errorMessage, _propertyName, _minLength); }
            set { _errorMessage = value; }
        }

        public int MinLength
        {
            get { return _minLength; }
            set { _minLength = value; }
        }

        public override bool IsValid(object o)
        {
            string validateObject = o as string;
            return validateObject != null && validateObject.Length >= _minLength;
            
        }
    }
}