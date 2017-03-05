namespace ObjectValidator.Rules
{
    /// <summary>
    /// Verifies if string dont have less characteres than especified.
    /// </summary>
    public class MinLengthRule:RuleBase
    {
        /// <summary>
        /// Create an intance of the MaxLengthRule.
        /// </summary>
        /// <param name="propertyName">Name of the property to be validated.</param>
        /// <param name="minLength">Min length of the string.</param>
        /// <param name="errorMessage">
        ///     <para>Error to be show error admits string format with the follow values:</para>
        ///     <para>1. Property name</para>
        ///     <para>2. MinLength</para>
        /// </param>
        public MinLengthRule(string propertyName, int minLength, string errorMessage):base(propertyName, errorMessage)
        {
            MinLength = minLength;
        }

        /// <summary>
        ///     <para>Error to be show error admits string format with the follow values:</para>
        ///     <para>1. Property name.</para>
        ///     <para>2. MaxLength.</para>
        /// </summary>
        public override string ErrorMessage
        {
            get { return string.Format(_errorMessage, _propertyName, MinLength); }
            set { _errorMessage = value; }
        }
        /// <summary>
        /// MinLength of the string.
        /// </summary>
        public int MinLength { get; set; }

        /// <summary>
        /// Validate current Rule.
        /// </summary>
        /// <param name="o">Object to validate.</param>
        /// <returns>Validation result.</returns>
        public override bool IsValid(object o)
        {
            string validateObject = o as string;
            return validateObject != null && validateObject.Length >= MinLength;
            
        }
    }
}