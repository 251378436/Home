using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Home.Common.Attributes;

namespace Home.Common.Helpers
{
    public static class AttributeHelper
    {
        /// <summary>
        /// Only get the properties which are used for Database columns.
        /// The property should contain attribute NotDBFieldAttribute.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetDBProperties(this Type type)
        {
            return type.GetProperties().Where(prop => prop.IsDefined(typeof(DBFieldAttribute), true));
        }
    }
}
