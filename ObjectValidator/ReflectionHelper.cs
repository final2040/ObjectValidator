using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ObjectValidator
{
    public class ReflectionHelper
    {
        public ReflectionHelper()
        {
        }

        public Dictionary<string, Type> GetProperties(object o)
        {
            if (o == null)
                throw new ArgumentNullException("o", "Object cannot be null.");

            Dictionary<string,Type> childProperties = o.GetType()
                .GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.CanRead)
                .ToDictionary(p => p.Name, p => p.PropertyType);

            foreach (PropertyInfo property in o.GetType().GetProperties().Where(p => p.CanRead && !childProperties.ContainsKey(p.Name)))
            {
                childProperties.Add(property.Name, property.PropertyType);
            }

            return childProperties;
        }

        public object GetPropertyValue(object o, string propertyName, Type valueType)
        {
            if (o == null)
                throw new ArgumentNullException("o", "Object cannot be null.");
            if (GetProperties(o).All(p => p.Key != propertyName))
                throw new ArgumentException("Especified property dont exists.");

            return o.GetType().GetProperty(propertyName, valueType).GetValue(o);
        }

        public Dictionary<string, object> GetPropertiesTable(object o)
        {
            return GetProperties(o)
                .ToDictionary(property => property.Key, property => GetPropertyValue(o, property.Key, property.Value));
        }
    }
}