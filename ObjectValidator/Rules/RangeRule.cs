using System;

namespace ObjectValidator.Rules
{
    /// <summary>
    /// Validate if a object is in especified Range.
    /// </summary>
    /// <typeparam name="T">Type of object to validate, must implement <see cref="IComparable"/></typeparam>
    public class RangeRule<T> : RuleBase where T : IComparable
    {
        /// <summary>
        /// Min value to compare.
        /// </summary>
        public T MinValue { get; }
        
        /// <summary>
        /// Max value to compare.
        /// </summary>
        public T MaxValue { get; }

        /// <summary>
        ///     <para>Error to be show error admits string format with the follow values:</para>
        ///     <para>1. Property name</para>
        ///     <para>2. MinValue</para>
        ///     <para>3. MaxValue</para>
        /// </summary>
        public override string ErrorMessage
        {
            get { return string.Format(_errorMessage, _propertyName, MinValue, MaxValue); }
            set { _errorMessage = value; }
        }

        /// <summary>
        /// Creates a instance of RangeRule.
        /// </summary>
        /// <param name="propertyName">Property to be tested</param>
        /// <param name="errorMessage">
        ///     <para>Error to be show error admits string format with the follow values:</para>
        ///     <para>1. Property name</para>
        ///     <para>2. MinValue</para>
        ///     <para>3. MaxValue</para>
        /// </param>
        /// <param name="minValue">Min Value</param>
        /// <param name="maxValue">Max Value</param>
        public RangeRule(string propertyName, string errorMessage, T minValue, T maxValue) : base(propertyName, errorMessage)
        {
            MinValue = minValue;
            MaxValue = maxValue;
        }

        /// <summary>
        /// Validate current Rule.
        /// </summary>
        /// <param name="o">Object to validate.</param>
        /// <returns>Validation result.</returns>
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