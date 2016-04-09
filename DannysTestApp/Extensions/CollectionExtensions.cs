using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DannysTestApp.Extensions
{
    public static class CollectionExtensions
    {
        public static void AddRange<T>(this ICollection<T> self, IEnumerable<T> items)
        {
            if (items == null || items.Count() == 0)
                return;

            foreach (var i in items)
            {
                self.Add(i);
            }
        }
    }
}
