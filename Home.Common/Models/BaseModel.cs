using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Home.Common.Models
{
    public class BaseModel : IValidatableObject
    {
        [DBField]
        public int Id { get; set; }

        [DBField]
        public string Description { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Description.ToLower().Contains("test"))
                yield return new ValidationResult($"The field {nameof(Description)} should not contain test", new[] { nameof(Description) });
        }
    }
}
