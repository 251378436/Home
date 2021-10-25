using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home.Common.Attributes;

namespace Home.Common.Models
{
    public class BaseModel
    {
        [DBField]
        public int Id { get; set; }

        [DBField]
        public string Description { get; set; }
    }
}
