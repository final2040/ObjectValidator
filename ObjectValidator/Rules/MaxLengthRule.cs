namespace ObjectValidator.Rules
{
    public class MaxLengthRule:RuleBase
    {
        private int _maxLength;

        public MaxLengthRule(string propertyName, int maxLength, string errorMessage):base(propertyName, errorMessage)
        {
            this._maxLength = maxLength;
        }

        public override string ErrorMessage
        {
            get { return string.Format(_errorMessage, _propertyName, _maxLength); }
            set { _errorMessage = value; }
        }

        public int MaxLength
        {
            get { return _maxLength; }
            set { _maxLength = value; }
        }

        public override bool IsValid(object o)
        {
            string validateObject = o as string;
            return !string.IsNullOrEmpty(validateObject) && validateObject.Length <= _maxLength;
            
        }
    }
}