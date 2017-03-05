namespace ObjectValidator.Rules
{
    /// <summary>
    /// Verifies if string dont have more characteres than especified.
    /// </summary>
    public class MaxLengthRule:RuleBase
    {
        /// <summary>
        /// Create an intance of the MaxLengthRule.
        /// </summary>
        /// <param name="propertyName">Name of the property to be validated.</param>
        /// <param name="maxLength">Max length of the string.</param>
        /// <param name="errorMessage">
        ///     <para>Error to be show error admits string format with the follow values:</para>
        ///     <para>1. Property name</para>
        ///     <para>2. MaxLength</para>
        /// </param>
        public MaxLengthRule(string propertyName, int maxLength, string errorMessage):base(propertyName, errorMessage)
        {
            MaxLength = maxLength;
        }

        /// <summary>
        ///     <para>Error to be show error admits string format with the follow values:</para>
        ///     <para>1. Property name.</para>
        ///     <para>2. MaxLength.</para>
        /// </summary>
        public override string ErrorMessage
        {
            get { return string.Format(_errorMessage, _propertyName, MaxLength); }
            set { _errorMessage = value; }
        }

        /// <summary>
        /// MaxLength of the string.
        /// </summary>
        public int MaxLength { get; set; }

        /// <summary>
        /// Validate current Rule.
        /// </summary>
        /// <param name="o">Object to validate.</param>
        /// <returns>Validation result.</returns>
        public override bool IsValid(object o)
        {
            string validateObject = o as string;
            return validateObject != null && validateObject.Length <= MaxLength;
            
        }
    }
}