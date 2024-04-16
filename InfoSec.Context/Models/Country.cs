using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoSec.Context.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string TitleEnglish { get; set; }
        [Required]
        public string CodeLetter { get; set; }
        [Required]
        public int CodeDigital { get; set; }
        public ICollection<User> Users { get; set; }
    }
}