using System;

namespace ObjectValidator.Rules
{
    public class MaxRule<T> : RuleBase where T:IComparable
    {
        public T MaxValue { get; }
        public override string ErrorMessage
        {
            get { return string.Format(_errorMessage, PropertyName, MaxValue); }
            set { _errorMessage = value; }
        }
        public MaxRule(string propertyName, string errorMessage, T maxValue) : base(propertyName,errorMessage)
        {
            this.MaxValue = maxValue;
        }

        public override bool IsValid(object o)
        {
            return o != null && o.GetType() == typeof(T) && Validate((T) o);
        }

        private bool Validate(T o)
        {
            return o.CompareTo(MaxValue) <= 0;
        }
    }
}