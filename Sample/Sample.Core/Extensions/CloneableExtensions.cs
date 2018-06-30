using System;
using System.Reflection;

namespace Sample.Core.Extensions
{
    public static class CloneableExtensions
    {
        /// <summary>
        /// Clones object U to T.
        /// </summary>
        /// <typeparam name="T">Targeet object</typeparam>
        /// <param name="u">Source object</param>
        /// <returns>Returns T</returns>
        public static T CloneTo<T>(this ICloneableType u) where T : ICloneableType, new()
        {
            var props = u.GetType().GetProperties();
            T destination = new T();
            foreach (var prop in props)
            {
                PropertyInfo info = destination.GetType().GetProperty(prop.Name);

                if (info == null)
                    continue;

                object underlyingType = Nullable.GetUnderlyingType(info.PropertyType);
                object value = prop.GetValue(u, null);

                if (underlyingType != null && value != null)
                {
                    value = Convert.ChangeType(value, Nullable.GetUnderlyingType(info.PropertyType) ?? throw new InvalidOperationException());
                }

                info.SetValue(destination, value, null);
            }
            return destination;
        }
    }

    public interface ICloneableType
    {

    }
}
