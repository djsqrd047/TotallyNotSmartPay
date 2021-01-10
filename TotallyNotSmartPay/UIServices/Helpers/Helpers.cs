using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TotallyNotSmartPayModels;

namespace TotallyNotSmartPay.UIServices.Helpers
{
    public static class Helpers
    {
        internal static List<string> GetPropertyNames(object obj)
        {
            var columnNames = new List<string>();
            foreach(var propName in obj.GetType().GetProperties())
            {
                if(propName.Name.ToLower() != "id")
                {
                    columnNames.Add(propName.Name);
                }
            }
            return columnNames;
        }
    }
}
