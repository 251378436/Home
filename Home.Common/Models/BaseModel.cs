using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xero.Common.Attributes;

namespace Xero.Common.Models
{
    public class BaseModel
    {
        [DBField]
        public int Id { get; set; }

        [DBField]
        public string Description { get; set; }
    }
}
