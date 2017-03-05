using System;

namespace ObjectValidator.Rules
{
    /// <summary>
    /// Validate if a object is lesser than especified limit.
    /// </summary>
    /// <typeparam name="T">Type of object to validate, must implement <see cref="IComparable"/></typeparam>
    public class MaxRule<T> : RuleBase where T:IComparable
    {
        /// <summary>
        /// Min value to compare.
        /// </summary>
        public T MaxValue { get; }

        /// <summary>
        ///     <para>Error to be show error admits string format with the follow values:</para>
        ///     <para>1. Property name</para>
        ///     <para>2. MaxValue</para>
        /// </summary>
        public override string ErrorMessage
        {
            get { return string.Format(_errorMessage, PropertyName, MaxValue); }
            set { _errorMessage = value; }
        }
        /// <summary>
        /// Creates a instance of MaxRule.
        /// </summary>
        /// <param name="propertyName">Property to be tested</param>
        /// <param name="errorMessage">
        ///     <para>Error to be show error admits string format with the follow values:</para>
        ///     <para>1. Property name</para>
        ///     <para>2. MaxValue</para>
        /// </param>
        /// <param name="maxValue">Max Value</param>
        public MaxRule(string propertyName, string errorMessage, T maxValue) : base(propertyName,errorMessage)
        {
            this.MaxValue = maxValue;
        }

        /// <summary>
        /// Validate current Rule.
        /// </summary>
        /// <param name="o">Object to validate.</param>
        /// <returns>Validation result.</returns>
        public override bool IsValid(object o)
        {
            return o != null && o.GetType() == typeof(T) && Validate((T) o);
        }
        /// <summary>
        /// Compares the object with the max value.
        /// </summary>
        /// <param name="o">Object</param>
        /// <returns>If object is Less than max value.</returns>
        private bool Validate(T o)
        {
            return o.CompareTo(MaxValue) <= 0;
        }
    }
}