using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Epam.Library.Mvc.Models
{
    public class PatentCreateFormVM : IValidatableObject
    {
        public HashSet<int> AuthorsId { get; set; }
        
        [Required]
        [StringLength(200)]
        [RegularExpression(@"(?:^[A-Z][a-z]+$)|(?:^[А-Я][а-я]+$)|(?:[A-Z]+)")]
        public string Country { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public string RegNumber { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime SubmissionDocuments { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateOfPublication { get; set; }

        [Required]
        [StringLength(300)]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int NumberOfPages { get; set; }

        [StringLength(2000)]
        public string Note { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (SubmissionDocuments == null)
            {
                if (DateOfPublication == null)
                {
                    yield return new ValidationResult("Check dates");
                }

                if ((DateOfPublication.Year >= 1474) & (DateOfPublication <= DateTime.Now))
                {
                    yield return new ValidationResult("Check dates!");
                }
            }
            else
            {
                if (DateOfPublication == null)
                {
                    yield return new ValidationResult("Check dates!");
                }

                if( (DateOfPublication.Year >= 1474) && (DateOfPublication <= DateTime.Now) && (DateOfPublication >= SubmissionDocuments) && SubmissionDocuments.Year >= 1474)
                {
                    yield return new ValidationResult("Check dates!");
                }
            }
        }
    }
}