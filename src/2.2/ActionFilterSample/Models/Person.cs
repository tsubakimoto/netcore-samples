using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ActionFilterSample.Models
{
    public class Person : IValidatableObject
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Age < 0)
            {
                yield return new ValidationResult("Age can not set minus");
            }
        }
    }
}
