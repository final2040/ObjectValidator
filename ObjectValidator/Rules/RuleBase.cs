namespace ObjectValidator.Rules
{
    public abstract class RuleBase : IRule
    {
        protected string _propertyName;
        protected string _errorMessage;

        public RuleBase(string propertyName, string errorMessage)
        {
            _propertyName = propertyName;
            _errorMessage = errorMessage;
        }

        public virtual string ErrorMessage
        {
            get { return string.Format(_errorMessage,_propertyName); }
            set { _errorMessage = value; }
        }

        public virtual string PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }

        public abstract bool IsValid(object o);
    }
}