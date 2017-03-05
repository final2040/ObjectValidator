namespace ObjectValidator.Rules
{
    /// <summary>
    /// Base for the rules.
    /// </summary>
    public abstract class RuleBase : IRule
    {
        protected string _propertyName;
        protected string _errorMessage;

        /// <summary>
        /// Creates a instance of the rule
        /// </summary>
        /// <param name="propertyName">Property to be tested</param>
        /// <param name="errorMessage">Message error</param>
        public RuleBase(string propertyName, string errorMessage)
        {
            _propertyName = propertyName;
            _errorMessage = errorMessage;
        }

        /// <summary>
        /// Error message to be show.
        /// </summary>
        public virtual string ErrorMessage
        {
            get { return string.Format(_errorMessage,_propertyName); }
            set { _errorMessage = value; }
        }

        /// <summary>
        /// Property to be validated.
        /// </summary>
        public virtual string PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }
        /// <summary>
        /// Test current rule.
        /// </summary>
        /// <param name="o">Object to test.</param>
        /// <returns>Test result.</returns>
        public abstract bool IsValid(object o);
    }
}