using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InfoSec.Context.Models
{
    public class Direction
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public ICollection<User> Users { get; set; }
    }
}