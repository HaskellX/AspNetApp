using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Epam.Library.Mvc.Models
{
    public class BookCreateFormVM
    {
        public HashSet<int> AuthorsId { get; set; }

        [Required]
        [RegularExpression(@"(^[A-Z][a-z]+(((-[a-z]+-[A-Z][a-z]*)?)|(-[A-Z][a-z]*))(\s(([A-Z])|([a-z]))[a-z]*)*$)|(^[А-ЯЁ][а-яё]+(((-[а-яё]+-[А-ЯЁ][а-яё]*)?)|(-[А-ЯЁ][а-яё]*))(\s(([А-ЯЁ])|([а-яё]))[а-яё]*)*$)")]
        [Display(Name = "Город издания")]
        public string CityOfPublishing { get; set; }

        public int PublisherId { get; set; }

        //[RegularExpression(@"^(ISBN ([0-7]||8[0-9]||9[0-4]||9([5-8][0-9]||9[0-3])||99[4-8][0-9]||999[0-9][0-9])-[0-9]{1,7}-[0-9]{1,7}-(X||[0-9]))$")]
        [Display(Name = "ISBN")]
        public string ISBN { get; set; }

        [Required]
        [StringLength(200, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int NumberOfPages { get; set; }

        [StringLength(2000)]
        public string Note { get; set; }

        [Required]
        //[Range(1400, 3000)]
        public int YearOfPublishing { get; set; }

    }
}