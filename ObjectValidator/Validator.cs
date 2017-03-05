using System;
using System.Collections.Generic;
using System.Linq;

namespace ObjectValidator
{
    /// <summary>
    /// Validate an object based on user providen rules.
    /// </summary>
    /// <typeparam name="T">Type of the object to be validated.</typeparam>
    public class Validator<T>
    {
        private readonly List<IRule> _rules = new List<IRule>();
        private readonly PropertyReflectionHelper _propertyReflectionHelper;

        /// <summary>
        /// Create an instance of Validator Object
        /// </summary>
        public Validator()
        {
            _propertyReflectionHelper = new PropertyReflectionHelper();
        }


        /// <summary>
        /// Try validated provided object using provided rules,
        /// returns true when all rules are passed or false when any rule fails,
        /// adds validation results to the provided collection.
        /// </summary>
        /// <param name="o">Object to validate</param>
        /// <param name="errorCollection">Collection to validate</param>
        /// <returns>
        ///     bolean that indicate all rules are passed.
        /// </returns>
        /// <exception cref="ArgumentNullException">When object to validate is null</exception>
        /// <exception cref="ArgumentNullException">When the collection provided to save results is null</exception>
        public bool TryValidate(T o, ICollection<ValidationError> errorCollection)
        {
            if(errorCollection == null) throw new ArgumentNullException(nameof(errorCollection), "Argument cannot be null.");
            if(o == null) throw new ArgumentNullException(nameof(o), "Argument cannot be null.");

            Dictionary<string, object> objectProperties = _propertyReflectionHelper.GetPropertiesTable(o);
            ValidateRules(objectProperties);

            errorCollection.Clear();
            GetErrors(objectProperties).ForEach(errorCollection.Add);

            return _rules.All(r => r.IsValid(objectProperties[r.PropertyName]));
        }
        /// <summary>
        /// Get Error list
        /// </summary>
        /// <param name="objectProperties">Properties and values of the object to validate</param>
        /// <returns>List of errors</returns>
        private List<ValidationError> GetErrors(Dictionary<string, object> objectProperties)
        {
            return _rules.Where(r => !r.IsValid(objectProperties[r.PropertyName]))
                .Select(r => new ValidationError(r.PropertyName, r.ErrorMessage, r.GetType().Name)).ToList();
        }
        /// <summary>
        /// Validate that the rules contain valid property names for the object
        /// </summary>
        /// <param name="objectProperties">Properties and values of the object to be validated</param>
        /// <exception cref="InvalidOperationException">When a rule property is invalid for the current object</exception>
        private void ValidateRules(Dictionary<string, object> objectProperties)
        {
            foreach (IRule rule in _rules.Where(rule => !objectProperties.ContainsKey(rule.PropertyName)))
            {
                throw new InvalidOperationException($"Object don't contain property {rule.PropertyName}" +
                                                    $" in rule {rule.GetType().Name}.");
            }
        }

        /// <summary>
        /// Add a new rule to the rule set of the validator
        /// </summary>
        /// <param name="rule">Rule to be validated</param>
        /// <exception cref="ArgumentNullException">When the rule provided is null</exception>
        public void AddRule(IRule rule)
        {
            if(rule == null) throw new ArgumentNullException();
            _rules.Add(rule);
        }
    }
}