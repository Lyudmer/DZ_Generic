using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_Generic
{
    public static class GetMaxItem
    {
        public static T GetMax<T>(this IEnumerable<T> collection, Func<T, float> convertToNumber) where T : class
        {
            if (collection == null || !collection.Any())
            {
                return default;
            }

            T maxItem = collection.First();
            float maxValue = convertToNumber(maxItem);

            foreach (T item in collection.Skip(1))
            {
                float currentValue = convertToNumber(item);
                if (currentValue > maxValue)
                {
                    maxItem = item;
                    maxValue = currentValue;
                }
            }

            return maxItem;
        }

    }
}
