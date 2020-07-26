using System;
using System.Linq;

namespace TestInventoryManagementSystem
{
    public static class TypeExtensions
        {
            public static bool HasPropertyOfType<T>(this Type model, string propertyName)
            {
                if (model.GetProperties().Any(x => x.Name == propertyName && x.PropertyType == typeof(T)))
                {
                    return true;
                }
                if (model.GetProperties().Any(x => x.Name == propertyName))
                {
                    var prop = model.GetProperty(propertyName);
                    throw new Exception(string.Format("Expected Type {0}, Actual Type {1}", typeof(T).Name,
                        prop.PropertyType.Name));
                }
                return false;
            }
        }

}
