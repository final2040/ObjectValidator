namespace ObjectValidator
{
    /// <summary>
    /// Interface to rules
    /// </summary>
    public interface IRule
    {
        string ErrorMessage { get; set; }
        string PropertyName { get; set; }
        bool IsValid(object o);
    }
}