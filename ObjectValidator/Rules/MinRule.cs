using System;

namespace ObjectValidator.Rules
{
    public class MinRule<T> : RuleBase where T : IComparable
    {
        public T MinValue { get; }
        public override string ErrorMessage
        {
            get { return string.Format(_errorMessage, PropertyName, MinValue); }
            set { _errorMessage = value; }
        }

        public MinRule(string propertyName, string errorMessage, T minValue) : base(propertyName, errorMessage)
        {
            this.MinValue = minValue;
        }

        public override bool IsValid(object o)
        {
            return o != null && o.GetType() == typeof(T) && Validate((T)o);
        }

        private bool Validate(T o)
        {
            return (o).CompareTo(MinValue) >= 0;
        }
    }
}