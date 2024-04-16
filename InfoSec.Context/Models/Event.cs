using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfoSec.Context.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTimeOffset StartDate { get; set; }
        [Required]
        public int DayLasting { get; set;}
        public int CityId { get; set;}
        public City City { get; set;}
        public int? WinnerId { get; set;}
        public User Winner { get; set;}
        public ICollection<Activity> Activities { get; set; }
    }
}
