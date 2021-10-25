using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home.Common.Attributes
{
    /// <summary>
    /// This attibute means the Field or property is not used for DB column
    /// </summary>
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class DBFieldAttribute : Attribute
    {
    }
}
