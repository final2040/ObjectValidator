using System;
using System.Collections.Generic;
using System.Linq;

namespace ObjectValidator
{
    public class Validator
    {
        private readonly List<IRule> _rules = new List<IRule>();
        private readonly ReflectionHelper _reflectionHelper;

        public Validator()
        {
            _reflectionHelper = new ReflectionHelper();
        }

        public bool TryValidate(object o, ICollection<ValidationError> errorCollection)
        {
            if(errorCollection == null) throw new ArgumentNullException(nameof(errorCollection), "Argument cannot be null.");
            if(o == null) throw new ArgumentNullException(nameof(o), "Argument cannot be null.");

            Dictionary<string, object> objectProperties = _reflectionHelper.GetPropertiesTable(o);
            ValidateRules(objectProperties);

            errorCollection.Clear();
            GetErrors(objectProperties).ForEach(errorCollection.Add);

            return _rules.All(r => r.IsValid(objectProperties[r.PropertyName]));
        }

        private List<ValidationError> GetErrors(Dictionary<string, object> objectProperties)
        {
            return _rules.Where(r => !r.IsValid(objectProperties[r.PropertyName]))
                .Select(r => new ValidationError(r.PropertyName, r.ErrorMessage, r.GetType().Name)).ToList();
        }

        private void ValidateRules(Dictionary<string, object> objectProperties)
        {
            foreach (IRule rule in _rules.Where(rule => !objectProperties.ContainsKey(rule.PropertyName)))
            {
                throw new InvalidOperationException($"Object don't contain property {rule.PropertyName}" +
                                                    $" in rule {rule.GetType().Name}.");
            }
        }

        public void AddRule(IRule rule)
        {
            if(rule == null) throw new ArgumentNullException();
            _rules.Add(rule);
        }
    }
}