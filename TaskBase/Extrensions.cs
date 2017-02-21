using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Keretrendszer.Base
{
    internal static class Extensions
    {
        public static string GetInputLabel(this PropertyInfo propertyInfo)
        {
            var property = propertyInfo.GetCustomAttributes(false).Where(a => a.GetType() == typeof(InputAttribute)).FirstOrDefault();
            if (propertyInfo != null)
            {
                return ((InputAttribute)property).Label;
            }
            return string.Empty;
        }
    }
}
