using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Home.Common.Attributes;

namespace Home.Common.Models
{
    public class Files : BaseModel, IValidatableObject
    {
        [DBField]
        public string Name { get; set; }

        [DBField]
        public string Data { get; set; }
    }
}