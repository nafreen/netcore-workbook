using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ToDoApp.ValidationAttributes;

namespace ToDoApp.Models
{
    public class ToDo : IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        [Required]
<<<<<<< HEAD
        [StringLength(50)]
        public string Title { get; set; }
       
=======
        [StringLength(50, MinimumLength = 5)]
        public string Title { get; set; }

>>>>>>> 50023806f65bc205afcb803d08f3e3dcc4035674
        [StringLength(200)]
        public string Description { get; set; }

        
        [UIHint("Status")]
        public Status Status { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
<<<<<<< HEAD
        [DateTimeBeforeToDayValidationAttribute]
=======
        [DateTimeBeforeToDayValidation]
>>>>>>> 50023806f65bc205afcb803d08f3e3dcc4035674
        public DateTime? Created { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
<<<<<<< HEAD
           if(this.Title == this.Description)
            {
                yield return new ValidationResult("Title and Description cannot be same");
            }

=======
            if (this.Title == this.Description)
                yield return new ValidationResult("Title and Description cannot be the same");
>>>>>>> 50023806f65bc205afcb803d08f3e3dcc4035674
        }
    }
}
