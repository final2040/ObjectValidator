using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ObjectValidator
{
    public class ReflectionHelper
    {
        public Dictionary<string, Type> GetProperties<T>(T o)
        {
            if(o == null) throw new ArgumentNullException(nameof(o),"Object cannot be null.");

            return typeof(T)
                .GetProperties()
                .Where(p => p.CanRead)
                .ToDictionary(p => p.Name, p => p.PropertyType);
        }

        public object GetPropertyValue<T>(T o, string propertyName, Type valueType)
        {
            if(o == null) throw new ArgumentNullException(nameof(o), "Object cannot be null.");
            if (GetProperties(o).All(p => p.Key != propertyName))
                throw new ArgumentException("Especified property dont exists.");

            return typeof(T).GetProperty(propertyName, valueType).GetValue(o);
        }

        public Dictionary<string, object> GetPropertiesTable<T>(T o)
        {
            return GetProperties(o)
                .ToDictionary(property => property.Key, property => GetPropertyValue(o, property.Key, property.Value));
        }
    }
}