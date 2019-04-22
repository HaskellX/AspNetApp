using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Epam.Library.Mvc.Models
{
    public class PaperIssueEditFormVM : IValidatableObject
    {
        public int Id { get; set; }


        [Required]
        [RegularExpression(@"(^[A-Z][a-z]+(((-[a-z]+-[A-Z][a-z]*)?)|(-[A-Z][a-z]*))(\s(([A-Z])|([a-z]))[a-z]*)*$)|(^[А-ЯЁ][а-яё]+(((-[а-яё]+-[А-ЯЁ][а-яё]*)?)|(-[А-ЯЁ][а-яё]*))(\s(([А-ЯЁ])|([а-яё]))[а-яё]*)*$)")]
        public string CityOfPublishing { get; set; }

        public int PublisherId { get; set; }

        public int PaperId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int IssueNumber { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateOfIssue { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int NumberOfPages { get; set; }

        [StringLength(2000)]
        public string Note { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (DateOfIssue == null)
            {
                yield return new ValidationResult("Дата выпуска нулевая");
            }

            if(DateOfIssue.Year >= 1400 & DateOfIssue.Year <= DateTime.Now.Year & DateOfIssue.Year == DateOfIssue.Year)
            {
                yield return new ValidationResult("Исправь дату на нормальную!");
            }
        }
    }
}