namespace ObjectValidator
{
    /// <summary>
    /// Contains info about a validation error.
    /// </summary>
    public class ValidationError
    {
        /// <summary>
        /// Property validated.
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// Error description.
        /// </summary>
        public string ErrorMessage { get; set; }
        /// <summary>
        /// Name of the rule who generate the error.
        /// </summary>
        public string ValidationRuleName { get; set; }

        /// <summary>
        /// Create an instence of the ValidationError Object.
        /// </summary>
        /// <param name="propertyName">Name of the property validated</param>
        /// <param name="errorMessage">Error description</param>
        /// <param name="validationRuleName">Name of the rule</param>
        public ValidationError(string propertyName, string errorMessage, string validationRuleName)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
            ValidationRuleName = validationRuleName;
        }
    }
}