using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.ValidationAttributes
{
    public class DateTimeBeforeToDayValidationAttribute : ValidationAttribute
    {
<<<<<<< HEAD
        public DateTimeBeforeToDayValidationAttribute()
        {

        }
=======
>>>>>>> 50023806f65bc205afcb803d08f3e3dcc4035674

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var dateTime = value as DateTime?;
<<<<<<< HEAD

            if (!dateTime.HasValue && value != null)
            {
                throw new ArgumentException("This attribute can only used with date time types");
            }

=======
            if (!dateTime.HasValue && value != null)
                throw new ArgumentException("This attibute can only used with date time types");
>>>>>>> 50023806f65bc205afcb803d08f3e3dcc4035674
            if (!dateTime.HasValue)
                return ValidationResult.Success;
            if (dateTime.Value > DateTime.Now)
                return ValidationResult.Success;

<<<<<<< HEAD
            return new ValidationResult("DateTime should be less than today");
        }
    }
}

    
=======
            return new ValidationResult("DateTime should be less than today.");

        }
    }
}
>>>>>>> 50023806f65bc205afcb803d08f3e3dcc4035674
