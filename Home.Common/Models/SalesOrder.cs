using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Home.Common.Attributes;

namespace Home.Common.Models
{
    public class SalesOrder : BaseModel, IValidatableObject
    {
        [DBField]
        public string Customer { get; set; }

        [DBField]
        public decimal Amount { get; set; }

        [DBField]
        [Range(1,10)]
        public decimal Discount { get; set; }

        public List<SalesOrderItem> SalesOrderItems { get; set; }

        public SalesOrder() : base()
        {
            this.SalesOrderItems = new List<SalesOrderItem>();
        }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var baseErrors = base.Validate(validationContext);
            if (baseErrors != null && baseErrors.Any())
            {
                foreach (var error in baseErrors)
                {
                    yield return error;
                }
            }

            if (Amount <= 0 || Amount> 1000)
                yield return new ValidationResult($"The field {nameof(Amount)} should be between 0 and 1000", new[] { nameof(Amount) });
        }
    }
}