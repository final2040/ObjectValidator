namespace ObjectValidator
{
    public class ValidationError
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
        public string ValidationRuleName { get; set; }

        public ValidationError(string propertyName, string errorMessage, string validationRuleName)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
            ValidationRuleName = validationRuleName;
        }
    }
}