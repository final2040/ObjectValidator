using System;

namespace ObjectValidator.Rules
{
    public class RangeRule<T> : RuleBase where T : IComparable
    {
        public T MinValue { get; }
        public T MaxValue { get; }

        public override string ErrorMessage
        {
            get { return string.Format(_errorMessage, _propertyName, MinValue, MaxValue); }
            set { _errorMessage = value; }
        }

        public RangeRule(string propertyName, string errorMessage, T minValue, T maxValue) : base(propertyName, errorMessage)
        {
            this.MinValue = minValue;
            this.MaxValue = maxValue;
        }

        public override bool IsValid(object o)
        {
            return o != null && o.GetType() == typeof (T) && Validate((T) o);
        }

        private bool Validate(T o)
        {
            return o.CompareTo(MinValue) >= 0 && o.CompareTo(MaxValue) <= 0;
        }
    }
}