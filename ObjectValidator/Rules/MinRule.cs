using System;

namespace ObjectValidator.Rules
{
    /// <summary>
    /// Validate if a object is Greather than especified limit.
    /// </summary>
    /// <typeparam name="T">Type of object to validate, must implement <see cref="IComparable"/></typeparam>
    public class MinRule<T> : RuleBase where T : IComparable
    {
        /// <summary>
        /// Min value to compare.
        /// </summary>
        public T MinValue { get; }

        /// <summary>
        ///     <para>Error to be show error admits string format with the follow values:</para>
        ///     <para>1. Property name</para>
        ///     <para>2. MaxValue</para>
        /// </summary>
        public override string ErrorMessage
        {
            get { return string.Format(_errorMessage, PropertyName, MinValue); }
            set { _errorMessage = value; }
        }

        /// <summary>
        /// Creates a instance of MinRule.
        /// </summary>
        /// <param name="propertyName">Property to be tested</param>
        /// <param name="errorMessage">
        ///     <para>Error to be show error admits string format with the follow values:</para>
        ///     <para>1. Property name</para>
        ///     <para>2. MinValue</para>
        /// </param>
        /// <param name="minValue">Min Value</param>
        public MinRule(string propertyName, string errorMessage, T minValue) : base(propertyName, errorMessage)
        {
            MinValue = minValue;
        }

        public override bool IsValid(object o)
        {
            return o != null && o.GetType() == typeof(T) && Validate((T)o);
        }

        /// <summary>
        /// Validate current Rule.
        /// </summary>
        /// <param name="o">Object to validate.</param>
        /// <returns>Validation result.</returns>
        private bool Validate(T o)
        {
            return o.CompareTo(MinValue) >= 0;
        }
    }
}