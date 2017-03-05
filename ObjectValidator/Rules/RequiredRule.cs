namespace ObjectValidator.Rules
{
    /// <summary>
    /// Validate if a object is not null.
    /// </summary>
    public class RequiredRule : RuleBase
    {
        private bool _validateStringEmptyOrWhiteSpace;
        /// <summary>
        /// Creates a instance of Required rule.
        /// </summary>
        /// <param name="propertyName">Property to be tested</param>
        /// <param name="errorMessage">
        ///     <para>Error to be show error admits string format with the follow values:</para>
        ///     <para>1. Property name</para>
        /// </param>
        public RequiredRule(string propertyName, string errorMessage) : base(propertyName, errorMessage){}

        /// <summary>
        /// Creates a instance of Required rule.
        /// </summary>
        /// <param name="propertyName">Property to be tested</param>
        /// <param name="errorMessage">
        ///     <para>Error to be show error admits string format with the follow values:</para>
        ///     <para>1. Property name</para>
        /// </param>
        /// <param name="validateStringEmptyOrWhiteSpace">Especifies if strings will be validated for empty or whitespace</param>
        public RequiredRule(string propertyName, string errorMessage, bool validateStringEmptyOrWhiteSpace):base(propertyName, errorMessage)
        {
            this._validateStringEmptyOrWhiteSpace = validateStringEmptyOrWhiteSpace;
        }

        /// <summary>
        ///     <para>Error to be show error admits string format with the follow values:</para>
        ///     <para>1. Property name</para>
        /// </summary>
        public override string ErrorMessage
        {
            get { return string.Format(_errorMessage, _propertyName); }
            set { _errorMessage = value; }
        }
        /// <summary>
        /// Especifies if strings will be validated for empty or whitespace.
        /// </summary>
        public bool ValidateStringEmptyOrWhiteSpace
        {
            get { return _validateStringEmptyOrWhiteSpace; }
            set { _validateStringEmptyOrWhiteSpace = value; }
        }

        /// <summary>
        /// Validate current Rule.
        /// </summary>
        /// <param name="o">Object to validate.</param>
        /// <returns>Validation result.</returns>
        public override bool IsValid(object o)
        {
            if (_validateStringEmptyOrWhiteSpace) return !string.IsNullOrWhiteSpace(o as string);
            return o != null;
        }
    }
}