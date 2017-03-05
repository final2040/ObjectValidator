using System;
using System.Collections.Generic;
using System.Linq;

namespace ObjectValidator
{
    /// <summary>
    /// Simple helper to Object Property Tasks.
    /// </summary>
    public class PropertyReflectionHelper
    {
        /// <summary>
        /// Gets a dictionary with the properties and property types on the provided object.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="o">Object to be procesed.</param>
        /// <returns>Dictionary with properties and property type of the object.</returns>
        public Dictionary<string, Type> GetProperties<T>(T o)
        {
            if(o == null) throw new ArgumentNullException(nameof(o),"Object cannot be null.");

            return typeof(T)
                .GetProperties()
                .Where(p => p.CanRead)
                .ToDictionary(p => p.Name, p => p.PropertyType);
        }

        /// <summary>
        /// Obtains the value of the providen property.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="o">Object to be processed.</param>
        /// <param name="propertyName">Name of the property to get.</param>
        /// <param name="valueType">Type of the property to get (to avoid ambiguos request).</param>
        /// <returns>Value of the property</returns>
        public object GetPropertyValue<T>(T o, string propertyName, Type valueType)
        {
            if(o == null) throw new ArgumentNullException(nameof(o), "Object cannot be null.");
            if (GetProperties(o).All(p => p.Key != propertyName))
                throw new ArgumentException("Especified property dont exists.");

            return typeof(T).GetProperty(propertyName, valueType).GetValue(o);
        }

        /// <summary>
        /// Gets a Dictionary with all properties and values of the object.
        /// </summary>
        /// <typeparam name="T">Type of object.</typeparam>
        /// <param name="o">Object to process.</param>
        /// <returns>Dictionary with all properties and values of the object.</returns>
        public Dictionary<string, object> GetPropertiesTable<T>(T o)
        {
            return GetProperties(o)
                .ToDictionary(property => property.Key, property => GetPropertyValue(o, property.Key, property.Value));
        }
    }
}